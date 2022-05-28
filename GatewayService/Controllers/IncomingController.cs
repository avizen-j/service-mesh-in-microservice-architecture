using GatewayService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GatewayService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomingController : ControllerBase
    {
        private readonly ILogger<IncomingController> _logger;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public IncomingController(ILogger<IncomingController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpPost("/incoming/new")]
        public async Task<IActionResult> RegisterIncomingRequest(IncomingPaymentRequest request)
        {
            _logger.LogInformation($"Received new payment request '{request.PaymentId}'");
            request.Status = "RegisteredInGatewayService";

            _logger.LogInformation($"Forwarding request '{request.PaymentId}' to Validation Service");
            var validationRequest = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                Application.Json);

            _httpClient.BaseAddress = new Uri(request.ValidationServiceUri);
            var response = await _httpClient.PostAsync("/validation/validate", validationRequest);

            var contentStream = await response.Content.ReadAsStreamAsync();
            var validationResponse = await JsonSerializer.DeserializeAsync<ValidationResponse>(contentStream, options);

            return Ok(validationResponse);
        }

        [HttpGet("/incoming/accounts/{accountId}/summary")]
        public async Task<IActionResult> RetrieveAccountSummary([FromRoute] string accountId, [FromQuery] string validationServiceUri, [FromQuery] string accountServiceUri)
        {
            try
            {
                _logger.LogInformation($"Received new summary request for account '{accountId}' in '{nameof(GatewayService)}'");

                Request.Headers.TryGetValue("user-country", out var country);
                var parsedCountry = string.IsNullOrEmpty(country.ToString()) ? "undefined" : country.ToString();
                _logger.LogInformation($"Summary request from '{parsedCountry}'");

                var validationRequest = new StringContent(
                    JsonSerializer.Serialize(
                        new
                        {
                            CreditorId = accountId,
                            DebtorId = "mock",
                            PaymentId = Guid.NewGuid(),
                        }),
                    Encoding.UTF8,
                    Application.Json);

                var response = await _httpClient.PostAsync($"{validationServiceUri}/validation/validate", validationRequest);
                response.EnsureSuccessStatusCode();

                var contentStream = await response.Content.ReadAsStreamAsync();
                var validationResponse = await JsonSerializer.DeserializeAsync<ValidationResponse>(contentStream, options);

                if (validationResponse.IsValid)
                {

                    using var summaryRequest = new HttpRequestMessage(HttpMethod.Get, $"{accountServiceUri}/accounts/{accountId}/summary");
                    summaryRequest.Headers.Add("user-country", parsedCountry);

                     var summaryResponse = await _httpClient.SendAsync(summaryRequest);
                    
                    //var summaryResponse = await _httpClient.GetAsync($"{accountServiceUri}/accounts/{accountId}/summary");
                    summaryResponse.EnsureSuccessStatusCode();

                    var summaryContentStream = await summaryResponse.Content.ReadAsStreamAsync();
                    var accountSummaryResponse = await JsonSerializer.DeserializeAsync<AccountSummaryResponse>(summaryContentStream, options);
                    return Ok(accountSummaryResponse);
                }

                return BadRequest($"Provided '{accountId}' did not pass validation.");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
