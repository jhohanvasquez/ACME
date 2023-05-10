using AutoMapper;
using ACME.Business.Entities;
using ACME.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.DataAccess.Projection
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {            
            CreateMap<DataLogDTO, DataLog>();      
            CreateMap<DataLog, DataLogDTO>();
        }
    }
}
