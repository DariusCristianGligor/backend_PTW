using Application;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReviewNow.Controllers;
using System.Collections.Generic;
using System.Net;

namespace ControllerTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var sessions = new List<Admin>();
            sessions.Add(
                new Admin()
                {
                    Name = "Cristi",
                    PhoneNumber = "0741199428",
                    Address = "Primaverii,nr 26",
                    Mail = "darius.gligor@gmail.com"
                });
            //Arrange
            var mockAdmin = new Mock<IAdminRepository>();
            mockAdmin.Setup(x => x.GetAll()).Returns(
                (System.Linq.IQueryable<Admin>)sessions);
            var controller = new AdminsController(mockAdmin.Object);
            //Act
            var result = controller.Index();
            var okResult = result as OkObjectResult;
            //Asert
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }


    }
}
