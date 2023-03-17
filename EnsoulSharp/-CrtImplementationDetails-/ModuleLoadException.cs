using System;
using System.Runtime.Serialization;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000173 RID: 371
	[Serializable]
	internal class ModuleLoadException : Exception
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x000108D4 File Offset: 0x0000FCD4
		protected ModuleLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x000108BC File Offset: 0x0000FCBC
		public ModuleLoadException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x000108A8 File Offset: 0x0000FCA8
		public ModuleLoadException(string message) : base(message)
		{
		}

		// Token: 0x0400040F RID: 1039
		public const string Nested = "A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n";
	}
}
