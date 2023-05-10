using System;
using System.Collections.Generic;
using System.Text;
using ACME.Business.Configuration;

namespace ACME.Business.Configuration
{
    public class ApiSettings
    {
        public EnvironmentVariables environmentVariables { get; set; }
    }

    public class EnvironmentVariables
    {        
        public GeneralSettings GeneralSettings { get; set; }
        public StorageSettings StorageSettings { get; set; }

    }

}
