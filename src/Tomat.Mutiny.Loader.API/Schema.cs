using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tomat.Mutiny.Loader.API;

public abstract class Schema {
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

    [JsonProperty("etc")]
    private Dictionary<string, object?> Etc { get; set; } = new();

    public static bool TryParse<T>(string json, [NotNullWhen(returnValue: true)] out T? schema) where T : Schema {
        schema = null;

        try {
            var jObject = JObject.Parse(json);
            if (!jObject.TryGetValue("schemaVersion", out var schemaVersionToken)) {
                return false;
            }

            if (schemaVersionToken.Type != JTokenType.Integer)
                return false;

            // Currently only 1 version, so we don't bother with special
            // parsing.
            var schemaVersion = schemaVersionToken.Value<int>();
            if (schemaVersion != 1)
                return false;

            schema = jObject.ToObject<T>();
            return schema is not null;
        }
        catch {
            return false;
        }
    }
}
