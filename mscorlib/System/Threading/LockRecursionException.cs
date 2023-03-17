using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Threading
{
	/// <summary>The exception that is thrown when recursive entry into a lock is not compatible with the recursion policy for the lock.</summary>
	// Token: 0x020004D2 RID: 1234
	[TypeForwardedFrom("System.Core, Version=3.5.0.0, Culture=Neutral, PublicKeyToken=b77a5c561934e089")]
	[__DynamicallyInvokable]
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	[Serializable]
	public class LockRecursionException : Exception
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with a system-supplied message that describes the error.</summary>
		// Token: 0x06003B3C RID: 15164 RVA: 0x000DF8A9 File Offset: 0x000DDAA9
		[__DynamicallyInvokable]
		public LockRecursionException()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with a specified message that describes the error.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor must make sure that this string has been localized for the current system culture.</param>
		// Token: 0x06003B3D RID: 15165 RVA: 0x000DF8B1 File Offset: 0x000DDAB1
		[__DynamicallyInvokable]
		public LockRecursionException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x06003B3E RID: 15166 RVA: 0x000DF8BA File Offset: 0x000DDABA
		protected LockRecursionException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.LockRecursionException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor must make sure that this string has been localized for the current system culture.</param>
		/// <param name="innerException">The exception that caused the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06003B3F RID: 15167 RVA: 0x000DF8C4 File Offset: 0x000DDAC4
		[__DynamicallyInvokable]
		public LockRecursionException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
