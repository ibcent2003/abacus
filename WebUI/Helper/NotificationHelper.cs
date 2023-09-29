using Microsoft.AspNetCore.Mvc.RazorPages;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;

namespace Wbc.WebUI.Helper
{
    public static class NotificationHelper
    {

        public static void Toast(PageModel handler, string title, string message, NotificationType toastType, NotificationPosition position, int duration = 7500, bool showCloseButton = true, bool showProgressBar = true)
        {
            handler.TempData["ToastMessage"] = message;
            handler.TempData["ToastTitle"] = title;
            handler.TempData["ToastType"] = toastType.GetAttributeStringValue();
            handler.TempData["ToastDuration"] = duration;
            handler.TempData["ToastPosition"] = position.GetAttributeStringValue();
            handler.TempData["ToastShowCloseButton"] = showCloseButton;
            handler.TempData["ToastShowProgress"] = showProgressBar;

        }
    }
}