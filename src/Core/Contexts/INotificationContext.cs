using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Contexts
{
    public interface INotificationContext
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool HasNotifications { get; }
        bool IsEmpty { get; }
        void AddNotification(string key, string message);

        void AddNotification(Notification notification);

        void AddNotifications(ValidationResult validationResult);

        void ClearNotifications();
    }
}
