using AnimalReviewApp.Model;

namespace AnimalReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnersOfAAnimal(int AnimalId);

        ICollection<Animal> GetAnimalsByOwner(int ownerId);
        bool OwnerExists(int ownerId);

        bool CreateOwner(Owner owner);

        bool UpdateOwner(Owner owner);
        bool DeleteOwner(Owner owner);

        bool Save();
    }
}
