using System.Collections.Generic;

namespace TarimCan.Models
{
    public class SiteResponseModel
    { 
        public bool IsSuccess { get; set; }
        public int MessageCode { get; set; }
        public string Message { get; set; }
        public string ResponseText { get; set; }
    }
}