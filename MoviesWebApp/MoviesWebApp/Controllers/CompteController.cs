using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApp.Models.EntityFramework;
using MoviesWebApp.Models.Repository;

namespace MoviesWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompteController : ControllerBase
    {
        private readonly IDataRepository<Compte> _dataRepository;

        public CompteController(IDataRepository<Compte> repository)
        {
            _dataRepository = repository;
        }

        /// <summary>
        /// Get all accounts
        /// </summary>
        /// <returns>HTTP Response</returns>
        // GET: api/Compte
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Compte>>> GetAllCompte()
        {
            return await _dataRepository.GetAll();
        }

        /// <summary>
        /// Get an account with its id.
        /// </summary>
        /// <param name="id">The id of the account</param>
        /// <returns>HTTP Response</returns>
        // GET: api/Compte/ById/5
        [HttpGet("ById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = await _dataRepository.GetById(id);

            if (compte.Value == null)
            {
                return NotFound("Compte not found");
            }

            return compte;
        }

        /// <summary>
        /// Get an account with its email.
        /// </summary>
        /// <param name="email">The email of the account</param>
        /// <returns>HTTP Response</returns>
        // GET: api/Compte/ByEmail/myemail@example.com
        [HttpGet("ByEmail/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await _dataRepository.GetByString(email);

            if (compte.Value == null)
            {
                return NotFound("Compte not found");
            }

            return compte;
        }

        /// <summary>
        /// Updated an account.
        /// </summary>
        /// <param name="id">The id of the account</param>
        /// <param name="compte">The new information of the account</param>
        /// <returns>HTTP Response</returns>
        // PUT: api/Compte/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest("Ids not matching");
            }

            var compteToUpdate = await _dataRepository.GetById(id);
            if (compteToUpdate.Value == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(compteToUpdate.Value, compte);
            return NoContent();
        }

        /// <summary>
        /// Adds an account to the database.
        /// </summary>
        /// <param name="compte">The new account</param>
        /// <returns>HTTP Response</returns>
        // POST: api/Compte
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            await _dataRepository.Add(compte);
            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Compte>> DeleteCompte(int id)
        //{
        //    var compte = _manager.GetById(id);
        //    if (compte == null)
        //    {
        //        return NotFound("Compte not found");
        //    }

        //    _manager.Delete(compte.Value);

        //    return compte;
        //}
    }
}
