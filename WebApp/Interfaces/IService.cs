using WebApp.Models;

namespace WebApp.Interfaces
{
    public interface IService
    {
        public IEnumerable<Entity> GetData(string whereString, string connectionString);
    }
}
