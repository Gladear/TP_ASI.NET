using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using WSConvertisseur.Controllers;
using WSConvertisseur.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private CurrencyController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new CurrencyController();
        }

        [TestMethod]
        public void getAll_ReturnsEnumerable()
        {
            // Act
            var result = _controller.GetAll();
            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable), "Pas un IEnumerable");
        }

        [TestMethod]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var _controller = new CurrencyController();

            // Act
            var result = _controller.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Currency), "Pas une Devise");
            Assert.AreEqual(new Currency(1, "Franc Suisse", 1.3), (Currency)result.Value, "Devises pas identiques");
        }

        [TestMethod]
        public void Post_CreatedAtRouteResult()
        {
            // Act
            var result = _controller.Post(new Currency());
            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult), "Pas un CreateAtRouteResult");
        }

        [TestMethod]
        public void Put_BadRequest_ReturnsBadRequest()
        {
            // Act
            var result = _controller.Put(1, new Currency());
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Pas un BadRequestResult");
        }

        [TestMethod]
        public void Put_UnknownId_ReturnsNotFound()
        {
            // Act
            var result = _controller.Put(4, new Currency(4, "Test", 0.2));
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas de NotFoundResult");
        }

        [TestMethod]
        public void Put_KnownId_ReturnsNoContent()
        {
            // Act
            var result = _controller.Put(1, new Currency(1, "Test", 0.1));
            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult), "Pas de NoContent");
        }

        [TestMethod]
        public void Delete_UnknownId_ReturnsNotFound()
        {
            // Act
            var result = _controller.Delete(5);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas de NotFoundResult");
        }

        [TestMethod]
        public void Delete_KnownId_ReturnsNoContent()
        {
            // Act
            var result = _controller.Delete(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult), "Pas de NoContentResult");
        }
    }
}
