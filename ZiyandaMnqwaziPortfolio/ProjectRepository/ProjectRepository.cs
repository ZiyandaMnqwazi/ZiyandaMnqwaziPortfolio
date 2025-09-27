using ZiyandaMnqwaziPortfolio.Models;
using ZiyandaMnqwaziPortfolio.Repositories;

namespace ZiyandaMnqwaziPortfolio.ProjectRepository
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly ISqlDataAccess _db;

        public ProjectRepository(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<ZiyandaProject>> GetAllProjects()
        {
            return _db.GetData<ZiyandaProject, dynamic>("spGetAllProjects", new { });
        }

    }
}
