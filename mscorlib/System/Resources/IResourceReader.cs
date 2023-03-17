using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace System.Resources
{
	/// <summary>Provides the base functionality for reading data from resource files.</summary>
	// Token: 0x02000361 RID: 865
	[ComVisible(true)]
	public interface IResourceReader : IEnumerable, IDisposable
	{
		/// <summary>Closes the resource reader after releasing any resources associated with it.</summary>
		// Token: 0x06002BCC RID: 11212
		void Close();

		/// <summary>Returns a dictionary enumerator of the resources for this reader.</summary>
		/// <returns>A dictionary enumerator for the resources for this reader.</returns>
		// Token: 0x06002BCD RID: 11213
		IDictionaryEnumerator GetEnumerator();
	}
}
