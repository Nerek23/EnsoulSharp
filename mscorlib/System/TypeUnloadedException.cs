using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System
{
	/// <summary>The exception that is thrown when there is an attempt to access an unloaded class.</summary>
	// Token: 0x020000BF RID: 191
	[ComVisible(true)]
	[Serializable]
	public class TypeUnloadedException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.TypeUnloadedException" /> class.</summary>
		// Token: 0x06000AFD RID: 2813 RVA: 0x00022B6A File Offset: 0x00020D6A
		public TypeUnloadedException() : base(Environment.GetResourceString("Arg_TypeUnloadedException"))
		{
			base.SetErrorCode(-2146234349);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.TypeUnloadedException" /> class with a specified error message.</summary>
		/// <param name="message">The message that describes the error.</param>
		// Token: 0x06000AFE RID: 2814 RVA: 0x00022B87 File Offset: 0x00020D87
		public TypeUnloadedException(string message) : base(message)
		{
			base.SetErrorCode(-2146234349);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.TypeUnloadedException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference (<see langword="Nothing" /> in Visual Basic), the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06000AFF RID: 2815 RVA: 0x00022B9B File Offset: 0x00020D9B
		public TypeUnloadedException(string message, Exception innerException) : base(message, innerException)
		{
			base.SetErrorCode(-2146234349);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.TypeUnloadedException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x06000B00 RID: 2816 RVA: 0x00022BB0 File Offset: 0x00020DB0
		protected TypeUnloadedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
