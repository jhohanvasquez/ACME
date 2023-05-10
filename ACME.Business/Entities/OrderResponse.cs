using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Entities
{
    public class OrderResponse
    {
        public class EnvEnvioPedidoAcmeResponse
        {
            public EnvioPedidoResponse EnvioPedidoResponse { get; set; }
        }

        public class EnvioPedidoResponse
        {
            [JsonProperty("#comment")]
            public List<object> comment { get; set; }
            public string Codigo { get; set; }
            public string Mensaje { get; set; }
        }

        public class Root
        {
            [JsonProperty("@xmlns:soapenv")]
            public string xmlnssoapenv { get; set; }

            [JsonProperty("@xmlns:env")]
            public string xmlnsenv { get; set; }

            [JsonProperty("soapenv:Header")]
            public object soapenvHeader { get; set; }

            [JsonProperty("soapenv:Body")]
            public SoapenvBody soapenvBody { get; set; }
        }

        public class SoapenvBody
        {
            [JsonProperty("env:EnvioPedidoAcmeResponse")]
            public EnvEnvioPedidoAcmeResponse envEnvioPedidoAcmeResponse { get; set; }
        }


    }
}
