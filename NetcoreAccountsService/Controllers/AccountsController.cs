using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetcoreAccountsService.Models;
using System;
using System.Linq;

namespace NetcoreAccountsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private static readonly Random Random = new Random();
        private static readonly string[] AccountsList = new[]
        {
            "test", "admin", "pilot"
        };

        private readonly ILogger<AccountsController> _logger;

        public AccountsController(ILogger<AccountsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/accounts/{accountId}/summary")]
        public IActionResult RetrieveAccountSummary([FromRoute] string accountId)
        {
            _logger.LogInformation($"Received new summary request for '{accountId}' account");

            var validAccount = AccountsList.Contains(accountId);

            if (validAccount)
            {
                var response = new AccountSummaryResponse
                {
                    AccountId = accountId,
                    Amount = Random.NextDouble() * (1000 - 20) + 20,
                    Currency = "EUR",
                };

                return Ok(response);
            }

            return NotFound();
        }
    }
}
