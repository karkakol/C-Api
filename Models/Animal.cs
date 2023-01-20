namespace AnimalReviewApp.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<AnimalOwner> AnimalOwners { get; set; }

        public ICollection<AnimalCategory> AnimalCategories { get; set; }

    }
}
