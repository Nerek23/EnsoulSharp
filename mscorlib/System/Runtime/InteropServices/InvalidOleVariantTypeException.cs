using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	/// <summary>The exception thrown by the marshaler when it encounters an argument of a variant type that can not be marshaled to managed code.</summary>
	// Token: 0x02000920 RID: 2336
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class InvalidOleVariantTypeException : SystemException
	{
		/// <summary>Initializes a new instance of the <see langword="InvalidOleVariantTypeException" /> class with default values.</summary>
		// Token: 0x06005FA1 RID: 24481 RVA: 0x00147F6D File Offset: 0x0014616D
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException() : base(Environment.GetResourceString("Arg_InvalidOleVariantTypeException"))
		{
			base.SetErrorCode(-2146233039);
		}

		/// <summary>Initializes a new instance of the <see langword="InvalidOleVariantTypeException" /> class with a specified message.</summary>
		/// <param name="message">The message that indicates the reason for the exception.</param>
		// Token: 0x06005FA2 RID: 24482 RVA: 0x00147F8A File Offset: 0x0014618A
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException(string message) : base(message)
		{
			base.SetErrorCode(-2146233039);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.InvalidOleVariantTypeException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06005FA3 RID: 24483 RVA: 0x00147F9E File Offset: 0x0014619E
		[__DynamicallyInvokable]
		public InvalidOleVariantTypeException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146233039);
		}

		/// <summary>Initializes a new instance of the <see langword="InvalidOleVariantTypeException" /> class from serialization data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x06005FA4 RID: 24484 RVA: 0x00147FB3 File Offset: 0x001461B3
		protected InvalidOleVariantTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
