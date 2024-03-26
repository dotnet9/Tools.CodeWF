using System.Reactive.Concurrency;

namespace CodeWF.Tools.Desktop.Helpers;
public static class NotificationHelpers
{
    private const int DefaultNotificationTimeout = 10;
    private static WindowNotificationManager? NotificationManager;

    public static void SetNotificationManager(Visual host)
    {
        var notificationManager = new WindowNotificationManager(TopLevel.GetTopLevel(host))
        {
            Position = NotificationPosition.BottomRight,
            MaxItems = 4,
            Margin = new Thickness(0, 0, 15, 40)
        };

        NotificationManager = notificationManager;
    }

    public static void Show(string title, string message, Action? onClick = null)
    {
        if (NotificationManager is { } nm)
        {
            RxApp.MainThreadScheduler.Schedule(() => nm.Show(new Notification(title, message, NotificationType.Information, TimeSpan.FromSeconds(DefaultNotificationTimeout), onClick)));
        }
    }
}
