using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Messaging
{
	/// <summary>Defines the out-of-band data for a call.</summary>
	// Token: 0x0200085C RID: 2140
	[ComVisible(true)]
	[Serializable]
	public class Header
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.Header" /> class with the given name and value.</summary>
		/// <param name="_Name">The name of the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		/// <param name="_Value">The object that contains the value for the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		// Token: 0x06005B87 RID: 23431 RVA: 0x00140477 File Offset: 0x0013E677
		public Header(string _Name, object _Value) : this(_Name, _Value, true)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.Header" /> class with the given name, value, and additional configuration information.</summary>
		/// <param name="_Name">The name of the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		/// <param name="_Value">The object that contains the value for the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		/// <param name="_MustUnderstand">Indicates whether the receiving end must understand the out-of-band data.</param>
		// Token: 0x06005B88 RID: 23432 RVA: 0x00140482 File Offset: 0x0013E682
		public Header(string _Name, object _Value, bool _MustUnderstand)
		{
			this.Name = _Name;
			this.Value = _Value;
			this.MustUnderstand = _MustUnderstand;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Messaging.Header" /> class.</summary>
		/// <param name="_Name">The name of the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		/// <param name="_Value">The object that contains the value of the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</param>
		/// <param name="_MustUnderstand">Indicates whether the receiving end must understand out-of-band data.</param>
		/// <param name="_HeaderNamespace">The <see cref="T:System.Runtime.Remoting.Messaging.Header" /> XML namespace.</param>
		// Token: 0x06005B89 RID: 23433 RVA: 0x0014049F File Offset: 0x0013E69F
		public Header(string _Name, object _Value, bool _MustUnderstand, string _HeaderNamespace)
		{
			this.Name = _Name;
			this.Value = _Value;
			this.MustUnderstand = _MustUnderstand;
			this.HeaderNamespace = _HeaderNamespace;
		}

		/// <summary>Contains the name of the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</summary>
		// Token: 0x04002918 RID: 10520
		public string Name;

		/// <summary>Contains the value for the <see cref="T:System.Runtime.Remoting.Messaging.Header" />.</summary>
		// Token: 0x04002919 RID: 10521
		public object Value;

		/// <summary>Indicates whether the receiving end must understand the out-of-band data.</summary>
		// Token: 0x0400291A RID: 10522
		public bool MustUnderstand;

		/// <summary>Indicates the XML namespace that the current <see cref="T:System.Runtime.Remoting.Messaging.Header" /> belongs to.</summary>
		// Token: 0x0400291B RID: 10523
		public string HeaderNamespace;
	}
}
