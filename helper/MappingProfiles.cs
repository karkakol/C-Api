using AutoMapper;
using AnimalReviewApp.Dto;
using AnimalReviewApp.Model;

namespace AnimalReviewApp.helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CountryDto, Country>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<AnimalDto, Animal>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
        }
    }
}
