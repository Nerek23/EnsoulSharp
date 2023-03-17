using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace System.Runtime.InteropServices
{
	/// <summary>Enables customization of managed objects that extend from unmanaged objects during creation.</summary>
	// Token: 0x02000936 RID: 2358
	[ComVisible(true)]
	public sealed class ExtensibleClassFactory
	{
		// Token: 0x06006107 RID: 24839 RVA: 0x0014AC4D File Offset: 0x00148E4D
		private ExtensibleClassFactory()
		{
		}

		/// <summary>Registers a <see langword="delegate" /> that is called when an instance of a managed type, that extends from an unmanaged type, needs to allocate the aggregated unmanaged object.</summary>
		/// <param name="callback">A <see langword="delegate" /> that is called in place of <see langword="CoCreateInstance" />.</param>
		// Token: 0x06006108 RID: 24840
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void RegisterObjectCreationCallback(ObjectCreationDelegate callback);
	}
}
