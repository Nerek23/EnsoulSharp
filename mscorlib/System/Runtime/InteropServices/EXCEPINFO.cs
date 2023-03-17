using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Use <see cref="T:System.Runtime.InteropServices.ComTypes.EXCEPINFO" /> instead.</summary>
	// Token: 0x02000971 RID: 2417
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.EXCEPINFO instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct EXCEPINFO
	{
		/// <summary>Represents an error code identifying the error.</summary>
		// Token: 0x04002BA1 RID: 11169
		public short wCode;

		/// <summary>This field is reserved; must be set to 0.</summary>
		// Token: 0x04002BA2 RID: 11170
		public short wReserved;

		/// <summary>Indicates the name of the source of the exception. Typically, this is an application name.</summary>
		// Token: 0x04002BA3 RID: 11171
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrSource;

		/// <summary>Describes the error intended for the customer.</summary>
		// Token: 0x04002BA4 RID: 11172
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrDescription;

		/// <summary>Contains the fully-qualified drive, path, and file name of a Help file with more information about the error.</summary>
		// Token: 0x04002BA5 RID: 11173
		[MarshalAs(UnmanagedType.BStr)]
		public string bstrHelpFile;

		/// <summary>Indicates the Help context ID of the topic within the Help file.</summary>
		// Token: 0x04002BA6 RID: 11174
		public int dwHelpContext;

		/// <summary>This field is reserved; must be set to <see langword="null" />.</summary>
		// Token: 0x04002BA7 RID: 11175
		public IntPtr pvReserved;

		/// <summary>Represents a pointer to a function that takes an <see cref="T:System.Runtime.InteropServices.EXCEPINFO" /> structure as an argument and returns an HRESULT value. If deferred fill-in is not desired, this field is set to <see langword="null" />.</summary>
		// Token: 0x04002BA8 RID: 11176
		public IntPtr pfnDeferredFillIn;
	}
}
