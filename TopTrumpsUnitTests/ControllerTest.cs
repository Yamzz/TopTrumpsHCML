using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopTrumpsHCML.Controllers;

namespace TopTrumpsUnitTests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            using (var controller = new HomeController())
            {
                // Act
                var result = controller.Index() as ViewResult;
                // Assert
                Assert.IsNotNull(result);
            }
        }
    }
}
