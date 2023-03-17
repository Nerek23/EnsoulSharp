using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the original settings of the <see langword="FUNCFLAGS" /> in the COM type library from where this method was imported.</summary>
	// Token: 0x020008F7 RID: 2295
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibFuncFlags
	{
		/// <summary>This flag is intended for system-level functions or functions that type browsers should not display.</summary>
		// Token: 0x040029D1 RID: 10705
		FRestricted = 1,
		/// <summary>The function returns an object that is a source of events.</summary>
		// Token: 0x040029D2 RID: 10706
		FSource = 2,
		/// <summary>The function that supports data binding.</summary>
		// Token: 0x040029D3 RID: 10707
		FBindable = 4,
		/// <summary>When set, any call to a method that sets the property results first in a call to <see langword="IPropertyNotifySink::OnRequestEdit" />.</summary>
		// Token: 0x040029D4 RID: 10708
		FRequestEdit = 8,
		/// <summary>The function that is displayed to the user as bindable. <see cref="F:System.Runtime.InteropServices.TypeLibFuncFlags.FBindable" /> must also be set.</summary>
		// Token: 0x040029D5 RID: 10709
		FDisplayBind = 16,
		/// <summary>The function that best represents the object. Only one function in a type information can have this attribute.</summary>
		// Token: 0x040029D6 RID: 10710
		FDefaultBind = 32,
		/// <summary>The function should not be displayed to the user, although it exists and is bindable.</summary>
		// Token: 0x040029D7 RID: 10711
		FHidden = 64,
		/// <summary>The function supports <see langword="GetLastError" />.</summary>
		// Token: 0x040029D8 RID: 10712
		FUsesGetLastError = 128,
		/// <summary>Permits an optimization in which the compiler looks for a member named "xyz" on the type "abc". If such a member is found and is flagged as an accessor function for an element of the default collection, then a call is generated to that member function.</summary>
		// Token: 0x040029D9 RID: 10713
		FDefaultCollelem = 256,
		/// <summary>The type information member is the default member for display in the user interface.</summary>
		// Token: 0x040029DA RID: 10714
		FUiDefault = 512,
		/// <summary>The property appears in an object browser, but not in a properties browser.</summary>
		// Token: 0x040029DB RID: 10715
		FNonBrowsable = 1024,
		/// <summary>Tags the interface as having default behaviors.</summary>
		// Token: 0x040029DC RID: 10716
		FReplaceable = 2048,
		/// <summary>The function is mapped as individual bindable properties.</summary>
		// Token: 0x040029DD RID: 10717
		FImmediateBind = 4096
	}
}
