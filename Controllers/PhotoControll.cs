using Microsoft.AspNetCore.Mvc;
using RentRazor.DbModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace RentRazor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoControll : ControllerBase
    {
        private readonly RentPropertyContext rentProperty;

        public PhotoControll(RentPropertyContext rend)
        {
            rentProperty = rend;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            PhotoOfPropert imageBD = await rentProperty.PhotoOfProperts.FindAsync(id);

            if (imageBD is null)
                return NotFound();

            return File(imageBD.Photo, "image/jpeg");
        }
    }
}
