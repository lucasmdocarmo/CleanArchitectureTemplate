using CleanArc.Domain.Entities;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Contracts;
using CleanArch.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infrastructure.Repositories
{
    public class ClientRepository : BaseRepository<Client, APIContext>, IClientRepository
    {
        internal ClientRepository() { }
        public ClientRepository(APIContext db) : base(db) { }
    }
}
