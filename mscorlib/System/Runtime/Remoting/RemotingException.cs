using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	/// <summary>The exception that is thrown when something has gone wrong during remoting.</summary>
	// Token: 0x0200079A RID: 1946
	[ComVisible(true)]
	[Serializable]
	public class RemotingException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingException" /> class with default properties.</summary>
		// Token: 0x060054F4 RID: 21748 RVA: 0x0012CA59 File Offset: 0x0012AC59
		public RemotingException() : base(RemotingException._nullMessage)
		{
			base.SetErrorCode(-2146233077);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingException" /> class with a specified message.</summary>
		/// <param name="message">The error message that explains why the exception occurred.</param>
		// Token: 0x060054F5 RID: 21749 RVA: 0x0012CA71 File Offset: 0x0012AC71
		public RemotingException(string message) : base(message)
		{
			base.SetErrorCode(-2146233077);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains why the exception occurred.</param>
		/// <param name="InnerException">The exception that is the cause of the current exception. If the <paramref name="InnerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060054F6 RID: 21750 RVA: 0x0012CA85 File Offset: 0x0012AC85
		public RemotingException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233077);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.RemotingException" /> class from serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination of the exception.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info" /> parameter is <see langword="null" />.</exception>
		// Token: 0x060054F7 RID: 21751 RVA: 0x0012CA9A File Offset: 0x0012AC9A
		protected RemotingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040026D3 RID: 9939
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
