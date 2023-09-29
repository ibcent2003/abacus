using System;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Parser;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public static class WorkflowInit
    {
        private static volatile WorkflowRuntime _runtime;

        private static readonly object Sync = new object();
        public static IServiceProvider ServiceProvider { get; private set; }

        public static WorkflowRuntime Create(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            CreateRuntime();
            return Runtime;
        }

        public static WorkflowRuntime Runtime => _runtime;

        private static void CreateRuntime()
        {
            if (_runtime == null)
            {
                lock (Sync)
                {
                    if (_runtime == null)
                    {
                        using var scope = ServiceProvider.CreateScope();

                        var plugin = new OptimaJet.Workflow.Core.Plugins.BasicPlugin();

                        //Settings for SendEmail actions
                        // plugin.Setting_Mailserver = "smtp.yourserver.com";
                        // plugin.Setting_MailserverPort = 25;
                        // plugin.Setting_MailserverFrom = "from@yourserver.com";
                        // plugin.Setting_MailserverLogin = "login@yourserver.com";
                        // plugin.Setting_MailserverPassword = "password";
                        // plugin.Setting_MailserverSsl = true;
                        //plugin.UsersInRoleAsync = UsersInRoleAsync;

                        var provider = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>().Provider;

                        var builder = new WorkflowBuilder<XElement>(provider, new XmlWorkflowParser(), provider).WithDefaultCache();

                        _runtime = new WorkflowRuntime()
                            .WithBuilder(builder)
                            .WithActionProvider(new WorkflowActionProvider(ServiceProvider))
                            .WithRuleProvider(new WorkflowRuleProvider(ServiceProvider))
                            .WithPersistenceProvider(provider)
                            .SwitchAutoUpdateSchemeBeforeGetAvailableCommandsOn()
                            .RegisterAssemblyForCodeActions(Assembly.GetExecutingAssembly())
                            .WithPlugin(plugin)
                            .AsSingleServer() //.AsMultiServer()
                            .Start();

                        _runtime.ProcessStatusChanged += Runtime_ProcessStatusChangedAsync;
                    }
                }
            }
        }

        static void Runtime_ProcessStatusChangedAsync(object sender, ProcessStatusChangedEventArgs e)
        {

            if (e.NewStatus != ProcessStatus.Idled && e.NewStatus != ProcessStatus.Finalized)

                return;

            if (string.IsNullOrEmpty(e.SchemeCode))

                return;

            if (e.NewStatus == ProcessStatus.Idled)
            {
                using (var scope = ServiceProvider.CreateScope())
                {

                    scope.ServiceProvider.GetRequiredService<IDocumentService>().DeleteEmptyPreHistory(e.ProcessId);
                }

                _runtime.PreExecuteFromCurrentActivity(e.ProcessId);
            }

            //Inbox
            new WorkflowInboxService(ServiceProvider).DropWorkflowInbox(e.ProcessId);

            if (e.NewStatus != ProcessStatus.Finalized)
            {
                PreExecuteAndFillInbox(e);
            }

            if (e.NewStatus == ProcessStatus.Finalized)
            {
                FinalizedDocument(e.ProcessId);
            }

            //Change state name
            if (!e.IsSubprocess)
            {
                var nextState = e.ProcessInstance.CurrentState;

                if (nextState == null)
                {
                    nextState = e.ProcessInstance.CurrentActivityName;
                }

                var nextStateName = Runtime.GetLocalizedStateName(e.ProcessId, nextState);

                using (var scope = ServiceProvider.CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<IDocumentService>().ChangeState(e.ProcessId, nextState, nextStateName);
                }
            }

        }

        private static void FinalizedDocument(Guid processId)
        {

            var inboxService = new WorkflowInboxService(ServiceProvider);

            inboxService.FinaliseDocument(processId);
        }

        #region Inbox
        private static void PreExecuteAndFillInbox(ProcessStatusChangedEventArgs e)
        {

            var inboxService = new WorkflowInboxService(ServiceProvider);

            inboxService.FillInbox(e.ProcessId, Runtime);
        }



        public static void RecalcInbox()
        {
            var service = new WorkflowInboxService(ServiceProvider);

            service.RecalcInbox(Runtime);
        }
        #endregion
    }
}
