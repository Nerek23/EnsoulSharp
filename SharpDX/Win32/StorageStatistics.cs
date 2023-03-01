using System;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000063 RID: 99
	public struct StorageStatistics
	{
		// Token: 0x0600026B RID: 619 RVA: 0x000075A7 File Offset: 0x000057A7
		internal void __MarshalFree(ref StorageStatistics.__Native @ref)
		{
			Marshal.FreeHGlobal(@ref.PwcsName);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x000075B4 File Offset: 0x000057B4
		internal void __MarshalFrom(ref StorageStatistics.__Native @ref)
		{
			this.PwcsName = Marshal.PtrToStringUni(@ref.PwcsName);
			this.Type = @ref.Type;
			this.CbSize = @ref.CbSize;
			this.Mtime = @ref.Mtime;
			this.Ctime = @ref.Ctime;
			this.Atime = @ref.Atime;
			this.GrfMode = @ref.GrfMode;
			this.GrfLocksSupported = @ref.GrfLocksSupported;
			this.Clsid = @ref.Clsid;
			this.GrfStateBits = @ref.GrfStateBits;
			this.Reserved = @ref.Reserved;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000764C File Offset: 0x0000584C
		internal void __MarshalTo(ref StorageStatistics.__Native @ref)
		{
			@ref.PwcsName = Marshal.StringToHGlobalUni(this.PwcsName);
			@ref.Type = this.Type;
			@ref.CbSize = this.CbSize;
			@ref.Mtime = this.Mtime;
			@ref.Ctime = this.Ctime;
			@ref.Atime = this.Atime;
			@ref.GrfMode = this.GrfMode;
			@ref.GrfLocksSupported = this.GrfLocksSupported;
			@ref.Clsid = this.Clsid;
			@ref.GrfStateBits = this.GrfStateBits;
			@ref.Reserved = this.Reserved;
		}

		// Token: 0x04000D5D RID: 3421
		public string PwcsName;

		// Token: 0x04000D5E RID: 3422
		public int Type;

		// Token: 0x04000D5F RID: 3423
		public long CbSize;

		// Token: 0x04000D60 RID: 3424
		public long Mtime;

		// Token: 0x04000D61 RID: 3425
		public long Ctime;

		// Token: 0x04000D62 RID: 3426
		public long Atime;

		// Token: 0x04000D63 RID: 3427
		public int GrfMode;

		// Token: 0x04000D64 RID: 3428
		public int GrfLocksSupported;

		// Token: 0x04000D65 RID: 3429
		public Guid Clsid;

		// Token: 0x04000D66 RID: 3430
		public int GrfStateBits;

		// Token: 0x04000D67 RID: 3431
		public int Reserved;

		// Token: 0x02000064 RID: 100
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		internal struct __Native
		{
			// Token: 0x04000D68 RID: 3432
			public IntPtr PwcsName;

			// Token: 0x04000D69 RID: 3433
			public int Type;

			// Token: 0x04000D6A RID: 3434
			public long CbSize;

			// Token: 0x04000D6B RID: 3435
			public long Mtime;

			// Token: 0x04000D6C RID: 3436
			public long Ctime;

			// Token: 0x04000D6D RID: 3437
			public long Atime;

			// Token: 0x04000D6E RID: 3438
			public int GrfMode;

			// Token: 0x04000D6F RID: 3439
			public int GrfLocksSupported;

			// Token: 0x04000D70 RID: 3440
			public Guid Clsid;

			// Token: 0x04000D71 RID: 3441
			public int GrfStateBits;

			// Token: 0x04000D72 RID: 3442
			public int Reserved;
		}
	}
}
