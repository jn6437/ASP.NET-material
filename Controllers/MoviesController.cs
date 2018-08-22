using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        //public ActionResult Random()
        //ViewResult is more specific and is a good practice
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shart" };

            //where does movie object go in the view result?
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model === movie;

            return View(movie); 
            //return new ViewResult();

            //RETURNS PLAIN WITH HELLO WORLD
            //return Content("hello world");

            //RETURNS EMPTY PAGE
            //return new EmptyResult();

            //RETURNS 404 NOT FOUND
            //return HttpNotFound();

            //REDIRECTS TO URL LOCALHOST/?page=1&sortBy=name  (PAGE, CONTROLLER, ARGUMENT)
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        //localhost/movies/Edit/1, id = 1
        //parameter is id as defined in App_Start -> RouteConfig.cs
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //localhost/movies
        // int? for nullable integer
        public ActionResult Index( int? pageIndex, string sortBy)
        {
            //default parameter handling
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0} sortBy={1}", pageIndex, sortBy));

        }

        //localhost/movies/released/2012/12, id = 1
        //parameter is id as defined in App_Start -> RouteConfig.cs
        //ASP.NET MVC Attributes Route Constraints

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("year = {0} month = {1}", year,month));
        }
    }
}