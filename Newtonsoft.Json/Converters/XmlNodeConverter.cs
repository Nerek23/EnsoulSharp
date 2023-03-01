using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Converters
{
	// Token: 0x02000101 RID: 257
	[NullableContext(1)]
	[Nullable(0)]
	public class XmlNodeConverter : JsonConverter
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x0003377B File Offset: 0x0003197B
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x00033783 File Offset: 0x00031983
		[Nullable(2)]
		public string DeserializeRootElementName { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x0003378C File Offset: 0x0003198C
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x00033794 File Offset: 0x00031994
		public bool WriteArrayAttribute { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x0003379D File Offset: 0x0003199D
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x000337A5 File Offset: 0x000319A5
		public bool OmitRootObject { get; set; }

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000D27 RID: 3367 RVA: 0x000337AE File Offset: 0x000319AE
		// (set) Token: 0x06000D28 RID: 3368 RVA: 0x000337B6 File Offset: 0x000319B6
		public bool EncodeSpecialCharacters { get; set; }

		// Token: 0x06000D29 RID: 3369 RVA: 0x000337C0 File Offset: 0x000319C0
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}
			IXmlNode node = this.WrapXml(value);
			XmlNamespaceManager manager = new XmlNamespaceManager(new NameTable());
			this.PushParentNamespaces(node, manager);
			if (!this.OmitRootObject)
			{
				writer.WriteStartObject();
			}
			this.SerializeNode(writer, node, manager, !this.OmitRootObject);
			if (!this.OmitRootObject)
			{
				writer.WriteEndObject();
			}
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00033820 File Offset: 0x00031A20
		private IXmlNode WrapXml(object value)
		{
			XObject xobject = value as XObject;
			if (xobject != null)
			{
				return XContainerWrapper.WrapNode(xobject);
			}
			XmlNode xmlNode = value as XmlNode;
			if (xmlNode != null)
			{
				return XmlNodeWrapper.WrapNode(xmlNode);
			}
			throw new ArgumentException("Value must be an XML object.", "value");
		}

		// Token: 0x06000D2B RID: 3371 RVA: 0x00033860 File Offset: 0x00031A60
		private void PushParentNamespaces(IXmlNode node, XmlNamespaceManager manager)
		{
			List<IXmlNode> list = null;
			IXmlNode xmlNode = node;
			while ((xmlNode = xmlNode.ParentNode) != null)
			{
				if (xmlNode.NodeType == XmlNodeType.Element)
				{
					if (list == null)
					{
						list = new List<IXmlNode>();
					}
					list.Add(xmlNode);
				}
			}
			if (list != null)
			{
				list.Reverse();
				foreach (IXmlNode xmlNode2 in list)
				{
					manager.PushScope();
					foreach (IXmlNode xmlNode3 in xmlNode2.Attributes)
					{
						if (xmlNode3.NamespaceUri == "http://www.w3.org/2000/xmlns/" && xmlNode3.LocalName != "xmlns")
						{
							manager.AddNamespace(xmlNode3.LocalName, xmlNode3.Value);
						}
					}
				}
			}
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00033958 File Offset: 0x00031B58
		private string ResolveFullName(IXmlNode node, XmlNamespaceManager manager)
		{
			string text = (node.NamespaceUri == null || (node.LocalName == "xmlns" && node.NamespaceUri == "http://www.w3.org/2000/xmlns/")) ? null : manager.LookupPrefix(node.NamespaceUri);
			if (!StringUtils.IsNullOrEmpty(text))
			{
				return text + ":" + XmlConvert.DecodeName(node.LocalName);
			}
			return XmlConvert.DecodeName(node.LocalName);
		}

		// Token: 0x06000D2D RID: 3373 RVA: 0x000339CC File Offset: 0x00031BCC
		private string GetPropertyName(IXmlNode node, XmlNamespaceManager manager)
		{
			switch (node.NodeType)
			{
			case XmlNodeType.Element:
				if (node.NamespaceUri == "http://james.newtonking.com/projects/json")
				{
					return "$" + node.LocalName;
				}
				return this.ResolveFullName(node, manager);
			case XmlNodeType.Attribute:
				if (node.NamespaceUri == "http://james.newtonking.com/projects/json")
				{
					return "$" + node.LocalName;
				}
				return "@" + this.ResolveFullName(node, manager);
			case XmlNodeType.Text:
				return "#text";
			case XmlNodeType.CDATA:
				return "#cdata-section";
			case XmlNodeType.ProcessingInstruction:
				return "?" + this.ResolveFullName(node, manager);
			case XmlNodeType.Comment:
				return "#comment";
			case XmlNodeType.DocumentType:
				return "!" + this.ResolveFullName(node, manager);
			case XmlNodeType.Whitespace:
				return "#whitespace";
			case XmlNodeType.SignificantWhitespace:
				return "#significant-whitespace";
			case XmlNodeType.XmlDeclaration:
				return "?xml";
			}
			throw new JsonSerializationException("Unexpected XmlNodeType when getting node name: " + node.NodeType.ToString());
		}

		// Token: 0x06000D2E RID: 3374 RVA: 0x00033B00 File Offset: 0x00031D00
		private bool IsArray(IXmlNode node)
		{
			foreach (IXmlNode xmlNode in node.Attributes)
			{
				if (xmlNode.LocalName == "Array" && xmlNode.NamespaceUri == "http://james.newtonking.com/projects/json")
				{
					return XmlConvert.ToBoolean(xmlNode.Value);
				}
			}
			return false;
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x00033B84 File Offset: 0x00031D84
		private void SerializeGroupedNodes(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName)
		{
			int count = node.ChildNodes.Count;
			if (count != 0)
			{
				if (count == 1)
				{
					string propertyName = this.GetPropertyName(node.ChildNodes[0], manager);
					this.WriteGroupedNodes(writer, manager, writePropertyName, node.ChildNodes, propertyName);
					return;
				}
				Dictionary<string, object> dictionary = null;
				string text = null;
				for (int i = 0; i < node.ChildNodes.Count; i++)
				{
					IXmlNode xmlNode = node.ChildNodes[i];
					string propertyName2 = this.GetPropertyName(xmlNode, manager);
					object obj;
					if (dictionary == null)
					{
						if (text == null)
						{
							text = propertyName2;
						}
						else if (!(propertyName2 == text))
						{
							dictionary = new Dictionary<string, object>();
							if (i > 1)
							{
								List<IXmlNode> list = new List<IXmlNode>(i);
								for (int j = 0; j < i; j++)
								{
									list.Add(node.ChildNodes[j]);
								}
								dictionary.Add(text, list);
							}
							else
							{
								dictionary.Add(text, node.ChildNodes[0]);
							}
							dictionary.Add(propertyName2, xmlNode);
						}
					}
					else if (!dictionary.TryGetValue(propertyName2, out obj))
					{
						dictionary.Add(propertyName2, xmlNode);
					}
					else
					{
						List<IXmlNode> list2 = obj as List<IXmlNode>;
						if (list2 == null)
						{
							list2 = new List<IXmlNode>
							{
								(IXmlNode)obj
							};
							dictionary[propertyName2] = list2;
						}
						list2.Add(xmlNode);
					}
				}
				if (dictionary == null)
				{
					this.WriteGroupedNodes(writer, manager, writePropertyName, node.ChildNodes, text);
					return;
				}
				foreach (KeyValuePair<string, object> keyValuePair in dictionary)
				{
					List<IXmlNode> list3 = keyValuePair.Value as List<IXmlNode>;
					if (list3 != null)
					{
						this.WriteGroupedNodes(writer, manager, writePropertyName, list3, keyValuePair.Key);
					}
					else
					{
						this.WriteGroupedNodes(writer, manager, writePropertyName, (IXmlNode)keyValuePair.Value, keyValuePair.Key);
					}
				}
			}
		}

		// Token: 0x06000D30 RID: 3376 RVA: 0x00033D6C File Offset: 0x00031F6C
		private void WriteGroupedNodes(JsonWriter writer, XmlNamespaceManager manager, bool writePropertyName, List<IXmlNode> groupedNodes, string elementNames)
		{
			if (groupedNodes.Count == 1 && !this.IsArray(groupedNodes[0]))
			{
				this.SerializeNode(writer, groupedNodes[0], manager, writePropertyName);
				return;
			}
			if (writePropertyName)
			{
				writer.WritePropertyName(elementNames);
			}
			writer.WriteStartArray();
			for (int i = 0; i < groupedNodes.Count; i++)
			{
				this.SerializeNode(writer, groupedNodes[i], manager, false);
			}
			writer.WriteEndArray();
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00033DE2 File Offset: 0x00031FE2
		private void WriteGroupedNodes(JsonWriter writer, XmlNamespaceManager manager, bool writePropertyName, IXmlNode node, string elementNames)
		{
			if (!this.IsArray(node))
			{
				this.SerializeNode(writer, node, manager, writePropertyName);
				return;
			}
			if (writePropertyName)
			{
				writer.WritePropertyName(elementNames);
			}
			writer.WriteStartArray();
			this.SerializeNode(writer, node, manager, false);
			writer.WriteEndArray();
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00033E1C File Offset: 0x0003201C
		private void SerializeNode(JsonWriter writer, IXmlNode node, XmlNamespaceManager manager, bool writePropertyName)
		{
			switch (node.NodeType)
			{
			case XmlNodeType.Element:
				if (this.IsArray(node) && XmlNodeConverter.AllSameName(node) && node.ChildNodes.Count > 0)
				{
					this.SerializeGroupedNodes(writer, node, manager, false);
					return;
				}
				manager.PushScope();
				foreach (IXmlNode xmlNode in node.Attributes)
				{
					if (xmlNode.NamespaceUri == "http://www.w3.org/2000/xmlns/")
					{
						string prefix = (xmlNode.LocalName != "xmlns") ? XmlConvert.DecodeName(xmlNode.LocalName) : string.Empty;
						string value = xmlNode.Value;
						if (value == null)
						{
							throw new JsonSerializationException("Namespace attribute must have a value.");
						}
						manager.AddNamespace(prefix, value);
					}
				}
				if (writePropertyName)
				{
					writer.WritePropertyName(this.GetPropertyName(node, manager));
				}
				if (!this.ValueAttributes(node.Attributes) && node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
				{
					writer.WriteValue(node.ChildNodes[0].Value);
				}
				else if (node.ChildNodes.Count == 0 && node.Attributes.Count == 0)
				{
					if (((IXmlElement)node).IsEmpty)
					{
						writer.WriteNull();
					}
					else
					{
						writer.WriteValue(string.Empty);
					}
				}
				else
				{
					writer.WriteStartObject();
					for (int i = 0; i < node.Attributes.Count; i++)
					{
						this.SerializeNode(writer, node.Attributes[i], manager, true);
					}
					this.SerializeGroupedNodes(writer, node, manager, true);
					writer.WriteEndObject();
				}
				manager.PopScope();
				return;
			case XmlNodeType.Attribute:
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if (node.NamespaceUri == "http://www.w3.org/2000/xmlns/" && node.Value == "http://james.newtonking.com/projects/json")
				{
					return;
				}
				if (node.NamespaceUri == "http://james.newtonking.com/projects/json" && node.LocalName == "Array")
				{
					return;
				}
				if (writePropertyName)
				{
					writer.WritePropertyName(this.GetPropertyName(node, manager));
				}
				writer.WriteValue(node.Value);
				return;
			case XmlNodeType.Comment:
				if (writePropertyName)
				{
					writer.WriteComment(node.Value);
					return;
				}
				return;
			case XmlNodeType.Document:
			case XmlNodeType.DocumentFragment:
				this.SerializeGroupedNodes(writer, node, manager, writePropertyName);
				return;
			case XmlNodeType.DocumentType:
			{
				IXmlDocumentType xmlDocumentType = (IXmlDocumentType)node;
				writer.WritePropertyName(this.GetPropertyName(node, manager));
				writer.WriteStartObject();
				if (!StringUtils.IsNullOrEmpty(xmlDocumentType.Name))
				{
					writer.WritePropertyName("@name");
					writer.WriteValue(xmlDocumentType.Name);
				}
				if (!StringUtils.IsNullOrEmpty(xmlDocumentType.Public))
				{
					writer.WritePropertyName("@public");
					writer.WriteValue(xmlDocumentType.Public);
				}
				if (!StringUtils.IsNullOrEmpty(xmlDocumentType.System))
				{
					writer.WritePropertyName("@system");
					writer.WriteValue(xmlDocumentType.System);
				}
				if (!StringUtils.IsNullOrEmpty(xmlDocumentType.InternalSubset))
				{
					writer.WritePropertyName("@internalSubset");
					writer.WriteValue(xmlDocumentType.InternalSubset);
				}
				writer.WriteEndObject();
				return;
			}
			case XmlNodeType.XmlDeclaration:
			{
				IXmlDeclaration xmlDeclaration = (IXmlDeclaration)node;
				writer.WritePropertyName(this.GetPropertyName(node, manager));
				writer.WriteStartObject();
				if (!StringUtils.IsNullOrEmpty(xmlDeclaration.Version))
				{
					writer.WritePropertyName("@version");
					writer.WriteValue(xmlDeclaration.Version);
				}
				if (!StringUtils.IsNullOrEmpty(xmlDeclaration.Encoding))
				{
					writer.WritePropertyName("@encoding");
					writer.WriteValue(xmlDeclaration.Encoding);
				}
				if (!StringUtils.IsNullOrEmpty(xmlDeclaration.Standalone))
				{
					writer.WritePropertyName("@standalone");
					writer.WriteValue(xmlDeclaration.Standalone);
				}
				writer.WriteEndObject();
				return;
			}
			}
			throw new JsonSerializationException("Unexpected XmlNodeType when serializing nodes: " + node.NodeType.ToString());
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x00034224 File Offset: 0x00032424
		private static bool AllSameName(IXmlNode node)
		{
			using (List<IXmlNode>.Enumerator enumerator = node.ChildNodes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.LocalName != node.LocalName)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000D34 RID: 3380 RVA: 0x00034288 File Offset: 0x00032488
		[return: Nullable(2)]
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer)
		{
			JsonToken tokenType = reader.TokenType;
			if (tokenType != JsonToken.StartObject)
			{
				if (tokenType == JsonToken.Null)
				{
					return null;
				}
				throw JsonSerializationException.Create(reader, "XmlNodeConverter can only convert JSON that begins with an object.");
			}
			else
			{
				XmlNamespaceManager manager = new XmlNamespaceManager(new NameTable());
				IXmlDocument xmlDocument = null;
				IXmlNode xmlNode = null;
				if (typeof(XObject).IsAssignableFrom(objectType))
				{
					if (objectType != typeof(XContainer) && objectType != typeof(XDocument) && objectType != typeof(XElement) && objectType != typeof(XNode) && objectType != typeof(XObject))
					{
						throw JsonSerializationException.Create(reader, "XmlNodeConverter only supports deserializing XDocument, XElement, XContainer, XNode or XObject.");
					}
					xmlDocument = new XDocumentWrapper(new XDocument());
					xmlNode = xmlDocument;
				}
				if (typeof(XmlNode).IsAssignableFrom(objectType))
				{
					if (objectType != typeof(XmlDocument) && objectType != typeof(XmlElement) && objectType != typeof(XmlNode))
					{
						throw JsonSerializationException.Create(reader, "XmlNodeConverter only supports deserializing XmlDocument, XmlElement or XmlNode.");
					}
					xmlDocument = new XmlDocumentWrapper(new XmlDocument
					{
						XmlResolver = null
					});
					xmlNode = xmlDocument;
				}
				if (xmlDocument == null || xmlNode == null)
				{
					throw JsonSerializationException.Create(reader, "Unexpected type when converting XML: " + ((objectType != null) ? objectType.ToString() : null));
				}
				if (!StringUtils.IsNullOrEmpty(this.DeserializeRootElementName))
				{
					this.ReadElement(reader, xmlDocument, xmlNode, this.DeserializeRootElementName, manager);
				}
				else
				{
					reader.ReadAndAssert();
					this.DeserializeNode(reader, xmlDocument, manager, xmlNode);
				}
				if (objectType == typeof(XElement))
				{
					XElement xelement = (XElement)xmlDocument.DocumentElement.WrappedNode;
					xelement.Remove();
					return xelement;
				}
				if (objectType == typeof(XmlElement))
				{
					return xmlDocument.DocumentElement.WrappedNode;
				}
				return xmlDocument.WrappedNode;
			}
		}

		// Token: 0x06000D35 RID: 3381 RVA: 0x00034450 File Offset: 0x00032650
		private void DeserializeValue(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, string propertyName, IXmlNode currentNode)
		{
			if (!this.EncodeSpecialCharacters)
			{
				if (propertyName != null)
				{
					if (propertyName == "#text")
					{
						currentNode.AppendChild(document.CreateTextNode(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
						return;
					}
					if (propertyName == "#cdata-section")
					{
						currentNode.AppendChild(document.CreateCDataSection(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
						return;
					}
					if (propertyName == "#whitespace")
					{
						currentNode.AppendChild(document.CreateWhitespace(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
						return;
					}
					if (propertyName == "#significant-whitespace")
					{
						currentNode.AppendChild(document.CreateSignificantWhitespace(XmlNodeConverter.ConvertTokenToXmlValue(reader)));
						return;
					}
				}
				if (!StringUtils.IsNullOrEmpty(propertyName) && propertyName[0] == '?')
				{
					this.CreateInstruction(reader, document, currentNode, propertyName);
					return;
				}
				if (string.Equals(propertyName, "!DOCTYPE", StringComparison.OrdinalIgnoreCase))
				{
					this.CreateDocumentType(reader, document, currentNode);
					return;
				}
			}
			if (reader.TokenType == JsonToken.StartArray)
			{
				this.ReadArrayElements(reader, document, propertyName, currentNode, manager);
				return;
			}
			this.ReadElement(reader, document, currentNode, propertyName, manager);
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x00034560 File Offset: 0x00032760
		private void ReadElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, XmlNamespaceManager manager)
		{
			if (StringUtils.IsNullOrEmpty(propertyName))
			{
				throw JsonSerializationException.Create(reader, "XmlNodeConverter cannot convert JSON with an empty property name to XML.");
			}
			Dictionary<string, string> attributeNameValues = null;
			string elementPrefix = null;
			if (!this.EncodeSpecialCharacters)
			{
				attributeNameValues = (this.ShouldReadInto(reader) ? this.ReadAttributeElements(reader, manager) : null);
				elementPrefix = MiscellaneousUtils.GetPrefix(propertyName);
				if (propertyName.StartsWith('@'))
				{
					string text = propertyName.Substring(1);
					string prefix = MiscellaneousUtils.GetPrefix(text);
					XmlNodeConverter.AddAttribute(reader, document, currentNode, propertyName, text, manager, prefix);
					return;
				}
				if (propertyName.StartsWith('$') && propertyName != null)
				{
					if (propertyName == "$values")
					{
						propertyName = propertyName.Substring(1);
						elementPrefix = manager.LookupPrefix("http://james.newtonking.com/projects/json");
						this.CreateElement(reader, document, currentNode, propertyName, manager, elementPrefix, attributeNameValues);
						return;
					}
					if (propertyName == "$id" || propertyName == "$ref" || propertyName == "$type" || propertyName == "$value")
					{
						string attributeName = propertyName.Substring(1);
						string attributePrefix = manager.LookupPrefix("http://james.newtonking.com/projects/json");
						XmlNodeConverter.AddAttribute(reader, document, currentNode, propertyName, attributeName, manager, attributePrefix);
						return;
					}
				}
			}
			else if (this.ShouldReadInto(reader))
			{
				reader.ReadAndAssert();
			}
			this.CreateElement(reader, document, currentNode, propertyName, manager, elementPrefix, attributeNameValues);
		}

		// Token: 0x06000D37 RID: 3383 RVA: 0x000346A4 File Offset: 0x000328A4
		private void CreateElement(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string elementName, XmlNamespaceManager manager, [Nullable(2)] string elementPrefix, [Nullable(new byte[]
		{
			2,
			1,
			2
		})] Dictionary<string, string> attributeNameValues)
		{
			IXmlElement xmlElement = this.CreateElement(elementName, document, elementPrefix, manager);
			currentNode.AppendChild(xmlElement);
			if (attributeNameValues != null)
			{
				foreach (KeyValuePair<string, string> keyValuePair in attributeNameValues)
				{
					string text = XmlConvert.EncodeName(keyValuePair.Key);
					string prefix = MiscellaneousUtils.GetPrefix(keyValuePair.Key);
					IXmlNode attributeNode = (!StringUtils.IsNullOrEmpty(prefix)) ? document.CreateAttribute(text, manager.LookupNamespace(prefix) ?? string.Empty, keyValuePair.Value) : document.CreateAttribute(text, keyValuePair.Value);
					xmlElement.SetAttributeNode(attributeNode);
				}
			}
			switch (reader.TokenType)
			{
			case JsonToken.Integer:
			case JsonToken.Float:
			case JsonToken.String:
			case JsonToken.Boolean:
			case JsonToken.Date:
			case JsonToken.Bytes:
			{
				string text2 = XmlNodeConverter.ConvertTokenToXmlValue(reader);
				if (text2 != null)
				{
					xmlElement.AppendChild(document.CreateTextNode(text2));
					return;
				}
				return;
			}
			case JsonToken.Null:
				return;
			case JsonToken.EndObject:
				manager.RemoveNamespace(string.Empty, manager.DefaultNamespace);
				return;
			}
			manager.PushScope();
			this.DeserializeNode(reader, document, manager, xmlElement);
			manager.PopScope();
			manager.RemoveNamespace(string.Empty, manager.DefaultNamespace);
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x00034804 File Offset: 0x00032A04
		private static void AddAttribute(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName, string attributeName, XmlNamespaceManager manager, [Nullable(2)] string attributePrefix)
		{
			if (currentNode.NodeType == XmlNodeType.Document)
			{
				throw JsonSerializationException.Create(reader, "JSON root object has property '{0}' that will be converted to an attribute. A root object cannot have any attribute properties. Consider specifying a DeserializeRootElementName.".FormatWith(CultureInfo.InvariantCulture, propertyName));
			}
			string text = XmlConvert.EncodeName(attributeName);
			string value = XmlNodeConverter.ConvertTokenToXmlValue(reader);
			IXmlNode attributeNode = (!StringUtils.IsNullOrEmpty(attributePrefix)) ? document.CreateAttribute(text, manager.LookupNamespace(attributePrefix), value) : document.CreateAttribute(text, value);
			((IXmlElement)currentNode).SetAttributeNode(attributeNode);
		}

		// Token: 0x06000D39 RID: 3385 RVA: 0x00034874 File Offset: 0x00032A74
		[return: Nullable(2)]
		private static string ConvertTokenToXmlValue(JsonReader reader)
		{
			switch (reader.TokenType)
			{
			case JsonToken.Integer:
			{
				object value = reader.Value;
				if (value is BigInteger)
				{
					return ((BigInteger)value).ToString(CultureInfo.InvariantCulture);
				}
				return XmlConvert.ToString(Convert.ToInt64(reader.Value, CultureInfo.InvariantCulture));
			}
			case JsonToken.Float:
			{
				object value = reader.Value;
				if (value is decimal)
				{
					decimal value2 = (decimal)value;
					return XmlConvert.ToString(value2);
				}
				value = reader.Value;
				if (value is float)
				{
					float value3 = (float)value;
					return XmlConvert.ToString(value3);
				}
				return XmlConvert.ToString(Convert.ToDouble(reader.Value, CultureInfo.InvariantCulture));
			}
			case JsonToken.String:
			{
				object value4 = reader.Value;
				if (value4 == null)
				{
					return null;
				}
				return value4.ToString();
			}
			case JsonToken.Boolean:
				return XmlConvert.ToString(Convert.ToBoolean(reader.Value, CultureInfo.InvariantCulture));
			case JsonToken.Null:
				return null;
			case JsonToken.Date:
			{
				object value = reader.Value;
				if (value is DateTimeOffset)
				{
					DateTimeOffset value5 = (DateTimeOffset)value;
					return XmlConvert.ToString(value5);
				}
				DateTime value6 = Convert.ToDateTime(reader.Value, CultureInfo.InvariantCulture);
				return XmlConvert.ToString(value6, DateTimeUtils.ToSerializationMode(value6.Kind));
			}
			case JsonToken.Bytes:
				return Convert.ToBase64String((byte[])reader.Value);
			}
			throw JsonSerializationException.Create(reader, "Cannot get an XML string value from token type '{0}'.".FormatWith(CultureInfo.InvariantCulture, reader.TokenType));
		}

		// Token: 0x06000D3A RID: 3386 RVA: 0x000349EC File Offset: 0x00032BEC
		private void ReadArrayElements(JsonReader reader, IXmlDocument document, string propertyName, IXmlNode currentNode, XmlNamespaceManager manager)
		{
			string prefix = MiscellaneousUtils.GetPrefix(propertyName);
			IXmlElement xmlElement = this.CreateElement(propertyName, document, prefix, manager);
			currentNode.AppendChild(xmlElement);
			int num = 0;
			while (reader.Read() && reader.TokenType != JsonToken.EndArray)
			{
				this.DeserializeValue(reader, document, manager, propertyName, xmlElement);
				num++;
			}
			if (this.WriteArrayAttribute)
			{
				this.AddJsonArrayAttribute(xmlElement, document);
			}
			if (num == 1 && this.WriteArrayAttribute)
			{
				foreach (IXmlNode xmlNode in xmlElement.ChildNodes)
				{
					IXmlElement xmlElement2 = xmlNode as IXmlElement;
					if (xmlElement2 != null && xmlElement2.LocalName == propertyName)
					{
						this.AddJsonArrayAttribute(xmlElement2, document);
						break;
					}
				}
			}
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x00034ABC File Offset: 0x00032CBC
		private void AddJsonArrayAttribute(IXmlElement element, IXmlDocument document)
		{
			element.SetAttributeNode(document.CreateAttribute("json:Array", "http://james.newtonking.com/projects/json", "true"));
			if (element is XElementWrapper && element.GetPrefixOfNamespace("http://james.newtonking.com/projects/json") == null)
			{
				element.SetAttributeNode(document.CreateAttribute("xmlns:json", "http://www.w3.org/2000/xmlns/", "http://james.newtonking.com/projects/json"));
			}
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x00034B14 File Offset: 0x00032D14
		private bool ShouldReadInto(JsonReader reader)
		{
			switch (reader.TokenType)
			{
			case JsonToken.StartConstructor:
			case JsonToken.Integer:
			case JsonToken.Float:
			case JsonToken.String:
			case JsonToken.Boolean:
			case JsonToken.Null:
			case JsonToken.Date:
			case JsonToken.Bytes:
				return false;
			}
			return true;
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00034B74 File Offset: 0x00032D74
		[return: Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		private Dictionary<string, string> ReadAttributeElements(JsonReader reader, XmlNamespaceManager manager)
		{
			Dictionary<string, string> dictionary = null;
			bool flag = false;
			while (!flag && reader.Read())
			{
				JsonToken tokenType = reader.TokenType;
				if (tokenType != JsonToken.PropertyName)
				{
					if (tokenType != JsonToken.Comment && tokenType != JsonToken.EndObject)
					{
						throw JsonSerializationException.Create(reader, "Unexpected JsonToken: " + reader.TokenType.ToString());
					}
					flag = true;
				}
				else
				{
					string text = reader.Value.ToString();
					if (!StringUtils.IsNullOrEmpty(text))
					{
						char c = text[0];
						if (c != '$')
						{
							if (c == '@')
							{
								if (dictionary == null)
								{
									dictionary = new Dictionary<string, string>();
								}
								text = text.Substring(1);
								reader.ReadAndAssert();
								string text2 = XmlNodeConverter.ConvertTokenToXmlValue(reader);
								dictionary.Add(text, text2);
								string prefix;
								if (this.IsNamespaceAttribute(text, out prefix))
								{
									manager.AddNamespace(prefix, text2);
								}
							}
							else
							{
								flag = true;
							}
						}
						else if (text != null && (text == "$values" || text == "$id" || text == "$ref" || text == "$type" || text == "$value"))
						{
							string text3 = manager.LookupPrefix("http://james.newtonking.com/projects/json");
							if (text3 == null)
							{
								if (dictionary == null)
								{
									dictionary = new Dictionary<string, string>();
								}
								int? num = null;
								int? num2;
								for (;;)
								{
									string str = "json";
									num2 = num;
									if (manager.LookupNamespace(str + num2.ToString()) == null)
									{
										break;
									}
									num = new int?(num.GetValueOrDefault() + 1);
								}
								string str2 = "json";
								num2 = num;
								text3 = str2 + num2.ToString();
								dictionary.Add("xmlns:" + text3, "http://james.newtonking.com/projects/json");
								manager.AddNamespace(text3, "http://james.newtonking.com/projects/json");
							}
							if (text == "$values")
							{
								flag = true;
							}
							else
							{
								text = text.Substring(1);
								reader.ReadAndAssert();
								if (!JsonTokenUtils.IsPrimitiveToken(reader.TokenType))
								{
									throw JsonSerializationException.Create(reader, "Unexpected JsonToken: " + reader.TokenType.ToString());
								}
								if (dictionary == null)
								{
									dictionary = new Dictionary<string, string>();
								}
								object value = reader.Value;
								string text2 = (value != null) ? value.ToString() : null;
								dictionary.Add(text3 + ":" + text, text2);
							}
						}
						else
						{
							flag = true;
						}
					}
					else
					{
						flag = true;
					}
				}
			}
			return dictionary;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x00034DD0 File Offset: 0x00032FD0
		private void CreateInstruction(JsonReader reader, IXmlDocument document, IXmlNode currentNode, string propertyName)
		{
			if (propertyName == "?xml")
			{
				string version = null;
				string encoding = null;
				string standalone = null;
				while (reader.Read() && reader.TokenType != JsonToken.EndObject)
				{
					object value = reader.Value;
					string text = (value != null) ? value.ToString() : null;
					if (text != null)
					{
						if (text == "@version")
						{
							reader.ReadAndAssert();
							version = XmlNodeConverter.ConvertTokenToXmlValue(reader);
							continue;
						}
						if (text == "@encoding")
						{
							reader.ReadAndAssert();
							encoding = XmlNodeConverter.ConvertTokenToXmlValue(reader);
							continue;
						}
						if (text == "@standalone")
						{
							reader.ReadAndAssert();
							standalone = XmlNodeConverter.ConvertTokenToXmlValue(reader);
							continue;
						}
					}
					string str = "Unexpected property name encountered while deserializing XmlDeclaration: ";
					object value2 = reader.Value;
					throw JsonSerializationException.Create(reader, str + ((value2 != null) ? value2.ToString() : null));
				}
				IXmlNode newChild = document.CreateXmlDeclaration(version, encoding, standalone);
				currentNode.AppendChild(newChild);
				return;
			}
			IXmlNode newChild2 = document.CreateProcessingInstruction(propertyName.Substring(1), XmlNodeConverter.ConvertTokenToXmlValue(reader));
			currentNode.AppendChild(newChild2);
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x00034ED4 File Offset: 0x000330D4
		private void CreateDocumentType(JsonReader reader, IXmlDocument document, IXmlNode currentNode)
		{
			string name = null;
			string publicId = null;
			string systemId = null;
			string internalSubset = null;
			while (reader.Read() && reader.TokenType != JsonToken.EndObject)
			{
				object value = reader.Value;
				string text = (value != null) ? value.ToString() : null;
				if (text != null)
				{
					if (text == "@name")
					{
						reader.ReadAndAssert();
						name = XmlNodeConverter.ConvertTokenToXmlValue(reader);
						continue;
					}
					if (text == "@public")
					{
						reader.ReadAndAssert();
						publicId = XmlNodeConverter.ConvertTokenToXmlValue(reader);
						continue;
					}
					if (text == "@system")
					{
						reader.ReadAndAssert();
						systemId = XmlNodeConverter.ConvertTokenToXmlValue(reader);
						continue;
					}
					if (text == "@internalSubset")
					{
						reader.ReadAndAssert();
						internalSubset = XmlNodeConverter.ConvertTokenToXmlValue(reader);
						continue;
					}
				}
				string str = "Unexpected property name encountered while deserializing XmlDeclaration: ";
				object value2 = reader.Value;
				throw JsonSerializationException.Create(reader, str + ((value2 != null) ? value2.ToString() : null));
			}
			IXmlNode newChild = document.CreateXmlDocumentType(name, publicId, systemId, internalSubset);
			currentNode.AppendChild(newChild);
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00034FCC File Offset: 0x000331CC
		private IXmlElement CreateElement(string elementName, IXmlDocument document, [Nullable(2)] string elementPrefix, XmlNamespaceManager manager)
		{
			string text = this.EncodeSpecialCharacters ? XmlConvert.EncodeLocalName(elementName) : XmlConvert.EncodeName(elementName);
			string text2 = StringUtils.IsNullOrEmpty(elementPrefix) ? manager.DefaultNamespace : manager.LookupNamespace(elementPrefix);
			if (StringUtils.IsNullOrEmpty(text2))
			{
				return document.CreateElement(text);
			}
			return document.CreateElement(text, text2);
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00035024 File Offset: 0x00033224
		private void DeserializeNode(JsonReader reader, IXmlDocument document, XmlNamespaceManager manager, IXmlNode currentNode)
		{
			JsonToken tokenType;
			for (;;)
			{
				tokenType = reader.TokenType;
				switch (tokenType)
				{
				case JsonToken.StartConstructor:
				{
					string propertyName = reader.Value.ToString();
					while (reader.Read())
					{
						if (reader.TokenType == JsonToken.EndConstructor)
						{
							break;
						}
						this.DeserializeValue(reader, document, manager, propertyName, currentNode);
					}
					goto IL_1AE;
				}
				case JsonToken.PropertyName:
				{
					if (currentNode.NodeType == XmlNodeType.Document && document.DocumentElement != null)
					{
						goto Block_3;
					}
					string text = reader.Value.ToString();
					reader.ReadAndAssert();
					if (reader.TokenType == JsonToken.StartArray)
					{
						int num = 0;
						while (reader.Read() && reader.TokenType != JsonToken.EndArray)
						{
							this.DeserializeValue(reader, document, manager, text, currentNode);
							num++;
						}
						if (num != 1 || !this.WriteArrayAttribute)
						{
							goto IL_1AE;
						}
						string text2;
						string b;
						MiscellaneousUtils.GetQualifiedNameParts(text, out text2, out b);
						string b2 = StringUtils.IsNullOrEmpty(text2) ? manager.DefaultNamespace : manager.LookupNamespace(text2);
						using (List<IXmlNode>.Enumerator enumerator = currentNode.ChildNodes.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								IXmlNode xmlNode = enumerator.Current;
								IXmlElement xmlElement = xmlNode as IXmlElement;
								if (xmlElement != null && xmlElement.LocalName == b && xmlElement.NamespaceUri == b2)
								{
									this.AddJsonArrayAttribute(xmlElement, document);
									break;
								}
							}
							goto IL_1AE;
						}
					}
					this.DeserializeValue(reader, document, manager, text, currentNode);
					goto IL_1AE;
				}
				case JsonToken.Comment:
					currentNode.AppendChild(document.CreateComment((string)reader.Value));
					goto IL_1AE;
				}
				break;
				IL_1AE:
				if (!reader.Read())
				{
					return;
				}
			}
			if (tokenType - JsonToken.EndObject > 1)
			{
				throw JsonSerializationException.Create(reader, "Unexpected JsonToken when deserializing node: " + reader.TokenType.ToString());
			}
			return;
			Block_3:
			throw JsonSerializationException.Create(reader, "JSON root object has multiple properties. The root object must have a single property in order to create a valid XML document. Consider specifying a DeserializeRootElementName.");
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x000351FC File Offset: 0x000333FC
		private bool IsNamespaceAttribute(string attributeName, [Nullable(2)] [NotNullWhen(true)] out string prefix)
		{
			if (attributeName.StartsWith("xmlns", StringComparison.Ordinal))
			{
				if (attributeName.Length == 5)
				{
					prefix = string.Empty;
					return true;
				}
				if (attributeName[5] == ':')
				{
					prefix = attributeName.Substring(6, attributeName.Length - 6);
					return true;
				}
			}
			prefix = null;
			return false;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0003524C File Offset: 0x0003344C
		private bool ValueAttributes(List<IXmlNode> c)
		{
			foreach (IXmlNode xmlNode in c)
			{
				if (!(xmlNode.NamespaceUri == "http://james.newtonking.com/projects/json") && (!(xmlNode.NamespaceUri == "http://www.w3.org/2000/xmlns/") || !(xmlNode.Value == "http://james.newtonking.com/projects/json")))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x000352D0 File Offset: 0x000334D0
		public override bool CanConvert(Type valueType)
		{
			if (valueType.AssignableToTypeName("System.Xml.Linq.XObject", false))
			{
				return this.IsXObject(valueType);
			}
			return valueType.AssignableToTypeName("System.Xml.XmlNode", false) && this.IsXmlNode(valueType);
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x000352FF File Offset: 0x000334FF
		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsXObject(Type valueType)
		{
			return typeof(XObject).IsAssignableFrom(valueType);
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x00035311 File Offset: 0x00033511
		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool IsXmlNode(Type valueType)
		{
			return typeof(XmlNode).IsAssignableFrom(valueType);
		}

		// Token: 0x040003F1 RID: 1009
		internal static readonly List<IXmlNode> EmptyChildNodes = new List<IXmlNode>();

		// Token: 0x040003F2 RID: 1010
		private const string TextName = "#text";

		// Token: 0x040003F3 RID: 1011
		private const string CommentName = "#comment";

		// Token: 0x040003F4 RID: 1012
		private const string CDataName = "#cdata-section";

		// Token: 0x040003F5 RID: 1013
		private const string WhitespaceName = "#whitespace";

		// Token: 0x040003F6 RID: 1014
		private const string SignificantWhitespaceName = "#significant-whitespace";

		// Token: 0x040003F7 RID: 1015
		private const string DeclarationName = "?xml";

		// Token: 0x040003F8 RID: 1016
		private const string JsonNamespaceUri = "http://james.newtonking.com/projects/json";
	}
}
