using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Business.Constracts;
using Todo.Business.Models.Todo;
using Todo.Data.Entities;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private ITodoService _todoService { get; set; }
        private readonly IMapper _mapper;

        public TodoController(IMapper mapper, ITodoService todoService) {
            _todoService = todoService;
            _mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _todoService.Get());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }           
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                var todo = await _todoService.GetById(id);

                if (todo == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<TodoModel>(todo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(TodoInputModel todoInputModel)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }            

            try {
                var newTodo = await _todoService.Create(_mapper.Map<TodoItem>(todoInputModel));

                return Ok(_mapper.Map<TodoModel>(newTodo));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TodoInputModel todoInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var todo = await _todoService.GetById(id);
                if (todo != null)
                {
                    _mapper.Map<TodoInputModel, TodoItem>(todoInputModel, todo);
                    await _todoService.Update(todo);
                    return Ok("Updated Successfully");
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }          
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var todo = await _todoService.GetById(id);

                if (todo != null) {
                    await _todoService.Delete(id);
                    return Ok();
                }

                return NotFound();               
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }          
        }
    }
}

