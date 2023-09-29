using Wbc.Application.Common.Attributes;

namespace Wbc.Application.Common.Enums
{
    public enum NotificationType
    {
        [StringValue("success")]
        Success,
        [StringValue("info")]
        Info,
        [StringValue("warning")]
        Warning,
        [StringValue("error")]
        Error
    }
}