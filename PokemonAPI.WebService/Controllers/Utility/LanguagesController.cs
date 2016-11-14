using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Core;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;

namespace PokemonAPI.WebService.Controllers
{
    [Route("api/v1/languages")]
    public class LanguagesController : ApiController
    {
        private readonly ILanguagesCacheService _languagesCacheService;

        public LanguagesController(ILanguagesCacheService languagesCacheService)
        {
            _languagesCacheService = languagesCacheService;
        }

        // GET api/v1/languages
        // GET api/v1/languages?skip=0&take=20
        [HttpGet]
        public async Task<IActionResult> GetAll(int limit = 20, int offset = 0)
        {
            var count          = await _languagesCacheService.Count();
            var controllerType = typeof(LanguagesController);
            var previous       = controllerType.Previous(limit, offset);
            var next           = controllerType.Next(limit, offset, count);

            var languages = await _languagesCacheService.GetAll(limit, offset);
            if (languages == null)
                return NotFound($"Not found with {limit} {offset}");

            return Ok(new NamedAPIResourceList(count, previous, next, languages));
        }

        // GET api/v1/languages/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var language = await _languagesCacheService.Get(id);
            if (language == null)
                return NotFound(id);

            return Ok(language);
        }

        // GET api/v1/languages/roomaji
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var language = await _languagesCacheService.Get(name);
            if (language == null)
                return NotFound(name);

            return Ok(language);
        }
    }
}