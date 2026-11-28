using Microsoft.Xaml.Behaviors;
using System.Windows;

namespace Wpf.AttachedBehaviors;

class SizeAwareBehavior : Behavior<FrameworkElement>
{
    public static readonly DependencyProperty ElementSizeProperty = DependencyProperty.Register(
        name: "ElementSize",
        propertyType: typeof(Size),
        ownerType: typeof(SizeAwareBehavior),
        typeMetadata: new PropertyMetadata(defaultValue: default(Size))
    );

    public Size ElementSize
    {
        get { return (Size)GetValue(ElementSizeProperty); }
        set { SetValue(ElementSizeProperty, value); }
    }

    protected override void OnAttached()
    {
        AssociatedObject.SizeChanged += AssociatedObjectSizeChanged;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.SizeChanged -= AssociatedObjectSizeChanged;
    }

    private void AssociatedObjectSizeChanged(object sender, SizeChangedEventArgs e)
    {
        ElementSize = e.NewSize;
    }
}
