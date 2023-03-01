using System;

namespace SharpDX.Diagnostics
{
	// Token: 0x020000AC RID: 172
	public class ComObjectEventArgs : EventArgs
	{
		// Token: 0x06000358 RID: 856 RVA: 0x000099CE File Offset: 0x00007BCE
		public ComObjectEventArgs(ComObject o)
		{
			this.Object = o;
		}

		// Token: 0x04001238 RID: 4664
		public ComObject Object;
	}
}
