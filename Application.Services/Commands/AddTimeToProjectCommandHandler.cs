using Application.DTO.Responses;
using Domain.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class AddTimeToProjectCommandHandler : IRequestHandler<AddTimeToProjectCommand, ApiResponse>
    {
        public IProjectRepository ProjectRepository;
        public AddTimeToProjectCommandHandler(IProjectRepository projectRepository)
        {
            ProjectRepository = projectRepository;
        }
        public async Task<ApiResponse> Handle(AddTimeToProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await ProjectRepository.GetFirstOrDefaultAsync(x => x.Id == request.Request.projectId);
            TimeSpan durationToAdd = TimeSpan.Parse(request.Request.time.ToString());
            TimeSpan previousDuration = TimeSpan.Parse(project.Duration);

            var totalDuration = previousDuration + durationToAdd;

            #region Update postgresql database
            try
            {
               project.Duration = totalDuration.ToString();


                ProjectRepository.Update(project);

                await ProjectRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                 throw ex;
            }
            #endregion

            return new ApiResponse(200, false, new List<string>());
        }
    }
}
