using WebPageTest.DataAccess.Repository.IRepository;

namespace WebPageTest.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            CoverRepository = new CoverRepository(_db);
        }

        public ICategoryRepository CategoryRepository { get; private set; }

        public ICoverRepository CoverRepository { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
