using ACME.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Contracts
{
    public interface ILogRegister : IDisposable
    {
        void Save(string classMessage, string method, string message);      

    }
}
