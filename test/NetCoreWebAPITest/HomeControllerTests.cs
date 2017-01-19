using System;
using WebApplication.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using WebApplication;
using Moq;
namespace WebApplication.Tests
{

    public class HomeControllerTests
    {
        [Fact]
        public void AboutTitleTest() 
        {
            // Using Moq Framework to setup the IOptions to be passed into the HomeController Constructor
            AppSettings app = new AppSettings(){Title="New Website Title Mocked"};
            var mock = new Mock<IOptions<AppSettings>>();
            // We need to set the Value of IOptions to be the AppSettings Class
            mock.Setup(ap => ap.Value).Returns(app);
            HomeController hc = new HomeController(mock.Object);   
            var ar = hc.About() as ViewResult;

            Assert.NotNull(ar);
            var mess = ar.ViewData["Message"];   
            Console.WriteLine(mess);  
            Assert.NotNull(mess);
        }

        [Fact]
        public void JsonResultAPITest() 
        {
            // Using Microsoft.Extensions.Options to create the IOptions to be passed into the HomeController Constructor
            var someOptions = Options.Create(new AppSettings(){Title="New Website"});
            HomeController hc = new HomeController(someOptions);   
            JsonResult ar = hc.JSonResultAPI() as JsonResult;

            Assert.NotNull(ar);
            var mess = ar.Value;  
             
            dynamic stuff = JsonConvert.DeserializeObject(ar.Value.ToString());

            string name = stuff.name;
            Assert.NotNull(name);
        }
    } 
}
