using ACME.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Contracts
{
    public interface IOrderRepository : IDisposable
    {
        CommandResponse SendOrder(EnviarPedido requestOperation, string token);
      
    }
}
