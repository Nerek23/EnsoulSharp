using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	/// <summary>The exception that is thrown when the server or the client cannot be reached for a previously specified period of time.</summary>
	// Token: 0x0200079C RID: 1948
	[ComVisible(true)]
	[Serializable]
	public class RemotingTimeoutException : RemotingException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingTimeoutException" /> class with default properties.</summary>
		// Token: 0x060054FE RID: 21758 RVA: 0x0012CB11 File Offset: 0x0012AD11
		public RemotingTimeoutException() : base(RemotingTimeoutException._nullMessage)
		{
		}

		/// <summary>Initializes a new instance of <see cref="T:System.Runtime.Remoting.RemotingTimeoutException" /> class with a specified message.</summary>
		/// <param name="message">The message that indicates the reason why the exception occurred.</param>
		// Token: 0x060054FF RID: 21759 RVA: 0x0012CB1E File Offset: 0x0012AD1E
		public RemotingTimeoutException(string message) : base(message)
		{
			base.SetErrorCode(-2146233077);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingTimeoutException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="InnerException">The exception that is the cause of the current exception. If the <paramref name="InnerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06005500 RID: 21760 RVA: 0x0012CB32 File Offset: 0x0012AD32
		public RemotingTimeoutException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233077);
		}

		// Token: 0x06005501 RID: 21761 RVA: 0x0012CB47 File Offset: 0x0012AD47
		internal RemotingTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040026D5 RID: 9941
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
