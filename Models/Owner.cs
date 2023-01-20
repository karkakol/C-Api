namespace AnimalReviewApp.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string School { get; set; }
        public Country Country { get; set; }
        public ICollection<AnimalOwner> AnimalOwners { get; set; }

    }
}
