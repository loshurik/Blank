//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Blank.WebUI.App_Code
//{
//    public class UserRepository
//    {
//        public GlobalBaseDataContext dataContext;

//        public UserRepository(GlobalBaseDataContext dataContext)
//        {
//            this.dataContext = dataContext;
//        }

//        public void Add(User user)
//        {
//            user.Id = dataContext.Users.Count() + 1;
//            dataContext.Users.InsertOnSubmit(user);
//            dataContext.SubmitChanges();
//        }

//        public void Delete(User user)
//        {
//            foreach (Presentation presentation in dataContext.Presentations)
//            {
//                if (presentation.UserId == user.Id) { Delete(presentation); }
//            }

//            Update(user);
//        }

//        public User GetUserById(int id)
//        {
//            var users = from user in dataContext.Users
//                        where (user.Id == id)
//                        select user;
//            if (users.Count() == 1)
//            {
//                return users.First();
//            }
//            return null;
//        }

//        public void Update(User user)
//        {
//            User baseUser = GetUserById(user.Id);
//            baseUser.IsActive = false;
//            dataContext.SubmitChanges();
//        }

//        public User ValidateUser(string Name, string Password)
//        {
//            List<User> result = new List<User>();
//            foreach (User user in dataContext.Users)
//            {
//                if (user.Name == Name && user.Password == Password)
//                {
//                    result.Add(user);
//                }
//            }
//            if (result.Count == 0)
//            {
//                return null;
//            }
//            else return result.First();
//        }

//        public void RegistrateUser(string Name, string Password, string City, int Age)
//        {
//            User user = new User();
//            user.Name = Name;
//            user.Password = Password;
//            user.City = City;
//            user.Age = Age;
//            user.IsActive = false;
//            Random rand = new Random();
//            user.ValidationCode = rand.Next(10000);
//            Add(user);
//        }

//        public void ValidateRegistration(User user)
//        {
//            User baseUser = GetUserById(user.Id);
//            baseUser.IsActive = true;
//            dataContext.SubmitChanges();
//        }

//        public void SendCode(User user)
//        {
//            MailMessage message = new MailMessage();
//            message.To.Add(user.Email);
//            MailAddress MA = new MailAddress("rodolfo_wolk@rambler.ru");
//            message.From = MA;
//            message.Subject = "Registration";
//            int? v = user.ValidationCode;
//            message.Body = "Your validation code is " + v.ToString();
//            SmtpClient client = new SmtpClient("smtp.rambler.ru");
//            client.Port = 25;
//            client.Credentials = new NetworkCredential("rodolfo_wolk@rambler.ru", "a14881488");
//            client.Send(message);
//        }
//    }
//}