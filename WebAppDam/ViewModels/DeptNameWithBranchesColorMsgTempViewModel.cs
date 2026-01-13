using Microsoft.Extensions.Primitives;

namespace WebAppDam.ViewModels
{
    public class DeptNameWithBranchesColorMsgTempViewModel
    {
        //Hide Some PRoerty + Hide Model Struct 
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        //Extra Inof
        public string Message { get; set; }
        public string Color { get; set; }
        public int Temp { get; set; }
        //megre 
        public List<string> Brancehes { get; set; }
    }
}
