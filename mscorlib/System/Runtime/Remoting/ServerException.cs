using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Runtime.Remoting
{
	/// <summary>The exception that is thrown to communicate errors to the client when the client connects to non-.NET Framework applications that cannot throw exceptions.</summary>
	// Token: 0x0200079B RID: 1947
	[ComVisible(true)]
	[Serializable]
	public class ServerException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.ServerException" /> class with default properties.</summary>
		// Token: 0x060054F9 RID: 21753 RVA: 0x0012CAB5 File Offset: 0x0012ACB5
		public ServerException() : base(ServerException._nullMessage)
		{
			base.SetErrorCode(-2146233074);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.ServerException" /> class with a specified message.</summary>
		/// <param name="message">The message that describes the exception</param>
		// Token: 0x060054FA RID: 21754 RVA: 0x0012CACD File Offset: 0x0012ACCD
		public ServerException(string message) : base(message)
		{
			base.SetErrorCode(-2146233074);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.Remoting.ServerException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="InnerException">The exception that is the cause of the current exception. If the <paramref name="InnerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060054FB RID: 21755 RVA: 0x0012CAE1 File Offset: 0x0012ACE1
		public ServerException(string message, Exception InnerException) : base(message, InnerException)
		{
			base.SetErrorCode(-2146233074);
		}

		// Token: 0x060054FC RID: 21756 RVA: 0x0012CAF6 File Offset: 0x0012ACF6
		internal ServerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x040026D4 RID: 9940
		private static string _nullMessage = Environment.GetResourceString("Remoting_Default");
	}
}
