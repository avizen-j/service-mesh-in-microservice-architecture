using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayService.Models
{
    public class IncomingPaymentRequest
    {
        [Required]
        public string CreditorId { get; set; } = null!;

        [Required]

        public string DebtorId { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        public string? Notes { get; set; }

        public string? Status { get; set; }

        public Guid PaymentId { get; set; } = Guid.NewGuid();

        public DateTime ReceivedTimestamp { get; set; } = DateTime.Now;

        [Required]
        public string ValidationServiceUri { get; set; } = null!;
    }
}
