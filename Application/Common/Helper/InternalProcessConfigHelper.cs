using System;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;

namespace Wbc.Application.Common.Helper
{
    public static class InternalProcessConfigHelper
    {
        public static string GetWorkflowScheme(this Process process, AdminConfiguration adminConfiguration)
        {
            return process switch
            {
                Process.ChamberSubscriptionProcess => adminConfiguration.ChamberRegistrationWorkflowScheme,
                Process.TraderSubscriptionProcess => adminConfiguration.TraderRegistrationWorkflowScheme,
                Process.AgentSubscriptionProcess => adminConfiguration.AgentRegistrationWorkflowScheme,
                _ => throw new ArgumentOutOfRangeException(nameof(process), process, null)
            };
        }
    }
}
