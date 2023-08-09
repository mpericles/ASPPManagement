using System;
namespace ASPPManagement.Models
{
    public class Project
    {
        public Project() { }

        public int ProjectID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int PortfolioID { get; set; }
        public int Active { get; set; }
        public int Level { get; set; }

        //public IEnumerable<Category> Categories { get; set; }
    }
}
