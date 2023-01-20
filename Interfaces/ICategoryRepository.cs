using AnimalReviewApp.Model;

namespace AnimalReviewApp.Interfaces
{
    public interface ICategoryRepository
    {

        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Animal> GetAnimalByCategory(int categoryId);

        bool CategoryExists(int id);

        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);

        bool Save();
    }
}
