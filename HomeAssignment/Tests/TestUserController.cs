using HomeAssignment.Controllers;
using HomeAssignment.Models;
using Microsoft.AspNetCore.Mvc;


namespace Tests
{
    public class Tests
    {
        UserController controller;
        UserLoginRequest loginRequest;
        UserInformationRequest informationRequest;

        [SetUp]
        public void Setup()
        {
            // Arrange
            controller = new UserController();    
            loginRequest = new UserLoginRequest("jhon", "verySecuredP@ssw0rd");
            informationRequest = new UserInformationRequest("A78b54gx0-uhj8");
        }

        [Test]
        public void TestLoginPost()
        {
            // Act
            IActionResult response = controller.PostLogin(loginRequest);

            // Assert
            string expected = "{\"UserLoginResponse\":{\"UserId\":\"A78b54gx0 - uhj8\",\"SessionKey\":\"_sdjh765riuyh\"}}";
            OkObjectResult okResult = response as OkObjectResult;
            Assert.AreEqual(okResult.Value,expected);
        }


        [Test]
        public void TestInformationPost()
        {
            // Act
            IActionResult response = controller.PostInformation(informationRequest);

            // Assert
            string expected = "{\"UserLoginResponse\":{\"UserId\":\"A78b54gx0 - uhj8\",\"SessionKey\":\"_sdjh765riuyh\"}}";
            OkObjectResult okResult = response as OkObjectResult;
            Assert.AreEqual(okResult.Value, expected);
        }
    }
}


