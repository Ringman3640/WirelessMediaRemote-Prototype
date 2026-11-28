using ViewModels.Services;

namespace ManualTestApp.TestServices;

internal class ImageSetServicer : IImageSetService
{
    public List<string> ImagePaths
    {
        get { return _imagePaths; }
        set
        {
            if (value != _imagePaths)
            {
                _imagePaths = value;
                _currentIndex = 0;
                ImagePathsChanged?.Invoke();
                CurrentIndexChanged?.Invoke();
            }
        }
    }
    private List<string> _imagePaths = [];

    public int CurrentIndex
    {
        get { return _currentIndex; }
        set
        {
            if (value != _currentIndex)
            {
                _currentIndex = value;
                CurrentIndexChanged?.Invoke();
            }
        }
    }

    private int _currentIndex = 0;
    public event Action? CurrentIndexChanged = null;
    public event Action? ImagePathsChanged = null;

    public ImageSetServicer(List<string> imagePaths)
    {
        ImagePaths = imagePaths;
    }
}
