//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blank.WebUI.App_Code
//{
//    public class TagRepository
//    {
//        public GlobalBaseDataContext dataContext;

//        public TagRepository(GlobalBaseDataContext dataContext)
//        {
//            this.dataContext = dataContext;
//        }

//        public void Add(Tag tag)
//        {
//            tag.Id = dataContext.Tags.Count() + 1;
//            dataContext.Tags.InsertOnSubmit(tag);
//            dataContext.SubmitChanges();
//        }
//    }
//}