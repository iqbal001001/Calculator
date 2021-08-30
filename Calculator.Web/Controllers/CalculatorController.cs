using Calculator.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Web.Extension;

namespace Calculator.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculator _calculator;

        public CalculatorController(
            ILogger<CalculatorController> logger,
            ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [Route("add")]
        public ActionResult<decimal> Add(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
                return Ok(_calculator.Add(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("subtract")]
        public ActionResult<decimal> Subtract(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
                return Ok(_calculator.Subtract(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("multiply")]
        public ActionResult<decimal> Multiply(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
                return Ok(_calculator.Multiply(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("divide")]
        public ActionResult<decimal> Divide(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
                return Ok(_calculator.Divide(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("splitEq")]
        public ActionResult<List<decimal>> SplitEq(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
                return Ok(_calculator.SplitEq(nums));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("splitNum")]
        public ActionResult<decimal> SplitNum(string numbers)
        {
            try
            {
                var nums = numbers.GetList<decimal>();
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
