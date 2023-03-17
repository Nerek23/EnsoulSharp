using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	/// <summary>The exception thrown when an invalid COM object is used.</summary>
	// Token: 0x0200093B RID: 2363
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class InvalidComObjectException : SystemException
	{
		/// <summary>Initializes an instance of the <see langword="InvalidComObjectException" /> with default properties.</summary>
		// Token: 0x0600610C RID: 24844 RVA: 0x0014AC55 File Offset: 0x00148E55
		[__DynamicallyInvokable]
		public InvalidComObjectException() : base(Environment.GetResourceString("Arg_InvalidComObjectException"))
		{
			base.SetErrorCode(-2146233049);
		}

		/// <summary>Initializes an instance of the <see langword="InvalidComObjectException" /> with a message.</summary>
		/// <param name="message">The message that indicates the reason for the exception.</param>
		// Token: 0x0600610D RID: 24845 RVA: 0x0014AC72 File Offset: 0x00148E72
		[__DynamicallyInvokable]
		public InvalidComObjectException(string message) : base(message)
		{
			base.SetErrorCode(-2146233049);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.InvalidComObjectException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x0600610E RID: 24846 RVA: 0x0014AC86 File Offset: 0x00148E86
		[__DynamicallyInvokable]
		public InvalidComObjectException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233049);
		}

		/// <summary>Initializes a new instance of the <see langword="COMException" /> class from serialization data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x0600610F RID: 24847 RVA: 0x0014AC9B File Offset: 0x00148E9B
		protected InvalidComObjectException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
