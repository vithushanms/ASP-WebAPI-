using System.Collections.Generic;
using APIapp.Models;

namespace APIapp.Data
{
    public interface IAPIappRepository
    {
        bool SaveChanges();
        IEnumerable<appCommands> GetAllCommands();
        appCommands GetCommandById(int Id);
        void CreateCommand(appCommands cmd);
        void UpdateCommand(appCommands cmd);
        void DeleteCommand(appCommands cmd);
    }
}