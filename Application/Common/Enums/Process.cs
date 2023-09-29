using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum Process
    {
        [StringDescription("CUBE Chamber Registration")]
        [StringValue("CCR")]
        ChamberSubscriptionProcess,
        [StringDescription("CUBE Trader Registration")]
        [StringValue("CTR")]
        TraderSubscriptionProcess,
        [StringDescription("CUBE Agent Registration")]
        [StringValue("CAR")]
        AgentSubscriptionProcess

    }
}
