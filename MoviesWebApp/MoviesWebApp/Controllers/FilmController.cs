using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApp.Models.EntityFramework;
using MoviesWebApp.Models.Repository;

namespace MoviesWebApp.Controllers
{
    /// <summary>
    /// Controller to manage movies.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IDataRepository<Film> _dataRepository;

        /// <summary>
        /// Constructor of FilmController
        /// </summary>
        /// <param name="repository">The data repository</param>
        public FilmController(IDataRepository<Film> repository)
        {
            _dataRepository = repository;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        // GET: api/Film
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Film>>> GetAllFilm()
        {
            return await _dataRepository.GetAll();
        }

        /// <summary>
        /// Get a movie with its id.
        /// </summary>
        /// <param name="id">The id of the movie</param>
        /// <returns>HTTP Response</returns>
        // GET: api/Film/ById/5
        [HttpGet("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Film>> GetFilmById(int id)
        {
            var film = await _dataRepository.GetById(id);

            if (film.Value == null)
            {
                return NotFound("Film not found");
            }

            return film;
        }

        /// <summary>
        /// Get a movie with its title.
        /// </summary>
        /// <param name="title">The title of the movie (case sensitive)</param>
        /// <returns>HTTP Response</returns>
        // GET: api/Film/ByTitle/5
        [HttpGet("ByTitle/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Film>> GetFilmByTitle(string title)
        {
            var film = await _dataRepository.GetByString(title);

            if (film.Value == null)
            {
                return NotFound("Film not found");
            }

            return film;
        }

        /// <summary>
        /// Update a movie.
        /// </summary>
        /// <param name="id">The id of the movie</param>
        /// <param name="film">The new information of the movie</param>
        /// <returns>HTTP Response</returns>
        // PUT: api/Film/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFilm(int id, Film film)
        {
            if (id != film.FilmId)
            {
                return BadRequest("Ids not matching");
            }

            var filmToUpdate = await _dataRepository.GetById(id);
            if (filmToUpdate.Value == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(filmToUpdate.Value, film);
            return NoContent();
        }

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="film">The new movie</param>
        /// <returns>HTTP Response</returns>
        // POST: api/Film
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Film>> PostFilm(Film film)
        {
            await _dataRepository.Add(film);
            return CreatedAtAction("GetFilm", new { id = film.FilmId }, film);
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="id">The id of the movie</param>
        /// <returns>HTTP Response</returns>
        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Film>> DeleteFilm(int id)
        {
            var filmToDelete = await _dataRepository.GetById(id);
            if (filmToDelete.Value == null)
            {
                return NotFound();
            }

            await _dataRepository.Delete(filmToDelete.Value);
            return filmToDelete;
        }
    }
}
