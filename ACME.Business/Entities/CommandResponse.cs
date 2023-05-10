using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Entities
{
    public class CommandResponse 
    {
        public bool IsSuccess { get; set; }
        public string ResponseXml { get; set; }
        public string ResponseJson { get; set; }
    }
}
