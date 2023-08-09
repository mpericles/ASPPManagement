using ASPPManagement.Models;
using System;
using System.Collections.Generic;

namespace ASPPManagement
{
    public interface IProjectRepository
    {
        public IEnumerable<Project> GetAllProjects();

        public Project GetProject(int ProjectID);

       // public Project GetProjectById(int ProjectID);

        public void UpdateProject(Project project);

        public void InsertProject(Project projectToInsert);

        //public IEnumerable<Category> GetCategories();

        public Project AssignCategory();

        public void DeleteProject(Project project);
    }
}
