using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	/// <summary>The exception that is thrown when an attempt is made to open a system mutex, semaphore, or event wait handle that does not exist.</summary>
	// Token: 0x02000508 RID: 1288
	[ComVisible(false)]
	[__DynamicallyInvokable]
	[Serializable]
	public class WaitHandleCannotBeOpenedException : ApplicationException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.WaitHandleCannotBeOpenedException" /> class with default values.</summary>
		// Token: 0x06003D88 RID: 15752 RVA: 0x000E4871 File Offset: 0x000E2A71
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException() : base(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException"))
		{
			base.SetErrorCode(-2146233044);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.WaitHandleCannotBeOpenedException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06003D89 RID: 15753 RVA: 0x000E488E File Offset: 0x000E2A8E
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException(string message) : base(message)
		{
			base.SetErrorCode(-2146233044);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.WaitHandleCannotBeOpenedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06003D8A RID: 15754 RVA: 0x000E48A2 File Offset: 0x000E2AA2
		[__DynamicallyInvokable]
		public WaitHandleCannotBeOpenedException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233044);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.WaitHandleCannotBeOpenedException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> object that contains contextual information about the source or destination.</param>
		// Token: 0x06003D8B RID: 15755 RVA: 0x000E48B7 File Offset: 0x000E2AB7
		protected WaitHandleCannotBeOpenedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
