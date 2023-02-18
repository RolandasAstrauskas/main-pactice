using WebPageTest.DataAccess.Repository.IRepository;
using WebPageTest.Models;

namespace WebPageTest.DataAccess.Repository
{
    public class CoverRepository : Repository<Cover>, ICoverRepository
    {
        private ApplicationDbContext _db;

        public CoverRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Cover obj)
        {
            _db.Update(obj);
        }
    }
}
