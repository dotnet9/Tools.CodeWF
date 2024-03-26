using Avalonia.Xaml.Interactions.Custom;
using CodeWF.Tools.Desktop.Helpers;
using System.Reactive.Disposables;

namespace CodeWF.Tools.Desktop.Behaviors;

public class RegisterNotificationHostBehavior : AttachedToVisualTreeBehavior<Visual>
{
    protected override void OnAttachedToVisualTree(CompositeDisposable disposable)
    {
        if (AssociatedObject is null)
        {
            return;
        }

        NotificationHelpers.SetNotificationManager(AssociatedObject);
    }
}