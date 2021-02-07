using SemearApi.Entities;
using SemearApi.Repository.Configuration;
using SemearApi.Repository.Interface;

namespace SemearApi.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SemearAppContext semearAppContext) : base(semearAppContext)
        {
        }
    }
}