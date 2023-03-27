using System;
using System.ComponentModel.DataAnnotations;
using Todo.Common.Enums;
using Todo.Data.Entities;

namespace Todo.Business.Models.Todo
{
	public class TodoModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int DayConstraint { get; set; }

        public string TodoStatus { get; set; }
    }
}

