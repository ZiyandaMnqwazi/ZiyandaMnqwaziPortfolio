using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZiyandaMnqwaziPortfolio.ProjectRepository;

namespace ZiyandaMnqwaziPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepository.GetAllProjects();
            return View(projects);
        }
    }
}
