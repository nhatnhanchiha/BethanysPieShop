using System.Collections.Generic;

namespace BethanysPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category
                {
                    CategoryId = 1, CategoryName = "Fruit pies", Description = "All fruit"
                }
            };
    }
}