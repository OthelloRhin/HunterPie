using HunterPie.Core.Architecture;
using HunterPie.Core.Client.Configuration.Overlay;
using HunterPie.UI.Overlay.Enums;
using HunterPie.UI.Overlay.ViewModels;
using System;
using System.Globalization;
using System.Collections.ObjectModel;

namespace HunterPie.UI.Overlay.Widgets.Clock.ViewModels;

#nullable enable
public class ClockViewModel : WidgetViewModel
{
    private readonly ClockWidgetConfig _config;
    private string _worldTimeFormattedCache = string.Empty;

    public ClockViewModel(ClockWidgetConfig config) : base(config, "Clock Widget", WidgetType.ClickThrough)
    {
        _config = config;

        // when the user toggles the format in settings, update the displayed string
        _config.Use24HourFormat.PropertyChanged += (s, e) =>
            SetValue(ref _worldTimeFormattedCache, WorldTimeFormatted, nameof(WorldTimeFormatted));

        // initialize formatted cache so binding has a value immediately
        SetValue(ref _worldTimeFormattedCache, WorldTimeFormatted, nameof(WorldTimeFormatted));
    }
    
    public TimeOnly WorldTime { get; set => SetValueThenExecute(ref field, value, () => SetValue(ref _worldTimeFormattedCache, WorldTimeFormatted, nameof(WorldTimeFormatted))); }

    public string WorldTimeFormatted => _config.Use24HourFormat.Value
        ? WorldTime.ToString("HH:mm")
        : WorldTime.ToString("hh:mm tt", new CultureInfo("en-US"));

    public TimeSpan? QuestTimeLeft { get; set => SetValue(ref field, value); } 

    public ObservableCollection<MoonViewModel> Moons { get; } = new();
    public MoonViewModel? Moon { get; set => SetValue(ref field, value); }

    public Observable<bool> IsMoonPhaseEnabled => _config.IsMoonPhaseEnabled;
    public Observable<bool> Use24HourFormat => _config.Use24HourFormat;
}
