using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data.Entities
{
    public class AccountEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string HashedPassword { get; set; }

        public bool Admin { get; set; }
    }
}
