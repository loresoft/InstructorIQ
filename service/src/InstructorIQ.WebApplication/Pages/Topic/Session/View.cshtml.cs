using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Session
{
    public class ViewModel : EntityIdentifierModelBase<SessionReadModel>
    {
        public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory) 
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid TopicId { get; set; }

        public IReadOnlyCollection<SessionInstructorModel> AdditionalInstructors { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var additionalTask = LoadAdditionalInstructors();

            // load all in parallel
            await Task.WhenAll(
                loadTask,
                additionalTask
            );

            AdditionalInstructors = additionalTask.Result;

            return Page();
        }


        private async Task<IReadOnlyCollection<SessionInstructorModel>> LoadAdditionalInstructors()
        {
            var dropdownQuery = new SessionInstructorQuery(User, Id);
            var items = await Mediator.Send(dropdownQuery);

            return items;
        }

    }
}