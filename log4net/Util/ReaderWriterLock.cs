using System;
using System.Threading;

namespace log4net.Util
{
	// Token: 0x0200002A RID: 42
	public sealed class ReaderWriterLock
	{
		// Token: 0x060001AB RID: 427 RVA: 0x00005BB7 File Offset: 0x00004BB7
		public ReaderWriterLock()
		{
			this.m_lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00005BCC File Offset: 0x00004BCC
		public void AcquireReaderLock()
		{
			try
			{
			}
			finally
			{
				this.m_lock.EnterReadLock();
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00005BF8 File Offset: 0x00004BF8
		public void ReleaseReaderLock()
		{
			this.m_lock.ExitReadLock();
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00005C08 File Offset: 0x00004C08
		public void AcquireWriterLock()
		{
			try
			{
			}
			finally
			{
				this.m_lock.EnterWriteLock();
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00005C34 File Offset: 0x00004C34
		public void ReleaseWriterLock()
		{
			this.m_lock.ExitWriteLock();
		}

		// Token: 0x0400005E RID: 94
		private ReaderWriterLockSlim m_lock;
	}
}
