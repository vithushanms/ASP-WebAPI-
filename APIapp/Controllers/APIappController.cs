using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIapp.Models;
using APIapp.Data;

namespace APIapp.Controllers
{
    [Route("api/[controller]")] /*this rout will take the controller name Ex: api/APIapp*/
    [ApiController]
    public class APIappController : Controller
    {
        private readonly IAPIappRepository _repo;
        public APIappController(IAPIappRepository repo)
        {
            _repo = repo;
        }
        
        //URI will be api/APIapp
        [HttpGet]
        public ActionResult <IEnumerable<appCommands>> GetCommands(){
            var commandItems = _repo.GetAllCommands();
            return Ok(commandItems);
        }

        //URI will be api/APIapp/{Id}
        [HttpGet("{Id}")]
        public ActionResult <appCommands> GetCommandById(int Id){
            var command = _repo.GetCommandById(Id);
            return Ok(command);
        }
    }
}