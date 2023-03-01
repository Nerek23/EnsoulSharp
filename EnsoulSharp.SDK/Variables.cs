using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200005A RID: 90
	public class Variables
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00019F11 File Offset: 0x00018111
		public static int GameTimeTickCount
		{
			get
			{
				return (int)(Game.Time * 1000f);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00019F20 File Offset: 0x00018120
		public static int TickCount
		{
			get
			{
				return (int)DateTime.UtcNow.Subtract(Variables.SDKLoadTime).TotalMilliseconds;
			}
		}

		// Token: 0x040001F4 RID: 500
		private static readonly DateTime SDKLoadTime = DateTime.UtcNow;

		// Token: 0x040001F5 RID: 501
		public static readonly Version SDKVersion = typeof(Bootstrap).Assembly.GetName().Version;
	}
}
