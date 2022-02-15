using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? BirthDay { get; set; }
        public int GenderId { get; set; }

        public Gender? Gender { get; set; }

    }
}
