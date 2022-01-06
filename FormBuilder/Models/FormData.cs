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
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<FormElement> FormElements { get; set; }
    }
    public class FormElement
    {
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
        public FormData? FormData { get; set; }
    }
    public class FormValidation
    {
        public FormValidation()
        {
            FormElements = new List<FormElement>();
        }
        [Key]
        public int FormValidationId { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string ValidationMessage { get; set; } = string.Empty;
        public int ElementId { set; get; }
        public virtual ICollection<FormElement> FormElements { get; set; }
    }

}
