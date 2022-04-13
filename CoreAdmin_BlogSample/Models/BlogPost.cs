using Markdig;
using System.ComponentModel.DataAnnotations;

namespace CoreAdmin_BlogSample.Models
{
    public class BlogPost : Model, IValidatableObject
    {
        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Title { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Required]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Slug { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public bool Public { get; set; }

        [Display(AutoGenerateField = false)]
        [DataType("Markdown")]
        public string? Content { get; set; }

        [Display(AutoGenerateField = false)]
        [ScaffoldColumn(false)]
        public string? RawHTML { get; set; }

        public byte[]? CoverImage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Generate the raw html
            RawHTML = Markdown.ToHtml(Content);
            yield return ValidationResult.Success;
        }
    }
}
