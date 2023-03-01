using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000011 RID: 17
	public static class ByteExtensions
	{
		// Token: 0x06000088 RID: 136 RVA: 0x00005FF8 File Offset: 0x000041F8
		public static byte[] GetBytes(this string str)
		{
			byte[] array = new byte[str.Length * 2];
			Buffer.BlockCopy(str.ToCharArray(), 0, array, 0, array.Length);
			return array;
		}
	}
}
