using SpaceX.Api.Models;
using System.Net;
using System.Net.Http;

namespace SpaceX.Api.Service
{
    public class LaunchService : ILaunchService
    {
        private readonly HttpClient _httpClient;
        public LaunchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Service to communicate with spaceX api to fetch all Launches
        /// </summary>
        /// <returns>list of all launches</returns>
        public async Task<List<LaunchModel>> GetAllLaunchesAsync()
        {
            List<LaunchModel> launchList = new List<LaunchModel>();
            
            using (HttpResponseMessage res = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/launches/"))
            {
                if (res.IsSuccessStatusCode)
                {
                    launchList = await res.Content.ReadFromJsonAsync<List<LaunchModel>>();
                }
            }
            return launchList;
        }

        /// <summary>
        /// Service to communicate with spaceX api to fetch upcoming Launches
        /// </summary>
        /// <returns>list of upcoming launches</returns>
        public async Task<List<LaunchModel>> GetUpcomingLaunchesAsync()
        {
            List<LaunchModel> launchList = new List<LaunchModel>(); 
            
            using (HttpResponseMessage res = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/launches/upcoming"))
            {
                if (res.IsSuccessStatusCode)
                {
                    launchList = await res.Content.ReadFromJsonAsync<List<LaunchModel>>();
                }
            }
            return launchList;
        }

        /// <summary>
        /// Service to communicate with spaceX api to fetch Launche details by Flight number
        /// </summary>
        /// <param name="flight_number">flight number</param>
        /// <returns>launch details</returns>
        public async Task<LaunchModel> GetLaunchByIdAsync(string flight_number)
        {
            LaunchModel launch = new LaunchModel();
            using (HttpResponseMessage res = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/launches/{flight_number}"))
            {
                if (!res.IsSuccessStatusCode)
                {
                    return null; 
                }
                launch = await res.Content.ReadFromJsonAsync<LaunchModel>();


            }
            return launch;
        }

        /// <summary>
        /// Service to communicate with spaceX api to fetch past Launches
        /// </summary>
        /// <returns>list of past launches</returns>
        public async Task<List<LaunchModel>> GetPastLaunchesAsync()
        {
            List<LaunchModel> launchList = new List<LaunchModel>();

            using (HttpResponseMessage res = await _httpClient.GetAsync($"{_httpClient.BaseAddress}/launches/past"))
            {
                if (res.IsSuccessStatusCode)
                {
                    launchList = await res.Content.ReadFromJsonAsync<List<LaunchModel>>();
                }
            }
            return launchList;
        }
    }
}
