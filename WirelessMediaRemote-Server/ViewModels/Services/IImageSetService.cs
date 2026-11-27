using System.Windows.Media.Imaging;

namespace ViewModels.Services;

public interface IImageSetService
{
    List<string>? ImagePaths { get; }

    int CurrentIndex { get; }

    event Action? ImagePathsChanged;

    event Action? CurrentIndexChanged;
}
