using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Defines the access modes for a dynamic assembly.</summary>
	// Token: 0x02000601 RID: 1537
	[ComVisible(true)]
	[Flags]
	[Serializable]
	public enum AssemblyBuilderAccess
	{
		/// <summary>The dynamic assembly can be executed, but not saved.</summary>
		// Token: 0x04001DC2 RID: 7618
		Run = 1,
		/// <summary>The dynamic assembly can be saved, but not executed.</summary>
		// Token: 0x04001DC3 RID: 7619
		Save = 2,
		/// <summary>The dynamic assembly can be executed and saved.</summary>
		// Token: 0x04001DC4 RID: 7620
		RunAndSave = 3,
		/// <summary>The dynamic assembly is loaded into the reflection-only context, and cannot be executed.</summary>
		// Token: 0x04001DC5 RID: 7621
		ReflectionOnly = 6,
		/// <summary>The dynamic assembly will be automatically unloaded and its memory reclaimed, when it's no longer accessible.</summary>
		// Token: 0x04001DC6 RID: 7622
		RunAndCollect = 9
	}
}
