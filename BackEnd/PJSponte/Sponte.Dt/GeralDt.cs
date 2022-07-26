using Sponte.Dt.Context;
using Sponte.Dt.Contratos;
using System.Threading.Tasks;

namespace Sponte.Dt
{
    public class GeralDt : IGeralDt
    {
        private readonly DContext _context;
        public GeralDt(DContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Posts
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove (entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
       
    }
}
