using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.DataAccess.Mappers
{
    public interface IMapperAdapterFactory
    {
        IMapperAdapter Create();
    }
}
