using Calculator.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Calculator2Controller : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculator _calculator;

        public Calculator2Controller(
            ILogger<CalculatorController> logger,
            ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [Route("/add")]
        public ActionResult<decimal> Add(string number1, string number2)
        {
            if (!decimal.TryParse(number1, out decimal num1))
            {
                return BadRequest("number 1 is not a valid integer");
            }

            if (!decimal.TryParse(number2, out decimal num2))
            {
                return BadRequest("number 2 is not a valid integer");
            }
            try
            {
                return Ok(_calculator.Add(num1, num2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/subtract")]
        public ActionResult<decimal> Subtract(string number1, string number2)
        {
            if (!int.TryParse(number1, out int num1))
            {
                return BadRequest("number 1 is not a valid integer");
            }

            if (!int.TryParse(number2, out int num2))
            {
                return BadRequest("number 2 is not a valid integer");
            }
            try
            {
                return Ok(_calculator.Subtract(num1, num2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/multiply")]
        public ActionResult<decimal> Multiply(string number1, string number2)
        {
            if (!int.TryParse(number1, out int num1))
            {
                return BadRequest("number 1 is not a valid integer");
            }

            if (!int.TryParse(number2, out int num2))
            {
                return BadRequest("number 2 is not a valid integer");
            }
            try
            {
                return Ok(_calculator.Multiply(num1, num2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/divide")]
        public ActionResult<decimal> Divide(string number1, string number2)
        {
            if (!int.TryParse(number1, out int num1))
            {
                return BadRequest("number 1 is not a valid integer");
            }

            if (!int.TryParse(number2, out int num2))
            {
                return BadRequest("number 2 is not a valid integer");
            }
            try
            {
                return Ok(_calculator.Divide(num1, num2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/splitEq")]
        public ActionResult<List<decimal>> SplitEq(string number1, string number2)
        {
            if (!int.TryParse(number1, out int num1))
            {
                return BadRequest("number 1 is not a valid integer");
            }

            if (!int.TryParse(number2, out int num2))
            {
                return BadRequest("number 2 is not a valid integer");
            }
            try
            {
                return Ok(_calculator.SplitEq(num1, num2));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/splitNum")]
        public ActionResult<decimal> SplitNum(string numbers)
        {
            try
            {
                var nums = numbers.Split(",").Select(decimal.Parse).ToList();
                return Ok(_calculator.SplitNum(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

