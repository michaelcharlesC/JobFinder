using _1150GroupAPI.Data;
using _1150GroupAPI.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1150GroupAPI.Services
{
    public class CategoryService
    {
        private readonly Guid _userid;
        public CategoryService(Guid userid)
        {
            _userid = userid;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CategoryID = model.CategoryID,
                    CategoryName = model.CategoryName,
                    CompanyID = model.CompanyProfile.CompanyID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryID = e.CategoryID,
                            CategoryName = e.CategoryName,
                            CompanyID = e.CompanyProfile.CompanyID
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
