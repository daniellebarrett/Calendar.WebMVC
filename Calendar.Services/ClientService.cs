using Calendar.Data;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services
{
    public class ClientService
    {
        private readonly Guid _userId;
        
        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerID = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Users
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                        e =>
                            new ClientListItem
                            {
                                //ClientID = e.ClientID,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                            }
                     );
                return query.ToArray();
            }
        }
    }
}
