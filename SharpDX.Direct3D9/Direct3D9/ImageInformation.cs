using System;
using System.IO;

namespace SharpDX.Direct3D9
{
	// Token: 0x020000ED RID: 237
	public struct ImageInformation
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x00019D6B File Offset: 0x00017F6B
		public static ImageInformation FromFile(string fileName)
		{
			return ImageInformation.FromMemory(File.ReadAllBytes(fileName));
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00019D78 File Offset: 0x00017F78
		public unsafe static ImageInformation FromMemory(byte[] memory)
		{
			void* value;
			if (memory == null || memory.Length == 0)
			{
				value = null;
			}
			else
			{
				value = (void*)(&memory[0]);
			}
			return D3DX9.GetImageInfoFromFileInMemory((IntPtr)value, memory.Length);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00019DAB File Offset: 0x00017FAB
		public static ImageInformation FromStream(Stream stream)
		{
			return ImageInformation.FromStream(stream, true);
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00019DB4 File Offset: 0x00017FB4
		public static ImageInformation FromStream(Stream stream, bool keepPosition)
		{
			long position = 0L;
			if (keepPosition)
			{
				position = stream.Position;
			}
			ImageInformation result;
			if (stream is DataStream)
			{
				DataStream dataStream = (DataStream)stream;
				result = D3DX9.GetImageInfoFromFileInMemory(dataStream.PositionPointer, (int)(dataStream.Length - dataStream.Position));
				dataStream.Position = dataStream.Length;
			}
			else
			{
				result = ImageInformation.FromMemory(Utilities.ReadStream(stream));
			}
			if (keepPosition)
			{
				stream.Position = position;
			}
			return result;
		}

		// Token: 0x04000D84 RID: 3460
		public int Width;

		// Token: 0x04000D85 RID: 3461
		public int Height;

		// Token: 0x04000D86 RID: 3462
		public int Depth;

		// Token: 0x04000D87 RID: 3463
		public int MipLevels;

		// Token: 0x04000D88 RID: 3464
		public Format Format;

		// Token: 0x04000D89 RID: 3465
		public ResourceType ResourceType;

		// Token: 0x04000D8A RID: 3466
		public ImageFileFormat ImageFileFormat;
	}
}
