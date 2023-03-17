using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	/// <summary>The exception that is thrown when the binary format of a custom attribute is invalid.</summary>
	// Token: 0x020005A1 RID: 1441
	[ComVisible(true)]
	[Serializable]
	public class CustomAttributeFormatException : FormatException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeFormatException" /> class with the default properties.</summary>
		// Token: 0x060043BC RID: 17340 RVA: 0x000F887C File Offset: 0x000F6A7C
		public CustomAttributeFormatException() : base(Environment.GetResourceString("Arg_CustomAttributeFormatException"))
		{
			base.SetErrorCode(-2146232827);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeFormatException" /> class with the specified message.</summary>
		/// <param name="message">The message that indicates the reason this exception was thrown.</param>
		// Token: 0x060043BD RID: 17341 RVA: 0x000F8899 File Offset: 0x000F6A99
		public CustomAttributeFormatException(string message) : base(message)
		{
			base.SetErrorCode(-2146232827);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeFormatException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060043BE RID: 17342 RVA: 0x000F88AD File Offset: 0x000F6AAD
		public CustomAttributeFormatException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232827);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.CustomAttributeFormatException" /> class with the specified serialization and context information.</summary>
		/// <param name="info">The data for serializing or deserializing the custom attribute.</param>
		/// <param name="context">The source and destination for the custom attribute.</param>
		// Token: 0x060043BF RID: 17343 RVA: 0x000F88C2 File Offset: 0x000F6AC2
		protected CustomAttributeFormatException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
