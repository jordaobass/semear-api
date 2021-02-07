using System;
using System.Linq;
using System.Threading.Tasks;

namespace SemearApi.Repository.Configuration
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly AppContext AppContext;

        public RepositoryBase(AppContext appContext)
        {
            AppContext = appContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return AppContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível recuperar entidades: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entidade não deve ser nula");
            }

            try
            {
                await AppContext.AddAsync(entity);
                await AppContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} não pôde ser salvo: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entidade não deve ser nula ");
            }

            try
            {
                AppContext.Update(entity);
                await AppContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} não pôde ser atualizado: {ex.Message}");
            }
        }
    }
}