using System.ComponentModel.DataAnnotations;

namespace AssessmentDemo.Foundation.Model
{
    public class Gift
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string Link { get; set; }

        public Person Recipient { get; set; }
    }
}