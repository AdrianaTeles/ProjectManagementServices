using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Services.Commands;
using Application.DTO.Responses;
using Application.DTO.Requests;
using Application.Services.Queries;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimeManagementController : ControllerBase
    {
        private readonly IMediator Mediator;

        /// <summary>
        /// Constructor for document controller
        /// </summary>
        /// <param name="mediator">Third party program to implement a CQRS pattern</param>
        public TimeManagementController(IMediator mediator)
        {
            Mediator = mediator;
        }

        #region Time
        /// <summary>
        /// Add Duration
        /// </summary>
        /// <param name="addTimeToProjectRequest">add time to project request </param>
        /// <returns></returns>
        [HttpPut(), ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> AddTimeToProject( [FromBody] AddTimeToProjectRequest addTimeToProjectRequest)
        {
            //Validate request
            var addTimeToProjectCommand = new AddTimeToProjectCommand( addTimeToProjectRequest);
            var res = await Mediator.Send(addTimeToProjectCommand);

            return Ok(res);
        }

        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="createProjectRequest">add time to project request </param>
        /// <returns></returns>
        [HttpPost(), ProducesResponseType(typeof(ApiResponse), 200)]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest createProjectRequest)
        {
            //Validate request
            var createProjectCommand = new CreateProjectCommand(createProjectRequest);
            var res = await Mediator.Send(createProjectCommand);

            return Ok(res);
        }

        /// <summary>
        ///Get All projects Info
        /// </summary>
        /// <returns></returns>
        [HttpGet(), ProducesResponseType(typeof(GetProjectTimeInformationsResponse), 200)]
        public async Task<IActionResult> GetProjectTimeInformations()
        {

            //Validate request
            var getProjectTimeInformationsQuery = new GetProjectTimeInformationsQuery();
            var res = await Mediator.Send(getProjectTimeInformationsQuery);

            return Ok(res);
        }
        #endregion
    }
}
