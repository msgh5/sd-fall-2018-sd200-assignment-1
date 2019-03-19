using AMCAssignment1.Models;
using AMCAssignment1.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMCAssignment1.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext DbContext { get; set; }

        public CoursesController()
        {
            DbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var courses = DbContext
                .Courses
                .ToList();

            var courseList = new List<IndexCoursesViewModel>();

            foreach(var course in courses)
            {
                var model = new IndexCoursesViewModel();
                model.Id = course.Id;
                model.Name = course.Name;
                model.Hours = course.NumberOfHours;

                foreach (var user in course.Users)
                {
                    model.EnrolledUsers.Add(new UserInfoViewModel
                    {
                        Name = user.FullName
                    });
                }

                courseList.Add(model);
            }

            return View(courseList);
        }

        public ActionResult Detail(int id)
        {
            var course = DbContext
                .Courses
                .FirstOrDefault(p => p.Id == id);

            var model = new IndexCoursesViewModel();
            model.Id = course.Id;
            model.Name = course.Name;
            model.Hours = course.NumberOfHours;
            
            foreach(var user in course.Users)
            {
                model.EnrolledUsers.Add(new UserInfoViewModel
                {
                    Name = user.FullName
                });
            }

            return View(model);
        }
    }
}