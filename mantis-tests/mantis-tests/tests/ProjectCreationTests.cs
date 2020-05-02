using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };

            ProjectData project = new ProjectData()
            {
                Name = "qqq",
                Description = "www"
            };

            app.Projects.DeleteIfProjectExist(account, project);

            List<ProjectData> oldProjects = app.Projects.GetProjectList(account);

            app.Projects.Create(account, project);

            Assert.AreEqual(oldProjects.Count + 1, app.Projects.GetProjectCount(account));

            List<ProjectData> newProjects = app.Projects.GetProjectList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}