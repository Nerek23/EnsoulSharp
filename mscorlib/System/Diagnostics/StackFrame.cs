using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace System.Diagnostics
{
	/// <summary>Provides information about a <see cref="T:System.Diagnostics.StackFrame" />, which represents a function call on the call stack for the current thread.</summary>
	// Token: 0x020003CC RID: 972
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	[Serializable]
	public class StackFrame
	{
		// Token: 0x0600325E RID: 12894 RVA: 0x000C155F File Offset: 0x000BF75F
		internal void InitMembers()
		{
			this.method = null;
			this.offset = -1;
			this.ILOffset = -1;
			this.strFileName = null;
			this.iLineNumber = 0;
			this.iColumnNumber = 0;
			this.fIsLastFrameFromForeignExceptionStackTrace = false;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class.</summary>
		// Token: 0x0600325F RID: 12895 RVA: 0x000C1592 File Offset: 0x000BF792
		public StackFrame()
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class, optionally capturing source information.</summary>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number of the stack frame; otherwise, <see langword="false" />.</param>
		// Token: 0x06003260 RID: 12896 RVA: 0x000C15A8 File Offset: 0x000BF7A8
		public StackFrame(bool fNeedFileInfo)
		{
			this.InitMembers();
			this.BuildStackFrame(0, fNeedFileInfo);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class that corresponds to a frame above the current stack frame.</summary>
		/// <param name="skipFrames">The number of frames up the stack to skip.</param>
		// Token: 0x06003261 RID: 12897 RVA: 0x000C15BE File Offset: 0x000BF7BE
		public StackFrame(int skipFrames)
		{
			this.InitMembers();
			this.BuildStackFrame(skipFrames, false);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class that corresponds to a frame above the current stack frame, optionally capturing source information.</summary>
		/// <param name="skipFrames">The number of frames up the stack to skip.</param>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number of the stack frame; otherwise, <see langword="false" />.</param>
		// Token: 0x06003262 RID: 12898 RVA: 0x000C15D4 File Offset: 0x000BF7D4
		public StackFrame(int skipFrames, bool fNeedFileInfo)
		{
			this.InitMembers();
			this.BuildStackFrame(skipFrames, fNeedFileInfo);
		}

		// Token: 0x06003263 RID: 12899 RVA: 0x000C15EA File Offset: 0x000BF7EA
		internal StackFrame(bool DummyFlag1, bool DummyFlag2)
		{
			this.InitMembers();
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class that contains only the given file name and line number.</summary>
		/// <param name="fileName">The file name.</param>
		/// <param name="lineNumber">The line number in the specified file.</param>
		// Token: 0x06003264 RID: 12900 RVA: 0x000C15F8 File Offset: 0x000BF7F8
		public StackFrame(string fileName, int lineNumber)
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
			this.strFileName = fileName;
			this.iLineNumber = lineNumber;
			this.iColumnNumber = 0;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackFrame" /> class that contains only the given file name, line number, and column number.</summary>
		/// <param name="fileName">The file name.</param>
		/// <param name="lineNumber">The line number in the specified file.</param>
		/// <param name="colNumber">The column number in the specified file.</param>
		// Token: 0x06003265 RID: 12901 RVA: 0x000C1623 File Offset: 0x000BF823
		public StackFrame(string fileName, int lineNumber, int colNumber)
		{
			this.InitMembers();
			this.BuildStackFrame(0, false);
			this.strFileName = fileName;
			this.iLineNumber = lineNumber;
			this.iColumnNumber = colNumber;
		}

		// Token: 0x06003266 RID: 12902 RVA: 0x000C164E File Offset: 0x000BF84E
		internal virtual void SetMethodBase(MethodBase mb)
		{
			this.method = mb;
		}

		// Token: 0x06003267 RID: 12903 RVA: 0x000C1657 File Offset: 0x000BF857
		internal virtual void SetOffset(int iOffset)
		{
			this.offset = iOffset;
		}

		// Token: 0x06003268 RID: 12904 RVA: 0x000C1660 File Offset: 0x000BF860
		internal virtual void SetILOffset(int iOffset)
		{
			this.ILOffset = iOffset;
		}

		// Token: 0x06003269 RID: 12905 RVA: 0x000C1669 File Offset: 0x000BF869
		internal virtual void SetFileName(string strFName)
		{
			this.strFileName = strFName;
		}

		// Token: 0x0600326A RID: 12906 RVA: 0x000C1672 File Offset: 0x000BF872
		internal virtual void SetLineNumber(int iLine)
		{
			this.iLineNumber = iLine;
		}

		// Token: 0x0600326B RID: 12907 RVA: 0x000C167B File Offset: 0x000BF87B
		internal virtual void SetColumnNumber(int iCol)
		{
			this.iColumnNumber = iCol;
		}

		// Token: 0x0600326C RID: 12908 RVA: 0x000C1684 File Offset: 0x000BF884
		internal virtual void SetIsLastFrameFromForeignExceptionStackTrace(bool fIsLastFrame)
		{
			this.fIsLastFrameFromForeignExceptionStackTrace = fIsLastFrame;
		}

		// Token: 0x0600326D RID: 12909 RVA: 0x000C168D File Offset: 0x000BF88D
		internal virtual bool GetIsLastFrameFromForeignExceptionStackTrace()
		{
			return this.fIsLastFrameFromForeignExceptionStackTrace;
		}

		/// <summary>Gets the method in which the frame is executing.</summary>
		/// <returns>The method in which the frame is executing.</returns>
		// Token: 0x0600326E RID: 12910 RVA: 0x000C1695 File Offset: 0x000BF895
		public virtual MethodBase GetMethod()
		{
			return this.method;
		}

		/// <summary>Gets the offset from the start of the native just-in-time (JIT)-compiled code for the method that is being executed. The generation of this debugging information is controlled by the <see cref="T:System.Diagnostics.DebuggableAttribute" /> class.</summary>
		/// <returns>The offset from the start of the JIT-compiled code for the method that is being executed.</returns>
		// Token: 0x0600326F RID: 12911 RVA: 0x000C169D File Offset: 0x000BF89D
		public virtual int GetNativeOffset()
		{
			return this.offset;
		}

		/// <summary>Gets the offset from the start of the Microsoft intermediate language (MSIL) code for the method that is executing. This offset might be an approximation depending on whether or not the just-in-time (JIT) compiler is generating debugging code. The generation of this debugging information is controlled by the <see cref="T:System.Diagnostics.DebuggableAttribute" />.</summary>
		/// <returns>The offset from the start of the MSIL code for the method that is executing.</returns>
		// Token: 0x06003270 RID: 12912 RVA: 0x000C16A5 File Offset: 0x000BF8A5
		public virtual int GetILOffset()
		{
			return this.ILOffset;
		}

		/// <summary>Gets the file name that contains the code that is executing. This information is typically extracted from the debugging symbols for the executable.</summary>
		/// <returns>The file name, or <see langword="null" /> if the file name cannot be determined.</returns>
		// Token: 0x06003271 RID: 12913 RVA: 0x000C16B0 File Offset: 0x000BF8B0
		[SecuritySafeCritical]
		public virtual string GetFileName()
		{
			if (this.strFileName != null)
			{
				new FileIOPermission(PermissionState.None)
				{
					AllFiles = FileIOPermissionAccess.PathDiscovery
				}.Demand();
			}
			return this.strFileName;
		}

		/// <summary>Gets the line number in the file that contains the code that is executing. This information is typically extracted from the debugging symbols for the executable.</summary>
		/// <returns>The file line number, or 0 (zero) if the file line number cannot be determined.</returns>
		// Token: 0x06003272 RID: 12914 RVA: 0x000C16DF File Offset: 0x000BF8DF
		public virtual int GetFileLineNumber()
		{
			return this.iLineNumber;
		}

		/// <summary>Gets the column number in the file that contains the code that is executing. This information is typically extracted from the debugging symbols for the executable.</summary>
		/// <returns>The file column number, or 0 (zero) if the file column number cannot be determined.</returns>
		// Token: 0x06003273 RID: 12915 RVA: 0x000C16E7 File Offset: 0x000BF8E7
		public virtual int GetFileColumnNumber()
		{
			return this.iColumnNumber;
		}

		/// <summary>Builds a readable representation of the stack trace.</summary>
		/// <returns>A readable representation of the stack trace.</returns>
		// Token: 0x06003274 RID: 12916 RVA: 0x000C16F0 File Offset: 0x000BF8F0
		[SecuritySafeCritical]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			if (this.method != null)
			{
				stringBuilder.Append(this.method.Name);
				if (this.method is MethodInfo && ((MethodInfo)this.method).IsGenericMethod)
				{
					Type[] genericArguments = ((MethodInfo)this.method).GetGenericArguments();
					stringBuilder.Append("<");
					int i = 0;
					bool flag = true;
					while (i < genericArguments.Length)
					{
						if (!flag)
						{
							stringBuilder.Append(",");
						}
						else
						{
							flag = false;
						}
						stringBuilder.Append(genericArguments[i].Name);
						i++;
					}
					stringBuilder.Append(">");
				}
				stringBuilder.Append(" at offset ");
				if (this.offset == -1)
				{
					stringBuilder.Append("<offset unknown>");
				}
				else
				{
					stringBuilder.Append(this.offset);
				}
				stringBuilder.Append(" in file:line:column ");
				bool flag2 = this.strFileName != null;
				if (flag2)
				{
					try
					{
						new FileIOPermission(PermissionState.None)
						{
							AllFiles = FileIOPermissionAccess.PathDiscovery
						}.Demand();
					}
					catch (SecurityException)
					{
						flag2 = false;
					}
				}
				if (!flag2)
				{
					stringBuilder.Append("<filename unknown>");
				}
				else
				{
					stringBuilder.Append(this.strFileName);
				}
				stringBuilder.Append(":");
				stringBuilder.Append(this.iLineNumber);
				stringBuilder.Append(":");
				stringBuilder.Append(this.iColumnNumber);
			}
			else
			{
				stringBuilder.Append("<null>");
			}
			stringBuilder.Append(Environment.NewLine);
			return stringBuilder.ToString();
		}

		// Token: 0x06003275 RID: 12917 RVA: 0x000C1890 File Offset: 0x000BFA90
		private void BuildStackFrame(int skipFrames, bool fNeedFileInfo)
		{
			using (StackFrameHelper stackFrameHelper = new StackFrameHelper(null))
			{
				stackFrameHelper.InitializeSourceInfo(0, fNeedFileInfo, null);
				int numberOfFrames = stackFrameHelper.GetNumberOfFrames();
				skipFrames += StackTrace.CalculateFramesToSkip(stackFrameHelper, numberOfFrames);
				if (numberOfFrames - skipFrames > 0)
				{
					this.method = stackFrameHelper.GetMethodBase(skipFrames);
					this.offset = stackFrameHelper.GetOffset(skipFrames);
					this.ILOffset = stackFrameHelper.GetILOffset(skipFrames);
					if (fNeedFileInfo)
					{
						this.strFileName = stackFrameHelper.GetFilename(skipFrames);
						this.iLineNumber = stackFrameHelper.GetLineNumber(skipFrames);
						this.iColumnNumber = stackFrameHelper.GetColumnNumber(skipFrames);
					}
				}
			}
		}

		// Token: 0x0400162A RID: 5674
		private MethodBase method;

		// Token: 0x0400162B RID: 5675
		private int offset;

		// Token: 0x0400162C RID: 5676
		private int ILOffset;

		// Token: 0x0400162D RID: 5677
		private string strFileName;

		// Token: 0x0400162E RID: 5678
		private int iLineNumber;

		// Token: 0x0400162F RID: 5679
		private int iColumnNumber;

		// Token: 0x04001630 RID: 5680
		[OptionalField]
		private bool fIsLastFrameFromForeignExceptionStackTrace;

		/// <summary>Defines the value that is returned from the <see cref="M:System.Diagnostics.StackFrame.GetNativeOffset" /> or <see cref="M:System.Diagnostics.StackFrame.GetILOffset" /> method when the native or Microsoft intermediate language (MSIL) offset is unknown. This field is constant.</summary>
		// Token: 0x04001631 RID: 5681
		public const int OFFSET_UNKNOWN = -1;
	}
}
