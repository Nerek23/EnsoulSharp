using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Security;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000B4 RID: 180
	[Serializable]
	public class LocationInfo
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x0000F9D8 File Offset: 0x0000E9D8
		public LocationInfo(Type callerStackBoundaryDeclaringType)
		{
			this.m_className = "?";
			this.m_fileName = "?";
			this.m_lineNumber = "?";
			this.m_methodName = "?";
			this.m_fullInfo = "?";
			if (callerStackBoundaryDeclaringType != null)
			{
				try
				{
					StackTrace stackTrace = new StackTrace(true);
					for (int i = 0; i < stackTrace.FrameCount; i++)
					{
						StackFrame frame = stackTrace.GetFrame(i);
						if (frame != null && frame.GetMethod().DeclaringType == callerStackBoundaryDeclaringType)
						{
							IL_A3:
							while (i < stackTrace.FrameCount)
							{
								StackFrame frame2 = stackTrace.GetFrame(i);
								if (frame2 != null && frame2.GetMethod().DeclaringType != callerStackBoundaryDeclaringType)
								{
									break;
								}
								i++;
							}
							if (i < stackTrace.FrameCount)
							{
								int num = stackTrace.FrameCount - i;
								ArrayList arrayList = new ArrayList(num);
								this.m_stackFrames = new StackFrameItem[num];
								for (int j = i; j < stackTrace.FrameCount; j++)
								{
									arrayList.Add(new StackFrameItem(stackTrace.GetFrame(j)));
								}
								arrayList.CopyTo(this.m_stackFrames, 0);
								StackFrame frame3 = stackTrace.GetFrame(i);
								if (frame3 != null)
								{
									MethodBase method = frame3.GetMethod();
									if (method != null)
									{
										this.m_methodName = method.Name;
										if (method.DeclaringType != null)
										{
											this.m_className = method.DeclaringType.FullName;
										}
									}
									this.m_fileName = frame3.GetFileName();
									this.m_lineNumber = frame3.GetFileLineNumber().ToString(NumberFormatInfo.InvariantInfo);
									this.m_fullInfo = string.Concat(new string[]
									{
										this.m_className,
										".",
										this.m_methodName,
										"(",
										this.m_fileName,
										":",
										this.m_lineNumber,
										")"
									});
								}
							}
							return;
						}
					}
					goto IL_A3;
				}
				catch (SecurityException)
				{
					LogLog.Debug(LocationInfo.declaringType, "Security exception while trying to get caller stack frame. Error Ignored. Location Information Not Available.");
				}
			}
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x0000FBF4 File Offset: 0x0000EBF4
		public LocationInfo(string className, string methodName, string fileName, string lineNumber)
		{
			this.m_className = className;
			this.m_fileName = fileName;
			this.m_lineNumber = lineNumber;
			this.m_methodName = methodName;
			this.m_fullInfo = string.Concat(new string[]
			{
				this.m_className,
				".",
				this.m_methodName,
				"(",
				this.m_fileName,
				":",
				this.m_lineNumber,
				")"
			});
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000FC79 File Offset: 0x0000EC79
		public string ClassName
		{
			get
			{
				return this.m_className;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0000FC81 File Offset: 0x0000EC81
		public string FileName
		{
			get
			{
				return this.m_fileName;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x0000FC89 File Offset: 0x0000EC89
		public string LineNumber
		{
			get
			{
				return this.m_lineNumber;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0000FC91 File Offset: 0x0000EC91
		public string MethodName
		{
			get
			{
				return this.m_methodName;
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0000FC99 File Offset: 0x0000EC99
		public string FullInfo
		{
			get
			{
				return this.m_fullInfo;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000FCA1 File Offset: 0x0000ECA1
		public StackFrameItem[] StackFrames
		{
			get
			{
				return this.m_stackFrames;
			}
		}

		// Token: 0x04000155 RID: 341
		private readonly string m_className;

		// Token: 0x04000156 RID: 342
		private readonly string m_fileName;

		// Token: 0x04000157 RID: 343
		private readonly string m_lineNumber;

		// Token: 0x04000158 RID: 344
		private readonly string m_methodName;

		// Token: 0x04000159 RID: 345
		private readonly string m_fullInfo;

		// Token: 0x0400015A RID: 346
		private readonly StackFrameItem[] m_stackFrames;

		// Token: 0x0400015B RID: 347
		private static readonly Type declaringType = typeof(LocationInfo);

		// Token: 0x0400015C RID: 348
		private const string NA = "?";
	}
}
