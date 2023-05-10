using ACME.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace ACME.Business.Interfaces
{
    public interface IACMEService : IDisposable
    {
        CommandResponse SendOrder(EnviarPedido operationRequest);
    }
}

