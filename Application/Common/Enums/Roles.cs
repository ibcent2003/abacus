using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum Roles
    {
        [StringValue("TradeHub Admin")]
        TradeHubAdmin,
        [StringValue("Cube Client Admin")]
        CubeClientAdmin,
        [StringValue("Cube Client User")]
        CubeClientUser,
        [StringValue("Cube Applicant")]
        CubeApplicant,
        [StringValue("etrade Tool Admin")]
        eTradeToolAdmin,
        [StringValue("etrade Tool User")]
        eTradeToolUser,
        [StringValue("Abacus Admin")]
        abacusAdmin,
        [StringValue("Abacus User")]
        abacusUser



    }
}
