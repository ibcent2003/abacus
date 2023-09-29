﻿using System;
using Wbc.Application.Common.Enums;

namespace Wbc.Application.Common.Helper
{
    public static class ProcessEntityTypeHelper
    {
        public static EntityTypes GetEntityType(this Process process)
        {
            return process switch
            {
                Process.ChamberSubscriptionProcess => EntityTypes.ChamberRegistration,
                Process.TraderSubscriptionProcess => EntityTypes.TraderRegistration,
                Process.AgentSubscriptionProcess => EntityTypes.AgentRegistration,
                _ => throw new ArgumentOutOfRangeException(nameof(process), process, null),
            };
        }
    }
}
