using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class LinkTokenCreateCommandHandler : DataContextHandlerBase<InstructorIQContext, LinkTokenCreateCommand, LinkTokenReadModel>
    {
        private readonly UserClaimManager _userClaimManager;

        public LinkTokenCreateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<LinkTokenReadModel> Process(LinkTokenCreateCommand request, CancellationToken cancellationToken)
        {
            // token is stored hashed to prevent session hijacking 
            var tokenHash = request.Token.ComputeHash();
            var returnUrl = GetReturnUrl(request);
            var tenantId = GetTenantId(request);

            var linkToken = new Data.Entities.LinkToken
            {
                Expires = request.Model.Expires,
                Issued = DateTimeOffset.UtcNow,
                TenantId = tenantId,
                TokenHash = tokenHash,
                Url = returnUrl,
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

        private Guid? GetTenantId(LinkTokenCreateCommand request)
        {
            return request.Model.TenantId ??
                _userClaimManager.GetTenantId(request.Principal);
        }

        private string GetReturnUrl(LinkTokenCreateCommand request)
        {
            var linkUrl = request.Model.Url;
            if (linkUrl.IsNullOrEmpty())
                return "/";

            var linkUri = new Uri(linkUrl, UriKind.RelativeOrAbsolute);
            var returnUrl = linkUri.ToLocalPath();

            return returnUrl;
        }
    }
}
