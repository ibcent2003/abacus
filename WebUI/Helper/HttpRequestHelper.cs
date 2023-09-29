using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Wbc.WebUI.Helper
{
    public static class DataTableHttpRequestHelper
    {
        public static int GetDataTableStartValue(this PageModel context)
        {
            return Convert.ToInt16(context.Request.Form["start"].FirstOrDefault());
        }

        public static int GetDataTableDrawValue(this PageModel context)
        {
            return Convert.ToInt16(context.Request.Form["draw"].FirstOrDefault());
        }

        public static int GetDataTableLenghtValue(this PageModel context)
        {
            return Convert.ToInt16(context.Request.Form["length"].FirstOrDefault());
        }

        public static int GetDataTableSortColumn(this PageModel context)
        {
            return Convert.ToInt16(context.Request.Form["order[0][column]"].FirstOrDefault());
        }

        public static string GetDataTableSortColumnDirection(this PageModel context)
        {
            return context.Request.Form["order[0][dir]"].FirstOrDefault();
        }


        public static string GetDataTableSearchValue(this PageModel context)
        {
            return context.Request.Form["search[value]"].FirstOrDefault();
        }
    }
}
