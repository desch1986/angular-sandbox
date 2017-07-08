using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularSandbox.Models;
using AngularSandbox.Repositories;
using AngularSandbox.Repositories.Entities;

namespace AngularSandbox.Controllers
{
    [Route("api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly ICrudRepository<ToDoItem> _toDoItemRepository;
        
        private readonly IMapper _mapper;

        public ToDosController(IMapper mapper, ICrudRepository<ToDoItem> toDoItemRepository)
        {
            _mapper = mapper;
            _toDoItemRepository = toDoItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetToDos()
        {
            var result = await _toDoItemRepository
                                    .ReadAll()
                                    .Select(t => _mapper.Map<ToDoItemDto>(t))
                                    .ToListAsync();
            return Json(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDo(int id)
        {
            var result = await _toDoItemRepository
                            .ReadAll()
                            .FirstOrDefaultAsync(t => t.Id == id);
            
            return result != null 
                ? (IActionResult) Json(_mapper.Map<ToDoItemDto>(result)) 
                : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo([FromBody] ToDoItemDto model)
        {
            if (model != null)
            {
                await _toDoItemRepository.CreateAsync(_mapper.Map<ToDoItem>(model));
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo([FromBody] ToDoItem model)
        {
            if (model != null)
            {
                await _toDoItemRepository
                        .UpdateAsync(_mapper.Map<ToDoItem>(model));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var itemToRemove = await _toDoItemRepository
                                .ReadAll()
                                .FirstOrDefaultAsync(t => t.Id == id);
            
            if (itemToRemove == null)
            {
                return NotFound();
            }
            await _toDoItemRepository.DeleteAsync(itemToRemove);
            return Ok();
        }
    }
}
