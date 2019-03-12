namespace AMCAssignment1.Migrations
{
    using AMCAssignment1.Models;
    using AMCAssignment1.Models.Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AMCAssignment1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AMCAssignment1.Models.ApplicationDbContext context)
        {
            var userManager =
               new UserManager<ApplicationUser>(
                       new UserStore<ApplicationUser>(context));

            ApplicationUser johnDoe;
            ApplicationUser janeDoe;
            Course softwareDeveloperCourse;
            Course cyberDefenseCourse;

            if (!context.Users.Any(p => p.UserName ==
            "johndoe@test.com"))
            {
                johnDoe = new ApplicationUser();
                johnDoe.FirstName = "John";
                johnDoe.LastName = "Doe";
                johnDoe.Email = "johndoe@test.com";
                johnDoe.UserName = "johndoe@test.com";

                userManager.Create(johnDoe, "Password-1");
            }
            else
            {
                johnDoe = context.Users.First(p =>
                p.UserName == "johndoe@test.com");
            }

            if (!context.Users.Any(p => p.UserName ==
            "janedoe@test.com"))
            {
                janeDoe = new ApplicationUser();
                janeDoe.FirstName = "Jane";
                janeDoe.LastName = "Doe";
                janeDoe.Email = "janedoe@test.com";
                janeDoe.UserName = "janedoe@test.com";

                userManager.Create(janeDoe, "Password-1");
            }
            else
            {
                janeDoe = context.Users.First(p =>
                p.UserName == "janedoe@test.com");
            }

            if (!context.Courses.Any(p =>
                p.Name == "Software Developer"))
            {
                softwareDeveloperCourse = new Course();
                softwareDeveloperCourse.Name = "Software Developer";
                softwareDeveloperCourse.NumberOfHours = 330;
                context.Courses.Add(softwareDeveloperCourse);
            }
            else
            {
                softwareDeveloperCourse = context.Courses.First(p => 
                p.Name == "Software Developer");
            }

            if (!context.Courses.Any(p =>
                p.Name == "Cyber Defense"))
            {
                cyberDefenseCourse = new Course();
                cyberDefenseCourse.Name = "Cyber Defense";
                cyberDefenseCourse.NumberOfHours = 340;
                context.Courses.Add(cyberDefenseCourse);
            }
            else
            {
                cyberDefenseCourse = context.Courses
                    .First(p => p.Name == "Cyber Defense");
            }

            context.SaveChanges();

            if (!johnDoe.Courses.Any())
            {
                johnDoe.Courses.Add(cyberDefenseCourse);
            }

            if (!janeDoe.Courses.Any())
            {
                janeDoe.Courses.Add(softwareDeveloperCourse);
                janeDoe.Courses.Add(cyberDefenseCourse);
            }

            context.SaveChanges();
        }
    }
}
