using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class LinkTokenValidateCommandHandler : DataContextHandlerBase<InstructorIQContext, LinkTokenValidateCommand, LinkTokenReadModel>
    {
        public LinkTokenValidateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<LinkTokenReadModel> Process(LinkTokenValidateCommand request, CancellationToken cancellationToken)
        {
            // token is stored hashed to prevent session hijacking 
            var tokenHash = request.Token.ComputeHash();

            var linkToken = await DataContext.LinkTokens
                .FirstOrDefaultAsync(t => t.TokenHash == tokenHash, cancellationToken)
                .ConfigureAwait(false);

            if (linkToken == null)
            {
                Logger.LogWarning("Link token '{token}' not found.", request.Token);
                return null;
            }

            // link expired
            if (linkToken.Expires.HasValue && linkToken.Expires.Value < DateTimeOffset.UtcNow)
            {
                Logger.LogWarning("User '{userName}' attempted to log in with expired link token: {token}", linkToken.UserName, request.Token);
                return null;
            }
            
            // return login information
            var readToken = new LinkTokenReadModel
            {
                Url = linkToken.Url,
                UserName = linkToken.UserName,
                TenantId = linkToken.TenantId
            };

            return readToken;
        }
    }
}