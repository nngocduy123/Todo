using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Business.Models.Todo
{
	public class TodoInputModel 
	{
        public TodoInputModel() {
            Title = string.Empty;
            Description = string.Empty;
        }

        public string Title { get; set; }
        public string Description { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required]
        public int DayConstraint { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (DueDate < DateTime.Now)
        //    {
        //        yield return new ValidationResult(
        //            "Due Date should not in the past");
        //    }
        //}
    }
}

