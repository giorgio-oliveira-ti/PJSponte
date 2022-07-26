using System.Threading.Tasks;

namespace Sponte.Dt.Contratos
{
    public interface IGeralDt
    {
        /// <summary>
        /// Completo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();

    }
}
