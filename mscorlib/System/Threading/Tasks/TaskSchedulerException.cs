using System;
using System.Runtime.Serialization;

namespace System.Threading.Tasks
{
	/// <summary>Represents an exception used to communicate an invalid operation by a <see cref="T:System.Threading.Tasks.TaskScheduler" />.</summary>
	// Token: 0x02000547 RID: 1351
	[__DynamicallyInvokable]
	[Serializable]
	public class TaskSchedulerException : Exception
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskSchedulerException" /> class with a system-supplied message that describes the error.</summary>
		// Token: 0x06004072 RID: 16498 RVA: 0x000F0326 File Offset: 0x000EE526
		[__DynamicallyInvokable]
		public TaskSchedulerException() : base(Environment.GetResourceString("TaskSchedulerException_ctor_DefaultMessage"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskSchedulerException" /> class with a specified message that describes the error.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		// Token: 0x06004073 RID: 16499 RVA: 0x000F0338 File Offset: 0x000EE538
		[__DynamicallyInvokable]
		public TaskSchedulerException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskSchedulerException" /> class using the default error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="innerException">The exception that is the cause of the current exception.</param>
		// Token: 0x06004074 RID: 16500 RVA: 0x000F0341 File Offset: 0x000EE541
		[__DynamicallyInvokable]
		public TaskSchedulerException(Exception innerException) : base(Environment.GetResourceString("TaskSchedulerException_ctor_DefaultMessage"), innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskSchedulerException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06004075 RID: 16501 RVA: 0x000F0354 File Offset: 0x000EE554
		[__DynamicallyInvokable]
		public TaskSchedulerException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskSchedulerException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x06004076 RID: 16502 RVA: 0x000F035E File Offset: 0x000EE55E
		protected TaskSchedulerException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
