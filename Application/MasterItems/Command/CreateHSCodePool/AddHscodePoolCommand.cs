using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Application.MasterItems.Command.CreateHSCodePool
{
    public class AddHscodePoolCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string HSCode { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public string StandardUnitOfQuantity { get; set; }
        public int CountryId { get; set; }
        public bool IsActive { get; set; }
    }

    public class AddHscodePoolCommandHandler : IRequestHandler<AddHscodePoolCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public AddHscodePoolCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddHscodePoolCommand request, CancellationToken cancellationToken)
        {
            var entity = new HSCodePool
            {
                 HSCode = request.HSCode,
                 Heading = request.Heading,
                 Description = request.Description,
                 StandardUnitOfQuantity = request.StandardUnitOfQuantity,
                 CountryId = request.CountryId,
                 IsActive = true
            };


            _context.HSCodePools.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
