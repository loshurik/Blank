using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System.Collections.Generic;
using Ninject;
using Moq;
using Blank.Domain.Abstract;
using Blank.Domain.Entities;

namespace Blank.WebUI.Infrastructure
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            
            Mock<IUserRepository> mock = new Mock<IUserRepository>();
            mock.Setup(m=>m.Users).Returns(new List<User>
            {
                new User{Id=1,Name="ivanhoe",Email="qwe@wer.com",Password="123456",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=1,Name="verocka",Email="vera@wer.com",Password="234567",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=1,Name="kitty",Email="kate@wer.com",Password="qwerty",City="Minsk",RoleId=1,Age=20,IsActive=true},
                new User{Id=1,Name="xXx",Email="xxx666@wer.com",Password="asdfgh",City="Hell",RoleId=1,Age=14,IsActive=true},
                new User{Id=1,Name="root",Email="ubuntarium@wer.com",Password="ytrewq",City="Minsk",RoleId=1,Age=30,IsActive=true},
                new User{Id=1,Name="neoC5H12",Email="chem@wer.com",Password="bvcxza",City="Minsk",RoleId=1,Age=22,IsActive=true}
            }.AsQueryable());
            ninjectKernel.Bind<IUserRepository>().ToConstant(mock.Object);
        
        
        }
    }
}