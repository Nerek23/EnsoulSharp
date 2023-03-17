using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	/// <summary>The exception that is thrown when the number of parameters for an invocation does not match the number expected. This class cannot be inherited.</summary>
	// Token: 0x020005F6 RID: 1526
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class TargetParameterCountException : ApplicationException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetParameterCountException" /> class with an empty message string and the root cause of the exception.</summary>
		// Token: 0x0600479C RID: 18332 RVA: 0x00102F8B File Offset: 0x0010118B
		[__DynamicallyInvokable]
		public TargetParameterCountException() : base(Environment.GetResourceString("Arg_TargetParameterCountException"))
		{
			base.SetErrorCode(-2147352562);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetParameterCountException" /> class with its message string set to the given message and the root cause exception.</summary>
		/// <param name="message">A <see langword="String" /> describing the reason this exception was thrown.</param>
		// Token: 0x0600479D RID: 18333 RVA: 0x00102FA8 File Offset: 0x001011A8
		[__DynamicallyInvokable]
		public TargetParameterCountException(string message) : base(message)
		{
			base.SetErrorCode(-2147352562);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.TargetParameterCountException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x0600479E RID: 18334 RVA: 0x00102FBC File Offset: 0x001011BC
		[__DynamicallyInvokable]
		public TargetParameterCountException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2147352562);
		}

		// Token: 0x0600479F RID: 18335 RVA: 0x00102FD1 File Offset: 0x001011D1
		internal TargetParameterCountException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
