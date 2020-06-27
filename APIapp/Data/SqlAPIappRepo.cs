using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using APIapp.Models;

namespace APIapp.Data
{
    public class SqlAPIappRepo : IAPIappRepository
    {
        private readonly APIappDBContext repository;

        public SqlAPIappRepo (APIappDBContext repository){
            this.repository = repository;
        }

        public appCommands CreateCommand(appCommands cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<appCommands> GetAllCommands(){
            return repository.Commands.ToList();
        } 

        public appCommands GetCommandById(int Id){
            return repository.Commands.FirstOrDefault(x => x.Id == Id);
        }

    }
}