using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Wpf.AttachedBehaviors;

internal class LoadedAwareBehavior : Behavior<FrameworkElement>
{
    public static readonly DependencyProperty IsLoadedProperty = DependencyProperty.RegisterAttached(
        name: "IsLoaded",
        propertyType: typeof(bool),
        ownerType: typeof(LoadedAwareBehavior),
        defaultMetadata: new PropertyMetadata(defaultValue: false)
    );

    public bool IsLoaded
    {
        get { return (bool)GetValue(IsLoadedProperty); }
        set { SetValue(IsLoadedProperty, value); }
    }

    protected override void OnAttached()
    {
        AssociatedObject.Loaded += OnAttachedObjectLoaded;
        AssociatedObject.Unloaded += OnAttachedObjectUnloaded;

        IsLoaded = AssociatedObject.IsLoaded;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.Loaded -= OnAttachedObjectLoaded;
        AssociatedObject.Unloaded -= OnAttachedObjectUnloaded;
    }

    private void OnAttachedObjectLoaded(object sender, RoutedEventArgs e)
    {
        IsLoaded = true;
    }

    private void OnAttachedObjectUnloaded(object sender, RoutedEventArgs e)
    {
        IsLoaded = false;
    }
}
