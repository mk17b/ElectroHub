using MudBlazor;

namespace ElectroHub.WebUI.Common.Configuration;

public class AppTheme : MudTheme
{
    public AppTheme()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#1976D2",
            Secondary = "#424242",
            Background = "#F5F5F5",
            Surface = "#FFFFFF",
            AppbarBackground = "#1976D2",
            DrawerBackground = "#F5F5F5",
            DrawerText = "#424242",
            TextPrimary = "#212121",
            TextSecondary = "#757575",
            ActionDefault = "#424242",
            ActionDisabled = "#BDBDBD",
            ActionDisabledBackground = "#E0E0E0"
        };

        PaletteDark = new PaletteDark
        {
            Primary = "#90CAF9",
            Secondary = "#9E9E9E",
            Background = "#121212",
            Surface = "#1E1E1E",
            AppbarBackground = "#1F1F1F",
            DrawerBackground = "#1E1E1E",
            DrawerText = "#E0E0E0",
            TextPrimary = "#F5F5F5",
            TextSecondary = "#B0BEC5",
            ActionDefault = "#E0E0E0",
            ActionDisabled = "#757575",
            ActionDisabledBackground = "#424242"
        };

        LayoutProperties = new LayoutProperties
        {
            DefaultBorderRadius = "8px"
        };

        Typography = new Typography
        {
            Default = new DefaultTypography
            {
                FontFamily = ["Roboto", "Helvetica", "Arial", "sans-serif"]
            }
        };
    }
}