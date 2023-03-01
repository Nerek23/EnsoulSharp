using System;
using System.Collections;

namespace log4net.Util
{
	// Token: 0x0200001E RID: 30
	public sealed class NullDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		// Token: 0x06000137 RID: 311 RVA: 0x000046F8 File Offset: 0x000036F8
		private NullDictionaryEnumerator()
		{
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00004700 File Offset: 0x00003700
		public static NullDictionaryEnumerator Instance
		{
			get
			{
				return NullDictionaryEnumerator.s_instance;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004707 File Offset: 0x00003707
		public object Current
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000470E File Offset: 0x0000370E
		public bool MoveNext()
		{
			return false;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00004711 File Offset: 0x00003711
		public void Reset()
		{
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00004713 File Offset: 0x00003713
		public object Key
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000471A File Offset: 0x0000371A
		public object Value
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00004721 File Offset: 0x00003721
		public DictionaryEntry Entry
		{
			get
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x04000037 RID: 55
		private static readonly NullDictionaryEnumerator s_instance = new NullDictionaryEnumerator();
	}
}
