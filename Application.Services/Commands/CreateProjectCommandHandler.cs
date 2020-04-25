using Application.DTO.Responses;
using Domain.Core.Repositories;
using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ApiResponse>
    {
        public IProjectRepository ProjectRepository;
    public CreateProjectCommandHandler(IProjectRepository projectRepository)
    {
        ProjectRepository = projectRepository;
    }
    public async Task<ApiResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
            var project = new ProjectDuration()
            {
                Id = new Guid(),
                Name = request.Request.ProjectName,
                Duration = "0"
                
            };

        #region Update postgresql database
        try
        {

            await ProjectRepository.AddAsync(project);

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