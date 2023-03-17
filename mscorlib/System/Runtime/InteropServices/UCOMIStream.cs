using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.IStream" /> instead.</summary>
	// Token: 0x02000960 RID: 2400
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IStream instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("0000000c-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface UCOMIStream
	{
		/// <summary>Reads a specified number of bytes from the stream object into memory starting at the current seek pointer.</summary>
		/// <param name="pv">On successful return, contains the data read frtom the stream.</param>
		/// <param name="cb">The number of bytes to read from the stream object.</param>
		/// <param name="pcbRead">Pointer to a <see langword="ULONG" /> variable that receives the actual number of bytes read from the stream object.</param>
		// Token: 0x060061B4 RID: 25012
		void Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] [Out] byte[] pv, int cb, IntPtr pcbRead);

		/// <summary>Writes a specified number of bytes into the stream object starting at the current seek pointer.</summary>
		/// <param name="pv">Buffer to write this stream to.</param>
		/// <param name="cb">The number of bytes to write into the stream.</param>
		/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the stream object. The caller can set this pointer to <see langword="null" />, in which case this method does not provide the actual number of bytes written.</param>
		// Token: 0x060061B5 RID: 25013
		void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);

		/// <summary>Changes the seek pointer to a new location relative to the beginning of the stream, to the end of the stream, or to the current seek pointer.</summary>
		/// <param name="dlibMove">Displacement to add to <paramref name="dwOrigin" />.</param>
		/// <param name="dwOrigin">Specifies the origin of the seek. The origin can be the beginning of the file, the current seek pointer, or the end of the file.</param>
		/// <param name="plibNewPosition">On successful return, contains the offset of the seek pointer from the beginning of the stream.</param>
		// Token: 0x060061B6 RID: 25014
		void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

		/// <summary>Changes the size of the stream object.</summary>
		/// <param name="libNewSize">Specifies the new size of the stream as a number of bytes.</param>
		// Token: 0x060061B7 RID: 25015
		void SetSize(long libNewSize);

		/// <summary>Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream.</summary>
		/// <param name="pstm">Reference to the destination stream.</param>
		/// <param name="cb">The number of bytes to copy from the source stream.</param>
		/// <param name="pcbRead">On successful return, contains the actual number of bytes read from the source.</param>
		/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the destination.</param>
		// Token: 0x060061B8 RID: 25016
		void CopyTo(UCOMIStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

		/// <summary>Ensures that any changes made to a stream object open in transacted mode are reflected in the parent storage.</summary>
		/// <param name="grfCommitFlags">Controls how the changes for the stream object are committed.</param>
		// Token: 0x060061B9 RID: 25017
		void Commit(int grfCommitFlags);

		/// <summary>Discards all changes that have been made to a transacted stream since the last <see cref="M:System.Runtime.InteropServices.UCOMIStream.Commit(System.Int32)" /> call.</summary>
		// Token: 0x060061BA RID: 25018
		void Revert();

		/// <summary>Restricts access to a specified range of bytes in the stream.</summary>
		/// <param name="libOffset">The byte offset for the beginning of the range.</param>
		/// <param name="cb">The length of the range, in bytes, to restrict.</param>
		/// <param name="dwLockType">The requested restrictions on accessing the range.</param>
		// Token: 0x060061BB RID: 25019
		void LockRegion(long libOffset, long cb, int dwLockType);

		/// <summary>Removes the access restriction on a range of bytes previously restricted with <see cref="M:System.Runtime.InteropServices.UCOMIStream.LockRegion(System.Int64,System.Int64,System.Int32)" />.</summary>
		/// <param name="libOffset">The byte offset for the beginning of the range.</param>
		/// <param name="cb">The length, in bytes, of the range to restrict.</param>
		/// <param name="dwLockType">The access restrictions previously placed on the range.</param>
		// Token: 0x060061BC RID: 25020
		void UnlockRegion(long libOffset, long cb, int dwLockType);

		/// <summary>Retrieves the <see cref="T:System.Runtime.InteropServices.STATSTG" /> structure for this stream.</summary>
		/// <param name="pstatstg">On successful return, contains a <see langword="STATSTG" /> structure which describes this stream object.</param>
		/// <param name="grfStatFlag">Specifies some of the members in the <see langword="STATSTG" /> structure that this method does not return, thus saving some memory allocation operations.</param>
		// Token: 0x060061BD RID: 25021
		void Stat(out STATSTG pstatstg, int grfStatFlag);

		/// <summary>Creates a new stream object with its own seek pointer that references the same bytes as the original stream.</summary>
		/// <param name="ppstm">On successful return, contains the new stream object.</param>
		// Token: 0x060061BE RID: 25022
		void Clone(out UCOMIStream ppstm);
	}
}
