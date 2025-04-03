using Application.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnTheWayWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericApiController<T> : ControllerBase where T : class
    {
        private readonly IServices<T> _service;

        public GenericApiController(IServices<T> service)
        {
            _service = service;
        }

        //[HttpGet]
        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    return await _service.GetAllAsync();
        //}
        [HttpGet]
        public virtual async Task<IEnumerable<T>> GetAll([FromQuery] string[] includes)
        {
            if (includes == null || includes.Length == 0)
            {
                return await _service.GetAllAsync();
            }

            return await _service.GetAllWithIncludesAsync(includes);
        }
        //[HttpGet]
        //public async Task<IEnumerable<T>> GetAllActiveAsync()
        //{
        //    return await _service.GetAllActiveAsync();
        //}

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetById(int id, [FromQuery] string[] includes)
        {
            if (includes == null || includes.Length == 0)
            {
                var entity = await _service.GetByIdAsync(id);
            }
            //if (entity == null)
            //{
            //    return NotFound();
            //}
            return await _service.GetByIdWithIncludesAsync(id,includes); ;
        }
        //[HttpGet("{id}")]
        //public virtual async Task<ActionResult<T>> GetByIdWithIncludesAsync(int id, [FromQuery] string[] includes)
        //{
        //    if (includes == null || includes.Length == 0)
        //    {
        //        var entity = await _service.GetByIdAsync(id);
        //        if (entity == null)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return await _service.GetByIdWithIncludesAsync(id,includes); ;
        //}
        //[HttpGet("Create")]
        //public IActionResult Create()
        //{
        //    return Ok(); // Placeholder, return appropriate response
        //}

        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] T entity)
        {
            
            await _service.CreateAsync(entity);
            return Ok();
            //////return CreatedAtAction(nameof(GetById), new { id = (entity as dynamic).Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] T entity)
        {
             
            var entityType = typeof(T);
            var idProperty = entityType.GetProperty("Id");

            if (idProperty == null)
            {
                return BadRequest("Entity type does not contain an 'Id' property.");
            }

            var entityId = (int)idProperty.GetValue(entity);
            if (entityId != id)
            {
                return BadRequest();
            }
            await _service.UpdateAsync(id, entity);
            return NoContent();
        }


        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete( [FromBody] T entity ,int id)
        //{
        //    var entityType = typeof(T);
        //    var idProperty = entityType.GetProperty("Id");

        //    if (idProperty == null)
        //    {
        //        return BadRequest("Entity type does not contain an 'Id' property.");
        //    }

        //    var entityId = (int)idProperty.GetValue(entity);
        //    if (entityId != id)
        //    {
        //        return BadRequest();
        //    }
        //    await _service.DeleteAsync(id, entity);
        //    return NoContent();

        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var entity = await _service.GetByIdAsync(id);
        //    if (entity == null)
        //    {
        //        return NotFound();
        //    }

        //    var statusProperty = entity.GetType().GetProperty("Status");
        //    if (statusProperty == null || statusProperty.PropertyType != typeof(bool))
        //    {
        //        return BadRequest("Entity does not contain a 'Status' property of type boolean.");
        //    }

        //    // Set status to false for soft-delete
        //    statusProperty.SetValue(entity, false);

        //    await _service.DeleteAsync(id,entity);
        //    return NoContent();
        //}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            var statusProperty = entity.GetType().GetProperty("Status");
            if (statusProperty != null && statusProperty.PropertyType == typeof(bool))
            {
                statusProperty.SetValue(entity, false); // Soft delete by setting Status to false
                await _service.UpdateAsync(id, entity); // Use Update to persist changes
            }

            return NoContent();
        }

    }
}
