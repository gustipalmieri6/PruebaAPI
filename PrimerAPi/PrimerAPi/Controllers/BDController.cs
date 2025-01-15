using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimerAPi.Models;
using PrimerAPi.Repositories;
namespace PrimerAPi.Controllers
{
    [Route("api/persona")]
    [ApiController]
    public class BDController : ControllerBase
    {


        private IPersonaCollection db = new PersonaCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllPersonas()
        {
            return Ok(await db.GetAllPersonas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonaDetails(string id)
        {
            return Ok(await db.GetPersonaById(id));
        }


        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] persona persona)
        {
            if (persona == null)
                return BadRequest();

            if (persona.nombre == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            await db.InsertPersona(persona);

            return Created("Created", true);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersona([FromBody] persona persona, string id)
        {
            if (persona == null)
                return BadRequest();

            if (persona.nombre == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            persona.Id= new MongoDB.Bson.ObjectId(id);

            await db.UpdatePersona(persona);

            return Created("Created", true);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(string id)
        {
            await db.DeletePersona(id);
            return NoContent(); // success
        }



    }
}
