namespace ViewModels.Services;

public interface IWindowService
{
    void ShowWindow(BaseWindowVM windowVM);

    void CloseWindow(BaseWindowVM windowVM);
}
