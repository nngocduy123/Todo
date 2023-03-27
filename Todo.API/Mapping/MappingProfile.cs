using System;
using AutoMapper;
using Microsoft.Extensions.Hosting;
using Todo.Business.Models.Todo;
using Todo.Common.Enums;
using Todo.Data.Entities;

namespace Todo.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoInputModel, TodoItem>().ForMember(t => t.TodoStatus, conf => conf.MapFrom(s => (CalculateTodoStatus(s))));
            CreateMap<TodoItem, TodoModel>().ForMember(t => t.TodoStatus, conf => conf.MapFrom(s => s.TodoStatus.ToDescription()));          
        }

        private static object CalculateTodoStatus(TodoInputModel arg)
        {
            var offeredDay = arg.DueDate.AddDays(arg.DayConstraint);

            if (offeredDay < DateTime.Now)
            {
                return (int)TodoStatusEnums.Expired;
            }
            else if (arg.DueDate < DateTime.Now) {
                return (int)TodoStatusEnums.OffTrack;
            }

            return (int)TodoStatusEnums.OnTrack;
        }
    }
}

