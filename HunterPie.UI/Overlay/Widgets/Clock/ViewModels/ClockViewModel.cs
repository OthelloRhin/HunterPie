using HunterPie.Core.Architecture;
using HunterPie.Core.Client.Configuration.Overlay;
using HunterPie.UI.Overlay.Enums;
using HunterPie.UI.Overlay.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace HunterPie.UI.Overlay.Widgets.Clock.ViewModels;

#nullable enable
public class ClockViewModel : WidgetViewModel
{
    private readonly ClockWidgetConfig _config;

    public ClockViewModel(ClockWidgetConfig config)
        : base(config, "Clock Widget", WidgetType.ClickThrough)
    {
        _config = config;
    }

    public TimeOnly WorldTime
    {
        get => field;
        set => SetValue(ref field, value);
    }

    public Observable<bool> Use24HourFormat => _config.Use24HourFormat;

    public TimeSpan? QuestTimeLeft
    {
        get => field;
        set => SetValue(ref field, value);
    }

    public ObservableCollection<MoonViewModel> Moons { get; } = new();

    public MoonViewModel? Moon
    {
        get => field;
        set => SetValue(ref field, value);
    }

    public Observable<bool> IsMoonPhaseEnabled => _config.IsMoonPhaseEnabled;
}