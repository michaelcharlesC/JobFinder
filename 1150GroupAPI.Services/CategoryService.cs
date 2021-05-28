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

                    CategoryName = model.CategoryName,
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
                        }
                        );
                return query.ToArray();
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Find(id);
                if (entity == null)
                    return false;

                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateCategory(CategoryCreate model, int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Categories.Find(id);
                if (entity == null)
                    return false;

                entity.CategoryName = model.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public CategoryListItem GetCategoryByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Find(id);
                if (query == null)
                    return null;

                return new CategoryListItem()
                {
                    CategoryID = query.CategoryID,
                    CategoryName = query.CategoryName
                };


            }
        }
    }
}
