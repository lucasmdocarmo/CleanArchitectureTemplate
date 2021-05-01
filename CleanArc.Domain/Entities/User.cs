using CleanArc.Domain.Shared.Entity;
using Flunt.Validations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static CleanArc.Domain.Entities.User;

namespace CleanArc.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public User(string name, string password, string login)
        {
            Name = name;
            Password = password;
            Login = login;
            AddNotifications(new UserValidation(this));
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Login { get; private set; }
    }
    internal class UserValidation : Contract<User>
    {
        public UserValidation(User user)
        {
            Requires()
                .IsNotNullOrWhiteSpace(user.Name, "Name", "Name is Required")
                .IsNotNullOrWhiteSpace(user.Login, "", "Login Invalid")
                .IsNotNullOrWhiteSpace(user.Password, "", "Profession is Required");
        }
    }
  
}
