using AnimalReviewApp.Data;
using AnimalReviewApp.Interfaces;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return Save();
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(e => e.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Owner> GetOwnersOfAAnimal(int AnimalId)
        {
            return _context.AnimalOwners.Where(e => e.AnimalId == AnimalId).Select(e => e.Owner).ToList();
        }

        public ICollection<Animal> GetAnimalsByOwner(int ownerId)
        {
            return _context.AnimalOwners.Where(e => e.OwnerId == ownerId).Select(e => e.Animal).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(e => e.Id == ownerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateOwner(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }
    }
}
