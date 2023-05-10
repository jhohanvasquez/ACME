using ACME.Business.Contracts;
using ACME.Business.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Xml;

namespace ACME.DataAccess.Common
{
    public class RestClient<T> : IRestClient<T> where T : class
    {
        private string RestUri;

        public RestClient(string restUri)
        {
            this.RestUri = restUri;
        }

        public T GetAsync(string token, string uriParams, Dictionary<string, string> headerParameters = null)
        {
            try
            {
                string url = this.RestUri;

                url += (string.IsNullOrEmpty(uriParams) ? "" : uriParams);

                using (var client = new HttpClient())
                {
                    try
                    {
                        //Add authentication 
                        client.DefaultRequestHeaders.Clear();
                        if (!string.IsNullOrEmpty(token))
                            client.DefaultRequestHeaders.Add("Authorization", token);

                        if (headerParameters != null)
                        {
                            foreach (var param in headerParameters)
                            {
                                client.DefaultRequestHeaders.Add(param.Key, param.Value);
                            }
                        }

                        var response = client.GetStringAsync(url).Result;  // Blocking call! 
                        return JsonConvert.DeserializeObject<T>(response.ToString());
                    }
                    catch (HttpRequestException ex)
                    {
                        throw new Exception("Error en consumo de metodo get de servicio rest: " + this.RestUri, ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en consumo de metodo get de servicio rest: " + this.RestUri, ex);
            }
        }

        public CommandResponse PostUrlEncodedAsync(string uriParams, Dictionary<string, string> parameters = null, Dictionary<string, string> headerParameters = null)
        {
            using (var client = new HttpClient())
            {
                string url = this.RestUri;

                url += (string.IsNullOrEmpty(uriParams) ? "" : uriParams);

                client.BaseAddress = new Uri(url);

                var request = new HttpRequestMessage(HttpMethod.Post, "");

                var keyValues = new List<KeyValuePair<string, string>>();
                if (parameters != null)
                {

                    foreach (var param in parameters)
                    {
                        keyValues.Add(new KeyValuePair<string, string>(param.Key, param.Value));
                    }
                }

                client.DefaultRequestHeaders.Clear();
                if (headerParameters != null)
                {
                    foreach (var param in headerParameters)
                    {
                        client.DefaultRequestHeaders.Add(param.Key, param.Value);
                    }
                }

                request.Content = new FormUrlEncodedContent(keyValues);
                CommandResponse oCommandResponse = new CommandResponse();

                var response = client.SendAsync(request).Result;
                var xml = response.Content.ReadAsStringAsync().Result;
                oCommandResponse.ResponseXml = xml.ToString();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
               
                oCommandResponse.ResponseJson = json;

                if (oCommandResponse != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return oCommandResponse;
                    }
                    else
                    {
                        return oCommandResponse;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
