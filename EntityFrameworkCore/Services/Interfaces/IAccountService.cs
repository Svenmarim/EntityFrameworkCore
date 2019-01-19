using EntityFrameworkCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Services.Interfaces
{
    public interface IAccountService : IService<AccountEntity>
    {
        // Extra methods specific for account
    }
}
