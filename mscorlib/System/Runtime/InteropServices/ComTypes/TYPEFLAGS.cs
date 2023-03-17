using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Defines the properties and attributes of a type description.</summary>
	// Token: 0x02000A0E RID: 2574
	[Flags]
	[__DynamicallyInvokable]
	[Serializable]
	public enum TYPEFLAGS : short
	{
		/// <summary>A type description that describes an <see langword="Application" /> object.</summary>
		// Token: 0x04002CB2 RID: 11442
		[__DynamicallyInvokable]
		TYPEFLAG_FAPPOBJECT = 1,
		/// <summary>Instances of the type can be created by <see langword="ITypeInfo::CreateInstance" />.</summary>
		// Token: 0x04002CB3 RID: 11443
		[__DynamicallyInvokable]
		TYPEFLAG_FCANCREATE = 2,
		/// <summary>The type is licensed.</summary>
		// Token: 0x04002CB4 RID: 11444
		[__DynamicallyInvokable]
		TYPEFLAG_FLICENSED = 4,
		/// <summary>The type is predefined. The client application should automatically create a single instance of the object that has this attribute. The name of the variable that points to the object is the same as the class name of the object.</summary>
		// Token: 0x04002CB5 RID: 11445
		[__DynamicallyInvokable]
		TYPEFLAG_FPREDECLID = 8,
		/// <summary>The type should not be displayed to browsers.</summary>
		// Token: 0x04002CB6 RID: 11446
		[__DynamicallyInvokable]
		TYPEFLAG_FHIDDEN = 16,
		/// <summary>The type is a control from which other types will be derived and should not be displayed to users.</summary>
		// Token: 0x04002CB7 RID: 11447
		[__DynamicallyInvokable]
		TYPEFLAG_FCONTROL = 32,
		/// <summary>The interface supplies both <see langword="IDispatch" /> and VTBL binding.</summary>
		// Token: 0x04002CB8 RID: 11448
		[__DynamicallyInvokable]
		TYPEFLAG_FDUAL = 64,
		/// <summary>The interface cannot add members at run time.</summary>
		// Token: 0x04002CB9 RID: 11449
		[__DynamicallyInvokable]
		TYPEFLAG_FNONEXTENSIBLE = 128,
		/// <summary>The types used in the interface are fully compatible with Automation, including VTBL binding support. Setting dual on an interface sets both this flag and the  <see cref="F:System.Runtime.InteropServices.TYPEFLAGS.TYPEFLAG_FDUAL" />. This flag is not allowed on dispinterfaces.</summary>
		// Token: 0x04002CBA RID: 11450
		[__DynamicallyInvokable]
		TYPEFLAG_FOLEAUTOMATION = 256,
		/// <summary>Should not be accessible from macro languages. This flag is intended for system-level types or types that type browsers should not display.</summary>
		// Token: 0x04002CBB RID: 11451
		[__DynamicallyInvokable]
		TYPEFLAG_FRESTRICTED = 512,
		/// <summary>The class supports aggregation.</summary>
		// Token: 0x04002CBC RID: 11452
		[__DynamicallyInvokable]
		TYPEFLAG_FAGGREGATABLE = 1024,
		/// <summary>The object supports <see langword="IConnectionPointWithDefault" />, and has default behaviors.</summary>
		// Token: 0x04002CBD RID: 11453
		[__DynamicallyInvokable]
		TYPEFLAG_FREPLACEABLE = 2048,
		/// <summary>Indicates that the interface derives from <see langword="IDispatch" />, either directly or indirectly. This flag is computed; there is no Object Description Language for the flag.</summary>
		// Token: 0x04002CBE RID: 11454
		[__DynamicallyInvokable]
		TYPEFLAG_FDISPATCHABLE = 4096,
		/// <summary>Indicates base interfaces should be checked for name resolution before checking children, which is the reverse of the default behavior.</summary>
		// Token: 0x04002CBF RID: 11455
		[__DynamicallyInvokable]
		TYPEFLAG_FREVERSEBIND = 8192,
		/// <summary>Indicates that the interface will be using a proxy/stub dynamic link library. This flag specifies that the type library proxy should not be unregistered when the type library is unregistered.</summary>
		// Token: 0x04002CC0 RID: 11456
		[__DynamicallyInvokable]
		TYPEFLAG_FPROXY = 16384
	}
}
