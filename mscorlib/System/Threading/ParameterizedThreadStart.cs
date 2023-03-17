using System;
using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>Represents the method that executes on a <see cref="T:System.Threading.Thread" />.</summary>
	/// <param name="obj">An object that contains data for the thread procedure.</param>
	// Token: 0x020004DF RID: 1247
	// (Invoke) Token: 0x06003BA8 RID: 15272
	[ComVisible(false)]
	public delegate void ParameterizedThreadStart(object obj);
}
