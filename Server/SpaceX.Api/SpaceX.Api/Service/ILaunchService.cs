using Microsoft.AspNetCore.Mvc;
using SpaceX.Api.Models;

namespace SpaceX.Api.Service
{
    public interface ILaunchService
    {
        Task<List<LaunchModel>> GetAllLaunchesAsync();
        Task<List<LaunchModel>> GetUpcomingLaunchesAsync(); 
        Task<List<LaunchModel>> GetPastLaunchesAsync();

        Task<LaunchModel> GetLaunchByIdAsync(string id);
    }
}
