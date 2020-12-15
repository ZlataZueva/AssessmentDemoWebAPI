using System.Collections.Generic;

namespace AssessmentDemo.Foundation.Model
{
    public class Group
    {
        public string Name { get; set; }

        public ICollection<Person> Members { get; set; }
    }
}