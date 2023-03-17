using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Metadata.W3cXsd2001
{
	/// <summary>Wraps an XSD <see langword="QName" /> type.</summary>
	// Token: 0x020007C2 RID: 1986
	[ComVisible(true)]
	[Serializable]
	public sealed class SoapQName : ISoapXsd
	{
		/// <summary>Gets the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> that indicates the XSD of the current SOAP type.</returns>
		// Token: 0x17000E6C RID: 3692
		// (get) Token: 0x06005694 RID: 22164 RVA: 0x00131993 File Offset: 0x0012FB93
		public static string XsdType
		{
			get
			{
				return "QName";
			}
		}

		/// <summary>Returns the XML Schema definition language (XSD) of the current SOAP type.</summary>
		/// <returns>A <see cref="T:System.String" /> indicating the XSD of the current SOAP type.</returns>
		// Token: 0x06005695 RID: 22165 RVA: 0x0013199A File Offset: 0x0012FB9A
		public string GetXsdType()
		{
			return SoapQName.XsdType;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> class.</summary>
		// Token: 0x06005696 RID: 22166 RVA: 0x001319A1 File Offset: 0x0012FBA1
		public SoapQName()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> class with the local part of a qualified name.</summary>
		/// <param name="value">A <see cref="T:System.String" /> that contains the local part of a qualified name.</param>
		// Token: 0x06005697 RID: 22167 RVA: 0x001319A9 File Offset: 0x0012FBA9
		public SoapQName(string value)
		{
			this._name = value;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> class with the namespace alias and the local part of a qualified name.</summary>
		/// <param name="key">A <see cref="T:System.String" /> that contains the namespace alias of a qualified name.</param>
		/// <param name="name">A <see cref="T:System.String" /> that contains the local part of a qualified name.</param>
		// Token: 0x06005698 RID: 22168 RVA: 0x001319B8 File Offset: 0x0012FBB8
		public SoapQName(string key, string name)
		{
			this._name = name;
			this._key = key;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> class with the namespace alias, the local part of a qualified name, and the namespace that is referenced by the alias.</summary>
		/// <param name="key">A <see cref="T:System.String" /> that contains the namespace alias of a qualified name.</param>
		/// <param name="name">A <see cref="T:System.String" /> that contains the local part of a qualified name.</param>
		/// <param name="namespaceValue">A <see cref="T:System.String" /> that contains the namespace that is referenced by <paramref name="key" />.</param>
		// Token: 0x06005699 RID: 22169 RVA: 0x001319CE File Offset: 0x0012FBCE
		public SoapQName(string key, string name, string namespaceValue)
		{
			this._name = name;
			this._namespace = namespaceValue;
			this._key = key;
		}

		/// <summary>Gets or sets the name portion of a qualified name.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the name portion of a qualified name.</returns>
		// Token: 0x17000E6D RID: 3693
		// (get) Token: 0x0600569A RID: 22170 RVA: 0x001319EB File Offset: 0x0012FBEB
		// (set) Token: 0x0600569B RID: 22171 RVA: 0x001319F3 File Offset: 0x0012FBF3
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}

		/// <summary>Gets or sets the namespace that is referenced by <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Key" />.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the namespace that is referenced by <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Key" />.</returns>
		// Token: 0x17000E6E RID: 3694
		// (get) Token: 0x0600569C RID: 22172 RVA: 0x001319FC File Offset: 0x0012FBFC
		// (set) Token: 0x0600569D RID: 22173 RVA: 0x00131A04 File Offset: 0x0012FC04
		public string Namespace
		{
			get
			{
				return this._namespace;
			}
			set
			{
				this._namespace = value;
			}
		}

		/// <summary>Gets or sets the namespace alias of a qualified name.</summary>
		/// <returns>A <see cref="T:System.String" /> that contains the namespace alias of a qualified name.</returns>
		// Token: 0x17000E6F RID: 3695
		// (get) Token: 0x0600569E RID: 22174 RVA: 0x00131A0D File Offset: 0x0012FC0D
		// (set) Token: 0x0600569F RID: 22175 RVA: 0x00131A15 File Offset: 0x0012FC15
		public string Key
		{
			get
			{
				return this._key;
			}
			set
			{
				this._key = value;
			}
		}

		/// <summary>Returns the qualified name as a <see cref="T:System.String" />.</summary>
		/// <returns>A <see cref="T:System.String" /> in the format " <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Key" /> : <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Name" /> ". If <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Key" /> is not specified, this method returns <see cref="P:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName.Name" />.</returns>
		// Token: 0x060056A0 RID: 22176 RVA: 0x00131A1E File Offset: 0x0012FC1E
		public override string ToString()
		{
			if (this._key == null || this._key.Length == 0)
			{
				return this._name;
			}
			return this._key + ":" + this._name;
		}

		/// <summary>Converts the specified <see cref="T:System.String" /> into a <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> object.</summary>
		/// <param name="value">The <see cref="T:System.String" /> to convert.</param>
		/// <returns>A <see cref="T:System.Runtime.Remoting.Metadata.W3cXsd2001.SoapQName" /> object that is obtained from <paramref name="value" />.</returns>
		// Token: 0x060056A1 RID: 22177 RVA: 0x00131A54 File Offset: 0x0012FC54
		public static SoapQName Parse(string value)
		{
			if (value == null)
			{
				return new SoapQName();
			}
			string key = "";
			string name = value;
			int num = value.IndexOf(':');
			if (num > 0)
			{
				key = value.Substring(0, num);
				name = value.Substring(num + 1);
			}
			return new SoapQName(key, name);
		}

		// Token: 0x04002765 RID: 10085
		private string _name;

		// Token: 0x04002766 RID: 10086
		private string _namespace;

		// Token: 0x04002767 RID: 10087
		private string _key;
	}
}
