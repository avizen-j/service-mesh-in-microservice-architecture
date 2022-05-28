using System;
using System.ComponentModel.DataAnnotations;

namespace ValidationService.Models
{
    public class ValidationResponse
    {
        [Required]
        public bool IsValid { get; set; }

        [Required]
        public Guid PaymentId { get; set; }
    }
}
