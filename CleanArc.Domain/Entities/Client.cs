using CleanArc.Domain.Contracts.Entities;
using CleanArc.Domain.Shared.Entity;
using CleanArc.Domain.Shared.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Entities
{
    public sealed class Client : BaseEntity, IClient
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public EClientType Type { get; private set; }
        public string Profession { get; private set; }

        public Client(string name, string email, EClientType type, string profession)
        {
            Name = name;
            Email = email;
            Type = type;
            Profession = profession;
            AddNotifications(new ClientValidation(this));
        }
        public Client UpdateClient(Client client)
        {
            this.Name = client.Name;
            this.Email = client.Email;
            this.Type = client.Type;
            this.Profession = client.Profession;
            AddNotifications(new ClientValidation(this));

            return client;
        }
        public void UpdateProfession(string Profession)
        {
            this.Profession = Profession;
        }
        public void UpdateClientType(EClientType Type)
        {
            this.Type = Type;
        }
    }
    internal class ClientValidation : Contract<Client>
    {
        public ClientValidation(Client client)
        {
            Requires()
                .IsNotNullOrWhiteSpace(client.Name, "Name", "Name is Required")
                .IsEmail(client.Email, nameof(client.Email), "Email Invalid")
                .IsNotNullOrWhiteSpace(client.Profession,nameof(client.Profession),"Profession is Required")
                .IsTrue(Enum.IsDefined(typeof(EClientType),client.Type),nameof(client.Type),"Type is not Valid");
        }
    }
}
