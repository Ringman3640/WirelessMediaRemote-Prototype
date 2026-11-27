using CommunityToolkit.Mvvm.ComponentModel;
using ViewModels.Services;

namespace ViewModels.UserControls;

public partial class VideoDisplayVM : ObservableObject
{
    public VideoDisplayVM(IMediaPlayerService mediaPlayerService)
    {
        
    }
}
