using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using APIapp.Models;
using APIapp.Data;
using AutoMapper;
using APIapp.DTOs;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.JsonPatch;

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
        
        //URI will be GET api/APIapp
        [HttpGet]
        public ActionResult <IEnumerable<APIappControllerRead>> GetCommands(){
            var commandItems = _repo.GetAllCommands();
            return Ok(_Mapper.Map<IEnumerable<APIappControllerRead>>(commandItems));
        }

        //URI will be GET api/APIapp/{Id}
        [HttpGet("{Id}" , Name = "GetCommandById")]
        public ActionResult <APIappControllerRead> GetCommandById(int Id){
            var command = _repo.GetCommandById(Id);
            if(command != null){
                return Ok(_Mapper.Map<APIappControllerRead>(command));
            }
            return NotFound();
        }

        //URI will be POST api/APIapp
        [HttpPost]
        public ActionResult <APIappControllerRead> CreateCommand(APIappCreateDTO aPIappCreateDTO){
            var commandModel = _Mapper.Map<appCommands>(aPIappCreateDTO);
            _repo.CreateCommand(commandModel);
            _repo.SaveChanges();
            var commandReadDTO = _Mapper.Map<APIappControllerRead>(commandModel);
            return CreatedAtRoute("GetCommandById", new {Id = commandReadDTO.Id}, commandReadDTO);
        }

        //URI will be PUT api/command/{Id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int Id, APIappUpdateDTO aPIappUpdateDTO)
        {
            var commandModel = _repo.GetCommandById(Id);
            if(commandModel == null)
            {
                return NoContent();
            }
            _Mapper.Map(aPIappUpdateDTO, commandModel);
            _repo.UpdateCommand(commandModel);
            _repo.SaveChanges();

            return NoContent();
        }

        ////URI will be Delete api/command/{Id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var deleteCommandModelFromRepo = _repo.GetCommandById(Id);
            if(deleteCommandModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteCommand(deleteCommandModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }

        //URI will be PATCH api/command/{Id}
        [HttpPatch("{Id}")]
        public ActionResult PatchUpdate(int Id, JsonPatchDocument<APIappUpdateDTO> patch)
        {
            var CommandModelFromRepo = _repo.GetCommandById(Id);
            if(CommandModelFromRepo == null)
            {
                return NotFound();
            }
            var PatchModel = _Mapper.Map<APIappUpdateDTO>(CommandModelFromRepo);
            patch.ApplyTo(PatchModel, ModelState);
            if(!TryValidateModel(PatchModel))
            {
                return ValidationProblem(ModelState);
            }
            _Mapper.Map(PatchModel, CommandModelFromRepo);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}