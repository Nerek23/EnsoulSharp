using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.IO
{
	/// <summary>The exception that is thrown when part of a file or directory cannot be found.</summary>
	// Token: 0x0200017D RID: 381
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class DirectoryNotFoundException : IOException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.IO.DirectoryNotFoundException" /> class with its message string set to a system-supplied message and its HRESULT set to COR_E_DIRECTORYNOTFOUND.</summary>
		// Token: 0x06001782 RID: 6018 RVA: 0x0004B5CB File Offset: 0x000497CB
		[__DynamicallyInvokable]
		public DirectoryNotFoundException() : base(Environment.GetResourceString("Arg_DirectoryNotFoundException"))
		{
			base.SetErrorCode(-2147024893);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.DirectoryNotFoundException" /> class with its message string set to <paramref name="message" /> and its HRESULT set to COR_E_DIRECTORYNOTFOUND.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		// Token: 0x06001783 RID: 6019 RVA: 0x0004B5E8 File Offset: 0x000497E8
		[__DynamicallyInvokable]
		public DirectoryNotFoundException(string message) : base(message)
		{
			base.SetErrorCode(-2147024893);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.DirectoryNotFoundException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06001784 RID: 6020 RVA: 0x0004B5FC File Offset: 0x000497FC
		[__DynamicallyInvokable]
		public DirectoryNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2147024893);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.DirectoryNotFoundException" /> class with the specified serialization and context information.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x06001785 RID: 6021 RVA: 0x0004B611 File Offset: 0x00049811
		protected DirectoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
