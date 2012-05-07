//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blank.WebUI.App_Code
//{
//    public class TagPresentationLinkRepository
//    {
//        public GlobalBaseDataContext dataContext;

//        public TagPresentationLinkRepository(GlobalBaseDataContext dataContext)
//        {
//            this.dataContext = dataContext;
//        }

//        public void Add(TagPresentationLink link)
//        {
//            link.Id = dataContext.TagPresentationLinks.Count();
//            bool temp = true;
//            foreach (TagPresentationLink link1 in dataContext.TagPresentationLinks)
//            {
//                if (link.PresentationId == link1.PresentationId && link.TagId == link1.TagId) { temp = false; }
//            }
//            if (temp)
//            {
//                dataContext.TagPresentationLinks.InsertOnSubmit(link);
//                dataContext.SubmitChanges();
//            }
//        }

//        public TagPresentationLink GetLinkById(int id)
//        {
//            var links = from link in dataContext.TagPresentationLinks
//                        where (link.Id == id)
//                        select link;
//            if (links.Count() == 1)
//            {
//                return links.First();
//            }
//            return null;
//        }

//        public void Update(TagPresentationLink link)
//        {
//            TagPresentationLink baseLink = GetLinkById(link.Id);
//            baseLink.IsActive = false;
//            dataContext.SubmitChanges();
//        }
//    }
//}