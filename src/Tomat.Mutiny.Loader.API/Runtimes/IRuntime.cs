using System;

namespace Tomat.Mutiny.Loader.API.Runtimes;

/// <summary>
///     Represents an arbitrary runtime environment/host.
/// </summary>
public interface IRuntime {
    /// <summary>
    ///     The runtime name.
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The runtime version.
    /// </summary>
    Version Version { get; }
}
