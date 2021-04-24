using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Shared.Entity
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public Guid Id { get; private set; }
        public DateTime LastUpdated { get; private set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            LastUpdated = DateTime.Now;
        }
    }
}
