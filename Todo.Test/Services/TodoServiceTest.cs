using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockQueryable.NSubstitute;
using NSubstitute;
using Todo.API.Controllers;
using Todo.Business.Constracts;
using Todo.Business.Models.Todo;
using Todo.Business.Services;
using Todo.Data.Constract;
using Todo.Data.Entities;

namespace Todo.Test.Services
{
	public class TodoServiceTest
	{
        private readonly ITodoService _todoService = Substitute.For<ITodoService>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        [Fact]
        public async Task GetTodos_ReturnOk()
        {
            var todos = new List<TodoItem>()
            {
                new TodoItem { Id = 1, Title = "TEST01", DayConstraint = 1, DueDate = DateTime.Now, Description = "TEST01", TodoStatus= Common.Enums.TodoStatusEnums.OnTrack },
                new TodoItem { Id = 2, Title = "TEST02", DayConstraint = 2, DueDate = DateTime.Now, Description = "TEST02", TodoStatus = Common.Enums.TodoStatusEnums.OnTrack }
            }.AsQueryable();

            var mock = todos.BuildMock();

            var mockRepository = Substitute.For<IRepository<TodoItem>>();          
            mockRepository.Query().Returns(mock);
            var myService = new TodoService(mockRepository);

            var result = await myService.Get();

            Assert.Equal("TEST01", result?.ElementAt(0).Title);
            Assert.Equal("TEST02", result?.ElementAt(1).Title);
        }
    }
}

