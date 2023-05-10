using Microsoft.AspNetCore.Mvc;
using ACME.Business.Entities;
using ACME.Business.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Options;
using ACME.Business.Configuration;
using System.Threading.Tasks;
using ACME.DataAccess.DTO;
using AutoMapper;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using ACME.Business.Services;

namespace ACME.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IACMEService _acmeService;
        private readonly GeneralSettings _settings;
        private readonly IMapper _mapper;
        private IMemoryCache _cache;

        public OrderController(IACMEService acmeService, IOptions<ApiSettings> settings, IMapper mapper, IMemoryCache cache)
        {
            _acmeService = acmeService;
            _settings = settings.Value.environmentVariables.GeneralSettings;
            _mapper = mapper;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        [HttpPost("SendOrder")]
        public ActionResult<OperationResult> SendOrder([FromBody] EnviarPedido Request)
        {
            if (Request != null)
            {
                var result = _acmeService.SendOrder(Request);
                if(result.IsSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }                
            }
            else
            {
                return NoContent();
            }
        }

    }
}