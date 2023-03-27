using System;
using Todo.Common.Enums;

namespace Todo.Data.Entities
{
	public class TodoItem : BaseEntity
	{
		public string Title { get; set; }

		public string? Description { get; set; }

		public DateTime DueDate { get; set; }

		public int DayConstraint { get; set; }

		public TodoStatusEnums TodoStatus { get; set; }

		public DateTime OfferedDay {
			get {
				return this.DueDate.AddDays(DayConstraint);
			}
		}
    }
}

