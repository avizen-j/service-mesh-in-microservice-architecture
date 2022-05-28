using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValidationService.Models
{
    public class ValidationRequest
    {
        [Required]
        public string CreditorId { get; set; } = null!;

        [Required]

        public string DebtorId { get; set; } = null!;

        [Required]
        public Guid PaymentId { get; set; }
    }
}
