
using System.Collections.Generic;
using System.Threading.Tasks;
using apief.Model;
using apief.Model.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("v1/categories")]
public class CategoryController: ControllerBase{


    [HttpGet]
    [Route("")]
    public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context){
        var categories = await context.Categories.ToListAsync();
        return categories;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Category>> Post(
        [FromServices] DataContext context,
        [FromBody] Category model
        )
    {
        if(ModelState.IsValid)
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult<Category>> Put(
        [FromServices] DataContext context,
        [FromBody] Category model
        )
    {
        if(ModelState.IsValid)
        {
            context.Categories.Update(model);
            await context.SaveChangesAsync();
            return model;
        }
        else
        {
            return BadRequest(ModelState);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> Delete(
        [FromServices] DataContext context,
        int id
        )
    {
        var category = await context.Categories.FindAsync(id);
        if(category == null)
        {
            return BadRequest();
        }
        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return category;
    }

}