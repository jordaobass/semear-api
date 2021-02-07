using System.Collections.Generic;
using System.Threading.Tasks;
using SemearApi.Entities;

namespace SemearApi.Service
{
    public interface IUserService
    {
        string Authenticate(string nomeDoUsuario, string senha);
        IEnumerable<User> GetAll();
        User GetById(int id);
        Task<int> CreateUser(User user);
        bool VerifyExist(string username);
    }
}