using Application.DTO.Responses;
using Domain.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Queries
{
   public class GetProjectTimeInformationsQueryHandler : IRequestHandler<GetProjectTimeInformationsQuery, GetProjectTimeInformationsResponse>
    {
        public IProjectRepository ProjectRepository;

        public GetProjectTimeInformationsQueryHandler(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }
        public async Task<GetProjectTimeInformationsResponse> Handle(GetProjectTimeInformationsQuery request, CancellationToken cancellationToken)
        {
           // Guid ProjectId = request.GetProjectTimeInformationsRequest.Id;

            var projects = await ProjectRepository.GetAllAsync();
            if (projects == null)
                return new GetProjectTimeInformationsResponse(new List<string>(), 200, false);

            var getProjectTimeInformationsResponse = new GetProjectTimeInformationsResponse(new List<string>(), 200, false);
            foreach (var project in projects)
            {
                var _project = new DTO.Models.Project()
                {
                    Id = project.Id,
                    ProjectName = project.Name,
                    Duration = project.Duration
                };

                getProjectTimeInformationsResponse.ProjectInformations.Add(_project);
            }

            return getProjectTimeInformationsResponse;
        }
    }
}
