using Microsoft.AspNetCore.Mvc;
using SWIAPI.Models;
using SWIAPI.Services;
using System.Collections.Generic;

namespace SWIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmImageController : ControllerBase
    {
        private readonly FilmImageService _filmImageService;

        public FilmImageController(FilmImageService filmImageService)
        {
            _filmImageService = filmImageService;
        }

        [HttpGet]
        public ActionResult<List<FilmImage>> Get() =>
            _filmImageService.Get();

        [HttpGet("{id:length(24)}", Name = "GetFilmImage")]
        public ActionResult<FilmImage> Get(string id)
        {
            var filmImage = _filmImageService.Get(id);

            if (filmImage == null) 
                return NotFound();

            return filmImage;
        }
    }
}