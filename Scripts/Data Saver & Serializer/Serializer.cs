using System.IO;
using System.Xml.Serialization;

/// <summary>
/// Serialize and deserialize the data to save it into storage.
/// This serializer is wrote by Epitome on youtube.
/// </summary>
public static class Serializer
{
    //Serialize
    public static string Serialize<T>(this T toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    //Deserialize
    public static T Deserialize<T>(this string toDeserialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(toDeserialize);
        return (T)xml.Deserialize(reader);
    }
}