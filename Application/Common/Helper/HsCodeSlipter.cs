using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Common.Helper
{
   public class HsCodeSlipter
    {
        public string Encode(string hscodeAfterSlipt)
        {
            hscodeAfterSlipt = hscodeAfterSlipt.Replace(" ", "");
            hscodeAfterSlipt = hscodeAfterSlipt.Replace(".", "");
            Regex regex = new Regex(@"^[0-9]+$");
            hscodeAfterSlipt = hscodeAfterSlipt.PadRight(10, '0');
           
            if (!regex.IsMatch(hscodeAfterSlipt)) return null;
            var fvar = hscodeAfterSlipt.Substring(0, 4);
            var svar = hscodeAfterSlipt.Substring(4, 2);
            var tvar = hscodeAfterSlipt.Substring(6, 2);
            var lvar = hscodeAfterSlipt.Substring(8);
            hscodeAfterSlipt = fvar + "." + svar + "." + tvar + "." + lvar;
            return hscodeAfterSlipt;
        }
    }
}
