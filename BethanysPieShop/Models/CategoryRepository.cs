﻿using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public IEnumerable<Category> AllCategories()
        {
            return _appDbContext.Categories;
        }
    }
}