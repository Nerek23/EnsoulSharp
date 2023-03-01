using System;
using EnsoulSharp.SDK.MenuUI;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000007 RID: 7
	public class Library
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000029A8 File Offset: 0x00000BA8
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000029AF File Offset: 0x00000BAF
		public static GameEvent GameEvent { get; internal set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000029B7 File Offset: 0x00000BB7
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000029BE File Offset: 0x00000BBE
		public static GameObjects GameObjects { get; internal set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000029 RID: 41 RVA: 0x000029C6 File Offset: 0x00000BC6
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000029CD File Offset: 0x00000BCD
		public static DamageData DamageData { get; internal set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000029D5 File Offset: 0x00000BD5
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000029DC File Offset: 0x00000BDC
		public static MenuWrapper MenuWrapper { get; internal set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000029E4 File Offset: 0x00000BE4
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000029EB File Offset: 0x00000BEB
		public static GameCache GameCache { get; set; }
	}
}
