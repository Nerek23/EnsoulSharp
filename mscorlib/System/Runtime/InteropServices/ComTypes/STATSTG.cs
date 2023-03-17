using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Contains statistical information about an open storage, stream, or byte-array object.</summary>
	// Token: 0x02000A08 RID: 2568
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STATSTG
	{
		/// <summary>Represents a pointer to a null-terminated string containing the name of the object described by this structure.</summary>
		// Token: 0x04002C92 RID: 11410
		[__DynamicallyInvokable]
		public string pwcsName;

		/// <summary>Indicates the type of storage object, which is one of the values from the <see langword="STGTY" /> enumeration.</summary>
		// Token: 0x04002C93 RID: 11411
		[__DynamicallyInvokable]
		public int type;

		/// <summary>Specifies the size, in bytes, of the stream or byte array.</summary>
		// Token: 0x04002C94 RID: 11412
		[__DynamicallyInvokable]
		public long cbSize;

		/// <summary>Indicates the last modification time for this storage, stream, or byte array.</summary>
		// Token: 0x04002C95 RID: 11413
		[__DynamicallyInvokable]
		public FILETIME mtime;

		/// <summary>Indicates the creation time for this storage, stream, or byte array.</summary>
		// Token: 0x04002C96 RID: 11414
		[__DynamicallyInvokable]
		public FILETIME ctime;

		/// <summary>Specifies the last access time for this storage, stream, or byte array.</summary>
		// Token: 0x04002C97 RID: 11415
		[__DynamicallyInvokable]
		public FILETIME atime;

		/// <summary>Indicates the access mode that was specified when the object was opened.</summary>
		// Token: 0x04002C98 RID: 11416
		[__DynamicallyInvokable]
		public int grfMode;

		/// <summary>Indicates the types of region locking supported by the stream or byte array.</summary>
		// Token: 0x04002C99 RID: 11417
		[__DynamicallyInvokable]
		public int grfLocksSupported;

		/// <summary>Indicates the class identifier for the storage object.</summary>
		// Token: 0x04002C9A RID: 11418
		[__DynamicallyInvokable]
		public Guid clsid;

		/// <summary>Indicates the current state bits of the storage object (the value most recently set by the <see langword="IStorage::SetStateBits" /> method).</summary>
		// Token: 0x04002C9B RID: 11419
		[__DynamicallyInvokable]
		public int grfStateBits;

		/// <summary>Reserved for future use.</summary>
		// Token: 0x04002C9C RID: 11420
		[__DynamicallyInvokable]
		public int reserved;
	}
}
