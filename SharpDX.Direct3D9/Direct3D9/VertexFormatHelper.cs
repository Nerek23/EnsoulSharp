using System;

namespace SharpDX.Direct3D9
{
	// Token: 0x02000127 RID: 295
	public class VertexFormatHelper
	{
		// Token: 0x060007B3 RID: 1971 RVA: 0x0001B4B8 File Offset: 0x000196B8
		public static VertexFormat TexCoordSize(int size, int coordIndex)
		{
			int num;
			switch (size)
			{
			case 1:
				num = 3;
				break;
			case 2:
				num = 0;
				break;
			case 3:
				num = 1;
				break;
			case 4:
				num = 2;
				break;
			default:
				throw new ArgumentException("Size must be in the range [1,4]", "size");
			}
			if (num != 0)
			{
				return (VertexFormat)(num << coordIndex * 2 + 16);
			}
			return (VertexFormat)num;
		}
	}
}
