using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPPManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPPManagement.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository repo;

        public ProjectController(IProjectRepository repo)
        {
            this.repo = repo;
        }

        //get: /<controller>/
        public IActionResult Index()
        {
            var projects = repo.GetAllProjects();
            return View(projects);
        }

        public IActionResult ViewProject(int id)
        {
            var project = repo.GetProject(id);
            return View(project);
        }
        public IActionResult UpdateProject(int id)
        {
            Project proj = repo.GetProject(id);
            if (proj == null)
            {
                return View("ProjectNotFound");
            }
            return View(proj);
        }

        public IActionResult UpdateProjectToDatabase(Project project)
        {
            repo.UpdateProject(project);

            return RedirectToAction("ViewProject", new { id = project.ProjectID });
        }

        public IActionResult InsertProject()
        {
            var proj = repo.AssignCategory();
            return View(proj);
        }
    
        public IActionResult InsertProjectToDatabase(Project projectToInsert)
        {
            repo.InsertProject(projectToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(Project project)
        {
            repo.DeleteProject(project);
            return RedirectToAction("Index");
        }
    }
}
