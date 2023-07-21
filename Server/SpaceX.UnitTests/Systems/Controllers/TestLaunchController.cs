using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaceX.Api.Controllers;
using SpaceX.Api.Models;
using SpaceX.Api.Service;
using SpaceX.UnitTests.Fixtures;
using System.Net;

namespace SpaceX.UnitTests.Systems.Controllers
{
    public class TestLaunchController
    {
        /// <summary>
        /// Success case Testing for Get all launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllLaunches_OnSuccess()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetAllLaunchesAsync())
                .ReturnsAsync(LaunchFixture.GetLaunchModel());
            var sut = new LaunchController(mockService.Object);

            //Act
            var result = await sut.GetAllLaunchesAsync();
            var objResult = (OkObjectResult)result;
            //Assert
            mockService.Verify(service => service.GetAllLaunchesAsync(), Times.Once);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            Assert.IsType<List<LaunchModel>>(objResult.Value);
            Assert.True(objResult.StatusCode == (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// No Content case Testing for Get all launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllLaunches_OnNoData_Returns204()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetAllLaunchesAsync())
                .ReturnsAsync(new List<LaunchModel>());
            var sut = new LaunchController(mockService.Object);
            //Act
            var result = await sut.GetAllLaunchesAsync();

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        /// Success case Testing for Get Past launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPastLaunches_OnSuccess()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetPastLaunchesAsync())
                .ReturnsAsync(LaunchFixture.GetLaunchModel());
            var sut = new LaunchController(mockService.Object);

            //Act
            var result = await sut.GetPastLaunchesAsync();
            var objResult = (OkObjectResult)result;
            //Assert
            mockService.Verify(service => service.GetPastLaunchesAsync(), Times.Once);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            Assert.IsType<List<LaunchModel>>(objResult.Value);
            Assert.True(objResult.StatusCode == (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// NoContent case Testing for Get Past launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetPastLaunches_OnNoData_Returns204()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetPastLaunchesAsync())
                .ReturnsAsync(new List<LaunchModel>());
            var sut = new LaunchController(mockService.Object);
            //Act
            var result = await sut.GetPastLaunchesAsync();

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        /// Success case Testing for Get Upoming launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUpcomingLaunches_OnSuccess()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetUpcomingLaunchesAsync())
                .ReturnsAsync(LaunchFixture.GetLaunchModel());
            var sut = new LaunchController(mockService.Object);

            //Act
            var result = await sut.GetUpcomingLaunchesAsync();
            var objResult = (OkObjectResult)result;
            //Assert
            mockService.Verify(service => service.GetUpcomingLaunchesAsync(), Times.Once);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            Assert.IsType<List<LaunchModel>>(objResult.Value);
            Assert.True(objResult.StatusCode == (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// No Content case Testing for Get Upcoming launches API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUpcomingLaunches_OnNoData_Returns204()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetUpcomingLaunchesAsync())
                .ReturnsAsync(new List<LaunchModel>());
            var sut = new LaunchController(mockService.Object);
            //Act
            var result = await sut.GetUpcomingLaunchesAsync();

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        /// <summary>
        /// Success case Testing for Get By Flight Number API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetByFlightNumber_OnSuccess()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            mockService
                .Setup(x => x.GetLaunchByIdAsync("1"))
                .ReturnsAsync(LaunchFixture.GetLaunchModel()[0]);
            var sut = new LaunchController(mockService.Object);
            //Act
            var result = (OkObjectResult)await sut.GetLaunchByFlightNumberAsync("1");
            var objResult = (OkObjectResult)result;


            //Assert
            Assert.True(result.StatusCode == (int)HttpStatusCode.OK);
            mockService.Verify(service => service.GetLaunchByIdAsync("1"), Times.Once);
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            Assert.IsType<LaunchModel>(objResult.Value);
        }

        /// <summary>
        /// KeyNotFound case Testing for Get By Flight Number API
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetByFlightNumber_OnNoData_Returns204()
        {
            //Arrange
            var mockService = new Mock<ILaunchService>();
            LaunchModel testData = null;
            mockService.Setup(x => x.GetLaunchByIdAsync("2")).ReturnsAsync(testData);
            var sut = new LaunchController(mockService.Object);
            //Act
            var result = await sut.GetLaunchByFlightNumberAsync("2");

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

    }
}