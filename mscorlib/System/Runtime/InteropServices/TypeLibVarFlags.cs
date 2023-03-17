using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the original settings of the <see cref="T:System.Runtime.InteropServices.VARFLAGS" /> in the COM type library from which the variable was imported.</summary>
	// Token: 0x020008F8 RID: 2296
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibVarFlags
	{
		/// <summary>Assignment to the variable should not be allowed.</summary>
		// Token: 0x040029DF RID: 10719
		FReadOnly = 1,
		/// <summary>The variable returns an object that is a source of events.</summary>
		// Token: 0x040029E0 RID: 10720
		FSource = 2,
		/// <summary>The variable supports data binding.</summary>
		// Token: 0x040029E1 RID: 10721
		FBindable = 4,
		/// <summary>Indicates that the property supports the COM <see langword="OnRequestEdit" /> notification.</summary>
		// Token: 0x040029E2 RID: 10722
		FRequestEdit = 8,
		/// <summary>The variable is displayed as bindable. <see cref="F:System.Runtime.InteropServices.TypeLibVarFlags.FBindable" /> must also be set.</summary>
		// Token: 0x040029E3 RID: 10723
		FDisplayBind = 16,
		/// <summary>The variable is the single property that best represents the object. Only one variable in a type info can have this value.</summary>
		// Token: 0x040029E4 RID: 10724
		FDefaultBind = 32,
		/// <summary>The variable should not be displayed in a browser, though it exists and is bindable.</summary>
		// Token: 0x040029E5 RID: 10725
		FHidden = 64,
		/// <summary>This flag is intended for system-level functions or functions that type browsers should not display.</summary>
		// Token: 0x040029E6 RID: 10726
		FRestricted = 128,
		/// <summary>Permits an optimization in which the compiler looks for a member named "xyz" on the type "abc". If such a member is found and is flagged as an accessor function for an element of the default collection, then a call is generated to that member function.</summary>
		// Token: 0x040029E7 RID: 10727
		FDefaultCollelem = 256,
		/// <summary>The default display in the user interface.</summary>
		// Token: 0x040029E8 RID: 10728
		FUiDefault = 512,
		/// <summary>The variable appears in an object browser, but not in a properties browser.</summary>
		// Token: 0x040029E9 RID: 10729
		FNonBrowsable = 1024,
		/// <summary>Tags the interface as having default behaviors.</summary>
		// Token: 0x040029EA RID: 10730
		FReplaceable = 2048,
		/// <summary>The variable is mapped as individual bindable properties.</summary>
		// Token: 0x040029EB RID: 10731
		FImmediateBind = 4096
	}
}
