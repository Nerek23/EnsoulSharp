using System;
using System.Collections;
using log4net.Core;

namespace log4net.Util
{
	// Token: 0x02000031 RID: 49
	public sealed class ThreadContextStack : IFixingRequired
	{
		// Token: 0x06000206 RID: 518 RVA: 0x00006974 File Offset: 0x00005974
		internal ThreadContextStack()
		{
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000207 RID: 519 RVA: 0x00006987 File Offset: 0x00005987
		public int Count
		{
			get
			{
				return this.m_stack.Count;
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00006994 File Offset: 0x00005994
		public void Clear()
		{
			this.m_stack.Clear();
		}

		// Token: 0x06000209 RID: 521 RVA: 0x000069A4 File Offset: 0x000059A4
		public string Pop()
		{
			Stack stack = this.m_stack;
			if (stack.Count > 0)
			{
				return ((ThreadContextStack.StackFrame)stack.Pop()).Message;
			}
			return "";
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000069D8 File Offset: 0x000059D8
		public IDisposable Push(string message)
		{
			Stack stack = this.m_stack;
			stack.Push(new ThreadContextStack.StackFrame(message, (stack.Count > 0) ? ((ThreadContextStack.StackFrame)stack.Peek()) : null));
			return new ThreadContextStack.AutoPopStackFrame(stack, stack.Count - 1);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00006A24 File Offset: 0x00005A24
		internal string GetFullMessage()
		{
			Stack stack = this.m_stack;
			if (stack.Count > 0)
			{
				return ((ThreadContextStack.StackFrame)stack.Peek()).FullMessage;
			}
			return null;
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600020C RID: 524 RVA: 0x00006A53 File Offset: 0x00005A53
		// (set) Token: 0x0600020D RID: 525 RVA: 0x00006A5B File Offset: 0x00005A5B
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

		// Token: 0x0600020E RID: 526 RVA: 0x00006A64 File Offset: 0x00005A64
		public override string ToString()
		{
			return this.GetFullMessage();
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00006A6C File Offset: 0x00005A6C
		object IFixingRequired.GetFixedObject()
		{
			return this.GetFullMessage();
		}

		// Token: 0x0400006F RID: 111
		private Stack m_stack = new Stack();

		// Token: 0x020000F4 RID: 244
		private sealed class StackFrame
		{
			// Token: 0x060007D0 RID: 2000 RVA: 0x00018CD9 File Offset: 0x00017CD9
			internal StackFrame(string message, ThreadContextStack.StackFrame parent)
			{
				this.m_message = message;
				this.m_parent = parent;
				if (parent == null)
				{
					this.m_fullMessage = message;
				}
			}

			// Token: 0x17000197 RID: 407
			// (get) Token: 0x060007D1 RID: 2001 RVA: 0x00018CF9 File Offset: 0x00017CF9
			internal string Message
			{
				get
				{
					return this.m_message;
				}
			}

			// Token: 0x17000198 RID: 408
			// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00018D01 File Offset: 0x00017D01
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

			// Token: 0x04000259 RID: 601
			private readonly string m_message;

			// Token: 0x0400025A RID: 602
			private readonly ThreadContextStack.StackFrame m_parent;

			// Token: 0x0400025B RID: 603
			private string m_fullMessage;
		}

		// Token: 0x020000F5 RID: 245
		private struct AutoPopStackFrame : IDisposable
		{
			// Token: 0x060007D3 RID: 2003 RVA: 0x00018D3A File Offset: 0x00017D3A
			internal AutoPopStackFrame(Stack frameStack, int frameDepth)
			{
				this.m_frameStack = frameStack;
				this.m_frameDepth = frameDepth;
			}

			// Token: 0x060007D4 RID: 2004 RVA: 0x00018D4A File Offset: 0x00017D4A
			public void Dispose()
			{
				if (this.m_frameDepth >= 0 && this.m_frameStack != null)
				{
					while (this.m_frameStack.Count > this.m_frameDepth)
					{
						this.m_frameStack.Pop();
					}
				}
			}

			// Token: 0x0400025C RID: 604
			private Stack m_frameStack;

			// Token: 0x0400025D RID: 605
			private int m_frameDepth;
		}
	}
}
