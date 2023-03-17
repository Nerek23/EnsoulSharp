using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Reflection
{
	/// <summary>The exception that is thrown in <see cref="M:System.Type.FindMembers(System.Reflection.MemberTypes,System.Reflection.BindingFlags,System.Reflection.MemberFilter,System.Object)" /> when the filter criteria is not valid for the type of filter you are using.</summary>
	// Token: 0x020005C2 RID: 1474
	[ComVisible(true)]
	[Serializable]
	public class InvalidFilterCriteriaException : ApplicationException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.InvalidFilterCriteriaException" /> class with the default properties.</summary>
		// Token: 0x06004541 RID: 17729 RVA: 0x000FDC4D File Offset: 0x000FBE4D
		public InvalidFilterCriteriaException() : base(Environment.GetResourceString("Arg_InvalidFilterCriteriaException"))
		{
			base.SetErrorCode(-2146232831);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.InvalidFilterCriteriaException" /> class with the given HRESULT and message string.</summary>
		/// <param name="message">The message text for the exception.</param>
		// Token: 0x06004542 RID: 17730 RVA: 0x000FDC6A File Offset: 0x000FBE6A
		public InvalidFilterCriteriaException(string message) : base(message)
		{
			base.SetErrorCode(-2146232831);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.InvalidFilterCriteriaException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06004543 RID: 17731 RVA: 0x000FDC7E File Offset: 0x000FBE7E
		public InvalidFilterCriteriaException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232831);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Reflection.InvalidFilterCriteriaException" /> class with the specified serialization and context information.</summary>
		/// <param name="info">A <see langword="SerializationInfo" /> object that contains the information required to serialize this instance.</param>
		/// <param name="context">A <see langword="StreamingContext" /> object that contains the source and destination of the serialized stream associated with this instance.</param>
		// Token: 0x06004544 RID: 17732 RVA: 0x000FDC93 File Offset: 0x000FBE93
		protected InvalidFilterCriteriaException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
