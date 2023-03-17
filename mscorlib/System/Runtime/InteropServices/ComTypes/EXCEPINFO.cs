using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Describes the exceptions that occur during <see langword="IDispatch::Invoke" />.</summary>
	// Token: 0x02000A1B RID: 2587
	[__DynamicallyInvokable]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EXCEPINFO
	{
		/// <summary>Represents an error code identifying the error.</summary>
		// Token: 0x04002D0B RID: 11531
		[__DynamicallyInvokable]
		public short wCode;

		/// <summary>This field is reserved; it must be set to 0.</summary>
		// Token: 0x04002D0C RID: 11532
		[__DynamicallyInvokable]
		public short wReserved;

		/// <summary>Indicates the name of the source of the exception. Typically, this is an application name.</summary>
		// Token: 0x04002D0D RID: 11533
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrSource;

		/// <summary>Describes the error intended for the customer.</summary>
		// Token: 0x04002D0E RID: 11534
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrDescription;

		/// <summary>Contains the fully-qualified drive, path, and file name of a Help file that contains more information about the error.</summary>
		// Token: 0x04002D0F RID: 11535
		[__DynamicallyInvokable]
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrHelpFile;

		/// <summary>Indicates the Help context ID of the topic within the Help file.</summary>
		// Token: 0x04002D10 RID: 11536
		[__DynamicallyInvokable]
		public int dwHelpContext;

		/// <summary>This field is reserved; it must be set to <see langword="null" />.</summary>
		// Token: 0x04002D11 RID: 11537
		public IntPtr pvReserved;

		/// <summary>Represents a pointer to a function that takes an <see cref="T:System.Runtime.InteropServices.EXCEPINFO" /> structure as an argument and returns an HRESULT value. If deferred fill-in is not desired, this field is set to <see langword="null" />.</summary>
		// Token: 0x04002D12 RID: 11538
		public IntPtr pfnDeferredFillIn;

		/// <summary>A return value describing the error.</summary>
		// Token: 0x04002D13 RID: 11539
		[__DynamicallyInvokable]
		public int scode;
	}
}
