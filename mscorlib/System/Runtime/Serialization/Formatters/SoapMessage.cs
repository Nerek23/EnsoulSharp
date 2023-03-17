using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Holds the names and types of parameters required during serialization of a SOAP RPC (Remote Procedure Call).</summary>
	// Token: 0x02000738 RID: 1848
	[ComVisible(true)]
	[Serializable]
	public class SoapMessage : ISoapMessage
	{
		/// <summary>Gets or sets the parameter names for the called method.</summary>
		/// <returns>The parameter names for the called method.</returns>
		// Token: 0x17000DA9 RID: 3497
		// (get) Token: 0x060051F5 RID: 20981 RVA: 0x0011F22D File Offset: 0x0011D42D
		// (set) Token: 0x060051F6 RID: 20982 RVA: 0x0011F235 File Offset: 0x0011D435
		public string[] ParamNames
		{
			get
			{
				return this.paramNames;
			}
			set
			{
				this.paramNames = value;
			}
		}

		/// <summary>Gets or sets the parameter values for the called method.</summary>
		/// <returns>Parameter values for the called method.</returns>
		// Token: 0x17000DAA RID: 3498
		// (get) Token: 0x060051F7 RID: 20983 RVA: 0x0011F23E File Offset: 0x0011D43E
		// (set) Token: 0x060051F8 RID: 20984 RVA: 0x0011F246 File Offset: 0x0011D446
		public object[] ParamValues
		{
			get
			{
				return this.paramValues;
			}
			set
			{
				this.paramValues = value;
			}
		}

		/// <summary>This property is reserved. Use the <see cref="P:System.Runtime.Serialization.Formatters.SoapMessage.ParamNames" /> and/or <see cref="P:System.Runtime.Serialization.Formatters.SoapMessage.ParamValues" /> properties instead.</summary>
		/// <returns>Parameter types for the called method.</returns>
		// Token: 0x17000DAB RID: 3499
		// (get) Token: 0x060051F9 RID: 20985 RVA: 0x0011F24F File Offset: 0x0011D44F
		// (set) Token: 0x060051FA RID: 20986 RVA: 0x0011F257 File Offset: 0x0011D457
		public Type[] ParamTypes
		{
			get
			{
				return this.paramTypes;
			}
			set
			{
				this.paramTypes = value;
			}
		}

		/// <summary>Gets or sets the name of the called method.</summary>
		/// <returns>The name of the called method.</returns>
		// Token: 0x17000DAC RID: 3500
		// (get) Token: 0x060051FB RID: 20987 RVA: 0x0011F260 File Offset: 0x0011D460
		// (set) Token: 0x060051FC RID: 20988 RVA: 0x0011F268 File Offset: 0x0011D468
		public string MethodName
		{
			get
			{
				return this.methodName;
			}
			set
			{
				this.methodName = value;
			}
		}

		/// <summary>Gets or sets the XML namespace name where the object that contains the called method is located.</summary>
		/// <returns>The XML namespace name where the object that contains the called method is located.</returns>
		// Token: 0x17000DAD RID: 3501
		// (get) Token: 0x060051FD RID: 20989 RVA: 0x0011F271 File Offset: 0x0011D471
		// (set) Token: 0x060051FE RID: 20990 RVA: 0x0011F279 File Offset: 0x0011D479
		public string XmlNameSpace
		{
			get
			{
				return this.xmlNameSpace;
			}
			set
			{
				this.xmlNameSpace = value;
			}
		}

		/// <summary>Gets or sets the out-of-band data of the called method.</summary>
		/// <returns>The out-of-band data of the called method.</returns>
		// Token: 0x17000DAE RID: 3502
		// (get) Token: 0x060051FF RID: 20991 RVA: 0x0011F282 File Offset: 0x0011D482
		// (set) Token: 0x06005200 RID: 20992 RVA: 0x0011F28A File Offset: 0x0011D48A
		public Header[] Headers
		{
			get
			{
				return this.headers;
			}
			set
			{
				this.headers = value;
			}
		}

		// Token: 0x0400241B RID: 9243
		internal string[] paramNames;

		// Token: 0x0400241C RID: 9244
		internal object[] paramValues;

		// Token: 0x0400241D RID: 9245
		internal Type[] paramTypes;

		// Token: 0x0400241E RID: 9246
		internal string methodName;

		// Token: 0x0400241F RID: 9247
		internal string xmlNameSpace;

		// Token: 0x04002420 RID: 9248
		internal Header[] headers;
	}
}
