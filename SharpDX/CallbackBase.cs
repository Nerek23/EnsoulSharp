using System;
using System.Threading;

namespace SharpDX
{
	// Token: 0x02000003 RID: 3
	public abstract class CallbackBase : DisposeBase, ICallbackable, IDisposable
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Release();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002070 File Offset: 0x00000270
		public int AddReference()
		{
			int num2;
			for (int num = this.refCount; num != 0; num = num2)
			{
				num2 = Interlocked.CompareExchange(ref this.refCount, num + 1, num);
				if (num2 == num)
				{
					return num + 1;
				}
			}
			throw new ObjectDisposedException("Cannot add a reference to a nonreferenced item");
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020B0 File Offset: 0x000002B0
		public int Release()
		{
			int num = this.refCount;
			for (;;)
			{
				int num2 = Interlocked.CompareExchange(ref this.refCount, num - 1, num);
				if (num2 == num)
				{
					break;
				}
				num = num2;
			}
			if (num == 1)
			{
				((ICallbackable)this).Shadow.Dispose();
				((ICallbackable)this).Shadow = null;
			}
			return num - 1;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020F8 File Offset: 0x000002F8
		public Result QueryInterface(ref Guid guid, out IntPtr comObject)
		{
			ShadowContainer shadowContainer = (ShadowContainer)((ICallbackable)this).Shadow;
			comObject = shadowContainer.Find(guid);
			if (comObject == IntPtr.Zero)
			{
				return Result.NoInterface;
			}
			return Result.Ok;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000213D File Offset: 0x0000033D
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002145 File Offset: 0x00000345
		IDisposable ICallbackable.Shadow { get; set; }

		// Token: 0x04000001 RID: 1
		private int refCount = 1;
	}
}
