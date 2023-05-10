using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.DataAccess.Mappers
{
    public class MapperAdapterFactory
    {
        private static IMapperAdapterFactory _adapterFactory = null;

        public static void SetCurrent(IMapperAdapterFactory adapterFactory)
        {
            _adapterFactory = adapterFactory;
        }

        public static IMapperAdapter CreateAdapter()
        {
            return _adapterFactory.Create();
        }
    }
}
