using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks4
{
    [TestFixture]
    public class HtmlHelperTests
    {
        [Test]
        public void HtmlHelperInputFor()
        {
            var helper = new HtmlHelper<Test>(new Test() { Location = "MyLocation" });
            var html = helper.InputFor(x => x.Location);
            Assert.AreEqual("<input type=\"text\" name=\"Location\" value=\"MyLocation\" />", html.ToString());
        }

        public class Test
        {
            public string Location { get; set; }
        }
    }
}
