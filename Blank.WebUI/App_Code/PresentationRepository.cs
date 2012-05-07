//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blank.WebUI.App_Code
//{
//    public class PresentationRepository
//    {
//        public GlobalBaseDataContext dataContext;

//        public PresentationRepository(GlobalBaseDataContext dataContext)
//        {
//            this.dataContext = dataContext;
//        }

//        public void Add(Presentation presentation)
//        {
//            presentation.Id = dataContext.Presentations.Count() + 1;
//            dataContext.Presentations.InsertOnSubmit(presentation);
//            dataContext.SubmitChanges();
//        }

//        public Presentation GetPresentationById(int id)
//        {
//            var presentations = from presentation in dataContext.Presentations
//                                where (presentation.Id == id)
//                                select presentation;
//            if (presentations.Count() == 1)
//            {
//                return presentations.First();
//            }
//            return null;
//        }

//        public void Update(Presentation presentation)
//        {
//            Presentation basePresentation = GetPresentationById(presentation.Id);
//            basePresentation.IsActive = false;
//            dataContext.SubmitChanges();
//        }

//        public void Delete(Presentation presentation)
//        {
//            foreach (Vote vote in dataContext.Votes)
//            {
//                if (vote.PresentationId == presentation.Id) { Update(vote); }
//            }

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.PresentationId == presentation.Id) { Update(link); }
//            }

//            Update(presentation);
//        }

//        public List<Presentation> Search(Tag tag1, Tag tag2, Tag tag3, Tag tag4)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList3 = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList4 = new List<TagPresentationLink>();
//            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.IsActive == true)
//                {
//                    pretempList.Add(link);
//                }
//            }


//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.TagId == tag1.Id)
//                {
//                    tempList.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag2.Id)
//                {
//                    tempList2.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag3.Id)
//                {
//                    tempList3.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag4.Id)
//                {
//                    tempList4.Add(link);
//                    resultList1.Add(GetPresentationById(link.PresentationId));
//                }
//            }

//            return resultList1;
//        }

//        public List<Presentation> Search(Tag tag1, Tag tag2, Tag tag3)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList3 = new List<TagPresentationLink>();
//            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.IsActive == true)
//                {
//                    pretempList.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.TagId == tag1.Id)
//                {
//                    tempList.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag2.Id)
//                {
//                    tempList2.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag3.Id)
//                {
//                    tempList3.Add(link);
//                    resultList1.Add(GetPresentationById(link.PresentationId));
//                }
//            }

//            return resultList1;
//        }

//        public List<Presentation> Search(Tag tag1, Tag tag2)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
//            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
//            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.IsActive == true)
//                {
//                    pretempList.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.TagId == tag1.Id)
//                {
//                    tempList.Add(link);
//                }
//            }


//            foreach (TagPresentationLink link in tempList)
//            {
//                if (link.TagId == tag2.Id)
//                {
//                    tempList2.Add(link);
//                    resultList1.Add(GetPresentationById(link.PresentationId));
//                }
//            }

//            return resultList1;
//        }

//        public List<Presentation> Search(Tag tag1)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
//            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.IsActive == true)
//                {
//                    pretempList.Add(link);
//                }
//            }

//            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
//            {
//                if (link.TagId == tag1.Id)
//                {
//                    tempList.Add(link);
//                    resultList1.Add(GetPresentationById(link.PresentationId));
//                }
//            }

//            return resultList1;
//        }

//        public List<Presentation> Search(User user)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            foreach (Presentation presentation in dataContext.Presentations)
//            {
//                if (presentation.UserId == user.Id && presentation.IsActive == true)
//                {
//                    resultList1.Add(presentation);
//                }
//            }

//            return resultList1;
//        }

//        public List<Presentation> Search(String name)
//        {
//            List<Presentation> resultList1 = new List<Presentation>();
//            foreach (Presentation presentation in dataContext.Presentations)
//            {
//                if (presentation.Name == name && presentation.IsActive == true)
//                {
//                    resultList1.Add(presentation);
//                }
//            }

//            return resultList1;
//        }

//        public void VoteUp(Presentation presentation)
//        {
//            Vote vote = new Vote();
//            Presentation basePresentation = GetPresentationById(presentation.Id);
//            basePresentation.Mark += 1;
//            dataContext.SubmitChanges();
//        }

//        public void VoteDown(Presentation presentation)
//        {
//            Vote vote = new Vote();
//            Presentation basePresentation = GetPresentationById(presentation.Id);
//            basePresentation.Mark -= 1;
//            dataContext.SubmitChanges();
//        }

//        public List<Presentation> VotedByMe(User user)
//        {
//            List<Presentation> list = new List<Presentation>();
//            foreach (Vote vote in dataContext.Votes)
//            {
//                if (vote.UserId == user.Id) list.Add(GetPresentationById(vote.PresentationId));
//            }
//            return list;
//        }
//    }
//}