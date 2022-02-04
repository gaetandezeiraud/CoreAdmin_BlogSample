using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAdmin_BlogSample.Models
{
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Will hold the original creation date of the field, 
        // The default value is set to DateTime.Now
        public DateTime Created { get; set; } = DateTime.Now;

        // Will hold the last updated date of the field
        // The default value is set to DateTime.Now
        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
