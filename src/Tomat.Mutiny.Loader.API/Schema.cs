using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tomat.Mutiny.Loader.API;

/// <summary>
///     An abstract schema object.
/// </summary>
public abstract class Schema<T> {
    public sealed class SchemaMetadata {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        // Fabric specifies a list of valid contact keys, I don't...
        [JsonProperty("contact")]
        public Dictionary<string, string> Contact { get; set; } = new();

        [JsonProperty("authors")]
        public List<SchemaAuthor> Authors { get; set; } = new();

        [JsonProperty("contributors")]
        public List<SchemaAuthor> Contributors { get; set; } = new();
    }

    public sealed class SchemaDependencies {
        [JsonProperty("provides")]
        public List<SchemaDependency> Provides { get; set; } = new();

        [JsonProperty("depends")]
        public List<SchemaDependency> Depends { get; set; } = new();

        [JsonProperty("recommends")]
        public List<SchemaDependency> Recommends { get; set; } = new();

        [JsonProperty("suggests")]
        public List<SchemaDependency> Suggests { get; set; } = new();

        [JsonProperty("breaks")]
        public List<SchemaDependency> Breaks { get; set; } = new();

        [JsonProperty("conflicts")]
        public List<SchemaDependency> Conflicts { get; set; } = new();
    }

    public sealed class SchemaAuthor {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        // Fabric specifies a list of valid contact keys, I don't...
        [JsonProperty("contact")]
        public Dictionary<string, string> Contact { get; set; } = new();
    }

    public sealed class SchemaDependency {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        // version range
        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }

    [JsonProperty("schemaVersion")]
    public int SchemaVersion { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("version")]
    public string Version { get; set; } = string.Empty;

    [JsonProperty("metadata")]
    public SchemaMetadata Metadata { get; set; } = new();

    [JsonProperty("dependencies")]
    public SchemaDependencies Dependencies { get; set; } = new();

    [JsonIgnore]
    public T? Object { get; set; }
}
