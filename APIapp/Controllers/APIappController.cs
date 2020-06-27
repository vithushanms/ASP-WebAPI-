using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIapp.Models;
using APIapp.Data;
using AutoMapper;
using APIapp.DTOs;

namespace APIapp.Controllers
{
    [Route("api/[controller]")] /*this rout will take the controller name Ex: api/APIapp*/
    [ApiController]
    public class APIappController : Controller
    {
        private readonly IAPIappRepository _repo;
        private readonly IMapper _Mapper;
        public APIappController(IAPIappRepository repo, IMapper Mapper)
        {
            _repo = repo;
            _Mapper = Mapper;
        }
        
        //URI will be api/APIapp
        [HttpGet]
        public ActionResult <IEnumerable<APIappControllerRead>> GetCommands(){
            var commandItems = _repo.GetAllCommands();
            return Ok(_Mapper.Map<IEnumerable<APIappControllerRead>>(commandItems));
        }

        //URI will be api/APIapp/{Id}
        [HttpGet("{Id}")]
        public ActionResult <APIappControllerRead> GetCommandById(int Id){
            var command = _repo.GetCommandById(Id);
            if(command != null){
                return Ok(_Mapper.Map<APIappControllerRead>(command));
            }
            return NoContent();
        }

        //URI will be POST api/APIapp
        [HttpPost]
        public ActionResult <APIappControllerRead> CreateCommand(APIappCreateDTO aPIappCreateDTO){
            var commandModel = _Mapper.Map<appCommands>(aPIappCreateDTO);
            _repo.CreateCommand(commandModel);
            return Ok(commandModel);
        }
    }
}