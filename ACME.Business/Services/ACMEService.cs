using ACME.Business.Contracts;
using ACME.Business.Entities;
using ACME.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ACME.Business.Services
{
    public class ACMEService : IACMEService
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ILogRegister logRegister;

        bool disposed = false;

        public ACMEService(IOrderRepository orderRepository, ILogRegister logRegister)
        {
            this.logRegister = logRegister;
            _orderRepository = orderRepository;
        }

        #region Public Members

        public CommandResponse SendOrder(EnviarPedido operationRequest)
        {
            try
            {
                return _orderRepository.SendOrder(operationRequest, null); 
            }
            catch (Exception ex)
            {
                logRegister.Save(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, "SendOrder", string.Format("{0} {1} {2} {3}", this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, ex.Message, ex.StackTrace));
                throw;
            }
        }

        #endregion

        #region Private Members

        #endregion


        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
            }

            disposed = true;
        }
        #endregion

    }
}
