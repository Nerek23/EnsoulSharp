using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x0200006A RID: 106
	[NullableContext(1)]
	[Nullable(0)]
	internal readonly struct StringReference
	{
		// Token: 0x170000D3 RID: 211
		public char this[int i]
		{
			get
			{
				return this._chars[i];
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x060005D2 RID: 1490 RVA: 0x00018EBB File Offset: 0x000170BB
		public char[] Chars
		{
			get
			{
				return this._chars;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x00018EC3 File Offset: 0x000170C3
		public int StartIndex
		{
			get
			{
				return this._startIndex;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00018ECB File Offset: 0x000170CB
		public int Length
		{
			get
			{
				return this._length;
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x00018ED3 File Offset: 0x000170D3
		public StringReference(char[] chars, int startIndex, int length)
		{
			this._chars = chars;
			this._startIndex = startIndex;
			this._length = length;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00018EEA File Offset: 0x000170EA
		public override string ToString()
		{
			return new string(this._chars, this._startIndex, this._length);
		}

		// Token: 0x04000202 RID: 514
		private readonly char[] _chars;

		// Token: 0x04000203 RID: 515
		private readonly int _startIndex;

		// Token: 0x04000204 RID: 516
		private readonly int _length;
	}
}
