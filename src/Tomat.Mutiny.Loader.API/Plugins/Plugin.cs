﻿namespace Tomat.Mutiny.Loader.API.Plugins;

/// <summary>
///     A loader plugin, which is responsible for extending the Mutiny Loader
///     with additional functionality. They may be responsible for hooking into
///     and transforming assemblies as they're loaded, loading assemblies from
///     mod loader implementations, and more.
/// </summary>
public interface IPlugin {
    /// <summary>
    ///     The plugin metadata.
    /// </summary>
    PluginMetadata Metadata { get; set; }

    /// <summary>
    ///     Called when the plugin is first loaded.
    /// </summary>
    /// <remarks>
    ///     This is a generic entrypoint called when the plugin is first loaded
    ///     and provides no particular API guarantees. Use only for very simple
    ///     and early initialization logic, preferably logic that does not
    ///     require any other plugins or loader components to be loaded.
    /// </remarks>
    void OnLoad();
}