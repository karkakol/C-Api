using AnimalReviewApp.Dto;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Interface
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimals();
        Animal GetAnimal(int id);
        Animal GetAnimal(string name);

        Animal GetAnimalTrimToUpper(AnimalDto AnimalCreate);
        decimal GetAnimalRating(int id);
        bool AnimalExists(int id);
        bool CreateAnimal(int ownerId, int categoryId, Animal Animal);
        bool UpdateAnimal(Animal Animal);
        bool DeleteAnimal(Animal Animal);
        bool Save();
    }
}
