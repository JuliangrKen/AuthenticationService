using System;
using System.Net.Mail;

namespace AuthenticationService
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public bool FromRussia { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            FullName = GetFullName(user.FirstName, user.LastName);

            FromRussia = GetFromRussiaValue(user.Email);
        }

        private string GetFullName(string firstName, string lastName)
            => string.Concat(firstName, " ", lastName);

        private bool GetFromRussiaValue(string email)
            => new MailAddress(email).Host.Contains(".ru");
    }
}
