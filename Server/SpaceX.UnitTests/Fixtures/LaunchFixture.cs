using SpaceX.Api.Models;

namespace SpaceX.UnitTests.Fixtures
{
    public static class LaunchFixture
    {
        public static List<LaunchModel> GetLaunchModel()
        {
            return new List<LaunchModel>()
            {
                new LaunchModel
                {
                    Details = "",
                    Flight_Number = 1,
                    Launch_Date_Utc = DateTime.UtcNow,
                    Launch_Year="2019",
                    Launch_Site= new LaunchSite
                    {
                        Site_Id="",
                        Site_Name="",
                        Site_Name_Long=""
                    },
                    Links= new ReferenceLinks
                    {
                        Flickr_Images= new List<string>()
                        {
                            "ws","as"
                        },
                        Video_Link="",
                        Wikipedia=""
                    },
                    Mission_Name="SpaceX",
                    Upcoming=true
                }
            };
            
        }
    }
}
