using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Client.Markers;

public sealed class MarkerSystem : EntitySystem
{
    [Dependency] private readonly SpriteSystem _sprite = default!;

    private bool _markersVisible;

    public bool MarkersVisible
    {
        get => _markersVisible;
        set
        {
            _markersVisible = value;
            UpdateMarkers();
        }
    }

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<MarkerComponent, ComponentStartup>(OnStartup);
    }

    private void OnStartup(EntityUid uid, MarkerComponent marker, ComponentStartup args)
    {
        UpdateVisibility(uid);
    }

    private void UpdateVisibility(EntityUid uid)
    {
        if (TryComp(uid, out SpriteComponent? sprite))
        {
            _sprite.SetVisible((uid, sprite), MarkersVisible);
        }
    }

    private void UpdateMarkers()
    {
        var query = AllEntityQuery<MarkerComponent>();

        while (query.MoveNext(out var uid, out var comp))
        {
            UpdateVisibility(uid);
        }
    }
}
