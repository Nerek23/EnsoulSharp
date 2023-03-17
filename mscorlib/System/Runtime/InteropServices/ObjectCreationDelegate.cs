using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Creates a COM object.</summary>
	/// <param name="aggregator">A pointer to the managed object's <see langword="IUnknown" /> interface.</param>
	/// <returns>An <see cref="T:System.IntPtr" /> object that represents the <see langword="IUnknown" /> interface of the COM object.</returns>
	// Token: 0x02000946 RID: 2374
	// (Invoke) Token: 0x06006122 RID: 24866
	[ComVisible(true)]
	public delegate IntPtr ObjectCreationDelegate(IntPtr aggregator);
}
