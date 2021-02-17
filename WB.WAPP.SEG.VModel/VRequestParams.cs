using System;
using System.Collections.Generic;
using System.Text;

namespace WB.WAPP.SEG.VModel
{
    public class VRequestParams
    {
        public int? Page { get; set; } = null;
        public int? Limit { get; set; } = null;
        public string Sort { get; set; } = "Id";
        public string Fields { get; set; } = null;
    }
}
