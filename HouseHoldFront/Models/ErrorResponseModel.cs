using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseHoldFront.Models
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public List<ErrorMessage> ModelState { get; set; }
    }

    public class ErrorMessage
    {
        public string Property { get; set; }

        public List<string> Messages { get; set; }
    }

}