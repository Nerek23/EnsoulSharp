using System;
using System.Runtime.Serialization;

namespace System.Threading.Tasks
{
	/// <summary>Represents an exception used to communicate task cancellation.</summary>
	// Token: 0x02000546 RID: 1350
	[__DynamicallyInvokable]
	[Serializable]
	public class TaskCanceledException : OperationCanceledException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskCanceledException" /> class with a system-supplied message that describes the error.</summary>
		// Token: 0x0600406C RID: 16492 RVA: 0x000F02B4 File Offset: 0x000EE4B4
		[__DynamicallyInvokable]
		public TaskCanceledException() : base(Environment.GetResourceString("TaskCanceledException_ctor_DefaultMessage"))
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskCanceledException" /> class with a specified message that describes the error.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		// Token: 0x0600406D RID: 16493 RVA: 0x000F02C6 File Offset: 0x000EE4C6
		[__DynamicallyInvokable]
		public TaskCanceledException(string message) : base(message)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskCanceledException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">The message that describes the exception. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		/// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x0600406E RID: 16494 RVA: 0x000F02CF File Offset: 0x000EE4CF
		[__DynamicallyInvokable]
		public TaskCanceledException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskCanceledException" /> class with a reference to the <see cref="T:System.Threading.Tasks.Task" /> that has been canceled.</summary>
		/// <param name="task">A task that has been canceled.</param>
		// Token: 0x0600406F RID: 16495 RVA: 0x000F02DC File Offset: 0x000EE4DC
		[__DynamicallyInvokable]
		public TaskCanceledException(Task task) : base(Environment.GetResourceString("TaskCanceledException_ctor_DefaultMessage"), (task != null) ? task.CancellationToken : default(CancellationToken))
		{
			this.m_canceledTask = task;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.TaskCanceledException" /> class with serialized data.</summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		// Token: 0x06004070 RID: 16496 RVA: 0x000F0314 File Offset: 0x000EE514
		protected TaskCanceledException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		/// <summary>Gets the task associated with this exception.</summary>
		/// <returns>A reference to the <see cref="T:System.Threading.Tasks.Task" /> that is associated with this exception.</returns>
		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06004071 RID: 16497 RVA: 0x000F031E File Offset: 0x000EE51E
		[__DynamicallyInvokable]
		public Task Task
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_canceledTask;
			}
		}

		// Token: 0x04001AA6 RID: 6822
		[NonSerialized]
		private Task m_canceledTask;
	}
}
