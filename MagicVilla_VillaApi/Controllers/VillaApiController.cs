using MagicVilla_VillaApi.Data;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaApi.Controllers;

[Route("api/VillaApi")]
[ApiController]
public class VillaApiController : ControllerBase
{
    [HttpGet]
    public IEnumerable<VillaDTO> GetVilla()
    {
        return VillaStore.villaList;
    }
    
    [HttpGet("{id:int} ",  Name ="GetVilla")]
    public VillaDTO GetVilla(int  id)
    {
        return VillaStore.villaList.FirstOrDefault(u => u.Id == id);
    }
    
    [HttpPost]
    public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO Villadto)
    {
        if (Villadto == null)
        {
            return BadRequest(Villadto);
        }

        if (Villadto.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        Villadto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            VillaStore.villaList.Add(Villadto);
            return  CreatedAtRoute( "GetVilla",new {id = Villadto.Id}, Villadto);
    }
    [HttpDelete]
    public ActionResult<VillaDTO> DeleteVilla(int id)
    {
        if (id == null)
        {
            return BadRequest();
        }

        var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);

        VillaStore.villaList.Remove(villa);
        return NoContent();
    }
    [HttpPut("{id:int}")]
    public ActionResult<VillaDTO> UpdateVilla(int id, [FromBody]VillaDTO Villadto)
    {
        if (Villadto == null)
        {
            return BadRequest(Villadto);
        }
        var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
        VillaStore.villaList.up(villa);
        return NoContent();
    }
}