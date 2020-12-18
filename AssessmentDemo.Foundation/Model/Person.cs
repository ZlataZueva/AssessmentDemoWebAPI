using System.Collections;

namespace AssessmentDemo.Foundation.Model
{
    public class Person
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public ICollection Gifts { get; set; }

        public Group Group { get; set; }
    }
}