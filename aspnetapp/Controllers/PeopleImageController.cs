using Microsoft.AspNetCore.Mvc;
using SWIAPI.Models;
using SWIAPI.Services;
using System.Collections.Generic;

namespace SWIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleImageController : ControllerBase
    {
        private readonly PeopleImageService _peopleImageService;

        public PeopleImageController(PeopleImageService peopleImageService)
        {
            _peopleImageService = peopleImageService;
        }

        [HttpGet]
        public ActionResult<List<PeopleImage>> Get() =>
            _peopleImageService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPeopleImage")]
        public ActionResult<PeopleImage> Get(string id)
        {
            var peopleImage = _peopleImageService.Get(id);

            if (peopleImage == null) 
                return NotFound();

            return peopleImage;
        }
    }
}