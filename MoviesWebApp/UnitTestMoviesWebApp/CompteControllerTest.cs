using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWebApp.Controllers;
using MoviesWebApp.Models.EntityFramework;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTestMoviesWebApp
{
    [TestClass]
    public class CompteControllerTest
    {
        private FilmsDBContext _context;
        private CompteController _controller;

        [TestInitialize]
        public void InitializeTest()
        {
            var builder = new DbContextOptionsBuilder<FilmsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDBTP3; uid=postgres; password=postgres;");
            _context = new FilmsDBContext(builder.Options);
            _controller = new CompteController(_context);
        }

        [TestMethod]
        public void GetAllCompte_Ok()
        {
            var got = _controller.GetAllCompte().Result;
            var expected = _context.Compte.ToArray();
            var gotArray = got.Value.ToArray();
            Assert.AreEqual(gotArray.Length, expected.Length, "Length are different");
            for (var i = gotArray.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(gotArray[i], expected[i], $"Item [{i}] are different");
            }
        }

        [TestMethod]
        public void GetCompteById_KnownId_Ok()
        {
            var got = _controller.GetCompteById(1).Result;
            var expected = _context.Compte.Find(1);
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetCompteById_UnknownId_NotFound()
        {
            var got = _controller.GetCompteById(-1).Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetCompteByEmail_KnownEmail_Ok()
        {
            var expected = _context.Compte.Find(1);
            var got = _controller.GetCompteByEmail(expected.Mel).Result;
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetCompteByEmail_UnknownEmail_NotFound()
        {
            var got = _controller.GetCompteByEmail("unknown_email").Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PutCompte_DifferentId_BadRequest()
        {
            var account = new Compte()
            {
                CompteId = 1,
                Nom = "MACHIN",
                Prenom = "Luc",
                TelPortable = "0606070809",
                Mel = "machin@example.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CP = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            var got = _controller.PutCompte(5, account).Result;
            Assert.IsInstanceOfType(got, typeof(BadRequestObjectResult));
        }
        
        [TestMethod]
        public void PutCompte_ModelValidated_NotFound()
        {
            var account = new Compte()
            {
                CompteId = -1,
                Nom = "MACHIN",
                Prenom = "Luc",
                TelPortable = "0606070809",
                Mel = "machin@example.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CP = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            var got = _controller.PutCompte(-1, account).Result;
            Assert.IsInstanceOfType(got, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PostCompte_ModelValidated_CreationOK()
        {
            // Arrange
            var rnd = new Random();
            var number = rnd.Next(1, 1000000000);
            // The email must be unique so we either:
            // 1. add a timestamps/random number
            // 2. we delete the account after (currently not a option)
            var account = new Compte()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                TelPortable = "0606070809",
                Mel = "machin" + number + "@example.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CP = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var got = _controller.PostCompte(account).Result;
            var actionResult = _controller.GetCompteByEmail(account.Mel).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Compte), "Not an account");
            var expected = _context.Compte.Where(c => c.Mel == account.Mel).FirstOrDefault();
            // We don't know the ID of the created account, because it was generated automatically,
            // so we retrieve it from the newly created entry
            account.CompteId = expected.CompteId;
            Assert.AreEqual(expected, account, "Different accounts");
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void PostCompte_DuplicateEmail_Error()
        {
            // Arrange
            var existingAccount = _context.Compte.First();
            // The email must be unique so we either:
            // 1. add a timestamps/random number
            // 2. we delete the account after (currently not a option)
            var account = new Compte()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                TelPortable = "0606070809",
                Mel = existingAccount.Mel,
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CP = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            _ = _controller.PostCompte(account).Result;
        }
    }
}
