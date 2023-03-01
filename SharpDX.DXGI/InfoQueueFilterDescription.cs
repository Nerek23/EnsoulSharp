using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000084 RID: 132
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct InfoQueueFilterDescription
	{
		// Token: 0x04000C33 RID: 3123
		public int NumCategories;

		// Token: 0x04000C34 RID: 3124
		public IntPtr PCategoryList;

		// Token: 0x04000C35 RID: 3125
		public int NumSeverities;

		// Token: 0x04000C36 RID: 3126
		public IntPtr PSeverityList;

		// Token: 0x04000C37 RID: 3127
		public int NumIDs;

		// Token: 0x04000C38 RID: 3128
		public IntPtr PIDList;
	}
}
