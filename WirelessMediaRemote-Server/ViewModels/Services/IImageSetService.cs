using System.Windows.Media.Imaging;

namespace ViewModels.Services;

public interface IImageSetService
{
    List<string> ImagePaths { get; }

    int CurrentIndex { get; }

    delegate void OnCurrentIndexChanged(int newIndex);

    event OnCurrentIndexChanged? CurrentIndexChanged;
}
