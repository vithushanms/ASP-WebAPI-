using System.Collections.Generic;
using APIapp.Models;

namespace APIapp.Data
{
    public interface IAPIappRepository
    {
        IEnumerable<appCommands> GetAllCommands();
        appCommands GetCommandById(int Id);

        appCommands CreateCommand(appCommands cmd);
    }
}