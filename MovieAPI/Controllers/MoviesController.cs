using Microsoft.AspNetCore.Mvc;
using MovieAPI.Database;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        XsisContext context=new XsisContext();  
        [HttpGet]
        public IActionResult Get()
        {
            var result = context.Movies.ToList();
            if (!result.Any()) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = context.Movies.Where(x=>x.Id==id).Select(x=>x).FirstOrDefault();
            if (result==null) return NotFound(id);
            return Ok(result);
        }

        [HttpPost]
        public bool Post([FromBody] Movie movie)
        {
            try
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        [HttpPatch("{id}")]
        public bool Patch(int id, [FromBody] Movie param)
        {
            var movie = context.Movies.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
            if(movie!=null)
            {
                if (param.Title!=null) movie.Title = param.Title;
                if (param.Description != null) movie.Description=param.Description;
                if (param.Rating != null) movie.Rating= param.Rating;
                if (param.Image != null) movie.Image=param.Image;
                if (param.UpdatedAt != null) movie.UpdatedAt=param.UpdatedAt;
                context.Update(movie);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var target=context.Movies.Where(x=>x.Id==id).Select(x=>x).FirstOrDefault();
            if(target!=null)
            {
                context.Movies.Remove(target);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
