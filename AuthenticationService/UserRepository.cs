using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationService
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAll()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "test1",
                    FirstName = "Test1",
                    LastName = "Tester1",
                    Email = "Test1@mail.ru",
                    Password = "ru1",
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "test2",
                    FirstName = "Test2",
                    LastName = "Tester2",
                    Email = "Test2@mail.ru",
                    Password = "ru2",
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    Login = "test3",
                    FirstName = "Test3",
                    LastName = "Tester3",
                    Email = "Test3@mail.ru",
                    Password = "ru3",
                },
            };
        }

        public User GetByLogin(string login)
            => GetAll().FirstOrDefault(x => x.Login == login);
    }
}
