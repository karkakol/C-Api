using AnimalReviewApp.Data;
using AnimalReviewApp.Dto;
using AnimalReviewApp.Interface;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Repository
{
    public class AnimalRepository: IAnimalRepository
    {
        private readonly DataContext _context;

        public AnimalRepository(DataContext context) {
            _context = context;
        }

        public Animal GetAnimal(int id)
        {
            return _context.Animal.Where(e => e.Id == id).FirstOrDefault();
        }

        public Animal GetAnimal(string name)
        {
            return _context.Animal.Where(e => e.Name == name).FirstOrDefault();
        }

        public decimal GetAnimalRating(int animalId)
        {
            var review = _context.Reviews.Where(p => p.Animal.Id == animalId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Animal> GetAnimals()
        {
            return _context.Animal.OrderBy(p => p.Id).ToList();
        }

        public bool AnimalExists(int id)
        {
            return _context.Animal.Any(e=> e.Id == id);    
        }

        public bool UpdateAnimal(Animal Animal)
        {
            _context.Update(Animal);
            return Save();
        }

        public Animal GetAnimalTrimToUpper(AnimalDto AnimalCreate)
        {
            return GetAnimals().Where(c => c.Name.Trim().ToUpper() == AnimalCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CreateAnimal(int ownerId, int categoryId, Animal Animal)
        {
            var AnimalOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var AnimalOwner = new AnimalOwner()
            {
                Owner = AnimalOwnerEntity,
                Animal = Animal,
            };

            _context.Add(AnimalOwner);

            var AnimalCategory = new AnimalCategory()
            {
                Category = category,
                Animal = Animal,
            };

            _context.Add(AnimalCategory);

            _context.Add(Animal);

            return Save();
        }

        public bool DeleteAnimal(Animal Animal)
        {
            _context.Remove(Animal);
            return Save();
        }
    }
}
