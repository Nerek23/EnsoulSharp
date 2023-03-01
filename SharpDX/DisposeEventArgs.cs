using System;

namespace SharpDX
{
	// Token: 0x0200001B RID: 27
	public class DisposeEventArgs : EventArgs
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x00003C84 File Offset: 0x00001E84
		private DisposeEventArgs(bool disposing)
		{
			this.Disposing = disposing;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003C93 File Offset: 0x00001E93
		public static DisposeEventArgs Get(bool disposing)
		{
			if (!disposing)
			{
				return DisposeEventArgs.NotDisposingEventArgs;
			}
			return DisposeEventArgs.DisposingEventArgs;
		}

		// Token: 0x0400002F RID: 47
		public static readonly DisposeEventArgs DisposingEventArgs = new DisposeEventArgs(true);

		// Token: 0x04000030 RID: 48
		public static readonly DisposeEventArgs NotDisposingEventArgs = new DisposeEventArgs(false);

		// Token: 0x04000031 RID: 49
		public readonly bool Disposing;
	}
}
