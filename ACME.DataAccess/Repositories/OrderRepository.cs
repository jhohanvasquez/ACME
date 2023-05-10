using ACME.Business.Contracts;
using ACME.Business.Entities;
using System;
using System.Collections.Generic;

namespace ACME.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IRestClient<CommandResponse> restCommandClient;
        private readonly ILogRegister logRegister;

        public OrderRepository(IRestClient<CommandResponse> restCommandClient, ILogRegister logRegister)
        {
            this.restCommandClient = restCommandClient;
            this.logRegister = logRegister;
        }


        public CommandResponse SendOrder(EnviarPedido requestOperation, string token)
        {
            try
            {

                Dictionary<string, string> headerParameters = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(token))
                    headerParameters.Add("Authorization", token);

                Dictionary<string, string> oParams = new Dictionary<string, string>();
                oParams.Add("numPedido", requestOperation.numPedido);
                oParams.Add("cantidadPedido", requestOperation.cantidadPedido);
                oParams.Add("codigoEAN", requestOperation.codigoEAN);
                oParams.Add("nombreProducto", requestOperation.nombreProducto);
                oParams.Add("numDocumento", requestOperation.numDocumento);
                oParams.Add("direccion", requestOperation.direccion);

                var result = this.restCommandClient.PostUrlEncodedAsync(null, oParams, headerParameters);

                return result;
            }
            catch (Exception ex)
            {
                logRegister.Save(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, ex.Message);
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    logRegister.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {

            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
