using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.DataAccess.Context;
using Tesodev.Entities.Entities;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class AddressRepository : SideRepository<Address>
    {
        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;
        public AddressRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public Address CreateAddress()
        {

            Address address = new Address
            {
                ID = Guid.NewGuid(),
                City = "",
                Country = "",
                CityCode = 0,
                Status = Core.Enum.Status.None
            };

            return address;
        }

    }
}
