using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// The controller handling currencies' name and rate
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private const string GetCurrency = "GetCurrency";
        private List<Currency> _currencies;

        /// <summary>
        /// The constructor for the currency controller
        /// </summary>
        public CurrencyController()
        {
            _currencies = new List<Currency>(3);
            _currencies.Add(new Currency(0, "Euro", 1.1));
            _currencies.Add(new Currency(1, "Franc Suisse", 1.3));
            _currencies.Add(new Currency(2, "Dollar", 1));
        }

        /// <summary>
        /// Get all currencies
        /// </summary>
        /// <returns>HTTP response</returns>
        /// <response code="200"></response>
        // GET: api/<CurrencyController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Currency>), 200)]
        public IEnumerable<Currency> GetAll()
        {
            return _currencies;
        }

        /// <summary>
        /// Get a specific currency
        /// </summary>
        /// <param name="id">The id of the currency</param>
        /// <returns>HTTP response</returns>
        /// <response code="200">When the id is found</response>
        /// <response code="404">When the id is not found</response>
        // GET api/<CurrencyController>/5
        [HttpGet("{id}", Name = GetCurrency)]
        [ProducesResponseType(typeof(Currency), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var currency = (
                from d in _currencies
                where d.Id == id
                select d).FirstOrDefault();
            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        /// <summary>
        /// Adds a new currency
        /// </summary>
        /// <param name="currency">The currency to be added</param>
        /// <returns>HTTP response</returns>
        /// <response code="201">When everything is fine</response>
        /// <response code="400">When the data sent is invalid</response>
        // POST api/<CurrencyController>
        [HttpPost]
        [ProducesResponseType(typeof(Currency), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _currencies.Add(currency);
            return CreatedAtRoute(GetCurrency, new { id = currency.Id }, currency);
        }

        /// <summary>
        /// Updates a currency
        /// </summary>
        /// <param name="id">The id of the currency</param>
        /// <param name="currency">The new currency</param>
        /// <returns>HTTP response</returns>
        /// <response code="204">When everything is fine</response>
        /// <response code="400">When the data sent is incorrect</response>
        /// <response code="404">When the currency cannot be found</response>
        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != currency.Id)
            {
                return BadRequest();
            }
            var index = _currencies.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            _currencies[index] = currency;
            return NoContent();
        }

        /// <summary>
        /// Deletes a currency
        /// </summary>
        /// <param name="id">The id of the currency</param>
        /// <returns>HTTP response</returns>
        /// <response code="204">When everything is fine</response>
        /// <response code="404">When the currency cannot be found</response>
        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var currency = (
                from d in _currencies
                where d.Id == id
                select d).FirstOrDefault();
            if (currency == null)
            {
                return NotFound();
            }
            _currencies.Remove(currency);
            return NoContent();
        }
    }
}
