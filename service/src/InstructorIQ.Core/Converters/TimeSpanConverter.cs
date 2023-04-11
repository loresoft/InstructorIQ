using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InstructorIQ.Core.Converters;

public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        return TimeSpan.Parse(stringValue);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        var stringValue = value.ToString();
        writer.WriteStringValue(stringValue);
    }
}
