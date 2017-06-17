using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AnonymousQuestions.Api.Controllers
{
    [Route("api/Test")]
    public class TestController : Controller
    {

        // GET api/test
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "test1", "test2" };
        }
    }
}