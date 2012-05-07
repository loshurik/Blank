using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blank.WebUI.Controllers;
using Blank.WebUI.Models;
using Blank.Domain.Abstract;
using Blank.Domain.Entities;
using Moq;
using Ninject;

namespace Blank.UnitTests
{
    [TestClass]
    public class CanPagingTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m => m.Users).Returns(new User[]
                {
                new User{Id=1,Name="ivanhoe",Email="qwe@wer.com",Password="123456",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=2,Name="verocka",Email="vera@wer.com",Password="234567",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=3,Name="kitty",Email="kate@wer.com",Password="qwerty",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=4,Name="xXx",Email="xxx666@wer.com",Password="asdfgh",City="Hell",RoleId=1,Age=14,IsActive=true},
                new User{Id=5,Name="root",Email="ubuntarium@wer.com",Password="ytrewq",City="Minsk",RoleId=1,Age=30,IsActive=true},
                new User{Id=6,Name="neoC5H12",Email="chem@wer.com",Password="bvcxza",City="Minsk",RoleId=1,Age=22,IsActive=true}
                }.AsQueryable());
            UserController controller = new UserController(mock.Object);
            controller.PageSize = 4;

            UserListViewModel result = (UserListViewModel)controller.List(2).Model;
           // Assert.IsTrue(result.PagingInfo. == 2);
           // Assert.AreEqual(userArray[0].Name, "root");
        }
    }
}
