using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000BF RID: 191
	[Serializable]
	public class StackFrameItem
	{
		// Token: 0x06000572 RID: 1394 RVA: 0x000117D0 File Offset: 0x000107D0
		public StackFrameItem(StackFrame frame)
		{
			this.m_lineNumber = "?";
			this.m_fileName = "?";
			this.m_method = new MethodItem();
			this.m_className = "?";
			try
			{
				this.m_lineNumber = frame.GetFileLineNumber().ToString(NumberFormatInfo.InvariantInfo);
				this.m_fileName = frame.GetFileName();
				MethodBase method = frame.GetMethod();
				if (method != null)
				{
					if (method.DeclaringType != null)
					{
						this.m_className = method.DeclaringType.FullName;
					}
					this.m_method = new MethodItem(method);
				}
			}
			catch (Exception exception)
			{
				LogLog.Error(StackFrameItem.declaringType, "An exception ocurred while retreiving stack frame information.", exception);
			}
			this.m_fullInfo = string.Concat(new string[]
			{
				this.m_className,
				".",
				this.m_method.Name,
				"(",
				this.m_fileName,
				":",
				this.m_lineNumber,
				")"
			});
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x000118F0 File Offset: 0x000108F0
		public string ClassName
		{
			get
			{
				return this.m_className;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x000118F8 File Offset: 0x000108F8
		public string FileName
		{
			get
			{
				return this.m_fileName;
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x00011900 File Offset: 0x00010900
		public string LineNumber
		{
			get
			{
				return this.m_lineNumber;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x00011908 File Offset: 0x00010908
		public MethodItem Method
		{
			get
			{
				return this.m_method;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06000577 RID: 1399 RVA: 0x00011910 File Offset: 0x00010910
		public string FullInfo
		{
			get
			{
				return this.m_fullInfo;
			}
		}

		// Token: 0x04000192 RID: 402
		private readonly string m_lineNumber;

		// Token: 0x04000193 RID: 403
		private readonly string m_fileName;

		// Token: 0x04000194 RID: 404
		private readonly string m_className;

		// Token: 0x04000195 RID: 405
		private readonly string m_fullInfo;

		// Token: 0x04000196 RID: 406
		private readonly MethodItem m_method;

		// Token: 0x04000197 RID: 407
		private static readonly Type declaringType = typeof(StackFrameItem);

		// Token: 0x04000198 RID: 408
		private const string NA = "?";
	}
}
