using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Indicates how to marshal the array elements when an array is marshaled from managed to unmanaged code as a <see cref="F:System.Runtime.InteropServices.UnmanagedType.SafeArray" />.</summary>
	// Token: 0x020008FC RID: 2300
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum VarEnum
	{
		/// <summary>Indicates that a value was not specified.</summary>
		// Token: 0x040029F0 RID: 10736
		[__DynamicallyInvokable]
		VT_EMPTY,
		/// <summary>Indicates a null value, similar to a null value in SQL.</summary>
		// Token: 0x040029F1 RID: 10737
		[__DynamicallyInvokable]
		VT_NULL,
		/// <summary>Indicates a <see langword="short" /> integer.</summary>
		// Token: 0x040029F2 RID: 10738
		[__DynamicallyInvokable]
		VT_I2,
		/// <summary>Indicates a <see langword="long" /> integer.</summary>
		// Token: 0x040029F3 RID: 10739
		[__DynamicallyInvokable]
		VT_I4,
		/// <summary>Indicates a <see langword="float" /> value.</summary>
		// Token: 0x040029F4 RID: 10740
		[__DynamicallyInvokable]
		VT_R4,
		/// <summary>Indicates a <see langword="double" /> value.</summary>
		// Token: 0x040029F5 RID: 10741
		[__DynamicallyInvokable]
		VT_R8,
		/// <summary>Indicates a currency value.</summary>
		// Token: 0x040029F6 RID: 10742
		[__DynamicallyInvokable]
		VT_CY,
		/// <summary>Indicates a DATE value.</summary>
		// Token: 0x040029F7 RID: 10743
		[__DynamicallyInvokable]
		VT_DATE,
		/// <summary>Indicates a BSTR string.</summary>
		// Token: 0x040029F8 RID: 10744
		[__DynamicallyInvokable]
		VT_BSTR,
		/// <summary>Indicates an <see langword="IDispatch" /> pointer.</summary>
		// Token: 0x040029F9 RID: 10745
		[__DynamicallyInvokable]
		VT_DISPATCH,
		/// <summary>Indicates an SCODE.</summary>
		// Token: 0x040029FA RID: 10746
		[__DynamicallyInvokable]
		VT_ERROR,
		/// <summary>Indicates a Boolean value.</summary>
		// Token: 0x040029FB RID: 10747
		[__DynamicallyInvokable]
		VT_BOOL,
		/// <summary>Indicates a VARIANT <see langword="far" /> pointer.</summary>
		// Token: 0x040029FC RID: 10748
		[__DynamicallyInvokable]
		VT_VARIANT,
		/// <summary>Indicates an <see langword="IUnknown" /> pointer.</summary>
		// Token: 0x040029FD RID: 10749
		[__DynamicallyInvokable]
		VT_UNKNOWN,
		/// <summary>Indicates a <see langword="decimal" /> value.</summary>
		// Token: 0x040029FE RID: 10750
		[__DynamicallyInvokable]
		VT_DECIMAL,
		/// <summary>Indicates a <see langword="char" /> value.</summary>
		// Token: 0x040029FF RID: 10751
		[__DynamicallyInvokable]
		VT_I1 = 16,
		/// <summary>Indicates a <see langword="byte" />.</summary>
		// Token: 0x04002A00 RID: 10752
		[__DynamicallyInvokable]
		VT_UI1,
		/// <summary>Indicates an <see langword="unsigned" /><see langword="short" />.</summary>
		// Token: 0x04002A01 RID: 10753
		[__DynamicallyInvokable]
		VT_UI2,
		/// <summary>Indicates an <see langword="unsigned" /><see langword="long" />.</summary>
		// Token: 0x04002A02 RID: 10754
		[__DynamicallyInvokable]
		VT_UI4,
		/// <summary>Indicates a 64-bit integer.</summary>
		// Token: 0x04002A03 RID: 10755
		[__DynamicallyInvokable]
		VT_I8,
		/// <summary>Indicates an 64-bit unsigned integer.</summary>
		// Token: 0x04002A04 RID: 10756
		[__DynamicallyInvokable]
		VT_UI8,
		/// <summary>Indicates an integer value.</summary>
		// Token: 0x04002A05 RID: 10757
		[__DynamicallyInvokable]
		VT_INT,
		/// <summary>Indicates an <see langword="unsigned" /> integer value.</summary>
		// Token: 0x04002A06 RID: 10758
		[__DynamicallyInvokable]
		VT_UINT,
		/// <summary>Indicates a C style <see langword="void" />.</summary>
		// Token: 0x04002A07 RID: 10759
		[__DynamicallyInvokable]
		VT_VOID,
		/// <summary>Indicates an HRESULT.</summary>
		// Token: 0x04002A08 RID: 10760
		[__DynamicallyInvokable]
		VT_HRESULT,
		/// <summary>Indicates a pointer type.</summary>
		// Token: 0x04002A09 RID: 10761
		[__DynamicallyInvokable]
		VT_PTR,
		/// <summary>Indicates a SAFEARRAY. Not valid in a VARIANT.</summary>
		// Token: 0x04002A0A RID: 10762
		[__DynamicallyInvokable]
		VT_SAFEARRAY,
		/// <summary>Indicates a C style array.</summary>
		// Token: 0x04002A0B RID: 10763
		[__DynamicallyInvokable]
		VT_CARRAY,
		/// <summary>Indicates a user defined type.</summary>
		// Token: 0x04002A0C RID: 10764
		[__DynamicallyInvokable]
		VT_USERDEFINED,
		/// <summary>Indicates a null-terminated string.</summary>
		// Token: 0x04002A0D RID: 10765
		[__DynamicallyInvokable]
		VT_LPSTR,
		/// <summary>Indicates a wide string terminated by <see langword="null" />.</summary>
		// Token: 0x04002A0E RID: 10766
		[__DynamicallyInvokable]
		VT_LPWSTR,
		/// <summary>Indicates a user defined type.</summary>
		// Token: 0x04002A0F RID: 10767
		[__DynamicallyInvokable]
		VT_RECORD = 36,
		/// <summary>Indicates a FILETIME value.</summary>
		// Token: 0x04002A10 RID: 10768
		[__DynamicallyInvokable]
		VT_FILETIME = 64,
		/// <summary>Indicates length prefixed bytes.</summary>
		// Token: 0x04002A11 RID: 10769
		[__DynamicallyInvokable]
		VT_BLOB,
		/// <summary>Indicates that the name of a stream follows.</summary>
		// Token: 0x04002A12 RID: 10770
		[__DynamicallyInvokable]
		VT_STREAM,
		/// <summary>Indicates that the name of a storage follows.</summary>
		// Token: 0x04002A13 RID: 10771
		[__DynamicallyInvokable]
		VT_STORAGE,
		/// <summary>Indicates that a stream contains an object.</summary>
		// Token: 0x04002A14 RID: 10772
		[__DynamicallyInvokable]
		VT_STREAMED_OBJECT,
		/// <summary>Indicates that a storage contains an object.</summary>
		// Token: 0x04002A15 RID: 10773
		[__DynamicallyInvokable]
		VT_STORED_OBJECT,
		/// <summary>Indicates that a blob contains an object.</summary>
		// Token: 0x04002A16 RID: 10774
		[__DynamicallyInvokable]
		VT_BLOB_OBJECT,
		/// <summary>Indicates the clipboard format.</summary>
		// Token: 0x04002A17 RID: 10775
		[__DynamicallyInvokable]
		VT_CF,
		/// <summary>Indicates a class ID.</summary>
		// Token: 0x04002A18 RID: 10776
		[__DynamicallyInvokable]
		VT_CLSID,
		/// <summary>Indicates a simple, counted array.</summary>
		// Token: 0x04002A19 RID: 10777
		[__DynamicallyInvokable]
		VT_VECTOR = 4096,
		/// <summary>Indicates a <see langword="SAFEARRAY" /> pointer.</summary>
		// Token: 0x04002A1A RID: 10778
		[__DynamicallyInvokable]
		VT_ARRAY = 8192,
		/// <summary>Indicates that a value is a reference.</summary>
		// Token: 0x04002A1B RID: 10779
		[__DynamicallyInvokable]
		VT_BYREF = 16384
	}
}
