using WebPageTest.Models;

namespace WebPageTest.DataAccess.Repository.IRepository
{
    public interface ICoverRepository : IRepository<Cover>
    {
        void Update(Cover obj);
    }
}
