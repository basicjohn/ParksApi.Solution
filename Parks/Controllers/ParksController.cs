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
    /// Method that returns instances of Parks.  It can be limited to Park types, Park Names and the year the park was established.
    /// </summary>
    /// <remarks>Get instance(s) of a park but doing a basic get request or inserting either 'National' or State'</remarks>
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


    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }
    // PUT: api/Parks/5
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
    // DELETE: api/Parks/5
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
