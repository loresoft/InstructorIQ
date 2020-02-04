using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberUpdateCommandHandler
        : EntityDataContextHandlerBase<InstructorIQContext, Data.Entities.User, Guid, MemberReadModel, EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel>, MemberReadModel>
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public MemberUpdateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserManager<Core.Data.Entities.User> userManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userManager = userManager;
        }

        protected override async Task<MemberReadModel> Process(EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel> request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var model = request.Model;

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;

            if (string.IsNullOrEmpty(user.SecurityStamp))
                await _userManager.UpdateSecurityStampAsync(user);

            bool isGlobalAdministrator = request.Principal.IsInRole(Data.Constants.Role.GlobalAdministrator);

            await UpdateEmail(id, model, user);
            await UpdatePhoneNumber(id, model, user);
            await UpdateModel(id, model, user, isGlobalAdministrator);
            await UpdateLockoutEnd(id, model, user);

            return await Read(id, cancellationToken).ConfigureAwait(false);
        }

        private async Task UpdateLockoutEnd(Guid id, MemberUpdateModel model, User user)
        {
            var currentLockoutEnabled = await _userManager.GetLockoutEndDateAsync(user);

            if (currentLockoutEnabled == model.LockoutEnd)
                return;
            
            var result = await _userManager.SetLockoutEndDateAsync(user, model.LockoutEnd);
            if (!result.Succeeded)
                throw new DomainException(System.Net.HttpStatusCode.InternalServerError, $"Unexpected error occurred setting lockout end date for user with ID '{id}'.");
        }

        private async Task UpdateModel(Guid id, MemberUpdateModel model, Data.Entities.User user, bool isGlobalAdministrator)
        {
            // update model properties
            user.GivenName = model.GivenName;
            user.MiddleName = model.MiddleName;
            user.FamilyName = model.FamilyName;
            user.DisplayName = model.DisplayName;
            user.JobTitle = model.JobTitle;

            // global admin fields
            if (isGlobalAdministrator)
            {
                user.IsGlobalAdministrator = model.IsGlobalAdministrator;
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                throw new InvalidOperationException($"Unexpected error occurred updating display name for user with ID '{id}'.");
        }

        private async Task UpdatePhoneNumber(Guid id, MemberUpdateModel model, Data.Entities.User user)
        {
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber == phoneNumber)
                return;

            var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
            if (!setPhoneResult.Succeeded)
                throw new DomainException(System.Net.HttpStatusCode.InternalServerError, $"Unexpected error occurred setting phone number for user with ID '{id}'.");
        }

        private async Task UpdateEmail(Guid id, MemberUpdateModel model, Data.Entities.User user)
        {
            var email = await _userManager.GetEmailAsync(user);
            if (model.Email == email)
                return;

            var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
            if (!setEmailResult.Succeeded)
                throw new DomainException(System.Net.HttpStatusCode.InternalServerError, $"Unexpected error occurred setting email for user with ID '{id}'.");
        }
    }
}
