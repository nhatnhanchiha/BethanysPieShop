using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;

        public MockCategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category {CategoryId = 1, CategoryName = "Fruit pies", Description = "All-fruity pies"},
                new Category {CategoryId = 2, CategoryName = "Cheese cakes", Description = "Cheesy all the way"},
                new Category
                    {CategoryId = 3, CategoryName = "Seasonal pies", Description = "Get in the mood for a seasonal pie"}
            };
        }

        public IEnumerable<Category> AllCategories()
        {
            return _categories;
        }
    }
}