using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x02000041 RID: 65
	[Guid("0000000c-0000-0000-C000-000000000046")]
	internal class ComStreamProxy : CallbackBase, IStream, IStreamBase, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x060001F9 RID: 505 RVA: 0x0000636C File Offset: 0x0000456C
		public ComStreamProxy(Stream sourceStream)
		{
			this.sourceStream = sourceStream;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000638C File Offset: 0x0000458C
		public unsafe int Read(IntPtr buffer, int numberOfBytesToRead)
		{
			int num = 0;
			while (numberOfBytesToRead > 0)
			{
				int count = Math.Min(numberOfBytesToRead, this.tempBuffer.Length);
				int num2 = this.sourceStream.Read(this.tempBuffer, 0, count);
				if (num2 == 0)
				{
					return num;
				}
				Utilities.Write<byte>(new IntPtr((void*)(num + (byte*)((void*)buffer))), this.tempBuffer, 0, num2);
				numberOfBytesToRead -= num2;
				num += num2;
			}
			return num;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000063F0 File Offset: 0x000045F0
		public unsafe int Write(IntPtr buffer, int numberOfBytesToWrite)
		{
			int num = 0;
			while (numberOfBytesToWrite > 0)
			{
				int num2 = Math.Min(numberOfBytesToWrite, this.tempBuffer.Length);
				Utilities.Read<byte>(new IntPtr((void*)(num + (byte*)((void*)buffer))), this.tempBuffer, 0, num2);
				this.sourceStream.Write(this.tempBuffer, 0, num2);
				numberOfBytesToWrite -= num2;
				num += num2;
			}
			return num;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000644C File Offset: 0x0000464C
		public long Seek(long offset, SeekOrigin origin)
		{
			return this.sourceStream.Seek(offset, origin);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000022F0 File Offset: 0x000004F0
		public void SetSize(long newSize)
		{
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000645C File Offset: 0x0000465C
		public unsafe long CopyTo(IStream streamDest, long numberOfBytesToCopy, out long bytesWritten)
		{
			bytesWritten = 0L;
			byte[] array;
			void* value;
			if ((array = this.tempBuffer) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			while (numberOfBytesToCopy > 0L)
			{
				int count = (int)Math.Min(numberOfBytesToCopy, (long)this.tempBuffer.Length);
				int num = this.sourceStream.Read(this.tempBuffer, 0, count);
				if (num == 0)
				{
					break;
				}
				streamDest.Write((IntPtr)value, num);
				numberOfBytesToCopy -= (long)num;
				bytesWritten += (long)num;
			}
			array = null;
			return bytesWritten;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000064D8 File Offset: 0x000046D8
		public void Commit(CommitFlags commitFlags)
		{
			this.sourceStream.Flush();
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00003F3C File Offset: 0x0000213C
		public void Revert()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00003F3C File Offset: 0x0000213C
		public void LockRegion(long offset, long numberOfBytesToLock, LockType dwLockType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00003F3C File Offset: 0x0000213C
		public void UnlockRegion(long offset, long numberOfBytesToLock, LockType dwLockType)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000064E8 File Offset: 0x000046E8
		public StorageStatistics GetStatistics(StorageStatisticsFlags storageStatisticsFlags)
		{
			long num = this.sourceStream.Length;
			if (num == 0L)
			{
				num = 2147483647L;
			}
			return new StorageStatistics
			{
				Type = 2,
				CbSize = num,
				GrfLocksSupported = 2,
				GrfMode = 2
			};
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00006534 File Offset: 0x00004734
		public IStream Clone()
		{
			return new ComStreamProxy(this.sourceStream);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00006541 File Offset: 0x00004741
		protected override void Dispose(bool disposing)
		{
			this.sourceStream = null;
			base.Dispose(disposing);
		}

		// Token: 0x040000A0 RID: 160
		private Stream sourceStream;

		// Token: 0x040000A1 RID: 161
		private byte[] tempBuffer = new byte[4096];
	}
}
