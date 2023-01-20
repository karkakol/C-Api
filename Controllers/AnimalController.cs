using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AnimalReviewApp.Dto;
using AnimalReviewApp.Interface;
using AnimalReviewApp.Interfaces;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalRepository AnimalRepository,
             IReviewRepository reviewRepository,
             ICategoryRepository categoryRepository,
             IMapper mapper)
        {
            _animalRepository = AnimalRepository;
            _reviewRepository = reviewRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Animal>))]
        public IActionResult GetAnimals()
        {
            var Animals = _mapper.Map<List<AnimalDto>>(_animalRepository.GetAnimals());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(Animals);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Animal))]
        [ProducesResponseType(400)] 
        public IActionResult GetAnimal(int id)
        {
            if(!_animalRepository.AnimalExists(id))
                return NotFound();

            var Animal = _mapper.Map<AnimalDto>(_animalRepository.GetAnimal(id));    

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Animal);
        }

        [HttpGet("{id}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimalRating(int id)
        {
            if (!_animalRepository.AnimalExists(id))
                return NotFound();

            var rating = _animalRepository.GetAnimalRating(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnimal([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] AnimalDto AnimalCreate)
        {
            if (AnimalCreate == null)
                return BadRequest(ModelState);

            var Animals = _animalRepository.GetAnimalTrimToUpper(AnimalCreate);

            if (Animals != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var AnimalMap = _mapper.Map<Animal>(AnimalCreate);


            if (!_animalRepository.CreateAnimal(ownerId, catId, AnimalMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{animalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAnimal(int animalId,
            [FromQuery] int ownerId, [FromQuery] int catId,
            [FromBody] AnimalDto updatedAnimal)
        {
            if (updatedAnimal == null)
                return BadRequest(ModelState);

            if (animalId != updatedAnimal.Id)
                return BadRequest(ModelState);

            if (!_animalRepository.AnimalExists(animalId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var AnimalMap = _mapper.Map<Animal>(updatedAnimal);

            if (!_animalRepository.UpdateAnimal( AnimalMap))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{animalId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAnimal(int animalId)
        {
            if (!_animalRepository.AnimalExists(animalId))
            {
                return NotFound();
            }

            var reviewsToDelete = _reviewRepository.GetReviewsOfAAnimal(animalId);
            var AnimalToDelete = _animalRepository.GetAnimal(animalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteReviews(reviewsToDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong when deleting reviews");
            }

            if (!_animalRepository.DeleteAnimal(AnimalToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting owner");
            }

            return NoContent();
        }
    }
}
