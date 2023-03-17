using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Identifies the platform targeted by an executable.</summary>
	// Token: 0x020005DF RID: 1503
	[ComVisible(true)]
	[Serializable]
	public enum ImageFileMachine
	{
		/// <summary>Targets a 32-bit Intel processor.</summary>
		// Token: 0x04001CFB RID: 7419
		I386 = 332,
		/// <summary>Targets a 64-bit Intel processor.</summary>
		// Token: 0x04001CFC RID: 7420
		IA64 = 512,
		/// <summary>Targets a 64-bit AMD processor.</summary>
		// Token: 0x04001CFD RID: 7421
		AMD64 = 34404,
		/// <summary>Targets an ARM processor.</summary>
		// Token: 0x04001CFE RID: 7422
		ARM = 452
	}
}
