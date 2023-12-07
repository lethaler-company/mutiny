using Tomat.Mutiny.Loader.API.Plugins;

namespace Tomat.Mutiny;

/// <summary>
///     The Mutiny plugin implementation for regular Mutiny mods.
/// </summary>
[PluginUsesAssemblyVersion("dev.tomat", "Mutiny")]
internal sealed class MutinyPlugin : IPlugin {
    PluginMetadata IPlugin.Metadata { get; set; }

    void IPlugin.OnLoad() { }
}
