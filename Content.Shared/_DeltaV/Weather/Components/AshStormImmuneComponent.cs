using Robust.Shared.GameStates;

namespace Content.Shared._DeltaV.Weather.Components;

/// <summary>
/// Makes an entity not take damage from ash storms.
/// </summary>
[RegisterComponent, NetworkedComponent]
public sealed partial class AshStormImmuneComponent : Component;
