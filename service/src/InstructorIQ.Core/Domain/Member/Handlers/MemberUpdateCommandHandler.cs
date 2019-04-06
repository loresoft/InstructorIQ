using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
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

        protected override async Task<MemberReadModel> Process(EntityUpdateCommand<Guid, MemberUpdateModel, MemberReadModel> message, CancellationToken cancellationToken)
        {
            var id = message.Id;
            var model = message.Model;

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return null;

            bool isGlobalAdministrator = message.Principal.IsInRole(Data.Constants.Role.GlobalAdministrator);

            await UpdateEmail(id, model, user);
            await UpdatePhoneNumber(id, model, user);
            await UpdateModel(id, model, user, isGlobalAdministrator);

            return await Read(id).ConfigureAwait(false);
        }

        private async Task UpdateModel(Guid id, MemberUpdateModel model, Data.Entities.User user, bool isGlobalAdministrator)
        {
            // update model properties
            user.DisplayName = model.DisplayName;

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
