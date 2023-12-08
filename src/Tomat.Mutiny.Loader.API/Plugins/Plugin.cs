using Tomat.Mutiny.Loader.API.Runtimes;

namespace Tomat.Mutiny.Loader.API.Plugins;

/// <summary>
///     A loader plugin, which is responsible for extending the Mutiny Loader
///     with additional functionality. They may be responsible for hooking into
///     and transforming assemblies as they're loaded, loading assemblies from
///     mod loader implementations, and more.
/// </summary>
public interface IPlugin {
    /// <summary>
    ///     Called when the plugin is first loaded.
    /// </summary>
    /// <param name="runtime">The runtime environment.</param>
    /// <remarks>
    ///     This is a generic entrypoint called when the plugin is first loaded
    ///     and provides no particular API guarantees. Use only for very simple
    ///     and early initialization logic, preferably logic that does not
    ///     require any other plugins or loader components to be loaded.
    /// </remarks>
    void OnLoad(IRuntime runtime);
}
