using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Resources
{
	/// <summary>The exception that is thrown if the main assembly does not contain the resources for the neutral culture, and an appropriate satellite assembly is missing.</summary>
	// Token: 0x02000364 RID: 868
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class MissingManifestResourceException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingManifestResourceException" /> class with default properties.</summary>
		// Token: 0x06002BE1 RID: 11233 RVA: 0x000A56CB File Offset: 0x000A38CB
		[__DynamicallyInvokable]
		public MissingManifestResourceException() : base(Environment.GetResourceString("Arg_MissingManifestResourceException"))
		{
			base.SetErrorCode(-2146233038);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingManifestResourceException" /> class with the specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06002BE2 RID: 11234 RVA: 0x000A56E8 File Offset: 0x000A38E8
		[__DynamicallyInvokable]
		public MissingManifestResourceException(string message) : base(message)
		{
			base.SetErrorCode(-2146233038);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingManifestResourceException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06002BE3 RID: 11235 RVA: 0x000A56FC File Offset: 0x000A38FC
		[__DynamicallyInvokable]
		public MissingManifestResourceException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233038);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.MissingManifestResourceException" /> class from serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination of the exception.</param>
		// Token: 0x06002BE4 RID: 11236 RVA: 0x000A5711 File Offset: 0x000A3911
		protected MissingManifestResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
