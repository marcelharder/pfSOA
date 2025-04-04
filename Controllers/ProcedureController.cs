using data.dtos;
using data.entities;
using interfaces;
using Microsoft.AspNetCore.Mvc;

namespace pfSOA.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedureController : ControllerBase
{
    private readonly IPhoto _p;
    public ProcedureController(IPhoto p)
    {
        _p = p;
    }
    [HttpGet("photosAvailable/{id}")]
    public async Task<IActionResult> ArePhotosAvailable(int id)
    {
       return Ok(await _p.PhotosAvailable(id));
    }

    [HttpGet("getPhotos/{id}")]
    public async Task<IActionResult> GetPhotos(int id)
    {
        return Ok(await _p.GetPhotos(id));
    }

    [HttpDelete("deletePhoto/{id}")]
    public async Task<IActionResult> DeletePhoto(int id)
    {
        return Ok(await _p.DeletePhoto(id));
    }

    [HttpPost("addPhoto")]
    public async Task<IActionResult> AddPhotos(PhotoDto ph)
    {
        var new_photo = new Class_Photo
        {
            DateAdded = ph.DateAdded,
            ProcedureId = ph.ProcedureId,
            PublicId = ph.PublicId,
            Url = ph.Url,
            Description = ph.Description
        };

        return Ok(await _p.AddPhoto(new_photo));
    }
}
