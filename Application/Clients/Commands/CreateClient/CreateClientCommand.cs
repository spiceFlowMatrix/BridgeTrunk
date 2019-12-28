using System.Threading;
using System.Threading.Tasks;
using Bridge.Application.Common.Interfaces;
using Bridge.Domain.Entities;
using MediatR;

namespace Bridge.Application.Clients.Commands.CreateCustomer
{
    public class CreateClientCommand : IRequest
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public class Handler : IRequestHandler<CreateClientCommand>
        {
            private IBridgeDbContext _context;
            private IMediator _mediator;

            public Handler(IBridgeDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var entity = new Client
                {
                    Address = request.Address,
                    City = request.City,
                    CompanyName = request.CompanyName,
                    ContactName = request.ContactName,
                    ContactTitle = request.ContactTitle,
                    Country = request.Country,
                    Fax = request.Fax,
                    Phone = request.Phone,
                    PostalCode = request.PostalCode
                };

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new ClientCreated {ClientId = entity.EntityId}, cancellationToken);

                return Unit.Value;
            }
        }
    }
}