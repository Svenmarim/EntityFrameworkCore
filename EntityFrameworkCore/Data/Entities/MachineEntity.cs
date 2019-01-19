using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data.Entities
{
    public class MachineEntity
    {
        [Key]
        public string Id { get; set; }

        public AccountEntity Account { get; set; }

        [Column(TypeName = "decimal (10,1)")]
        public decimal? WorkingHours { get; set; }

        [Column(TypeName = "decimal (10,2)")]
        public decimal? TravelDistInKm { get; set; }

        public bool Active { get; set; }
    }
}
