using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using APIapp.Models;

namespace APIapp.Data
{
    public class SqlAPIappRepo : IAPIappRepository
    {
        private readonly APIappDBContext _repository;

        public SqlAPIappRepo (APIappDBContext repository){
            this._repository = repository;
        }

        public void CreateCommand(appCommands cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _repository.Commands.Add(cmd);
        }

        public void DeleteCommand(appCommands cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _repository.Commands.Remove(cmd);
        }

        public IEnumerable<appCommands> GetAllCommands(){
            return _repository.Commands.ToList();
        } 

        public appCommands GetCommandById(int Id){
            return _repository.Commands.FirstOrDefault(x => x.Id == Id);
        }

        public bool SaveChanges()
        {
            return (_repository.SaveChanges() >= 0);
        }

        public void UpdateCommand(appCommands cmd)
        {
        
        }
    }
}