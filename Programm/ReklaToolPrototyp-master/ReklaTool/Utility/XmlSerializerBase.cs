using System.Xml.Serialization;

namespace ReklaTool.Utility;

public abstract class XmlSerializerBase
{
    public virtual string ToXML()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(GetType());
        StringWriter stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, this);
        string result = stringWriter.ToString();
        result = result.Replace("encoding=\"utf-16\"?>", "encoding=\"utf-8\"?>");
        return result;
    }
}