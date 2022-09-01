using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultCrudController<TContext, TEntity, TDto> : ControllerBase
        where TContext : DbContext
        where TEntity : Entity
        where TDto : class
    {
        protected IUnitOfWork<TContext> unitOfWork;
        protected IMapper<TEntity, TDto> mapper;
        public virtual bool HasCustomRepository { get; set; } = false;
        public DefaultCrudController(IUnitOfWork<TContext> unitOfWork, IMapper<TEntity, TDto> mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("get/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            TEntity result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).GetByIdAsync(id);
            if (result == null)
                return NotFound(id);
            TDto resultDto = mapper.MapBack(result);
            return Ok(resultDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<IActionResult> Create(TDto dto)
        {
            TEntity entity = mapper.Map(dto);
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).AddEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public virtual async Task<IActionResult> Update(TDto dto)
        {
            TEntity entity = mapper.Map(dto);
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).UpdateEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return AcceptedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult> Delete(TDto dto)
        {
            TEntity entity = mapper.Map(dto);
            var result = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).DeleteEntityAsync(entity);
            if (result == null)
                return NotFound(entity);
            else
                return Ok(mapper.MapBack(result));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll()
        {
            var collection = await unitOfWork.GetRequiredRepository<TEntity>(HasCustomRepository).GetAllAsync();
            if (collection != null)
            {
                List<TDto> dtos = new List<TDto>();
                foreach (var item in collection)
                {
                    dtos.Add(mapper.MapBack(item));
                }
                return Ok(dtos);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
