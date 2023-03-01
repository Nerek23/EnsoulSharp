using System;

namespace SharpDX
{
	// Token: 0x02000017 RID: 23
	public class CompilationException : SharpDXException
	{
		// Token: 0x060000B5 RID: 181 RVA: 0x00003873 File Offset: 0x00001A73
		public CompilationException(string message) : base(message, new object[0])
		{
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003882 File Offset: 0x00001A82
		public CompilationException(Result errorCode, string message) : base(errorCode, message)
		{
		}
	}
}
