using SemearApi.Entities;
using SemearApi.Repository.Configuration;
using SemearApi.Repository.Interface;

namespace SemearApi.Repository
{
    public class UserRepositoryBase : RepositoryBase<User>, IUserRepositoryBase
    {
        public UserRepositoryBase(AppContext appContext) : base(appContext)
        {
        }
    }
}