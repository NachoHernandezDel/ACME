//using ACME.Repositorio.IRepositorio;


//namespace ACME.Repositorio
//{

//    public class Repositorio<T> : IRepositorio<T> where T : class
//    {

//        private readonly ApplicationDbContext _db;
//        internal DbSet<T> dbSet;

//        public Repositorio(ApplicationDbContext db)
//        {
//            _db = db;
//            this.dbSet = _db.Set<T>();
//        }


//        public async Task Crear(T entidad)
//        {
//            await dbSet.AddAsync(entidad);
//            await Guardar();
//        }

//        public async Task Guardar()
//        {
//            await _db.SaveChangesAsync();
//        }

//        public async Task<T> Obtener()
//        {
//            IQueryable<T> query = dbSet;


//            return await query.FirstOrDefaultAsync();
//        }

//        public async Task<T> ObtenerTodos()
//        {
//            IQueryable<T> query = dbSet;


//            return await query.ToListAsync();

//        }

//        public async Task Eliminar(T entidad)
//        {
//            dbSet.Remove(entidad);
//            await Guardar();
//        }


//    }
//}