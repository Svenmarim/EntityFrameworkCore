using EntityFrameworkCore.Data;
using EntityFrameworkCore.Data.Entities;
using EntityFrameworkCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Services
{
    public class MachineService : Service<MachineEntity>, IMachineService
    {
        public MachineService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
