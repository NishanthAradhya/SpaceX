# SpaceX API

This API was implemented with C# and .Net 6.

## Available API's

In this API project we have follwing API's :

### `api/launch`

Fetch all the SpaceX launches including past and upcoming launches.It accepts no parameters.

### `api/launch/upcoming`

Fetch all the upcoming SpaceX Launches.This accepts no parameters.

### `api/launch/past`

Fetch all the past SpaceX Launches.This accepts no parameters.\

### `api/launch/{id}`

Fetch the flight details by flight number.This accepts flight number as parameter.\

**Note: This Api internally consumes SpaceX External API!**

**Sample Data of the flight Model.
###  {
    "flight_Number": 1,
    "mission_Name": "FalconSat",
    "launch_Year": "2006",
    "launch_Date_Utc": "2006-03-24T22:30:00Z",
    "details": "Engine failure at 33 seconds and loss of vehicle",
    "links": {
      "wikipedia": "https://en.wikipedia.org/wiki/DemoSat",
      "video_Link": "https://www.youtube.com/watch?v=0a_00nJ_Y88",
      "flickr_Images": []
    },
    "launch_Site": {
      "site_Id": "kwajalein_atoll",
      "site_Name": "Kwajalein Atoll",
      "site_Name_Long": "Kwajalein Atoll Omelek Island"
    },
    "upcoming": false
}"
