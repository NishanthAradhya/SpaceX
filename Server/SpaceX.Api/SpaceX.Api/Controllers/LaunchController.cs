using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceX.Api.Models;
using SpaceX.Api.Service;

namespace SpaceX.Api.Controllers
{
    [ApiController]
    public class LaunchController : ControllerBase
    {
        private readonly ILaunchService _spaceXService;
        public LaunchController(ILaunchService spaceXService)
        {
            _spaceXService = spaceXService;
        }
        /// <summary>
        /// Fetch all the SpaceX launches including past and upcoming launches
        /// </summary>
        /// <returns>List of Launches</returns>
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<ActionResult> GetAllLaunchesAsync()
        {
            var launchList = await _spaceXService.GetAllLaunchesAsync();
            if(launchList.Count != 0)
            {
                return Ok(launchList);
            }
            return NoContent();
        }

        /// <summary>
        /// Fetch all the upcoming SpaceX Launches
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/upcoming")]
        [HttpGet]
        public async Task<ActionResult> GetUpcomingLaunchesAsync()
        {
            var launchList = await _spaceXService.GetUpcomingLaunchesAsync();
            if (launchList.Count != 0)
            {
                return Ok(launchList);
            }
            return NoContent();
        }

        /// <summary>
        /// Fetch all the Past SpaceX Launches
        /// </summary>
        /// <returns></returns>
        [Route("api/[controller]/past")]
        [HttpGet]
        public async Task<ActionResult> GetPastLaunchesAsync()
        {
            var launchList = await _spaceXService.GetPastLaunchesAsync();
            if (launchList.Count != 0)
            {
                return Ok(launchList);
            }
            return NoContent();
        }

        /// <summary>
        /// Fetch the launch details with Flight number
        /// </summary>
        /// <param name="id">Flight Number</param>
        /// <returns>Launch details of the gievn flight number</returns>
        /// <exception cref="BadHttpRequestException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        [Route("api/[controller]/{id}")]
        [HttpGet]
        public async Task<ActionResult> GetLaunchByFlightNumberAsync(string id)
        {
            LaunchModel launch = await _spaceXService.GetLaunchByIdAsync(id);
            if(launch == null)
            {
                return new NotFoundResult();
            }
            return Ok(launch);

        }

    }
}
