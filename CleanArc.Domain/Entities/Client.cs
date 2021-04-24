using CleanArc.Domain.Shared.Entity;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Entities
{
    public sealed class Client : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Client(string name, string email)
        {
            Name = name;
            Email = email;
            AddNotifications(new ClientValidation(this));
        }
    }
    internal class ClientValidation : Contract<Client>
    {
        public ClientValidation(Client client)
        {
            Requires()
                .IsNotNullOrWhiteSpace(client.Name, "Name", "Name is empty")
                .IsEmail(client.Email, nameof(client.Email), "Email Invalid");
        }
    }
}
