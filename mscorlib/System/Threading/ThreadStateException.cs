using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	/// <summary>The exception that is thrown when a <see cref="T:System.Threading.Thread" /> is in an invalid <see cref="P:System.Threading.Thread.ThreadState" /> for the method call.</summary>
	// Token: 0x020004FD RID: 1277
	[ComVisible(true)]
	[Serializable]
	public class ThreadStateException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ThreadStateException" /> class with default properties.</summary>
		// Token: 0x06003D09 RID: 15625 RVA: 0x000E31D0 File Offset: 0x000E13D0
		public ThreadStateException() : base(Environment.GetResourceString("Arg_ThreadStateException"))
		{
			base.SetErrorCode(-2146233056);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ThreadStateException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06003D0A RID: 15626 RVA: 0x000E31ED File Offset: 0x000E13ED
		public ThreadStateException(string message) : base(message)
		{
			base.SetErrorCode(-2146233056);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ThreadStateException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06003D0B RID: 15627 RVA: 0x000E3201 File Offset: 0x000E1401
		public ThreadStateException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146233056);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.ThreadStateException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x06003D0C RID: 15628 RVA: 0x000E3216 File Offset: 0x000E1416
		protected ThreadStateException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
