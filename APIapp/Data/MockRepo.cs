using System.Collections.Generic;
using APIapp.Data;
using APIapp.Models;

namespace APIapp.Data
{
    public class MockRepo : IAPIappRepository
    {
        public IEnumerable<appCommands> GetAllCommands(){
            var appCommands = new List<appCommands>{
                new appCommands{Id=0, How = "Text", Line = "2", Platform = "Linux"},
                new appCommands{Id=1, How = "Int", Line = "12", Platform = "Windows"},
                new appCommands{Id=2, How = "Float", Line = "3", Platform = "Linux"},
                new appCommands{Id=3, How = "Text", Line = "4", Platform = "Linux"}
            }; 
            return appCommands;
        }

        public appCommands GetCommandById(int Id){
            return new appCommands{Id=0, How = "Text", Line = "2", Platform = "Linux"};
        }

        public appCommands CreateCommand(appCommands cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}