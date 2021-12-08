using FluentValidation.Results;

namespace Core.Contexts;

public class NotificationContext : INotificationContext
{
    private readonly List<Notification> _notifications = new();
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
    public bool HasNotifications => Notifications.Any();
    public bool IsEmpty => !HasNotifications;

    public void AddNotification(string key, string message)
    {
        AddNotification(new Notification(key, message));
    }

    public void AddNotification(Notification message)
    {
        _notifications.Add(message);
    }

    public void AddNotifications(ValidationResult validationResult)
    {
        AddNotification(validationResult.Errors.Select(x => new Notification(x.PropertyName, x.ErrorMessage)));
    }

    public void ClearNotifications()
    {
        _notifications.Clear();
    }

    public void AddNotification(IEnumerable<Notification> message)
    {
        _notifications.AddRange(message);
    }
}