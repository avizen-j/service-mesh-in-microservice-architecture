using System;
using System.ComponentModel.DataAnnotations;

namespace GatewayService.Models
{
    public class ValidationResponse
    {
        [Required]
        public bool IsValid { get; set; }

        [Required]
        public Guid PaymentId { get; set; }
    }
}
