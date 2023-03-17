using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Identifies the nature of the code in an executable file.</summary>
	// Token: 0x020005DE RID: 1502
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum PortableExecutableKinds
	{
		/// <summary>The file is not in portable executable (PE) file format.</summary>
		// Token: 0x04001CF4 RID: 7412
		NotAPortableExecutableImage = 0,
		/// <summary>The executable contains only Microsoft intermediate language (MSIL), and is therefore neutral with respect to 32-bit or 64-bit platforms.</summary>
		// Token: 0x04001CF5 RID: 7413
		ILOnly = 1,
		/// <summary>The executable can be run on a 32-bit platform, or in the 32-bit Windows on Windows (WOW) environment on a 64-bit platform.</summary>
		// Token: 0x04001CF6 RID: 7414
		Required32Bit = 2,
		/// <summary>The executable requires a 64-bit platform.</summary>
		// Token: 0x04001CF7 RID: 7415
		PE32Plus = 4,
		/// <summary>The executable contains pure unmanaged code.</summary>
		// Token: 0x04001CF8 RID: 7416
		Unmanaged32Bit = 8,
		/// <summary>The executable is platform-agnostic but should be run on a 32-bit platform whenever possible.</summary>
		// Token: 0x04001CF9 RID: 7417
		[ComVisible(false)]
		Preferred32Bit = 16
	}
}
