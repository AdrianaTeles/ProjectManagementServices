using System;
using System.Collections.Generic;
using System.Text;
using Application.DTO.Requests;
using Application.DTO.Responses;
using MediatR;

namespace Application.Services.Commands
{
    public class AddTimeToProjectCommand : IRequest<ApiResponse>
    {
        public AddTimeToProjectCommand()
        {
        }

        public AddTimeToProjectCommand( AddTimeToProjectRequest request)
        {
            Request = request;
        }

        public AddTimeToProjectRequest Request { get; set; }
    }
}