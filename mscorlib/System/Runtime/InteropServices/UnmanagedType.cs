using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Identifies how to marshal parameters or fields to unmanaged code.</summary>
	// Token: 0x020008FD RID: 2301
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum UnmanagedType
	{
		/// <summary>A 4-byte Boolean value (<see langword="true" /> != 0, <see langword="false" /> = 0). This is the Win32 BOOL type.</summary>
		// Token: 0x04002A1D RID: 10781
		[__DynamicallyInvokable]
		Bool = 2,
		/// <summary>A 1-byte signed integer. You can use this member to transform a Boolean value into a 1-byte, C-style <see langword="bool" /> (<see langword="true" /> = 1, <see langword="false" /> = 0).</summary>
		// Token: 0x04002A1E RID: 10782
		[__DynamicallyInvokable]
		I1,
		/// <summary>A 1-byte unsigned integer.</summary>
		// Token: 0x04002A1F RID: 10783
		[__DynamicallyInvokable]
		U1,
		/// <summary>A 2-byte signed integer.</summary>
		// Token: 0x04002A20 RID: 10784
		[__DynamicallyInvokable]
		I2,
		/// <summary>A 2-byte unsigned integer.</summary>
		// Token: 0x04002A21 RID: 10785
		[__DynamicallyInvokable]
		U2,
		/// <summary>A 4-byte signed integer.</summary>
		// Token: 0x04002A22 RID: 10786
		[__DynamicallyInvokable]
		I4,
		/// <summary>A 4-byte unsigned integer.</summary>
		// Token: 0x04002A23 RID: 10787
		[__DynamicallyInvokable]
		U4,
		/// <summary>An 8-byte signed integer.</summary>
		// Token: 0x04002A24 RID: 10788
		[__DynamicallyInvokable]
		I8,
		/// <summary>An 8-byte unsigned integer.</summary>
		// Token: 0x04002A25 RID: 10789
		[__DynamicallyInvokable]
		U8,
		/// <summary>A 4-byte floating-point number.</summary>
		// Token: 0x04002A26 RID: 10790
		[__DynamicallyInvokable]
		R4,
		/// <summary>An 8-byte floating-point number.</summary>
		// Token: 0x04002A27 RID: 10791
		[__DynamicallyInvokable]
		R8,
		/// <summary>A currency type. Used on a <see cref="T:System.Decimal" /> to marshal the decimal value as a COM currency type instead of as a <see langword="Decimal" />.</summary>
		// Token: 0x04002A28 RID: 10792
		[__DynamicallyInvokable]
		Currency = 15,
		/// <summary>A Unicode character string that is a length-prefixed double byte. You can use this member, which is the default string in COM, on the <see cref="T:System.String" /> data type.</summary>
		// Token: 0x04002A29 RID: 10793
		[__DynamicallyInvokable]
		BStr = 19,
		/// <summary>A single byte, null-terminated ANSI character string. You can use this member on the <see cref="T:System.String" /> and <see cref="T:System.Text.StringBuilder" /> data types.</summary>
		// Token: 0x04002A2A RID: 10794
		[__DynamicallyInvokable]
		LPStr,
		/// <summary>A 2-byte, null-terminated Unicode character string.</summary>
		// Token: 0x04002A2B RID: 10795
		[__DynamicallyInvokable]
		LPWStr,
		/// <summary>A platform-dependent character string: ANSI on Windows 98, and Unicode on Windows NT and Windows XP. This value is supported only for platform invoke and not for COM interop, because exporting a string of type <see langword="LPTStr" /> is not supported.</summary>
		// Token: 0x04002A2C RID: 10796
		[__DynamicallyInvokable]
		LPTStr,
		/// <summary>Used for in-line, fixed-length character arrays that appear within a structure. The character type used with <see cref="F:System.Runtime.InteropServices.UnmanagedType.ByValTStr" /> is determined by the <see cref="T:System.Runtime.InteropServices.CharSet" /> argument of the <see cref="T:System.Runtime.InteropServices.StructLayoutAttribute" /> attribute applied to the containing structure. Always use the <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.SizeConst" /> field to indicate the size of the array.</summary>
		// Token: 0x04002A2D RID: 10797
		[__DynamicallyInvokable]
		ByValTStr,
		/// <summary>A COM <see langword="IUnknown" /> pointer. You can use this member on the <see cref="T:System.Object" /> data type.</summary>
		// Token: 0x04002A2E RID: 10798
		[__DynamicallyInvokable]
		IUnknown = 25,
		/// <summary>A COM <see langword="IDispatch" /> pointer (<see langword="Object" /> in Microsoft Visual Basic 6.0).</summary>
		// Token: 0x04002A2F RID: 10799
		[__DynamicallyInvokable]
		IDispatch,
		/// <summary>A VARIANT, which is used to marshal managed formatted classes and value types.</summary>
		// Token: 0x04002A30 RID: 10800
		[__DynamicallyInvokable]
		Struct,
		/// <summary>A COM interface pointer. The <see cref="T:System.Guid" /> of the interface is obtained from the class metadata. Use this member to specify the exact interface type or the default interface type if you apply it to a class. This member produces the same behavior as <see cref="F:System.Runtime.InteropServices.UnmanagedType.IUnknown" /> when you apply it to the <see cref="T:System.Object" /> data type.</summary>
		// Token: 0x04002A31 RID: 10801
		[__DynamicallyInvokable]
		Interface,
		/// <summary>A <see langword="SafeArray" />, which is a self-describing array that carries the type, rank, and bounds of the associated array data. You can use this member with the <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.SafeArraySubType" /> field to override the default element type.</summary>
		// Token: 0x04002A32 RID: 10802
		[__DynamicallyInvokable]
		SafeArray,
		/// <summary>When the <see cref="P:System.Runtime.InteropServices.MarshalAsAttribute.Value" /> property is set to <see langword="ByValArray" />, the <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.SizeConst" /> field must be set to indicate the number of elements in the array. The <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.ArraySubType" /> field can optionally contain the <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> of the array elements when it is necessary to differentiate among string types. You can use this <see cref="T:System.Runtime.InteropServices.UnmanagedType" /> only on an array that whose elements appear as fields in a structure.</summary>
		// Token: 0x04002A33 RID: 10803
		[__DynamicallyInvokable]
		ByValArray,
		/// <summary>A platform-dependent, signed integer: 4 bytes on 32-bit Windows, 8 bytes on 64-bit Windows.</summary>
		// Token: 0x04002A34 RID: 10804
		[__DynamicallyInvokable]
		SysInt,
		/// <summary>A platform-dependent, unsigned integer: 4 bytes on 32-bit Windows, 8 bytes on 64-bit Windows.</summary>
		// Token: 0x04002A35 RID: 10805
		[__DynamicallyInvokable]
		SysUInt,
		/// <summary>A value that enables Visual Basic to change a string in unmanaged code and have the results reflected in managed code. This value is only supported for platform invoke.</summary>
		// Token: 0x04002A36 RID: 10806
		[__DynamicallyInvokable]
		VBByRefStr = 34,
		/// <summary>An ANSI character string that is a length-prefixed single byte. You can use this member on the <see cref="T:System.String" /> data type.</summary>
		// Token: 0x04002A37 RID: 10807
		[__DynamicallyInvokable]
		AnsiBStr,
		/// <summary>A length-prefixed, platform-dependent <see langword="char" /> string: ANSI on Windows 98, Unicode on Windows NT. You rarely use this BSTR-like member.</summary>
		// Token: 0x04002A38 RID: 10808
		[__DynamicallyInvokable]
		TBStr,
		/// <summary>A 2-byte, OLE-defined VARIANT_BOOL type (<see langword="true" /> = -1, <see langword="false" /> = 0).</summary>
		// Token: 0x04002A39 RID: 10809
		[__DynamicallyInvokable]
		VariantBool,
		/// <summary>An integer that can be used as a C-style function pointer. You can use this member on a <see cref="T:System.Delegate" /> data type or on a type that inherits from a <see cref="T:System.Delegate" />.</summary>
		// Token: 0x04002A3A RID: 10810
		[__DynamicallyInvokable]
		FunctionPtr,
		/// <summary>A dynamic type that determines the type of an object at run time and marshals the object as that type. This member is valid for platform invoke methods only.</summary>
		// Token: 0x04002A3B RID: 10811
		[__DynamicallyInvokable]
		AsAny = 40,
		/// <summary>A pointer to the first element of a C-style array. When marshaling from managed to unmanaged code, the length of the array is determined by the length of the managed array. When marshaling from unmanaged to managed code, the length of the array is determined from the <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.SizeConst" /> and <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.SizeParamIndex" /> fields, optionally followed by the unmanaged type of the elements within the array when it is necessary to differentiate among string types.</summary>
		// Token: 0x04002A3C RID: 10812
		[__DynamicallyInvokable]
		LPArray = 42,
		/// <summary>A pointer to a C-style structure that you use to marshal managed formatted classes. This member is valid for platform invoke methods only.</summary>
		// Token: 0x04002A3D RID: 10813
		[__DynamicallyInvokable]
		LPStruct,
		/// <summary>Specifies the custom marshaler class when used with the <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.MarshalType" /> or <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.MarshalTypeRef" /> field. The <see cref="F:System.Runtime.InteropServices.MarshalAsAttribute.MarshalCookie" /> field can be used to pass additional information to the custom marshaler. You can use this member on any reference type. This member is valid for parameters and return values only. It cannot be used on fields.</summary>
		// Token: 0x04002A3E RID: 10814
		[__DynamicallyInvokable]
		CustomMarshaler,
		/// <summary>A native type that is associated with an <see cref="F:System.Runtime.InteropServices.UnmanagedType.I4" /> or an <see cref="F:System.Runtime.InteropServices.UnmanagedType.U4" /> and that causes the parameter to be exported as an HRESULT in the exported type library.</summary>
		// Token: 0x04002A3F RID: 10815
		[__DynamicallyInvokable]
		Error,
		/// <summary>A Windows Runtime interface pointer. You can use this member on the <see cref="T:System.Object" /> data type.</summary>
		// Token: 0x04002A40 RID: 10816
		[ComVisible(false)]
		[__DynamicallyInvokable]
		IInspectable,
		/// <summary>A Windows Runtime string. You can use this member on the <see cref="T:System.String" /> data type.</summary>
		// Token: 0x04002A41 RID: 10817
		[ComVisible(false)]
		[__DynamicallyInvokable]
		HString,
		/// <summary>A pointer to a UTF-8 encoded string.</summary>
		// Token: 0x04002A42 RID: 10818
		[ComVisible(false)]
		LPUTF8Str
	}
}
