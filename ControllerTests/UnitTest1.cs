using Application;
using AutoMapper;
using Domain.NormalDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ReviewNow.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ControllerTests
{
    [TestClass]
    public class AdminControllerTest
    {
        private Mock<IAdminRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;

        public AdminControllerTest()
        {
            _mockRepository = new Mock<IAdminRepository>();
            _mockMapper = new Mock<IMapper>();
        }


        [TestMethod]
        public void GetAll_GetsAllSuccessfully_ReturnOk()
        {
            //Arrange
            //var sessions = new List<Admin>();
            //sessions.Add(
            //    new Admin()
            //    {
            //        Name = "Cristi",
            //        PhoneNumber = "0741199428",
            //        Address = "Primaverii,nr 26",
            //        Mail = "darius.gligor@gmail.com"
            //    });

            //_mockRepository.Setup(x => x.GetAll()).Returns(
            //    (System.Linq.IQueryable<Admin>)sessions;;
            _mockRepository.Setup(x => x.GetAll());

            var controller = new AdminsController(_mockRepository.Object, _mockMapper.Object);

            //Act
            var result = controller.Index();

            //Asert
            Assert.AreEqual((int)HttpStatusCode.OK, ((OkObjectResult)result).StatusCode);
        }


    }
}
