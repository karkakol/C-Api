using AutoMapper;
using AnimalReviewApp.Data;
using AnimalReviewApp.Interfaces;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id== id);
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(e => e.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(e => e.Id == ownerId).Select(e => e.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(e => e.Country.Id == countryId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCountry(Country country)
        {
            _context.Update(country);
            return Save();
        }

        public bool DeleteCountry(Country country)
        {
            _context.Remove(country);
            return Save();
        }
    }
}
