using MudBlazor;

namespace ElectroHub.WebUI.Common.Services;

public interface ISnackbarService
{
    void ShowSuccessSnackbar(string message);
    void ShowInformationSnackbar(string message);
    void ShowErrorSnackbar(string message);
}

public sealed class SnackbarService : ISnackbarService
{
    private readonly ISnackbar _snackbar;

    public SnackbarService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
        _snackbar.Configuration.PreventDuplicates = true;
        _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomCenter;
        _snackbar.Configuration.VisibleStateDuration = 4000;
        _snackbar.Configuration.ShowTransitionDuration = 250;
        _snackbar.Configuration.HideTransitionDuration = 500;
    }

    public void ShowSuccessSnackbar(string message)
    {
        _snackbar.Add(message, Severity.Success);
    }

    public void ShowInformationSnackbar(string message)
    {
        _snackbar.Add(message, Severity.Info);
    }

    public void ShowErrorSnackbar(string message)
    {
        _snackbar.Add(message, Severity.Error);
    }
}