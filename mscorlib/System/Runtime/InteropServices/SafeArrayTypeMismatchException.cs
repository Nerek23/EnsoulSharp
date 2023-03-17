using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	/// <summary>The exception thrown when the type of the incoming <see langword="SAFEARRAY" /> does not match the type specified in the managed signature.</summary>
	// Token: 0x0200094B RID: 2379
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SafeArrayTypeMismatchException : SystemException
	{
		/// <summary>Initializes a new instance of the <see langword="SafeArrayTypeMismatchException" /> class with default values.</summary>
		// Token: 0x06006146 RID: 24902 RVA: 0x0014C4CA File Offset: 0x0014A6CA
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException() : base(Environment.GetResourceString("Arg_SafeArrayTypeMismatchException"))
		{
			base.SetErrorCode(-2146233037);
		}

		/// <summary>Initializes a new instance of the <see langword="SafeArrayTypeMismatchException" /> class with the specified message.</summary>
		/// <param name="message">The message that indicates the reason for the exception.</param>
		// Token: 0x06006147 RID: 24903 RVA: 0x0014C4E7 File Offset: 0x0014A6E7
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException(string message) : base(message)
		{
			base.SetErrorCode(-2146233037);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SafeArrayTypeMismatchException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06006148 RID: 24904 RVA: 0x0014C4FB File Offset: 0x0014A6FB
		[__DynamicallyInvokable]
		public SafeArrayTypeMismatchException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233037);
		}

		/// <summary>Initializes a new instance of the <see langword="SafeArrayTypeMismatchException" /> class from serialization data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06006149 RID: 24905 RVA: 0x0014C510 File Offset: 0x0014A710
		protected SafeArrayTypeMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
