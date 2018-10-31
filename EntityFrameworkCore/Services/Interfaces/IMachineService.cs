using EntityFrameworkCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Services.Interfaces
{
    public interface IMachineService : IService<MachineEntity>
    {
        // Extra methods specific for machine
    }
}
