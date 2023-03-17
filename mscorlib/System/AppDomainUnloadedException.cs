using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	/// <summary>The exception that is thrown when an attempt is made to access an unloaded application domain.</summary>
	// Token: 0x020000A2 RID: 162
	[ComVisible(true)]
	[Serializable]
	public class AppDomainUnloadedException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.AppDomainUnloadedException" /> class.</summary>
		// Token: 0x06000963 RID: 2403 RVA: 0x0001E8F1 File Offset: 0x0001CAF1
		public AppDomainUnloadedException() : base(Environment.GetResourceString("Arg_AppDomainUnloadedException"))
		{
			base.SetErrorCode(-2146234348);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.AppDomainUnloadedException" /> class with a specified error message.</summary>
		/// <param name="message">The message that describes the error.</param>
		// Token: 0x06000964 RID: 2404 RVA: 0x0001E90E File Offset: 0x0001CB0E
		public AppDomainUnloadedException(string message) : base(message)
		{
			base.SetErrorCode(-2146234348);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.AppDomainUnloadedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06000965 RID: 2405 RVA: 0x0001E922 File Offset: 0x0001CB22
		public AppDomainUnloadedException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146234348);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.AppDomainUnloadedException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x06000966 RID: 2406 RVA: 0x0001E937 File Offset: 0x0001CB37
		protected AppDomainUnloadedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
