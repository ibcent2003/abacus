using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum EntityTypes
    {
        [StringValue("CCR")]
        [StringDescription("/Subscription/RegistrationApprovalDetails/")]
        ChamberRegistration,
        [StringValue("CTR")]
        [StringDescription("/Subscription/RegistrationApprovalDetails/")]
        TraderRegistration,
        [StringValue("CAR")]
        [StringDescription("/Subscription/RegistrationApprovalDetails/")]
        AgentRegistration
    }
}
