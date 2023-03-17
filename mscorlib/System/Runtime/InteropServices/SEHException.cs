using System;
using System.Runtime.Serialization;

namespace System.Runtime.InteropServices
{
	/// <summary>Represents structured exception handling (SEH) errors.</summary>
	// Token: 0x02000928 RID: 2344
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class SEHException : ExternalException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SEHException" /> class.</summary>
		// Token: 0x060060A1 RID: 24737 RVA: 0x00149B48 File Offset: 0x00147D48
		[__DynamicallyInvokable]
		public SEHException()
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SEHException" /> class with a specified message.</summary>
		/// <param name="message">The message that indicates the reason for the exception.</param>
		// Token: 0x060060A2 RID: 24738 RVA: 0x00149B5B File Offset: 0x00147D5B
		[__DynamicallyInvokable]
		public SEHException(string message) : base(message)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SEHException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060060A3 RID: 24739 RVA: 0x00149B6F File Offset: 0x00147D6F
		[__DynamicallyInvokable]
		public SEHException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147467259);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.InteropServices.SEHException" /> class from serialization data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="info" /> is <see langword="null" />.</exception>
		// Token: 0x060060A4 RID: 24740 RVA: 0x00149B84 File Offset: 0x00147D84
		protected SEHException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Indicates whether the exception can be recovered from, and whether the code can continue from the point at which the exception was thrown.</summary>
		/// <returns>Always <see langword="false" />, because resumable exceptions are not implemented.</returns>
		// Token: 0x060060A5 RID: 24741 RVA: 0x00149B8E File Offset: 0x00147D8E
		[__DynamicallyInvokable]
		public virtual bool CanResume()
		{
			return false;
		}
	}
}
