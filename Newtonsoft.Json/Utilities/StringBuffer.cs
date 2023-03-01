﻿using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000069 RID: 105
	[NullableContext(2)]
	[Nullable(0)]
	internal struct StringBuffer
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00018D51 File Offset: 0x00016F51
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x00018D59 File Offset: 0x00016F59
		public int Position
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00018D62 File Offset: 0x00016F62
		public bool IsEmpty
		{
			get
			{
				return this._buffer == null;
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00018D6D File Offset: 0x00016F6D
		public StringBuffer(IArrayPool<char> bufferPool, int initalSize)
		{
			this = new StringBuffer(BufferUtils.RentBuffer(bufferPool, initalSize));
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00018D7C File Offset: 0x00016F7C
		[NullableContext(1)]
		private StringBuffer(char[] buffer)
		{
			this._buffer = buffer;
			this._position = 0;
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00018D8C File Offset: 0x00016F8C
		public void Append(IArrayPool<char> bufferPool, char value)
		{
			if (this._position == this._buffer.Length)
			{
				this.EnsureSize(bufferPool, 1);
			}
			char[] buffer = this._buffer;
			int position = this._position;
			this._position = position + 1;
			buffer[position] = value;
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00018DCC File Offset: 0x00016FCC
		[NullableContext(1)]
		public void Append([Nullable(2)] IArrayPool<char> bufferPool, char[] buffer, int startIndex, int count)
		{
			if (this._position + count >= this._buffer.Length)
			{
				this.EnsureSize(bufferPool, count);
			}
			Array.Copy(buffer, startIndex, this._buffer, this._position, count);
			this._position += count;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00018E19 File Offset: 0x00017019
		public void Clear(IArrayPool<char> bufferPool)
		{
			if (this._buffer != null)
			{
				BufferUtils.ReturnBuffer(bufferPool, this._buffer);
				this._buffer = null;
			}
			this._position = 0;
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x00018E40 File Offset: 0x00017040
		private void EnsureSize(IArrayPool<char> bufferPool, int appendLength)
		{
			char[] array = BufferUtils.RentBuffer(bufferPool, (this._position + appendLength) * 2);
			if (this._buffer != null)
			{
				Array.Copy(this._buffer, array, this._position);
				BufferUtils.ReturnBuffer(bufferPool, this._buffer);
			}
			this._buffer = array;
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x00018E8B File Offset: 0x0001708B
		[NullableContext(1)]
		public override string ToString()
		{
			return this.ToString(0, this._position);
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x00018E9A File Offset: 0x0001709A
		[NullableContext(1)]
		public string ToString(int start, int length)
		{
			return new string(this._buffer, start, length);
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00018EA9 File Offset: 0x000170A9
		public char[] InternalBuffer
		{
			get
			{
				return this._buffer;
			}
		}

		// Token: 0x04000200 RID: 512
		private char[] _buffer;

		// Token: 0x04000201 RID: 513
		private int _position;
	}
}
