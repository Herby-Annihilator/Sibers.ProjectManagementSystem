using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultCrudController<TContext, TEntity, TDto> : ControllerBase
        where TContext : DbContext
        where TEntity : Entity
    {
        protected IUnitOfWork<TContext> unitOfWork;
        public virtual bool HasCustomRepository { get; set; } = false;
        public DefaultCrudController(IUnitOfWork<TContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            TEntity result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).GetByIdAsync(id);
            if (result == null)
                return NotFound(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).AddEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public virtual async Task<IActionResult> Update(TEntity entity)
        {
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).UpdateEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return AcceptedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult> Delete(TEntity entity)
        {
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).DeleteEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll() => Ok(await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).GetAllAsync());
    }
}
