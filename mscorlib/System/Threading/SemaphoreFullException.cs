using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Threading
{
	/// <summary>The exception that is thrown when the <see cref="Overload:System.Threading.Semaphore.Release" /> method is called on a semaphore whose count is already at the maximum.</summary>
	// Token: 0x020004E4 RID: 1252
	[ComVisible(false)]
	[TypeForwardedFrom("System, Version=2.0.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	[__DynamicallyInvokable]
	[Serializable]
	public class SemaphoreFullException : SystemException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreFullException" /> class with default values.</summary>
		// Token: 0x06003BF0 RID: 15344 RVA: 0x000E16BB File Offset: 0x000DF8BB
		[__DynamicallyInvokable]
		public SemaphoreFullException() : base(Environment.GetResourceString("Threading_SemaphoreFullException"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreFullException" /> class with a specified error message.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		// Token: 0x06003BF1 RID: 15345 RVA: 0x000E16CD File Offset: 0x000DF8CD
		[__DynamicallyInvokable]
		public SemaphoreFullException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreFullException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06003BF2 RID: 15346 RVA: 0x000E16D6 File Offset: 0x000DF8D6
		[__DynamicallyInvokable]
		public SemaphoreFullException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.SemaphoreFullException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> object that contains contextual information about the source or destination.</param>
		// Token: 0x06003BF3 RID: 15347 RVA: 0x000E16E0 File Offset: 0x000DF8E0
		protected SemaphoreFullException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
