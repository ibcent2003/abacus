using Application.Registration.GetGuestUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wbc.Application.Common.Interfaces;
using Wbc.Domain.Entities;

namespace Wbc.Application.Registration.Command.AddGuestUser
{
    public class AddGuestUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public int NoOfUse { get; set; }
        public DateTime AccessDate { get; set; }
    }
    public class AddGuestUserCommandHandler : IRequestHandler<AddGuestUserCommand, string>
    {
        private readonly IApplicationDbContext _context;
       


        public AddGuestUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
           
        }
        public async Task<string> Handle(AddGuestUserCommand request, CancellationToken cancellationToken)
        {
           
            var check = _context.GuestUsers.Where(x => x.Ip == request.Ip).FirstOrDefault();
            if(check == null)
            {
                var entity = new GuestUser
                {
                    Ip = request.Ip,
                    NoOfUse = request.NoOfUse,
                    AccessDate = request.AccessDate,
                };

                _context.GuestUsers.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Ip;
            }
            return null;

            
        }

    }
    }
