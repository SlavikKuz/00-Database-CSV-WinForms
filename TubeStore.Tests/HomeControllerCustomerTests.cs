using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;
using System.Threading.Tasks;

namespace TubeStore.Tests
{
    public class HomeControllerCustomerTests
    {
        private readonly Mock<IGenericRepository<Tube>> mockTubeRepo;
        private readonly HomeController sut;

        public HomeControllerCustomerTests()
        {
            mockTubeRepo = new Mock<IGenericRepository<Tube>>();
            sut = new HomeController(mockTubeRepo.Object);
        }

        [Fact]
        public void ReturnViewForIndex()
        {
            IActionResult result = sut.Index();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void SearchReturnCorrectModel()
        {
            var mockForm = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            { { "search", "6N1P" } });
           
            IActionResult result = sut.Search(mockForm);
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(viewResult.Model.GetType() == typeof(PaginatedList<Tube>));
            Assert.Equal("SearchList", viewResult.ViewName);
        }

        [Fact]
        public async Task IndexCategoryReturnCategory()
        {
            sut.ModelState.AddModelError("", "Sample Error");
            string category = "Pre Triodes";
            int categoryId = 1;

            IActionResult result = await sut.IndexCategory(category, null, null);
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<PaginatedList<Tube>>(viewResult.Model);
            Assert.Contains(category, model.FindLast(x=>x.CategoryId.Equals(categoryId)).ToString());
        }
    }
}
