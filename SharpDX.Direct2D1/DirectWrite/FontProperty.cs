using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000155 RID: 341
	public struct FontProperty
	{
		// Token: 0x0600065F RID: 1631 RVA: 0x00014966 File Offset: 0x00012B66
		internal void __MarshalFree(ref FontProperty.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.PropertyValue);
			Marshal.FreeHGlobal(@ref.LocaleName);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0001497E File Offset: 0x00012B7E
		internal void __MarshalFrom(ref FontProperty.__Native @ref)
		{
			this.PropertyId = @ref.PropertyId;
			this.PropertyValue = Marshal.PtrToStringUni(@ref.PropertyValue);
			this.LocaleName = Marshal.PtrToStringUni(@ref.LocaleName);
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x000149AE File Offset: 0x00012BAE
		internal void __MarshalTo(ref FontProperty.__Native @ref)
		{
			@ref.PropertyId = this.PropertyId;
			@ref.PropertyValue = Marshal.StringToHGlobalUni(this.PropertyValue);
			@ref.LocaleName = Marshal.StringToHGlobalUni(this.LocaleName);
		}

		// Token: 0x04000520 RID: 1312
		public FontPropertyId PropertyId;

		// Token: 0x04000521 RID: 1313
		public string PropertyValue;

		// Token: 0x04000522 RID: 1314
		public string LocaleName;

		// Token: 0x02000156 RID: 342
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000523 RID: 1315
			public FontPropertyId PropertyId;

			// Token: 0x04000524 RID: 1316
			public IntPtr PropertyValue;

			// Token: 0x04000525 RID: 1317
			public IntPtr LocaleName;
		}
	}
}
