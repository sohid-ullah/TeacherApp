using System.ComponentModel.DataAnnotations;

namespace TeacherApp.Business.BusinessObjects
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }

    }
}
