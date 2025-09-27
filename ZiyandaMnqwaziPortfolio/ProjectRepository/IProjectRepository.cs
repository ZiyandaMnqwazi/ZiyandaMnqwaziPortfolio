using ZiyandaMnqwaziPortfolio.Models;

namespace ZiyandaMnqwaziPortfolio.ProjectRepository
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<ZiyandaProject>> GetAllProjects();

    }
}
