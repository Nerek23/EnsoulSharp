using System;
using System.Runtime.Serialization;

namespace System.Diagnostics.Tracing
{
	/// <summary>The exception that is thrown when an error occurs during event tracing for Windows (ETW).</summary>
	// Token: 0x02000406 RID: 1030
	[__DynamicallyInvokable]
	[Serializable]
	public class EventSourceException : Exception
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventSourceException" /> class.</summary>
		// Token: 0x0600346C RID: 13420 RVA: 0x000CC740 File Offset: 0x000CA940
		[__DynamicallyInvokable]
		public EventSourceException() : base(Environment.GetResourceString("EventSource_ListenerWriteFailure"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventSourceException" /> class with a specified error message.</summary>
		/// <param name="message">The message that describes the error.</param>
		// Token: 0x0600346D RID: 13421 RVA: 0x000CC752 File Offset: 0x000CA952
		[__DynamicallyInvokable]
		public EventSourceException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventSourceException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or <see langword="null" /> if no inner exception is specified.</param>
		// Token: 0x0600346E RID: 13422 RVA: 0x000CC75B File Offset: 0x000CA95B
		[__DynamicallyInvokable]
		public EventSourceException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.Tracing.EventSourceException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x0600346F RID: 13423 RVA: 0x000CC765 File Offset: 0x000CA965
		protected EventSourceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x000CC76F File Offset: 0x000CA96F
		internal EventSourceException(Exception innerException) : base(Environment.GetResourceString("EventSource_ListenerWriteFailure"), innerException)
		{
		}
	}
}
