using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SharpDX.Multimedia
{
	// Token: 0x0200006D RID: 109
	public class RiffParser : IEnumerator<RiffChunk>, IDisposable, IEnumerator, IEnumerable<RiffChunk>, IEnumerable
	{
		// Token: 0x060002A3 RID: 675 RVA: 0x00007DF4 File Offset: 0x00005FF4
		public RiffParser(Stream input)
		{
			this.input = input;
			this.startPosition = input.Position;
			this.reader = new BinaryReader(input);
			this.chunckStack = new Stack<RiffChunk>();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000022F0 File Offset: 0x000004F0
		public void Dispose()
		{
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00007E28 File Offset: 0x00006028
		public bool MoveNext()
		{
			this.CheckState();
			if (this.current != null)
			{
				long num = (long)((ulong)this.current.DataPosition);
				if (this.descendNext)
				{
					this.descendNext = false;
				}
				else
				{
					num += (long)((ulong)this.current.Size);
					if ((num & 1L) != 0L)
					{
						num += 1L;
					}
				}
				this.input.Position = num;
				RiffChunk riffChunk = this.chunckStack.Peek();
				long num2 = (long)((ulong)(riffChunk.DataPosition + riffChunk.Size));
				if (this.input.Position >= num2)
				{
					this.chunckStack.Pop();
				}
				if (this.chunckStack.Count == 0)
				{
					this.isEndOfRiff = true;
					return false;
				}
			}
			FourCC fourCC = this.reader.ReadUInt32();
			bool flag = fourCC == "LIST";
			bool flag2 = fourCC == "RIFF";
			if (this.input.Position == this.startPosition + 4L && !flag2)
			{
				this.isErrorState = true;
				throw new InvalidOperationException("Invalid RIFF file format");
			}
			uint num3 = this.reader.ReadUInt32();
			if (flag || flag2)
			{
				if (flag2 && (ulong)num3 > (ulong)(this.input.Length - 8L))
				{
					this.isErrorState = true;
					throw new InvalidOperationException("Invalid RIFF file format");
				}
				num3 -= 4U;
				fourCC = this.reader.ReadUInt32();
			}
			this.current = new RiffChunk(this.input, fourCC, num3, (uint)this.input.Position, flag, flag2);
			return true;
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00007FB0 File Offset: 0x000061B0
		private void CheckState()
		{
			if (this.isEndOfRiff)
			{
				throw new InvalidOperationException("End of Riff. Cannot MoveNext");
			}
			if (this.isErrorState)
			{
				throw new InvalidOperationException("The enumerator is in an error state");
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00007FD8 File Offset: 0x000061D8
		public Stack<RiffChunk> ChunkStack
		{
			get
			{
				return this.chunckStack;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00007FE0 File Offset: 0x000061E0
		public void Reset()
		{
			this.CheckState();
			this.current = null;
			this.input.Position = this.startPosition;
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00008000 File Offset: 0x00006200
		public void Ascend()
		{
			this.CheckState();
			RiffChunk riffChunk = this.chunckStack.Pop();
			this.input.Position = (long)((ulong)(riffChunk.DataPosition + riffChunk.Size));
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00008038 File Offset: 0x00006238
		public void Descend()
		{
			this.CheckState();
			this.chunckStack.Push(this.current);
			this.descendNext = true;
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00008058 File Offset: 0x00006258
		public IList<RiffChunk> GetAllChunks()
		{
			List<RiffChunk> list = new List<RiffChunk>();
			foreach (RiffChunk item in this)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002AC RID: 684 RVA: 0x000080A8 File Offset: 0x000062A8
		public RiffChunk Current
		{
			get
			{
				this.CheckState();
				return this.current;
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000041A4 File Offset: 0x000023A4
		public IEnumerator<RiffChunk> GetEnumerator()
		{
			return this;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002AE RID: 686 RVA: 0x000080B6 File Offset: 0x000062B6
		object IEnumerator.Current
		{
			get
			{
				this.CheckState();
				return this.Current;
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x000080C4 File Offset: 0x000062C4
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x04000D7F RID: 3455
		private readonly Stream input;

		// Token: 0x04000D80 RID: 3456
		private readonly long startPosition;

		// Token: 0x04000D81 RID: 3457
		private readonly BinaryReader reader;

		// Token: 0x04000D82 RID: 3458
		private readonly Stack<RiffChunk> chunckStack;

		// Token: 0x04000D83 RID: 3459
		private bool descendNext;

		// Token: 0x04000D84 RID: 3460
		private bool isEndOfRiff;

		// Token: 0x04000D85 RID: 3461
		private bool isErrorState;

		// Token: 0x04000D86 RID: 3462
		private RiffChunk current;
	}
}
