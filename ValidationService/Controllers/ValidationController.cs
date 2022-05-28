using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationService.Models;

namespace ValidationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private static readonly string[] ValidCreditorsList = new[]
        {
            "test", "admin"
        };

        private readonly ILogger<ValidationController> _logger;

        public ValidationController(ILogger<ValidationController> logger)
        {
            _logger = logger;
        }

        [HttpPost("/validation/validate")]
        public IActionResult ValidateIncomingRequest(ValidationRequest request)
        {
            _logger.LogInformation($"Received new validation request '{request.PaymentId}'");

            var validationResult = ValidCreditorsList.Contains(request.CreditorId);

            var response = new ValidationResponse
            {
                PaymentId = request.PaymentId,
                IsValid = validationResult,
            };

            return Ok(response);
        }
    }
}
