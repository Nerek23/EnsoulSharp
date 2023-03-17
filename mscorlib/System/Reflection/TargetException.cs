using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	/// <summary>Represents the exception that is thrown when an attempt is made to invoke an invalid target.</summary>
	// Token: 0x020005F4 RID: 1524
	[ComVisible(true)]
	[Serializable]
	public class TargetException : ApplicationException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetException" /> class with an empty message and the root cause of the exception.</summary>
		// Token: 0x06004793 RID: 18323 RVA: 0x00102ED7 File Offset: 0x001010D7
		public TargetException()
		{
			base.SetErrorCode(-2146232829);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetException" /> class with the given message and the root cause exception.</summary>
		/// <param name="message">A <see langword="String" /> describing the reason why the exception occurred.</param>
		// Token: 0x06004794 RID: 18324 RVA: 0x00102EEA File Offset: 0x001010EA
		public TargetException(string message) : base(message)
		{
			base.SetErrorCode(-2146232829);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06004795 RID: 18325 RVA: 0x00102EFE File Offset: 0x001010FE
		public TargetException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232829);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetException" /> class with the specified serialization and context information.</summary>
		/// <param name="info">The data for serializing or deserializing the object.</param>
		/// <param name="context">The source of and destination for the object.</param>
		// Token: 0x06004796 RID: 18326 RVA: 0x00102F13 File Offset: 0x00101113
		protected TargetException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
