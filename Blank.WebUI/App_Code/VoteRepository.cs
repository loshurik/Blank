//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blank.WebUI.App_Code
//{
//    public class VoteRepository
//    {
//        public GlobalBaseDataContext dataContext;

//        public VoteRepository(GlobalBaseDataContext dataContext)
//        {
//            this.dataContext = dataContext;
//        }

//        public void Add(Vote vote)
//        {
//            dataContext.Votes.InsertOnSubmit(vote);
//            dataContext.SubmitChanges();
//        }

//        public Vote GetVoteById(int id)
//        {
//            var votes = from vote in dataContext.Votes
//                        where (vote.Id == id)
//                        select vote;
//            if (votes.Count() == 1)
//            {
//                return votes.First();
//            }
//            return null;
//        }

//        public void Update(Vote vote)
//        {
//            Vote baseVote = GetVoteById(vote.Id);
//            baseVote.IsActive = false;
//            dataContext.SubmitChanges();
//        }
//    }
//}