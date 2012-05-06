using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blank.WebUI.HtmlHelpers;
using Blank.WebUI.Models;
using Moq;
using Ninject;

namespace Blank.UnitTests
{
    [TestClass]
    public class HtmlHelperTest
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper helper = null;
            PagingInfo pagingInfo = new PagingInfo()
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "page" + i;
            
            MvcHtmlString result = helper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(result.ToString(),@"<a href=""page1"">1</a><a class=""selected"" href=""page2"">2</a><a href=""page3"">3</a>");
        }
    
    }
}
