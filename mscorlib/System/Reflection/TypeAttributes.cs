using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies type attributes.</summary>
	// Token: 0x020005F7 RID: 1527
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum TypeAttributes
	{
		/// <summary>Specifies type visibility information.</summary>
		// Token: 0x04001D66 RID: 7526
		[__DynamicallyInvokable]
		VisibilityMask = 7,
		/// <summary>Specifies that the class is not public.</summary>
		// Token: 0x04001D67 RID: 7527
		[__DynamicallyInvokable]
		NotPublic = 0,
		/// <summary>Specifies that the class is public.</summary>
		// Token: 0x04001D68 RID: 7528
		[__DynamicallyInvokable]
		Public = 1,
		/// <summary>Specifies that the class is nested with public visibility.</summary>
		// Token: 0x04001D69 RID: 7529
		[__DynamicallyInvokable]
		NestedPublic = 2,
		/// <summary>Specifies that the class is nested with private visibility.</summary>
		// Token: 0x04001D6A RID: 7530
		[__DynamicallyInvokable]
		NestedPrivate = 3,
		/// <summary>Specifies that the class is nested with family visibility, and is thus accessible only by methods within its own type and any derived types.</summary>
		// Token: 0x04001D6B RID: 7531
		[__DynamicallyInvokable]
		NestedFamily = 4,
		/// <summary>Specifies that the class is nested with assembly visibility, and is thus accessible only by methods within its assembly.</summary>
		// Token: 0x04001D6C RID: 7532
		[__DynamicallyInvokable]
		NestedAssembly = 5,
		/// <summary>Specifies that the class is nested with assembly and family visibility, and is thus accessible only by methods lying in the intersection of its family and assembly.</summary>
		// Token: 0x04001D6D RID: 7533
		[__DynamicallyInvokable]
		NestedFamANDAssem = 6,
		/// <summary>Specifies that the class is nested with family or assembly visibility, and is thus accessible only by methods lying in the union of its family and assembly.</summary>
		// Token: 0x04001D6E RID: 7534
		[__DynamicallyInvokable]
		NestedFamORAssem = 7,
		/// <summary>Specifies class layout information.</summary>
		// Token: 0x04001D6F RID: 7535
		[__DynamicallyInvokable]
		LayoutMask = 24,
		/// <summary>Specifies that class fields are automatically laid out by the common language runtime.</summary>
		// Token: 0x04001D70 RID: 7536
		[__DynamicallyInvokable]
		AutoLayout = 0,
		/// <summary>Specifies that class fields are laid out sequentially, in the order that the fields were emitted to the metadata.</summary>
		// Token: 0x04001D71 RID: 7537
		[__DynamicallyInvokable]
		SequentialLayout = 8,
		/// <summary>Specifies that class fields are laid out at the specified offsets.</summary>
		// Token: 0x04001D72 RID: 7538
		[__DynamicallyInvokable]
		ExplicitLayout = 16,
		/// <summary>Specifies class semantics information; the current class is contextful (else agile).</summary>
		// Token: 0x04001D73 RID: 7539
		[__DynamicallyInvokable]
		ClassSemanticsMask = 32,
		/// <summary>Specifies that the type is a class.</summary>
		// Token: 0x04001D74 RID: 7540
		[__DynamicallyInvokable]
		Class = 0,
		/// <summary>Specifies that the type is an interface.</summary>
		// Token: 0x04001D75 RID: 7541
		[__DynamicallyInvokable]
		Interface = 32,
		/// <summary>Specifies that the type is abstract.</summary>
		// Token: 0x04001D76 RID: 7542
		[__DynamicallyInvokable]
		Abstract = 128,
		/// <summary>Specifies that the class is concrete and cannot be extended.</summary>
		// Token: 0x04001D77 RID: 7543
		[__DynamicallyInvokable]
		Sealed = 256,
		/// <summary>Specifies that the class is special in a way denoted by the name.</summary>
		// Token: 0x04001D78 RID: 7544
		[__DynamicallyInvokable]
		SpecialName = 1024,
		/// <summary>Specifies that the class or interface is imported from another module.</summary>
		// Token: 0x04001D79 RID: 7545
		[__DynamicallyInvokable]
		Import = 4096,
		/// <summary>Specifies that the class can be serialized.</summary>
		// Token: 0x04001D7A RID: 7546
		[__DynamicallyInvokable]
		Serializable = 8192,
		/// <summary>Specifies a Windows Runtime type.</summary>
		// Token: 0x04001D7B RID: 7547
		[ComVisible(false)]
		[__DynamicallyInvokable]
		WindowsRuntime = 16384,
		/// <summary>Used to retrieve string information for native interoperability.</summary>
		// Token: 0x04001D7C RID: 7548
		[__DynamicallyInvokable]
		StringFormatMask = 196608,
		/// <summary>LPTSTR is interpreted as ANSI.</summary>
		// Token: 0x04001D7D RID: 7549
		[__DynamicallyInvokable]
		AnsiClass = 0,
		/// <summary>LPTSTR is interpreted as UNICODE.</summary>
		// Token: 0x04001D7E RID: 7550
		[__DynamicallyInvokable]
		UnicodeClass = 65536,
		/// <summary>LPTSTR is interpreted automatically.</summary>
		// Token: 0x04001D7F RID: 7551
		[__DynamicallyInvokable]
		AutoClass = 131072,
		/// <summary>LPSTR is interpreted by some implementation-specific means, which includes the possibility of throwing a <see cref="T:System.NotSupportedException" />. Not used in the Microsoft implementation of the .NET Framework.</summary>
		// Token: 0x04001D80 RID: 7552
		[__DynamicallyInvokable]
		CustomFormatClass = 196608,
		/// <summary>Used to retrieve non-standard encoding information for native interop. The meaning of the values of these 2 bits is unspecified. Not used in the Microsoft implementation of the .NET Framework.</summary>
		// Token: 0x04001D81 RID: 7553
		[__DynamicallyInvokable]
		CustomFormatMask = 12582912,
		/// <summary>Specifies that calling static methods of the type does not force the system to initialize the type.</summary>
		// Token: 0x04001D82 RID: 7554
		[__DynamicallyInvokable]
		BeforeFieldInit = 1048576,
		/// <summary>Attributes reserved for runtime use.</summary>
		// Token: 0x04001D83 RID: 7555
		ReservedMask = 264192,
		/// <summary>Runtime should check name encoding.</summary>
		// Token: 0x04001D84 RID: 7556
		[__DynamicallyInvokable]
		RTSpecialName = 2048,
		/// <summary>Type has security associate with it.</summary>
		// Token: 0x04001D85 RID: 7557
		[__DynamicallyInvokable]
		HasSecurity = 262144
	}
}
