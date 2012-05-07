using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace Blank.WebUI.App_Code
{
    public class Repository
    {

        public GlobalBaseDataContext dataContext;

        public Repository(GlobalBaseDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(User user)
        {
            user.Id = dataContext.Users.Count() + 1;
            dataContext.Users.InsertOnSubmit(user);
            dataContext.SubmitChanges();
        }

        public void Add(Presentation presentation)
        {
            presentation.Id = dataContext.Presentations.Count() + 1;
            dataContext.Presentations.InsertOnSubmit(presentation);
            dataContext.SubmitChanges();
        }

        public void Add(Tag tag)
        {
            tag.Id = dataContext.Tags.Count() + 1;
            dataContext.Tags.InsertOnSubmit(tag);
            dataContext.SubmitChanges();
        }

        public void Add(Vote vote)
        {
            dataContext.Votes.InsertOnSubmit(vote);
            dataContext.SubmitChanges();
        }

        public void Add(TagPresentationLink link)
        {
            link.Id = dataContext.TagPresentationLinks.Count();
            bool temp = true;
            foreach (TagPresentationLink link1 in dataContext.TagPresentationLinks)
            {
                if (link.PresentationId == link1.PresentationId && link.TagId == link1.TagId) { temp = false; }
            }
            if (temp)
            {
                dataContext.TagPresentationLinks.InsertOnSubmit(link);
                dataContext.SubmitChanges();
            }
        }

        public User GetUserById(int id)
        {
            var users = from user in dataContext.Users
                        where (user.Id == id)
                        select user;
            if (users.Count() == 1)
            {
                return users.First();
            }
            return null;
        }

        public Vote GetVoteById(int id)
        {
            var votes = from vote in dataContext.Votes
                        where (vote.Id == id)
                        select vote;
            if (votes.Count() == 1)
            {
                return votes.First();
            }
            return null;
        }

        public TagPresentationLink GetLinkById(int id)
        {
            var links = from link in dataContext.TagPresentationLinks
                        where (link.Id == id)
                        select link;
            if (links.Count() == 1)
            {
                return links.First();
            }
            return null;
        }

        public Presentation GetPresentationById(int id)
        {
            var presentations = from presentation in dataContext.Presentations
                                where (presentation.Id == id)
                                select presentation;
            if (presentations.Count() == 1)
            {
                return presentations.First();
            }
            return null;
        }

        public void Update(Vote vote)
        {
            Vote baseVote = GetVoteById(vote.Id);
            baseVote.IsActive = false;
            dataContext.SubmitChanges();
        }

        public void Update(TagPresentationLink link)
        {
            TagPresentationLink baseLink = GetLinkById(link.Id);
            baseLink.IsActive = false;
            dataContext.SubmitChanges();
        }

        public void Update(Presentation presentation)
        {
            Presentation basePresentation = GetPresentationById(presentation.Id);
            basePresentation.IsActive = false;
            dataContext.SubmitChanges();
        }

        public void Update(User user)
        {
            User baseUser = GetUserById(user.Id);
            baseUser.IsActive = false;
            dataContext.SubmitChanges();
        }

        public void Delete(Presentation presentation)
        {
            foreach (Vote vote in dataContext.Votes)
            {
                if (vote.PresentationId == presentation.Id) { Update(vote); }
            }

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.PresentationId == presentation.Id) { Update(link); }
            }

            Update(presentation);
        }

        public void Delete(User user)
        {
            foreach (Presentation presentation in dataContext.Presentations)
            {
                if (presentation.UserId == user.Id) { Delete(presentation); }
            }

            Update(user);
        }

        public List<Presentation> Search(Tag tag1, Tag tag2, Tag tag3, Tag tag4)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList3 = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList4 = new List<TagPresentationLink>();
            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.IsActive == true)
                {
                    pretempList.Add(link);
                }
            }


            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.TagId == tag1.Id)
                {
                    tempList.Add(link);
                }
            }

            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag2.Id)
                {
                    tempList2.Add(link);
                }
            }

            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag3.Id)
                {
                    tempList3.Add(link);
                }
            }

            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag4.Id)
                {
                    tempList4.Add(link);
                    resultList1.Add(GetPresentationById(link.PresentationId));
                }
            }

            return resultList1;
        }

        public List<Presentation> Search(Tag tag1, Tag tag2, Tag tag3)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList3 = new List<TagPresentationLink>();
            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.IsActive == true)
                {
                    pretempList.Add(link);
                }
            }

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.TagId == tag1.Id)
                {
                    tempList.Add(link);
                }
            }

            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag2.Id)
                {
                    tempList2.Add(link);
                }
            }

            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag3.Id)
                {
                    tempList3.Add(link);
                    resultList1.Add(GetPresentationById(link.PresentationId));
                }
            }

            return resultList1;
        }

        public List<Presentation> Search(Tag tag1, Tag tag2)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
            List<TagPresentationLink> tempList2 = new List<TagPresentationLink>();
            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.IsActive == true)
                {
                    pretempList.Add(link);
                }
            }

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.TagId == tag1.Id)
                {
                    tempList.Add(link);
                }
            }


            foreach (TagPresentationLink link in tempList)
            {
                if (link.TagId == tag2.Id)
                {
                    tempList2.Add(link);
                    resultList1.Add(GetPresentationById(link.PresentationId));
                }
            }

            return resultList1;
        }

        public List<Presentation> Search(Tag tag1)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            List<TagPresentationLink> tempList = new List<TagPresentationLink>();
            List<TagPresentationLink> pretempList = new List<TagPresentationLink>();

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.IsActive == true)
                {
                    pretempList.Add(link);
                }
            }

            foreach (TagPresentationLink link in dataContext.TagPresentationLinks)
            {
                if (link.TagId == tag1.Id)
                {
                    tempList.Add(link);
                    resultList1.Add(GetPresentationById(link.PresentationId));
                }
            }

            return resultList1;
        }

        public List<Presentation> Search(User user)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            foreach (Presentation presentation in dataContext.Presentations)
            {
                if (presentation.UserId == user.Id && presentation.IsActive == true)
                {
                    resultList1.Add(presentation);
                }
            }

            return resultList1;
        }

        public List<Presentation> Search(String name)
        {
            List<Presentation> resultList1 = new List<Presentation>();
            foreach (Presentation presentation in dataContext.Presentations)
            {
                if (presentation.Name == name && presentation.IsActive == true)
                {
                    resultList1.Add(presentation);
                }
            }

            return resultList1;
        }

        public User ValidateUser(string Name, string Password)
        {
            List<User> result = new List<User>();
            foreach (User user in dataContext.Users)
            {
                if (user.Name == Name && user.Password == Password)
                {
                    result.Add(user);
                }
            }
            if (result.Count == 0)
            {
                return null;
            }
            else return result.First();
        }

        public void RegistrateUser(string Name, string Password, string City, int Age)
        {
            User user = new User();
            user.Name = Name;
            user.Password = Password;
            user.City = City;
            user.Age = Age;
            user.IsActive = false;
            Random rand = new Random();
            user.ValidationCode = rand.Next(10000);
            Add(user);
        }

        public void VoteUp(Presentation presentation)
        {
            Vote vote = new Vote();
            Presentation basePresentation = GetPresentationById(presentation.Id);
            basePresentation.Mark += 1;
            dataContext.SubmitChanges();
        }

        public void VoteDown(Presentation presentation)
        {
            Vote vote = new Vote();
            Presentation basePresentation = GetPresentationById(presentation.Id);
            basePresentation.Mark -= 1;
            dataContext.SubmitChanges();
        }

        public List<Presentation> VotedByMe(User user)
        {
            List<Presentation> list = new List<Presentation>();
            foreach (Vote vote in dataContext.Votes)
            {
                if (vote.UserId == user.Id) list.Add(GetPresentationById(vote.PresentationId));
            }
            return list;
        }

        public void ValidateRegistration(User user)
        {
            User baseUser = GetUserById(user.Id);
            baseUser.IsActive = true;
            dataContext.SubmitChanges();
        }

        public void SendCode(User user)
        {
            MailMessage message = new MailMessage();
            message.To.Add(user.Email);
            MailAddress MA = new MailAddress("rodolfo_wolk@rambler.ru");
            message.From = MA;
            message.Subject = "Registration";
            int? v = user.ValidationCode;
            message.Body = "Your validation code is " + v.ToString();
            SmtpClient client = new SmtpClient("smtp.rambler.ru");
            client.Port = 25;
            client.Credentials = new NetworkCredential("rodolfo_wolk@rambler.ru", "a14881488");
            client.Send(message);
        }

    }
}