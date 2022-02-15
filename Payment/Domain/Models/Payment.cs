using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? FoundationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }
    }
}
