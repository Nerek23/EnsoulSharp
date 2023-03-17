using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Describes the original settings of the <see cref="T:System.Runtime.InteropServices.TYPEFLAGS" /> in the COM type library from which the type was imported.</summary>
	// Token: 0x020008F6 RID: 2294
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum TypeLibTypeFlags
	{
		/// <summary>A type description that describes an <see langword="Application" /> object.</summary>
		// Token: 0x040029C2 RID: 10690
		FAppObject = 1,
		/// <summary>Instances of the type can be created by <see langword="ITypeInfo::CreateInstance" />.</summary>
		// Token: 0x040029C3 RID: 10691
		FCanCreate = 2,
		/// <summary>The type is licensed.</summary>
		// Token: 0x040029C4 RID: 10692
		FLicensed = 4,
		/// <summary>The type is predefined. The client application should automatically create a single instance of the object that has this attribute. The name of the variable that points to the object is the same as the class name of the object.</summary>
		// Token: 0x040029C5 RID: 10693
		FPreDeclId = 8,
		/// <summary>The type should not be displayed to browsers.</summary>
		// Token: 0x040029C6 RID: 10694
		FHidden = 16,
		/// <summary>The type is a control from which other types will be derived, and should not be displayed to users.</summary>
		// Token: 0x040029C7 RID: 10695
		FControl = 32,
		/// <summary>The interface supplies both <see langword="IDispatch" /> and V-table binding.</summary>
		// Token: 0x040029C8 RID: 10696
		FDual = 64,
		/// <summary>The interface cannot add members at run time.</summary>
		// Token: 0x040029C9 RID: 10697
		FNonExtensible = 128,
		/// <summary>The types used in the interface are fully compatible with Automation, including vtable binding support.</summary>
		// Token: 0x040029CA RID: 10698
		FOleAutomation = 256,
		/// <summary>This flag is intended for system-level types or types that type browsers should not display.</summary>
		// Token: 0x040029CB RID: 10699
		FRestricted = 512,
		/// <summary>The class supports aggregation.</summary>
		// Token: 0x040029CC RID: 10700
		FAggregatable = 1024,
		/// <summary>The object supports <see langword="IConnectionPointWithDefault" />, and has default behaviors.</summary>
		// Token: 0x040029CD RID: 10701
		FReplaceable = 2048,
		/// <summary>Indicates that the interface derives from <see langword="IDispatch" />, either directly or indirectly.</summary>
		// Token: 0x040029CE RID: 10702
		FDispatchable = 4096,
		/// <summary>Indicates base interfaces should be checked for name resolution before checking child interfaces. This is the reverse of the default behavior.</summary>
		// Token: 0x040029CF RID: 10703
		FReverseBind = 8192
	}
}
