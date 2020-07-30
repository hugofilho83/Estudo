using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{firstNumber}/{secundNumber}")]
        public ActionResult<string> Sum(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            else 
            {
                return BadRequest("Input invalid, Values is not number");
            }
        }

        private decimal ConvertToDecimal(string value)
        {
            decimal decimalValue;
            if (decimal.TryParse(value, out decimalValue)) 
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string value)
        {
            decimal number;
            bool isNumber = decimal.TryParse(value, 
                                             System.Globalization.NumberStyles.Any, 
                                             System.Globalization.NumberFormatInfo.InvariantInfo, 
                                             out number);

            return isNumber;
        }
    }
}
