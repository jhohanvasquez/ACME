using ACME.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Contracts
{
    public interface IRestClient<T> where T : class
    {
        T GetAsync(string token, string uriParams, Dictionary<string, string> headerParameters = null);
        CommandResponse PostUrlEncodedAsync(string uriParams, Dictionary<string, string> parameters = null, Dictionary<string, string> headerParameters = null);
    }
}
