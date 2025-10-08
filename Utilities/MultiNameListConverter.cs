using System.Text.Json;
using System.Text.Json.Serialization;

namespace FEBookStoreManagement.Utilities;

public class MultiNameListConverter<T> : JsonConverter<List<T>?>
{
    private readonly string[] _propertyNames;

    public MultiNameListConverter(params string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    public override List<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var document = JsonDocument.ParseValue(ref reader))
        {
            foreach (var name in _propertyNames)
                if (document.RootElement.TryGetProperty(name, out var element))
                    return JsonSerializer.Deserialize<List<T>>(element.GetRawText(), options);
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, List<T>? value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}