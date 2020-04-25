using Application.DTO.Requests;
using Application.DTO.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Queries
{
   public class GetProjectTimeInformationsQuery: IRequest<GetProjectTimeInformationsResponse>
    {
        public GetProjectTimeInformationsRequest GetProjectTimeInformationsRequest { get; set; }
        public GetProjectTimeInformationsQuery()
        {

        }

        public GetProjectTimeInformationsQuery(GetProjectTimeInformationsRequest getProjectTimeInformationsRequest)
        {
            GetProjectTimeInformationsRequest = getProjectTimeInformationsRequest;
        }
    }
}