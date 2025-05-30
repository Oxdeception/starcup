﻿using Content.Shared.Chemistry.Components;
using Robust.Shared.GameStates;

namespace Content.Shared._EinsteinEngines.FootPrint;

/// <summary>
///     This is used for marking footsteps, handling footprint drawing.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class FootPrintComponent : Component
{
    /// <summary>
    ///     Owner (with <see cref="FootPrintsComponent"/>) of a print (this component).
    /// </summary>
    [AutoNetworkedField]
    public EntityUid PrintOwner;

    [DataField]
    public string SolutionName = "step";

    [ViewVariables]
    public Entity<SolutionComponent>? Solution;
}
