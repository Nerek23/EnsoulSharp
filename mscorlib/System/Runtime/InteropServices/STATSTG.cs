using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.STATSTG" /> instead.</summary>
	// Token: 0x0200095F RID: 2399
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.STATSTG instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STATSTG
	{
		/// <summary>Pointer to a null-terminated string containing the name of the object described by this structure.</summary>
		// Token: 0x04002B2E RID: 11054
		public string pwcsName;

		/// <summary>Indicates the type of storage object which is one of the values from the <see langword="STGTY" /> enumeration.</summary>
		// Token: 0x04002B2F RID: 11055
		public int type;

		/// <summary>Specifies the size in bytes of the stream or byte array.</summary>
		// Token: 0x04002B30 RID: 11056
		public long cbSize;

		/// <summary>Indicates the last modification time for this storage, stream, or byte array.</summary>
		// Token: 0x04002B31 RID: 11057
		public FILETIME mtime;

		/// <summary>Indicates the creation time for this storage, stream, or byte array.</summary>
		// Token: 0x04002B32 RID: 11058
		public FILETIME ctime;

		/// <summary>Indicates the last access time for this storage, stream or byte array.</summary>
		// Token: 0x04002B33 RID: 11059
		public FILETIME atime;

		/// <summary>Indicates the access mode that was specified when the object was opened.</summary>
		// Token: 0x04002B34 RID: 11060
		public int grfMode;

		/// <summary>Indicates the types of region locking supported by the stream or byte array.</summary>
		// Token: 0x04002B35 RID: 11061
		public int grfLocksSupported;

		/// <summary>Indicates the class identifier for the storage object.</summary>
		// Token: 0x04002B36 RID: 11062
		public Guid clsid;

		/// <summary>Indicates the current state bits of the storage object (the value most recently set by the <see langword="IStorage::SetStateBits" /> method).</summary>
		// Token: 0x04002B37 RID: 11063
		public int grfStateBits;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002B38 RID: 11064
		public int reserved;
	}
}
