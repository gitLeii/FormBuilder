using System.ComponentModel.DataAnnotations;

namespace FormBuilder.Models
{
    public class FormData
    {
        public FormData()
        {
            FormElements = new List<FormElement>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<FormElement> FormElements { get; set; }
    }
    public class FormElement
    {
        public FormElement()
        {
            FormData = new FormData();
        }
        [Key]
        public int ElementId { get; set; }
        [Required]
        [Display(Name = "Label")]
        public string ElementLabel { get; set; } = string.Empty;
        [Display(Name = "Type")]
        public string ElementType { get; set; } = string.Empty;
        [Display(Name = "Value")]
        public string ElementValue { get; set; } = string.Empty;
        [Required]
        public int FormDataId { get; set; }
        public virtual FormData FormData { get; set; }
    }
}
