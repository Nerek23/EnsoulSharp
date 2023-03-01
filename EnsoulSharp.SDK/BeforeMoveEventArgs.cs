using System;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000043 RID: 67
	public class BeforeMoveEventArgs : EventArgs
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002CE RID: 718 RVA: 0x000120D6 File Offset: 0x000102D6
		// (set) Token: 0x060002CF RID: 719 RVA: 0x000120DE File Offset: 0x000102DE
		public bool Process { get; set; } = true;

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x000120E7 File Offset: 0x000102E7
		// (set) Token: 0x060002D1 RID: 721 RVA: 0x000120EF File Offset: 0x000102EF
		public Vector3 MovePosition { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x000120F8 File Offset: 0x000102F8
		// (set) Token: 0x060002D3 RID: 723 RVA: 0x00012100 File Offset: 0x00010300
		public string OrbwalkerName { get; set; }
	}
}
