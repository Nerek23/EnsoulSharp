using System;

namespace SharpDX
{
	// Token: 0x02000019 RID: 25
	public abstract class DisposeBase : IDisposable
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000C0 RID: 192 RVA: 0x00003934 File Offset: 0x00001B34
		// (remove) Token: 0x060000C1 RID: 193 RVA: 0x0000396C File Offset: 0x00001B6C
		public event EventHandler<EventArgs> Disposing;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000C2 RID: 194 RVA: 0x000039A4 File Offset: 0x00001BA4
		// (remove) Token: 0x060000C3 RID: 195 RVA: 0x000039DC File Offset: 0x00001BDC
		public event EventHandler<EventArgs> Disposed;

		// Token: 0x060000C4 RID: 196 RVA: 0x00003A14 File Offset: 0x00001C14
		~DisposeBase()
		{
			this.CheckAndDispose(false);
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00003A44 File Offset: 0x00001C44
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x00003A4C File Offset: 0x00001C4C
		public bool IsDisposed { get; private set; }

		// Token: 0x060000C7 RID: 199 RVA: 0x00003A55 File Offset: 0x00001C55
		public void Dispose()
		{
			this.CheckAndDispose(true);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003A60 File Offset: 0x00001C60
		private void CheckAndDispose(bool disposing)
		{
			if (!this.IsDisposed)
			{
				EventHandler<EventArgs> disposing2 = this.Disposing;
				if (disposing2 != null)
				{
					disposing2(this, DisposeEventArgs.Get(disposing));
				}
				this.Dispose(disposing);
				GC.SuppressFinalize(this);
				this.IsDisposed = true;
				EventHandler<EventArgs> disposed = this.Disposed;
				if (disposed != null)
				{
					disposed(this, DisposeEventArgs.Get(disposing));
				}
			}
		}

		// Token: 0x060000C9 RID: 201
		protected abstract void Dispose(bool disposing);
	}
}
