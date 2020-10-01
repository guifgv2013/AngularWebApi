using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("site/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public DataContext Context { get; }

        public ValuesController(DataContext context)
        {
            Context = context;

        }

        // GET api/values
        [HttpGet]
        //HttpGet opção 3 - chamada assincrona, espera o retorno do banco -- além do try catch
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await Context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
                //return BadRequest();
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        //HttpGet Opção 2 - add try catch
        // public IActionResult Get()
        // {
        //     try
        //     {
        //         return Ok(Context.Eventos.ToList());
        //     }
        //     catch (System.Exception)
        //     {
        //         //return BadRequest();
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
        //     }
        // }

        //HttpGet Opção 1 - versão bem simples
        // public ActionResult<IEnumerable<Evento>> Get()
        // {
        //     return Context.Eventos.ToList();
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        // HttpGet+Id Forma ASincorna
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await Context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            
        }

        // HttpGet+Id Forma Sincorna
        // public ActionResult<Evento> Get(int id)
        // {
        //     return 
        //         Context.Eventos.ToList().FirstOrDefault(x => x.EventoId == id);
            
        // }
        

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
