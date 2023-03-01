using System;
using System.Collections;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000018 RID: 24
	public sealed class LogicalThreadContextStack : IFixingRequired
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00003FA3 File Offset: 0x00002FA3
		internal LogicalThreadContextStack(string propertyKey, TwoArgAction<string, LogicalThreadContextStack> registerNew)
		{
			this.m_propertyKey = propertyKey;
			this.m_registerNew = registerNew;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00003FC4 File Offset: 0x00002FC4
		public int Count
		{
			get
			{
				return this.m_stack.Count;
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00003FD1 File Offset: 0x00002FD1
		public void Clear()
		{
			this.m_registerNew(this.m_propertyKey, new LogicalThreadContextStack(this.m_propertyKey, this.m_registerNew));
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00003FF8 File Offset: 0x00002FF8
		public string Pop()
		{
			Stack stack = new Stack(new Stack(this.m_stack));
			string result = "";
			if (stack.Count > 0)
			{
				result = ((LogicalThreadContextStack.StackFrame)stack.Pop()).Message;
			}
			LogicalThreadContextStack logicalThreadContextStack = new LogicalThreadContextStack(this.m_propertyKey, this.m_registerNew);
			logicalThreadContextStack.m_stack = stack;
			this.m_registerNew(this.m_propertyKey, logicalThreadContextStack);
			return result;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00004064 File Offset: 0x00003064
		public IDisposable Push(string message)
		{
			Stack stack = new Stack(new Stack(this.m_stack));
			stack.Push(new LogicalThreadContextStack.StackFrame(message, (stack.Count > 0) ? ((LogicalThreadContextStack.StackFrame)stack.Peek()) : null));
			LogicalThreadContextStack logicalThreadContextStack = new LogicalThreadContextStack(this.m_propertyKey, this.m_registerNew);
			logicalThreadContextStack.m_stack = stack;
			this.m_registerNew(this.m_propertyKey, logicalThreadContextStack);
			return new LogicalThreadContextStack.AutoPopStackFrame(logicalThreadContextStack, stack.Count - 1);
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000040E4 File Offset: 0x000030E4
		internal string GetFullMessage()
		{
			Stack stack = this.m_stack;
			if (stack.Count > 0)
			{
				return ((LogicalThreadContextStack.StackFrame)stack.Peek()).FullMessage;
			}
			return null;
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00004113 File Offset: 0x00003113
		// (set) Token: 0x06000105 RID: 261 RVA: 0x0000411B File Offset: 0x0000311B
		internal Stack InternalStack
		{
			get
			{
				return this.m_stack;
			}
			set
			{
				this.m_stack = value;
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004124 File Offset: 0x00003124
		public override string ToString()
		{
			return this.GetFullMessage();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000412C File Offset: 0x0000312C
		object IFixingRequired.GetFixedObject()
		{
			return this.GetFullMessage();
		}

		// Token: 0x04000023 RID: 35
		private Stack m_stack = new Stack();

		// Token: 0x04000024 RID: 36
		private string m_propertyKey;

		// Token: 0x04000025 RID: 37
		private TwoArgAction<string, LogicalThreadContextStack> m_registerNew;

		// Token: 0x020000F0 RID: 240
		private sealed class StackFrame
		{
			// Token: 0x060007C4 RID: 1988 RVA: 0x00018B2C File Offset: 0x00017B2C
			internal StackFrame(string message, LogicalThreadContextStack.StackFrame parent)
			{
				this.m_message = message;
				this.m_parent = parent;
				if (parent == null)
				{
					this.m_fullMessage = message;
				}
			}

			// Token: 0x17000194 RID: 404
			// (get) Token: 0x060007C5 RID: 1989 RVA: 0x00018B4C File Offset: 0x00017B4C
			internal string Message
			{
				get
				{
					return this.m_message;
				}
			}

			// Token: 0x17000195 RID: 405
			// (get) Token: 0x060007C6 RID: 1990 RVA: 0x00018B54 File Offset: 0x00017B54
			internal string FullMessage
			{
				get
				{
					if (this.m_fullMessage == null && this.m_parent != null)
					{
						this.m_fullMessage = this.m_parent.FullMessage + " " + this.m_message;
					}
					return this.m_fullMessage;
				}
			}

			// Token: 0x04000251 RID: 593
			private readonly string m_message;

			// Token: 0x04000252 RID: 594
			private readonly LogicalThreadContextStack.StackFrame m_parent;

			// Token: 0x04000253 RID: 595
			private string m_fullMessage;
		}

		// Token: 0x020000F1 RID: 241
		private struct AutoPopStackFrame : IDisposable
		{
			// Token: 0x060007C7 RID: 1991 RVA: 0x00018B8D File Offset: 0x00017B8D
			internal AutoPopStackFrame(LogicalThreadContextStack logicalThreadContextStack, int frameDepth)
			{
				this.m_frameDepth = frameDepth;
				this.m_logicalThreadContextStack = logicalThreadContextStack;
			}

			// Token: 0x060007C8 RID: 1992 RVA: 0x00018BA0 File Offset: 0x00017BA0
			public void Dispose()
			{
				if (this.m_frameDepth >= 0 && this.m_logicalThreadContextStack.m_stack != null)
				{
					Stack stack = new Stack(new Stack(this.m_logicalThreadContextStack.m_stack));
					while (stack.Count > this.m_frameDepth)
					{
						stack.Pop();
					}
					LogicalThreadContextStack logicalThreadContextStack = new LogicalThreadContextStack(this.m_logicalThreadContextStack.m_propertyKey, this.m_logicalThreadContextStack.m_registerNew);
					logicalThreadContextStack.m_stack = stack;
					this.m_logicalThreadContextStack.m_registerNew(this.m_logicalThreadContextStack.m_propertyKey, logicalThreadContextStack);
				}
			}

			// Token: 0x04000254 RID: 596
			private int m_frameDepth;

			// Token: 0x04000255 RID: 597
			private LogicalThreadContextStack m_logicalThreadContextStack;
		}
	}
}
