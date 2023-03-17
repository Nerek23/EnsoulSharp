using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	/// <summary>The exception that is thrown when the key specified for accessing an element in a collection does not match any key in the collection.</summary>
	// Token: 0x020004AD RID: 1197
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class KeyNotFoundException : SystemException, ISerializable
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.KeyNotFoundException" /> class using default property values.</summary>
		// Token: 0x060039C4 RID: 14788 RVA: 0x000DB020 File Offset: 0x000D9220
		[__DynamicallyInvokable]
		public KeyNotFoundException() : base(Environment.GetResourceString("Arg_KeyNotFound"))
		{
			base.SetErrorCode(-2146232969);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.KeyNotFoundException" /> class with the specified error message.</summary>
		/// <param name="message">The message that describes the error.</param>
		// Token: 0x060039C5 RID: 14789 RVA: 0x000DB03D File Offset: 0x000D923D
		[__DynamicallyInvokable]
		public KeyNotFoundException(string message) : base(message)
		{
			base.SetErrorCode(-2146232969);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.KeyNotFoundException" /> class with the specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060039C6 RID: 14790 RVA: 0x000DB051 File Offset: 0x000D9251
		[__DynamicallyInvokable]
		public KeyNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146232969);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Collections.Generic.KeyNotFoundException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x060039C7 RID: 14791 RVA: 0x000DB066 File Offset: 0x000D9266
		protected KeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
