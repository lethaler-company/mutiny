using System;
using System.Reflection;

namespace Tomat.Mutiny.Loader.API.Plugins;

/// <summary>
///     Marks a class as a plugin.
/// </summary>
public abstract class AbstractPluginAttribute : Attribute {
    private string Name { get; }

    private string Group { get; }

    private Version Version { get; }

    protected AbstractPluginAttribute(string name, string group, Version version) {
        Name = name;
        Group = group;
        Version = version;
    }

    /// <summary>
    ///     Converts this attribute to a <see cref="PluginMetadata"/> instance.
    /// </summary>
    /// <returns>
    ///     The <see cref="PluginMetadata"/> instance.
    /// </returns>
    /// <remarks>
    ///     This is how data within the attribute should be accessed.
    /// </remarks>
    public PluginMetadata AsMetadata() {
        return new PluginMetadata(Name, Group, Version);
    }
}

/// <summary>
///     The default <see cref="AbstractPluginAttribute"/> implementation.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class PluginAttribute : AbstractPluginAttribute {
    public PluginAttribute(string name, string group, int major, int minor, int build = 0, int revision = 0) : base(name, group, new Version(major, minor, build, revision)) { }

    public PluginAttribute(string name, string group, string version) : base(name, group, Version.Parse(version)) { }
}

/// <summary>
///     A <see cref="AbstractPluginAttribute"/> which special logic for
///     automatically resolving a plugin version from the assembly version.
/// </summary>
/// <remarks>
///     This class itself contains no particular, special logic; the
///     implementation is handled specially by the loader.
/// </remarks>
public sealed class PluginUsesAssemblyVersionAttribute : AbstractPluginAttribute {
    public PluginUsesAssemblyVersionAttribute(string name, string group) : base(name, group, new Version()) { }

    private PluginUsesAssemblyVersionAttribute(string name, string group, Assembly assembly) : base(name, group, assembly.GetName().Version) { }

    public AbstractPluginAttribute WithAssembly(Assembly assembly) {
        var metadata = AsMetadata();
        return new PluginUsesAssemblyVersionAttribute(metadata.Name, metadata.Group, assembly);
    }
}
