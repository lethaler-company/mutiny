using System;

namespace Tomat.Mutiny.Loader.API.Plugins;

/// <summary>
///     On-load plugin metadata.
/// </summary>
/// <param name="Name">The plugin name.</param>
/// <param name="Group">The plugin group.</param>
/// <param name="Version">The plugin version.</param>
public readonly record struct PluginMetadata(string Name, string Group, Version Version);
