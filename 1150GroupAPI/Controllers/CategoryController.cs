using _1150GroupAPI.Models.CategoryModels;
using _1150GroupAPI.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1150GroupAPI.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var categoryService = new CategoryService(userId);
            return categoryService;
        }
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult GetByID(int Id)
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategoryByID(Id);
            return Ok(categories);
        }

        public IHttpActionResult Delete(int Id)
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.DeleteCategory(Id);
            return Ok("Category was deleted");
        }

        public IHttpActionResult Put(CategoryCreate model, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            var categories = service.UpdateCategory(model, Id);

            return Ok();
        }
    }
}
