using System.Collections.Generic;

namespace AMCAssignment1.Models
{
    public class IndexCoursesViewModel
    {
        public IndexCoursesViewModel()
        {
            EnrolledUsers = new List<UserInfoViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public int Enrollments
        {
            get
            {
                return EnrolledUsers.Count;
            }
        }

        public List<UserInfoViewModel> EnrolledUsers { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Name { get; set; }
    }
}