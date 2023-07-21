namespace SpaceX.Api.Models
{
    public class LaunchModel
    {
        public int Flight_Number { get; set; } 
        public string Mission_Name { get;set; } = default!;
        public string Launch_Year { get; set; } = default!;
        public DateTime Launch_Date_Utc { get;set; }
        public string Details { get; set; } = default!;
        public ReferenceLinks Links { get; set; } = default!;
        public LaunchSite Launch_Site { get; set; } = default!;
        public bool Upcoming { get; set; } = default!;

    }

    public class ReferenceLinks
    {
        public string Wikipedia { get; set; } = default!;
        public string Video_Link { get; set; } = default!;
        public List<string> Flickr_Images { get; set; } = default!;

    }
    public class LaunchSite
    {
        public string Site_Id { get; set; } = default!;
        public string Site_Name { get; set; } = default!;
        public string Site_Name_Long { get; set; } = default!;

    }
}