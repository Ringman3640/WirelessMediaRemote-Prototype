using ViewModels.Services;

namespace ManualTestApp.TestServices;

internal class ImageSetServicer : IImageSetService
{
    public List<string>? ImagePaths
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
    private List<string>? _imagePaths = null;

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

    public void NextIdx()
    {
        if (ImagePaths is null)
        {
            return;
        }
        if (CurrentIndex >= ImagePaths.Count)
        {
            return;
        }

        ++CurrentIndex;
    }

    public void PrevIdx()
    {
        if (ImagePaths is null)
        {
            return;
        }
        if (CurrentIndex <= 0)
        {
            return;
        }

        --CurrentIndex;
    }

    private int _currentIndex = 0;
    public event Action? CurrentIndexChanged = null;
    public event Action? ImagePathsChanged = null;

    public ImageSetServicer(List<string> imagePaths)
    {
        ImagePaths = imagePaths;
    }
}
