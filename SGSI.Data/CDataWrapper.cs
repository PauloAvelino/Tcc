using System;
using System.Xml;
using System.Xml.Serialization;

namespace SGSI.Data
{
    public sealed class CDataWrapper : IXmlSerializable
    {
        // implicit to/from string
        public static implicit operator string(CDataWrapper value)
        {
            return value == null ? null : value.Value;
        }
        public static implicit operator CDataWrapper(string value)
        {
            return value == null ? null : new CDataWrapper
            {
                Value = value
            };
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        // "" => <Node/>
        // "Foo" => <Node><![CDATA[Foo]]></Node>
        public void WriteXml(XmlWriter writer)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                writer.WriteCData(Value);
            }
        }
        // <Node/> => ""
        // <Node></Node> => ""
        // <Node>Foo</Node> => "Foo"
        // <Node><![CDATA[Foo]]></Node> => "Foo"
        public void ReadXml(XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                Value = "";
            }
            else
            {
                reader.Read();
                switch (reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        Value = ""; // empty after all...
                        break;
                    case XmlNodeType.Text:
                    case XmlNodeType.CDATA:
                        Value = reader.ReadContentAsString();
                        break;

                    default:
                        throw new InvalidOperationException("Expected text cdata");
                }
            }
        }
        // underlying value
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
