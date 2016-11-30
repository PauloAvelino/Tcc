using System;
using System.Xml;
using System.Xml.Serialization;

namespace SGSI.Data
{
    public sealed class CommentWrapper : IXmlSerializable
    {
        // implicit to/from string
        public static implicit operator string(CommentWrapper value)
        {
            return value == null ? null : value.Value;
        }
        public static implicit operator CommentWrapper(string value)
        {
            return value == null ? null : new CommentWrapper
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
                writer.WriteComment(Value);
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
                //string doc = reader.ReadOuterXml();
                //Value = ((XComment)XDocument.Parse(doc).Elements().First().FirstNode).Value;
                switch (reader.NodeType)
                {
                    case XmlNodeType.EndElement:
                        Value = ""; // empty after all...
                        break;
                    case XmlNodeType.Text:
                    case XmlNodeType.CDATA:
                        Value = reader.ReadContentAsString();
                        break;
                    case XmlNodeType.Comment:
                        Value = reader.Value;
                        //utilizado para avançar
                        reader.ReadContentAsString();
                        break;
                    default:
                        throw new InvalidOperationException("Expected text cdata");
                }
                reader.Skip();
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
