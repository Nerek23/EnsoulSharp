using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Runtime.Remoting.Channels
{
	/// <summary>Stores sink provider data for sink providers.</summary>
	// Token: 0x02000821 RID: 2081
	[ComVisible(true)]
	public class SinkProviderData
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> class.</summary>
		/// <param name="name">The name of the sink provider that the data in the current <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> object is associated with.</param>
		// Token: 0x06005917 RID: 22807 RVA: 0x00138C6F File Offset: 0x00136E6F
		public SinkProviderData(string name)
		{
			this._name = name;
		}

		/// <summary>Gets the name of the sink provider that the data in the current <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> object is associated with.</summary>
		/// <returns>A <see cref="T:System.String" /> with the name of the XML node that the data in the current <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> object is associated with.</returns>
		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x06005918 RID: 22808 RVA: 0x00138C99 File Offset: 0x00136E99
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		/// <summary>Gets a dictionary through which properties on the sink provider can be accessed.</summary>
		/// <returns>A dictionary through which properties on the sink provider can be accessed.</returns>
		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x06005919 RID: 22809 RVA: 0x00138CA1 File Offset: 0x00136EA1
		public IDictionary Properties
		{
			get
			{
				return this._properties;
			}
		}

		/// <summary>Gets a list of the child <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> nodes.</summary>
		/// <returns>A <see cref="T:System.Collections.IList" /> of the child <see cref="T:System.Runtime.Remoting.Channels.SinkProviderData" /> nodes.</returns>
		// Token: 0x17000EEC RID: 3820
		// (get) Token: 0x0600591A RID: 22810 RVA: 0x00138CA9 File Offset: 0x00136EA9
		public IList Children
		{
			get
			{
				return this._children;
			}
		}

		// Token: 0x04002843 RID: 10307
		private string _name;

		// Token: 0x04002844 RID: 10308
		private Hashtable _properties = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

		// Token: 0x04002845 RID: 10309
		private ArrayList _children = new ArrayList();
	}
}
