using System;
using System.Collections;

namespace log4net.Util
{
	// Token: 0x0200001F RID: 31
	public sealed class NullEnumerator : IEnumerator
	{
		// Token: 0x06000140 RID: 320 RVA: 0x00004734 File Offset: 0x00003734
		private NullEnumerator()
		{
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000473C File Offset: 0x0000373C
		public static NullEnumerator Instance
		{
			get
			{
				return NullEnumerator.s_instance;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00004743 File Offset: 0x00003743
		public object Current
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000474A File Offset: 0x0000374A
		public bool MoveNext()
		{
			return false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000474D File Offset: 0x0000374D
		public void Reset()
		{
		}

		// Token: 0x04000038 RID: 56
		private static readonly NullEnumerator s_instance = new NullEnumerator();
	}
}
