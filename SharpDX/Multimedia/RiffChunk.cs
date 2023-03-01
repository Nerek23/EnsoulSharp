using System;
using System.Globalization;
using System.IO;

namespace SharpDX.Multimedia
{
	// Token: 0x0200006C RID: 108
	public class RiffChunk
	{
		// Token: 0x06000292 RID: 658 RVA: 0x00007C05 File Offset: 0x00005E05
		public RiffChunk(Stream stream, FourCC type, uint size, uint dataPosition, bool isList = false, bool isHeader = false)
		{
			this.Stream = stream;
			this.Type = type;
			this.Size = size;
			this.DataPosition = dataPosition;
			this.IsList = isList;
			this.IsHeader = isHeader;
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00007C3A File Offset: 0x00005E3A
		// (set) Token: 0x06000294 RID: 660 RVA: 0x00007C42 File Offset: 0x00005E42
		public Stream Stream { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000295 RID: 661 RVA: 0x00007C4B File Offset: 0x00005E4B
		// (set) Token: 0x06000296 RID: 662 RVA: 0x00007C53 File Offset: 0x00005E53
		public FourCC Type { get; private set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000297 RID: 663 RVA: 0x00007C5C File Offset: 0x00005E5C
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00007C64 File Offset: 0x00005E64
		public uint Size { get; private set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000299 RID: 665 RVA: 0x00007C6D File Offset: 0x00005E6D
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00007C75 File Offset: 0x00005E75
		public uint DataPosition { get; private set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00007C7E File Offset: 0x00005E7E
		// (set) Token: 0x0600029C RID: 668 RVA: 0x00007C86 File Offset: 0x00005E86
		public bool IsList { get; private set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00007C8F File Offset: 0x00005E8F
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00007C97 File Offset: 0x00005E97
		public bool IsHeader { get; private set; }

		// Token: 0x0600029F RID: 671 RVA: 0x00007CA0 File Offset: 0x00005EA0
		public byte[] GetData()
		{
			byte[] array = new byte[this.Size];
			this.Stream.Position = (long)((ulong)this.DataPosition);
			this.Stream.Read(array, 0, (int)this.Size);
			return array;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public unsafe T GetDataAs<T>() where T : struct
		{
			T result = Activator.CreateInstance<T>();
			byte[] array;
			void* value;
			if ((array = this.GetData()) == null || array.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array[0]);
			}
			Utilities.Read<T>((IntPtr)value, ref result);
			array = null;
			return result;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00007D20 File Offset: 0x00005F20
		public unsafe T[] GetDataAsArray<T>() where T : struct
		{
			int num = Utilities.SizeOf<T>();
			if ((ulong)this.Size % (ulong)((long)num) != 0UL)
			{
				throw new ArgumentException("Size of T is incompatible with size of chunk");
			}
			T[] array = new T[(ulong)this.Size / (ulong)((long)num)];
			byte[] array2;
			void* value;
			if ((array2 = this.GetData()) == null || array2.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&array2[0]);
			}
			Utilities.Read<T>((IntPtr)value, array, 0, array.Length);
			array2 = null;
			return array;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00007D8C File Offset: 0x00005F8C
		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "Type: {0}, Size: {1}, Position: {2}, IsList: {3}, IsHeader: {4}", new object[]
			{
				this.Type,
				this.Size,
				this.DataPosition,
				this.IsList,
				this.IsHeader
			});
		}
	}
}
