using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListAPI.Core;
using TodoListAPI.Model;

namespace TodoListAPI.Controllers;
[ApiController]
[Route("[controller]")]



public class TodoController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public TodoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Todos.GetAllAsync());
    }


    [HttpGet("GetSingleTodos")]
    public async Task<IActionResult> Get(int id)
    {
        var todo = await _unitOfWork.Todos.GetById(id);
        if (todo == null) return NotFound();
        return Ok(todo);
    }

    [HttpPost]
    [Route("AddTodo")]
    public async Task<IActionResult> Post(Todo todo)
    {
        await _unitOfWork.Todos.Add(todo);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }
    [HttpDelete]
    [Route("DeleteATodo")]
    public async Task<IActionResult> Delete(int id)
    {
        var todo = await _unitOfWork.Todos.GetById(id);
        if (todo == null) return NotFound();
        await _unitOfWork.Todos.Delete(todo);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
    [HttpPatch]
    [Route("UpdateATask")]
    public async Task<IActionResult> Patch(Todo todo)
    {
        var existingTodo = await _unitOfWork.Todos.GetById(todo.Id);
        if (existingTodo == null) return NotFound();
        await _unitOfWork.Todos.Update(todo);
        await _unitOfWork.CompleteAsync();
        return NoContent();
    }
}
