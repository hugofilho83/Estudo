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

        // GET api/calculator/sum/5/2
        [HttpGet("sum/{firstNumber}/{secundNumber}")]
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

        // GET api/calculator/subtraction/5/2
        [HttpGet("subtraction/{firstNumber}/{secundNumber}")]
        public ActionResult<string> Subtraction(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            else
            {
                return BadRequest("Input invalid, Values is not number");
            }
        }

        // GET api/calculator/division/5/2
        [HttpGet("division/{firstNumber}/{secundNumber}")]
        public ActionResult<string> Division(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            else
            {
                return BadRequest("Input invalid, Values is not number");
            }
        }

        // GET api/calculator/multiplication/5/2
        [HttpGet("multiplication/{firstNumber}/{secundNumber}")]
        public ActionResult<string> Multiplication(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            else
            {
                return BadRequest("Input invalid, Values is not number");
            }
        }

        // GET api/calculator/multiplication/5/2
        [HttpGet("mean/{firstNumber}/{secundNumber}")]
        public ActionResult<string> Mean(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber)) / 2;
                return Ok(sum.ToString());
            }
            else
            {
                return BadRequest("Input invalid, Values is not number");
            }
        }

        // GET api/calculator/square-root/5/2
        [HttpGet("square-root/{firstNumber}/{secundNumber}")]
        public ActionResult<string> SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber)) 
            {
                var square = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(square.ToString());
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
