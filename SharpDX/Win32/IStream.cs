using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SharpDX.Win32
{
	// Token: 0x0200004F RID: 79
	[Guid("0000000c-0000-0000-C000-000000000046")]
	[Shadow(typeof(ComStreamShadow))]
	public interface IStream : IStreamBase, IUnknown, ICallbackable, IDisposable
	{
		// Token: 0x06000243 RID: 579
		long Seek(long offset, SeekOrigin origin);

		// Token: 0x06000244 RID: 580
		void SetSize(long newSize);

		// Token: 0x06000245 RID: 581
		long CopyTo(IStream streamDest, long numberOfBytesToCopy, out long bytesWritten);

		// Token: 0x06000246 RID: 582
		void Commit(CommitFlags commitFlags);

		// Token: 0x06000247 RID: 583
		void Revert();

		// Token: 0x06000248 RID: 584
		void LockRegion(long offset, long numberOfBytesToLock, LockType dwLockType);

		// Token: 0x06000249 RID: 585
		void UnlockRegion(long offset, long numberOfBytesToLock, LockType dwLockType);

		// Token: 0x0600024A RID: 586
		StorageStatistics GetStatistics(StorageStatisticsFlags storageStatisticsFlags);

		// Token: 0x0600024B RID: 587
		IStream Clone();
	}
}
