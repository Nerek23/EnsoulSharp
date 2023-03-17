using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	/// <summary>The exception that is thrown when a method requires the caller to own the lock on a given Monitor, and the method is invoked by a caller that does not own that lock.</summary>
	// Token: 0x020004E5 RID: 1253
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SynchronizationLockException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SynchronizationLockException" /> class with default properties.</summary>
		// Token: 0x06003BF4 RID: 15348 RVA: 0x000E16EA File Offset: 0x000DF8EA
		[__DynamicallyInvokable]
		public SynchronizationLockException() : base(Environment.GetResourceString("Arg_SynchronizationLockException"))
		{
			base.SetErrorCode(-2146233064);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SynchronizationLockException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06003BF5 RID: 15349 RVA: 0x000E1707 File Offset: 0x000DF907
		[__DynamicallyInvokable]
		public SynchronizationLockException(string message) : base(message)
		{
			base.SetErrorCode(-2146233064);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SynchronizationLockException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06003BF6 RID: 15350 RVA: 0x000E171B File Offset: 0x000DF91B
		[__DynamicallyInvokable]
		public SynchronizationLockException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233064);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SynchronizationLockException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x06003BF7 RID: 15351 RVA: 0x000E1730 File Offset: 0x000DF930
		protected SynchronizationLockException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
