using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Parks.Models;

namespace Parks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [ApiVersion("1.0")]
  public class ParksController : ControllerBase
  {
    private readonly ParksContext _db;

    public ParksController(ParksContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Queries instance(s) of park(s) using a GET request.  The query can be filtered to type, name and year established.
    /// </summary>
    /// <remarks>Click 'Try it out' then to get all instances of parks leave the parameter feilds empty and click 'Execute'.  To get a specific instance fill out any or all of the parameter feilds  and click 'Execute'.</remarks>
    /// <param name="parkType" example="National">Type of Park (National or State)</param>
    /// <param name="parkName" example="Yosemite">Name of Park</param>
    /// <param name="established" example="1872">Year Established</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Park>>> Get(string parkType, string parkName, int established)
    {
      var query = _db.Parks.AsQueryable();

      if (parkType == "National" || parkType == "national" || parkType == "State" || parkType == "state")
      {
        query = query.Where(entry => entry.ParkType == parkType);
      }

      if (parkName != null)
      {
        query = query.Where(entry => entry.ParkName == parkName);
      }
      if (established != 0)
      {
        query = query.Where(entry => entry.Established == established);
      }

      return await query.ToListAsync();
    }

    /// <summary>
    /// Adds a new instance of a park using a POST request.
    /// </summary>
    /// <remarks>Click 'Try it out' then fill out the request body below to add a new instance of Park to the API and click 'Execute'.</remarks>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }
    /// <summary>
    /// Updates an instance of a park using a PUT request.
    /// </summary>
    /// <remarks>Click 'Try it out' then insert the object Id in the paramentor field and use the "Request body" section to update the object and click 'Execute'.</remarks>
    /// <param name="id" example="42">Id object to be updated</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    /// <summary>
    /// Deletes an instance of a park using a DELETE request.
    /// </summary>
    /// <remarks>Click 'Try it out' then insert the object Id in the paramentor section to delete the object and click 'Execute'.</remarks>
    /// <param name="id" example="42">Id object to be deleted</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}
