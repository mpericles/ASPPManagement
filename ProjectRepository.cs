using ASPPManagement.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace ASPPManagement
{
    public class ProjectRepository : IProjectRepository
    {
        //DB Connection
        private readonly IDbConnection _conn;

        public ProjectRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        //get all Projects
        public IEnumerable<Project> GetAllProjects()
        {
            return _conn.Query<Project>("SELECT * FROM PROJECTS;");
        }
        //get all Projects by id
        //public Project GetProjectById(int projectid)
        public Project GetProject(int projectid)
        {
            return _conn.QuerySingle<Project>("SELECT * FROM PROJECTS WHERE PROJECTID = @id", new { id = projectid });
        }

        //update projects              
        public void UpdateProject(Project project)
        {
            _conn.Execute("UPDATE projects SET Name = @name, Cost = @cost WHERE ProjectID = @id",
             new { name = project.Name, cost = project.Cost, id = project.ProjectID });
        }

        //insert projects
        public void InsertProject(Project projectToInsert)
        {
            _conn.Execute("INSERT INTO projects (PROJECTID, NAME, COST) VALUES (@projectid, @name, @cost);",
                new { projectID = projectToInsert.ProjectID, name = projectToInsert.Name, cost = projectToInsert.Cost});
             //new { name = projectToInsert.Name, cost = projectToInsert.Cost });
            //new { name = projectToInsert.Name, cost = projectToInsert.Cost, projectID = projectToInsert.ProjectID });
        }

        //public IEnumerable<Category> GetCategories()
        //{
        //    return _conn.Query<Category>("SELECT * FROM categories;");
        //}

        public Project AssignCategory()
        {
            //var categoryList = GetCategories();
            var project = new Project();
            //product.Categories = categoryList;
            return project;
        }



        //delete projects
        public void DeleteProject(Project project)
        {
            _conn.Execute("DELETE FROM REVIEWS WHERE ProjectID = @id;", new { id = project.ProjectID });
            _conn.Execute("DELETE FROM Sales WHERE ProjectID = @id;", new { id = project.ProjectID });
            _conn.Execute("DELETE FROM Products WHERE ProjectID = @id;", new { id = project.ProjectID });
        }
    }
}
