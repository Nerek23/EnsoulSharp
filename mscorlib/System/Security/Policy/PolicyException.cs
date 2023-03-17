using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Security.Policy
{
	/// <summary>The exception that is thrown when policy forbids code to run.</summary>
	// Token: 0x02000336 RID: 822
	[ComVisible(true)]
	[Serializable]
	public class PolicyException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PolicyException" /> class with default properties.</summary>
		// Token: 0x060029B0 RID: 10672 RVA: 0x00099DEF File Offset: 0x00097FEF
		public PolicyException() : base(Environment.GetResourceString("Policy_Default"))
		{
			base.HResult = -2146233322;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PolicyException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x060029B1 RID: 10673 RVA: 0x00099E0C File Offset: 0x0009800C
		public PolicyException(string message) : base(message)
		{
			base.HResult = -2146233322;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PolicyException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="exception">The exception that is the cause of the current exception. If the <paramref name="exception" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x060029B2 RID: 10674 RVA: 0x00099E20 File Offset: 0x00098020
		public PolicyException(string message, Exception exception) : base(message, exception)
		{
			base.HResult = -2146233322;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Policy.PolicyException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x060029B3 RID: 10675 RVA: 0x00099E35 File Offset: 0x00098035
		protected PolicyException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060029B4 RID: 10676 RVA: 0x00099E3F File Offset: 0x0009803F
		internal PolicyException(string message, int hresult) : base(message)
		{
			base.HResult = hresult;
		}

		// Token: 0x060029B5 RID: 10677 RVA: 0x00099E4F File Offset: 0x0009804F
		internal PolicyException(string message, int hresult, Exception exception) : base(message, exception)
		{
			base.HResult = hresult;
		}
	}
}
