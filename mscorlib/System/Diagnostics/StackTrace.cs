using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace System.Diagnostics
{
	/// <summary>Represents a stack trace, which is an ordered collection of one or more stack frames.</summary>
	// Token: 0x020003CB RID: 971
	[ComVisible(true)]
	[SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
	[Serializable]
	public class StackTrace
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class from the caller's frame.</summary>
		// Token: 0x0600324B RID: 12875 RVA: 0x000C0E3C File Offset: 0x000BF03C
		public StackTrace()
		{
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(0, false, null, null);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class from the caller's frame, optionally capturing source information.</summary>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number; otherwise, <see langword="false" />.</param>
		// Token: 0x0600324C RID: 12876 RVA: 0x000C0E5C File Offset: 0x000BF05C
		public StackTrace(bool fNeedFileInfo)
		{
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(0, fNeedFileInfo, null, null);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class from the caller's frame, skipping the specified number of frames.</summary>
		/// <param name="skipFrames">The number of frames up the stack from which to start the trace.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="skipFrames" /> parameter is negative.</exception>
		// Token: 0x0600324D RID: 12877 RVA: 0x000C0E7C File Offset: 0x000BF07C
		public StackTrace(int skipFrames)
		{
			if (skipFrames < 0)
			{
				throw new ArgumentOutOfRangeException("skipFrames", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(skipFrames, false, null, null);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class from the caller's frame, skipping the specified number of frames and optionally capturing source information.</summary>
		/// <param name="skipFrames">The number of frames up the stack from which to start the trace.</param>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="skipFrames" /> parameter is negative.</exception>
		// Token: 0x0600324E RID: 12878 RVA: 0x000C0EB5 File Offset: 0x000BF0B5
		public StackTrace(int skipFrames, bool fNeedFileInfo)
		{
			if (skipFrames < 0)
			{
				throw new ArgumentOutOfRangeException("skipFrames", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(skipFrames, fNeedFileInfo, null, null);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class using the provided exception object.</summary>
		/// <param name="e">The exception object from which to construct the stack trace.</param>
		/// <exception cref="T:System.ArgumentNullException">The parameter <paramref name="e" /> is <see langword="null" />.</exception>
		// Token: 0x0600324F RID: 12879 RVA: 0x000C0EEE File Offset: 0x000BF0EE
		public StackTrace(Exception e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(0, false, null, e);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class, using the provided exception object and optionally capturing source information.</summary>
		/// <param name="e">The exception object from which to construct the stack trace. </param>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentNullException">The parameter <paramref name="e" /> is <see langword="null" />.</exception>
		// Token: 0x06003250 RID: 12880 RVA: 0x000C0F1C File Offset: 0x000BF11C
		public StackTrace(Exception e, bool fNeedFileInfo)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(0, fNeedFileInfo, null, e);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class using the provided exception object and skipping the specified number of frames.</summary>
		/// <param name="e">The exception object from which to construct the stack trace.</param>
		/// <param name="skipFrames">The number of frames up the stack from which to start the trace.</param>
		/// <exception cref="T:System.ArgumentNullException">The parameter <paramref name="e" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="skipFrames" /> parameter is negative.</exception>
		// Token: 0x06003251 RID: 12881 RVA: 0x000C0F4C File Offset: 0x000BF14C
		public StackTrace(Exception e, int skipFrames)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (skipFrames < 0)
			{
				throw new ArgumentOutOfRangeException("skipFrames", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(skipFrames, false, null, e);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class using the provided exception object, skipping the specified number of frames and optionally capturing source information.</summary>
		/// <param name="e">The exception object from which to construct the stack trace.</param>
		/// <param name="skipFrames">The number of frames up the stack from which to start the trace.</param>
		/// <param name="fNeedFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.ArgumentNullException">The parameter <paramref name="e" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The <paramref name="skipFrames" /> parameter is negative.</exception>
		// Token: 0x06003252 RID: 12882 RVA: 0x000C0FA0 File Offset: 0x000BF1A0
		public StackTrace(Exception e, int skipFrames, bool fNeedFileInfo)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			if (skipFrames < 0)
			{
				throw new ArgumentOutOfRangeException("skipFrames", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
			}
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(skipFrames, fNeedFileInfo, null, e);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class that contains a single frame.</summary>
		/// <param name="frame">The frame that the <see cref="T:System.Diagnostics.StackTrace" /> object should contain.</param>
		// Token: 0x06003253 RID: 12883 RVA: 0x000C0FF2 File Offset: 0x000BF1F2
		public StackTrace(StackFrame frame)
		{
			this.frames = new StackFrame[1];
			this.frames[0] = frame;
			this.m_iMethodsToSkip = 0;
			this.m_iNumOfFrames = 1;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Diagnostics.StackTrace" /> class for a specific thread, optionally capturing source information.  
		///  Do not use this constructor overload.</summary>
		/// <param name="targetThread">The thread whose stack trace is requested.</param>
		/// <param name="needFileInfo">
		///   <see langword="true" /> to capture the file name, line number, and column number; otherwise, <see langword="false" />.</param>
		/// <exception cref="T:System.Threading.ThreadStateException">The thread <paramref name="targetThread" /> is not suspended.</exception>
		// Token: 0x06003254 RID: 12884 RVA: 0x000C101D File Offset: 0x000BF21D
		[Obsolete("This constructor has been deprecated.  Please use a constructor that does not require a Thread parameter.  http://go.microsoft.com/fwlink/?linkid=14202")]
		public StackTrace(Thread targetThread, bool needFileInfo)
		{
			this.m_iNumOfFrames = 0;
			this.m_iMethodsToSkip = 0;
			this.CaptureStackTrace(0, needFileInfo, targetThread, null);
		}

		// Token: 0x06003255 RID: 12885
		[SecuritySafeCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern void GetStackFramesInternal(StackFrameHelper sfh, int iSkip, bool fNeedFileInfo, Exception e);

		// Token: 0x06003256 RID: 12886 RVA: 0x000C1040 File Offset: 0x000BF240
		internal static int CalculateFramesToSkip(StackFrameHelper StackF, int iNumFrames)
		{
			int num = 0;
			string strB = "System.Diagnostics";
			for (int i = 0; i < iNumFrames; i++)
			{
				MethodBase methodBase = StackF.GetMethodBase(i);
				if (methodBase != null)
				{
					Type declaringType = methodBase.DeclaringType;
					if (declaringType == null)
					{
						break;
					}
					string @namespace = declaringType.Namespace;
					if (@namespace == null || string.Compare(@namespace, strB, StringComparison.Ordinal) != 0)
					{
						break;
					}
				}
				num++;
			}
			return num;
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x000C10A4 File Offset: 0x000BF2A4
		private void CaptureStackTrace(int iSkip, bool fNeedFileInfo, Thread targetThread, Exception e)
		{
			this.m_iMethodsToSkip += iSkip;
			using (StackFrameHelper stackFrameHelper = new StackFrameHelper(targetThread))
			{
				stackFrameHelper.InitializeSourceInfo(0, fNeedFileInfo, e);
				this.m_iNumOfFrames = stackFrameHelper.GetNumberOfFrames();
				if (this.m_iMethodsToSkip > this.m_iNumOfFrames)
				{
					this.m_iMethodsToSkip = this.m_iNumOfFrames;
				}
				if (this.m_iNumOfFrames != 0)
				{
					this.frames = new StackFrame[this.m_iNumOfFrames];
					for (int i = 0; i < this.m_iNumOfFrames; i++)
					{
						bool dummyFlag = true;
						bool dummyFlag2 = true;
						StackFrame stackFrame = new StackFrame(dummyFlag, dummyFlag2);
						stackFrame.SetMethodBase(stackFrameHelper.GetMethodBase(i));
						stackFrame.SetOffset(stackFrameHelper.GetOffset(i));
						stackFrame.SetILOffset(stackFrameHelper.GetILOffset(i));
						stackFrame.SetIsLastFrameFromForeignExceptionStackTrace(stackFrameHelper.IsLastFrameFromForeignExceptionStackTrace(i));
						if (fNeedFileInfo)
						{
							stackFrame.SetFileName(stackFrameHelper.GetFilename(i));
							stackFrame.SetLineNumber(stackFrameHelper.GetLineNumber(i));
							stackFrame.SetColumnNumber(stackFrameHelper.GetColumnNumber(i));
						}
						this.frames[i] = stackFrame;
					}
					if (e == null)
					{
						this.m_iMethodsToSkip += StackTrace.CalculateFramesToSkip(stackFrameHelper, this.m_iNumOfFrames);
					}
					this.m_iNumOfFrames -= this.m_iMethodsToSkip;
					if (this.m_iNumOfFrames < 0)
					{
						this.m_iNumOfFrames = 0;
					}
				}
				else
				{
					this.frames = null;
				}
			}
		}

		/// <summary>Gets the number of frames in the stack trace.</summary>
		/// <returns>The number of frames in the stack trace.</returns>
		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06003258 RID: 12888 RVA: 0x000C1218 File Offset: 0x000BF418
		public virtual int FrameCount
		{
			get
			{
				return this.m_iNumOfFrames;
			}
		}

		/// <summary>Gets the specified stack frame.</summary>
		/// <param name="index">The index of the stack frame requested.</param>
		/// <returns>The specified stack frame.</returns>
		// Token: 0x06003259 RID: 12889 RVA: 0x000C1220 File Offset: 0x000BF420
		public virtual StackFrame GetFrame(int index)
		{
			if (this.frames != null && index < this.m_iNumOfFrames && index >= 0)
			{
				return this.frames[index + this.m_iMethodsToSkip];
			}
			return null;
		}

		/// <summary>Returns a copy of all stack frames in the current stack trace.</summary>
		/// <returns>An array of type <see cref="T:System.Diagnostics.StackFrame" /> representing the function calls in the stack trace.</returns>
		// Token: 0x0600325A RID: 12890 RVA: 0x000C1248 File Offset: 0x000BF448
		[ComVisible(false)]
		public virtual StackFrame[] GetFrames()
		{
			if (this.frames == null || this.m_iNumOfFrames <= 0)
			{
				return null;
			}
			StackFrame[] array = new StackFrame[this.m_iNumOfFrames];
			Array.Copy(this.frames, this.m_iMethodsToSkip, array, 0, this.m_iNumOfFrames);
			return array;
		}

		/// <summary>Builds a readable representation of the stack trace.</summary>
		/// <returns>A readable representation of the stack trace.</returns>
		// Token: 0x0600325B RID: 12891 RVA: 0x000C128E File Offset: 0x000BF48E
		public override string ToString()
		{
			return this.ToString(StackTrace.TraceFormat.TrailingNewLine);
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x000C1298 File Offset: 0x000BF498
		internal string ToString(StackTrace.TraceFormat traceFormat)
		{
			bool flag = true;
			string arg = "at";
			string format = "in {0}:line {1}";
			if (traceFormat != StackTrace.TraceFormat.NoResourceLookup)
			{
				arg = Environment.GetResourceString("Word_At");
				format = Environment.GetResourceString("StackTrace_InFileLineNumber");
			}
			bool flag2 = true;
			StringBuilder stringBuilder = new StringBuilder(255);
			for (int i = 0; i < this.m_iNumOfFrames; i++)
			{
				StackFrame frame = this.GetFrame(i);
				MethodBase method = frame.GetMethod();
				if (method != null)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else
					{
						stringBuilder.Append(Environment.NewLine);
					}
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "   {0} ", arg);
					Type declaringType = method.DeclaringType;
					if (declaringType != null)
					{
						stringBuilder.Append(declaringType.FullName.Replace('+', '.'));
						stringBuilder.Append(".");
					}
					stringBuilder.Append(method.Name);
					if (method is MethodInfo && ((MethodInfo)method).IsGenericMethod)
					{
						Type[] genericArguments = ((MethodInfo)method).GetGenericArguments();
						stringBuilder.Append("[");
						int j = 0;
						bool flag3 = true;
						while (j < genericArguments.Length)
						{
							if (!flag3)
							{
								stringBuilder.Append(",");
							}
							else
							{
								flag3 = false;
							}
							stringBuilder.Append(genericArguments[j].Name);
							j++;
						}
						stringBuilder.Append("]");
					}
					stringBuilder.Append("(");
					ParameterInfo[] parameters = method.GetParameters();
					bool flag4 = true;
					for (int k = 0; k < parameters.Length; k++)
					{
						if (!flag4)
						{
							stringBuilder.Append(", ");
						}
						else
						{
							flag4 = false;
						}
						string str = "<UnknownType>";
						if (parameters[k].ParameterType != null)
						{
							str = parameters[k].ParameterType.Name;
						}
						stringBuilder.Append(str + " " + parameters[k].Name);
					}
					stringBuilder.Append(")");
					if (flag && frame.GetILOffset() != -1)
					{
						string text = null;
						try
						{
							text = frame.GetFileName();
						}
						catch (NotSupportedException)
						{
							flag = false;
						}
						catch (SecurityException)
						{
							flag = false;
						}
						if (text != null)
						{
							stringBuilder.Append(' ');
							stringBuilder.AppendFormat(CultureInfo.InvariantCulture, format, text, frame.GetFileLineNumber());
						}
					}
					if (frame.GetIsLastFrameFromForeignExceptionStackTrace())
					{
						stringBuilder.Append(Environment.NewLine);
						stringBuilder.Append(Environment.GetResourceString("Exception_EndStackTraceFromPreviousThrow"));
					}
				}
			}
			if (traceFormat == StackTrace.TraceFormat.TrailingNewLine)
			{
				stringBuilder.Append(Environment.NewLine);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x000C1544 File Offset: 0x000BF744
		private static string GetManagedStackTraceStringHelper(bool fNeedFileInfo)
		{
			StackTrace stackTrace = new StackTrace(0, fNeedFileInfo);
			return stackTrace.ToString();
		}

		// Token: 0x04001626 RID: 5670
		private StackFrame[] frames;

		// Token: 0x04001627 RID: 5671
		private int m_iNumOfFrames;

		/// <summary>Defines the default for the number of methods to omit from the stack trace. This field is constant.</summary>
		// Token: 0x04001628 RID: 5672
		public const int METHODS_TO_SKIP = 0;

		// Token: 0x04001629 RID: 5673
		private int m_iMethodsToSkip;

		// Token: 0x02000B4C RID: 2892
		internal enum TraceFormat
		{
			// Token: 0x040033F3 RID: 13299
			Normal,
			// Token: 0x040033F4 RID: 13300
			TrailingNewLine,
			// Token: 0x040033F5 RID: 13301
			NoResourceLookup
		}
	}
}
