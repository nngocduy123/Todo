using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Todo.API.Controllers;
using Todo.Business.Constracts;
using Todo.Business.Models.Todo;

namespace Todo.Test.Controller
{
    public class TodoControllerTest
    {
        private readonly ITodoService _todoService = Substitute.For<ITodoService>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();

        [Fact]
        public async Task GetTodos_ReturnOk()
        {
            var todos = new List<TodoModel>()
            {
                new TodoModel { Title = "TEST01", DayConstraint = 1 },
                new TodoModel { Title = "TEST02", DayConstraint = 2 }
            };

            _todoService.Get().Returns(todos);

            var controller = new TodoController(_mapper, _todoService);

            var result = await controller.Get() as OkObjectResult;
            var resultModel = result.Value as IEnumerable<TodoModel>;

            Assert.Equal("TEST01", resultModel?.ElementAt(0).Title);
            Assert.Equal("TEST02", resultModel?.ElementAt(1).Title);
        }
    }
}


