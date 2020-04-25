using Application.DTO.Requests;
using Application.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Commands
{
    public class CreateProjectCommand : IRequest<ApiResponse>
    {
        public CreateProjectCommand()
        {
        }

        public CreateProjectCommand(CreateProjectRequest request)
        {
            Request = request;
        }

        public CreateProjectRequest Request { get; set; }
    }
}