using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.IO
{
	// Token: 0x0200009C RID: 156
	public class NativeFileStream : Stream
	{
		// Token: 0x06000324 RID: 804 RVA: 0x0000934C File Offset: 0x0000754C
		public NativeFileStream(string fileName, NativeFileMode fileMode, NativeFileAccess access, NativeFileShare share = NativeFileShare.Read)
		{
			this.handle = NativeFile.Create(fileName, access, share, IntPtr.Zero, fileMode, NativeFileOptions.None, IntPtr.Zero);
			if (!(this.handle == new IntPtr(-1)))
			{
				this.canRead = ((access & (NativeFileAccess)2147483648U) > (NativeFileAccess)0U);
				this.canWrite = ((access & NativeFileAccess.Write) > (NativeFileAccess)0U);
				this.canSeek = true;
				return;
			}
			int num = NativeFileStream.MarshalGetLastWin32Error();
			if (num == 2)
			{
				throw new FileNotFoundException("Unable to find file", fileName);
			}
			Result resultFromWin32Error = Result.GetResultFromWin32Error(num);
			throw new IOException(string.Format(CultureInfo.InvariantCulture, "Unable to open file {0}", new object[]
			{
				fileName
			}), resultFromWin32Error.Code);
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000093F5 File Offset: 0x000075F5
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000093FD File Offset: 0x000075FD
		private static int MarshalGetLastWin32Error()
		{
			return Marshal.GetLastWin32Error();
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00009404 File Offset: 0x00007604
		public override void Flush()
		{
			if (!NativeFile.FlushFileBuffers(this.handle))
			{
				throw new IOException("Unable to flush stream", NativeFileStream.MarshalGetLastWin32Error());
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00009424 File Offset: 0x00007624
		public override long Seek(long offset, SeekOrigin origin)
		{
			long num;
			if (!NativeFile.SetFilePointerEx(this.handle, offset, out num, origin))
			{
				throw new IOException("Unable to seek to this position", NativeFileStream.MarshalGetLastWin32Error());
			}
			this.position = num;
			return this.position;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x00009460 File Offset: 0x00007660
		public override void SetLength(long value)
		{
			long num;
			if (!NativeFile.SetFilePointerEx(this.handle, value, out num, SeekOrigin.Begin))
			{
				throw new IOException("Unable to seek to this position", NativeFileStream.MarshalGetLastWin32Error());
			}
			if (!NativeFile.SetEndOfFile(this.handle))
			{
				throw new IOException("Unable to set the new length", NativeFileStream.MarshalGetLastWin32Error());
			}
			if (this.position < value)
			{
				this.Seek(this.position, SeekOrigin.Begin);
				return;
			}
			this.Seek(0L, SeekOrigin.End);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x000094D0 File Offset: 0x000076D0
		public unsafe override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			void* value;
			if (buffer == null || buffer.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&buffer[0]);
			}
			return this.Read((IntPtr)value, offset, count);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00009514 File Offset: 0x00007714
		public unsafe int Read(IntPtr buffer, int offset, int count)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			void* value = (void*)((byte*)((void*)buffer) + offset);
			int num;
			if (!NativeFile.ReadFile(this.handle, (IntPtr)value, count, out num, IntPtr.Zero))
			{
				throw new IOException("Unable to read from file", NativeFileStream.MarshalGetLastWin32Error());
			}
			this.position += (long)num;
			return num;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00009580 File Offset: 0x00007780
		public unsafe override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			fixed (byte[] array = buffer)
			{
				void* value;
				if (buffer == null || array.Length == 0)
				{
					value = null;
				}
				else
				{
					value = (void*)(&array[0]);
				}
				this.Write((IntPtr)value, offset, count);
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000095C4 File Offset: 0x000077C4
		public unsafe void Write(IntPtr buffer, int offset, int count)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			void* value = (void*)((byte*)((void*)buffer) + offset);
			int num;
			if (!NativeFile.WriteFile(this.handle, (IntPtr)value, count, out num, IntPtr.Zero))
			{
				throw new IOException("Unable to write to file", NativeFileStream.MarshalGetLastWin32Error());
			}
			this.position += (long)num;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000962C File Offset: 0x0000782C
		public override bool CanRead
		{
			get
			{
				return this.canRead;
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00009634 File Offset: 0x00007834
		public override bool CanSeek
		{
			get
			{
				return this.canSeek;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000963C File Offset: 0x0000783C
		public override bool CanWrite
		{
			get
			{
				return this.canWrite;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00009644 File Offset: 0x00007844
		public override long Length
		{
			get
			{
				long result;
				if (!NativeFile.GetFileSizeEx(this.handle, out result))
				{
					throw new IOException("Unable to get file length", NativeFileStream.MarshalGetLastWin32Error());
				}
				return result;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000332 RID: 818 RVA: 0x00009671 File Offset: 0x00007871
		// (set) Token: 0x06000333 RID: 819 RVA: 0x00009679 File Offset: 0x00007879
		public override long Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.Seek(value, SeekOrigin.Begin);
				this.position = value;
			}
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000968B File Offset: 0x0000788B
		protected override void Dispose(bool disposing)
		{
			Utilities.CloseHandle(this.handle);
			this.handle = IntPtr.Zero;
			base.Dispose(disposing);
		}

		// Token: 0x040011D0 RID: 4560
		private bool canRead;

		// Token: 0x040011D1 RID: 4561
		private bool canWrite;

		// Token: 0x040011D2 RID: 4562
		private bool canSeek;

		// Token: 0x040011D3 RID: 4563
		private IntPtr handle;

		// Token: 0x040011D4 RID: 4564
		private long position;
	}
}
