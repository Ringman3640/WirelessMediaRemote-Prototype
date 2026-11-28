using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Wpf.AttachedBehaviors;

internal class LoadedAwareBehavior : Behavior<FrameworkElement>
{
    public static readonly DependencyProperty LoadedStateProperty = DependencyProperty.RegisterAttached(
        name: "LoadedState",
        propertyType: typeof(bool),
        ownerType: typeof(LoadedAwareBehavior),
        defaultMetadata: new PropertyMetadata(defaultValue: false)
    );

    protected override void OnAttached()
    {
        AssociatedObject.Loaded += OnAttachedObjectLoaded;
        AssociatedObject.Unloaded += OnAttachedObjectUnloaded;

        SetValue(LoadedStateProperty, AssociatedObject.IsLoaded);
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Loaded -= OnAttachedObjectLoaded;
        AssociatedObject.Unloaded -= OnAttachedObjectUnloaded;
    }

    private void OnAttachedObjectLoaded(object sender, RoutedEventArgs e)
    {
        SetValue(LoadedStateProperty, true);
    }

    private void OnAttachedObjectUnloaded(object sender, RoutedEventArgs e)
    {
        SetValue(LoadedStateProperty, false);
    }
}
