using System;
using System.Runtime.Serialization;

namespace <CrtImplementationDetails>
{
	// Token: 0x02000171 RID: 369
	[Serializable]
	internal class ModuleLoadException : Exception
	{
		// Token: 0x060006AB RID: 1707 RVA: 0x000107E4 File Offset: 0x0000FBE4
		protected ModuleLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000107CC File Offset: 0x0000FBCC
		public ModuleLoadException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000107B8 File Offset: 0x0000FBB8
		public ModuleLoadException(string message) : base(message)
		{
		}

		// Token: 0x0400040F RID: 1039
		public const string Nested = "A nested exception occurred after the primary exception that caused the C++ module to fail to load.\n";
	}
}
