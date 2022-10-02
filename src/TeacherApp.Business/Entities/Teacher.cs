using System.ComponentModel.DataAnnotations;
using TeacherApp.Data;

namespace TeacherApp.Business.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(25)]
        public string Tel { get; set; }
    }
}
