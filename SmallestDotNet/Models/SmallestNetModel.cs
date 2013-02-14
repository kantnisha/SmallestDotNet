using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmallestDotNet.Models
{
    public class SmallestNetModel
    {
        public DeveloperResult DeveloperResult { get; set; }
        public string UserResult { get; set; }
        public bool ShowGetDotNet { get; set; }
        public bool CheckDotNet { get; set; }
        public string UserAgent { get; set; }
    }
}