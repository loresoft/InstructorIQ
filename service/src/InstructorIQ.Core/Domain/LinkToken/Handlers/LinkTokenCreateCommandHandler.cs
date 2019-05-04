using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Queries;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class LinkTokenCreateCommandHandler : DataContextHandlerBase<InstructorIQContext, LinkTokenCreateCommand, LinkTokenReadModel>
    {
        public LinkTokenCreateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper) 
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<LinkTokenReadModel> Process(LinkTokenCreateCommand request, CancellationToken cancellationToken)
        {
            // token is stored hashed to prevent session hijacking 
            var tokenHash = request.Token.ComputeHash();

            var linkToken = new Data.Entities.LinkToken
            {
                Expires = request.Model.Expires,
                Issued = DateTimeOffset.UtcNow,
                TenantId = request.Model.TenantId,
                TokenHash = tokenHash,
                Url = request.Model.Url,
                UserName = request.Model.UserName
            };

            // save to db
            DataContext.LinkTokens.Add(linkToken);
            await DataContext.SaveChangesAsync(cancellationToken);

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
