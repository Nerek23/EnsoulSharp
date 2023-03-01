using System;
using System.Runtime.Serialization;

namespace log4net.Core
{
	// Token: 0x020000B5 RID: 181
	[Serializable]
	public class LogException : ApplicationException
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x0000FCBA File Offset: 0x0000ECBA
		public LogException()
		{
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000FCC2 File Offset: 0x0000ECC2
		public LogException(string message) : base(message)
		{
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x0000FCCB File Offset: 0x0000ECCB
		public LogException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x0000FCD5 File Offset: 0x0000ECD5
		protected LogException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
