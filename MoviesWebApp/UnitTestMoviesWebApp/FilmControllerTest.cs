using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesWebApp.Controllers;
using MoviesWebApp.Models.EntityFramework;
using MoviesWebApp.Models.Repository;
using MoviesWebApp.Models.DataManager;
using System;
using System.Linq;

namespace UnitTestMoviesWebApp
{
    [TestClass]
    public class FilmControllerTest
    {
        private FilmsDBContext _context;
        private FilmController _controller;
        private IDataRepository<Film> _dataRepository;

        [TestInitialize]
        public void InitializeTest()
        {
            var builder = new DbContextOptionsBuilder<FilmsDBContext>().UseNpgsql("Server=localhost;port=5432;Database=FilmsDBTP3; uid=postgres; password=postgres;");
            _context = new FilmsDBContext(builder.Options);
            _dataRepository = new FilmManager(_context);
            _controller = new FilmController(_dataRepository);
        }

        [TestMethod]
        public void GetAllFilm_Ok()
        {
            var got = _controller.GetAllFilm().Result;
            var expected = _context.Film.ToArray();
            var gotArray = got.Value.ToArray();
            Assert.AreEqual(gotArray.Length, expected.Length, "Length are different");
            for (var i = gotArray.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(gotArray[i], expected[i], $"Item [{i}] are different");
            }
        }

        [TestMethod]
        public void GetFilmById_KnownId_Ok()
        {
            var got = _controller.GetFilmById(1).Result;
            var expected = _context.Film.Find(1);
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetFilmById_UnknownId_NotFound()
        {
            var got = _controller.GetFilmById(-1).Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void GetFilmByEmail_KnownEmail_Ok()
        {
            var expected = _context.Film.Find(1);
            var got = _controller.GetFilmByTitle(expected.Titre).Result;
            Assert.AreEqual(got.Value, expected, "Not the same objects");
        }

        [TestMethod]
        public void GetFilmByEmail_UnknownEmail_NotFound()
        {
            var got = _controller.GetFilmByTitle("__most_likely_an_unknown_title__").Result;
            Assert.IsInstanceOfType(got.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void PutFilm_DifferentId_BadRequest()
        {
            var movie = new Film()
            {
                FilmId = 1,
            };
            var got = _controller.PutFilm(5, movie).Result;
            Assert.IsInstanceOfType(got, typeof(BadRequestObjectResult));
        }
        
        [TestMethod]
        public void PutFilm_ModelValidated_NotFound()
        {
            var movie = new Film()
            {
                FilmId = -1,
            };
            var got = _controller.PutFilm(-1, movie).Result;
            Assert.IsInstanceOfType(got, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostFilm_ModelValidated_CreationOK()
        {
            // Arrange
            var rnd = new Random();
            var number = rnd.Next(1, 1000000000);
            // The email must be unique so we either:
            // 1. add a timestamps/random number
            // 2. we delete the account after (currently not a option)
            var movie = new Film()
            {
                Titre = "A title",
                Synopsis = "A synopsis",
                DateParution = DateTime.Now,
                Duree = 12300L,
                Genre = "Drame",
                UrlPhoto = "http://example.com/",
            };
            // Act
            var got = _controller.PostFilm(movie).Result;
            var actionResult = _controller.GetFilmByTitle(movie.Titre).Result;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Film), "Not a movie");
            var expected = _context.Film.Where(c => c.Titre == movie.Titre).FirstOrDefault();
            // We don't know the ID of the created account, because it was generated automatically,
            // so we retrieve it from the newly created entry
            movie.FilmId = expected.FilmId;
            Assert.AreEqual(expected, movie, "Different movies");
        }
    }
}
