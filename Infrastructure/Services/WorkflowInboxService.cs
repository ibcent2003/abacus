using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using OptimaJet.Workflow.Core.Runtime;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public class WorkflowInboxService
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public WorkflowInboxService(IServiceProvider serviceProvider)
        {

            ServiceProvider = serviceProvider;
        }


        public void DropWorkflowInbox(Guid processId)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var toDelete = dbContext.WorkflowInboxes.Where(x => x.ProcessId == processId);

            dbContext.WorkflowInboxes.RemoveRange(toDelete);

            var result = dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

        public void FinaliseDocument(Guid processId)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            var doc = dbContext.Documents.FirstOrDefault(x => x.WorkflowProcessId.Equals(processId));

            if (doc == null) return;

            doc.IsFinalised = true;

            var result = dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

        public void RecalcInbox(WorkflowRuntime runtimeProvider)
        {
            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            foreach (var document in dbContext.Documents.ToList())
            {
                var id = document.WorkflowProcessId;

                if (!runtimeProvider.IsProcessExists(id)) continue;

                runtimeProvider.UpdateSchemeIfObsolete(id);

                var toDelete = dbContext.WorkflowInboxes.Where(x => x.ProcessId == id);

                dbContext.WorkflowInboxes.RemoveRange(toDelete);

                FillInbox(id, runtimeProvider);
            }
        }

        public void FillInbox(Guid processId, WorkflowRuntime runtimeProvider)
        {

            var newActors = runtimeProvider.GetAllActorsForDirectCommandTransitions(processId).ToList();

            using var scope = ServiceProvider.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();

            foreach (var newActor in newActors)
            {
                var newInboxItem = new Domain.Entities.WorkflowInbox { Id = Guid.NewGuid(), IdentityId = newActor, ProcessId = processId };

                dbContext.WorkflowInboxes.Add(newInboxItem);
            }

            var result = dbContext.SaveChangesAsync(CancellationToken.None).Result;
        }

    }
}
