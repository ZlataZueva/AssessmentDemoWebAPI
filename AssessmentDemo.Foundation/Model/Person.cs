using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace AssessmentDemo.Foundation.Model
{
    public class Person
    {
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public ICollection Gifts { get; set; }

        public Group Group { get; set; }
    }
}