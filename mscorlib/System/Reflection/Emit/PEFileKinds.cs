using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Specifies the type of the portable executable (PE) file.</summary>
	// Token: 0x02000626 RID: 1574
	[ComVisible(true)]
	[Serializable]
	public enum PEFileKinds
	{
		/// <summary>The portable executable (PE) file is a DLL.</summary>
		// Token: 0x04001EAD RID: 7853
		Dll = 1,
		/// <summary>The application is a console (not a Windows-based) application.</summary>
		// Token: 0x04001EAE RID: 7854
		ConsoleApplication,
		/// <summary>The application is a Windows-based application.</summary>
		// Token: 0x04001EAF RID: 7855
		WindowApplication
	}
}
