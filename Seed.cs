using AnimalReviewApp.Data;
using AnimalReviewApp.Model;

namespace AnimalReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.AnimalOwners.Any())
            {
                var AnimalOwners = new List<AnimalOwner>()
                {
                    new AnimalOwner()
                    {
                        Animal = new Animal()
                        {
                            Name = "Pies",
                            BirthDate = new DateTime(1903,1,1),
                            AnimalCategories = new List<AnimalCategory>()
                            {
                                new AnimalCategory { Category = new Category() { Name = "Ssak"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pies",Text = "Super szybki psiak", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Jan", LastName = "Kowalski" } },
                                new Review { Title="Pies", Text = "Pies super szybko biega", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Krzysztof", LastName = "Nowak" } },
                                new Review { Title="Pies",Text = "Pies jest gorszy od kota", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Karolina", LastName = "Dec" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Jan",
                            LastName = "Palikot",
                            School = "Szkoła psinek",
                            Country = new Country()
                            {
                                Name = "Polska"
                            }
                        }
                    },
                    new AnimalOwner()
                    {
                        Animal = new Animal()
                        {
                            Name = "Rekin",
                            BirthDate = new DateTime(1903,1,1),
                            AnimalCategories = new List<AnimalCategory>()
                            {
                                new AnimalCategory { Category = new Category() { Name = "Ryba"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Rekin", Text = "Rekin ma super płetwe", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Kamil", LastName = "Stoch" } },
                                new Review { Title= "Rekin",Text = "Rekin oddycha pod wodą", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Andrzej", LastName = "Duda" } },
                                new Review { Title= "Rekin", Text = "Wodny skurczybyk, zjadł mi psa", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Anna", LastName = "Mucha" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Mateusz",
                            LastName = "Morawiecki",
                            School = "Szkoła rekinów",
                            Country = new Country()
                            {
                                Name = "Rosja"
                            }
                        }
                    },
                    new AnimalOwner()
                    {
                        Animal = new Animal()
                        {
                            Name = "Żółw",
                            BirthDate = new DateTime(1903,1,1),
                            AnimalCategories = new List<AnimalCategory>()
                            {
                                new AnimalCategory { Category = new Category() { Name = "Gad"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Żółw",Text = "Żółw ma turbo skorupe", Rating = 5,
                                Reviewer = new Reviewer(){ FirstName = "Janina", LastName = "Mostkowiak" } },
                                new Review { Title="Żółw",Text = "Zółw bezciała robi za freesbe", Rating = 4,
                                Reviewer = new Reviewer(){ FirstName = "Kuba", LastName = "Wojewódzki" } },
                                new Review { Title="Żółw",Text = "Za długo żyje", Rating = 1,
                                Reviewer = new Reviewer(){ FirstName = "Maryla", LastName = "Rodowicz" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            FirstName = "Karol",
                            LastName = "Nowicki",
                            School = "Szkoła żółwi",
                            Country = new Country()
                            {
                                Name = "Czechy"
                            }
                        }
                    }
                };
                dataContext.AnimalOwners.AddRange(AnimalOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
