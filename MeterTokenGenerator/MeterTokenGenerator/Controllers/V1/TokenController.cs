using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StsTokenGenerator;
using StsTokenGenerator.Models;

namespace MeterTokenGenerator.V1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IGenerator _generator;

        public TokenController(IGenerator generator)
        {
            _generator = generator;
        }
        [HttpGet("[action]/{amount}")]
        public IActionResult Currency(int amount)
        {
            try
            {
                return Ok(_generator.BulkToToken(new BulkRequest { Currency = amount.ToString() }));
            }
            catch (Exception)
            {
                return StatusCode(500, "Data Not Decrypted");

            }
      
        }
        [HttpGet("[action]/{amount}")]
        public IActionResult DebtCredit(int amount)
        {
            try
            {
                return Ok(_generator.BulkToToken(new BulkRequest { Borc_Kredi = amount.ToString() }));
            }
            catch (Exception)
            {
                return StatusCode(500, "Data Not Decrypted");

            }

        }
        [HttpGet("[action]/{amount}")]
        public IActionResult MaxPowerLimit(int amount)
        {
            try
            {
                return Ok(_generator.BulkToToken(new BulkRequest { Max_Power_Limit = amount.ToString() }));
            }
            catch (Exception)
            {
                return StatusCode(500, "Data Not Decrypted");
            }

        }
        [HttpPost("[action]")]
        public IActionResult TariffChange([FromBody]Tariff tariff)
        {
            try
            {
                return Ok(_generator.BulkToToken(new BulkRequest { Tariff = tariff }));
            }
            catch (Exception)
            {
                return StatusCode(500, "Data Not Decrypted");
            }

        }
    }
}
