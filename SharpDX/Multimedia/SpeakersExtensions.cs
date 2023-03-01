using System;

namespace SharpDX.Multimedia
{
	// Token: 0x0200006F RID: 111
	public static class SpeakersExtensions
	{
		// Token: 0x060002C8 RID: 712 RVA: 0x000084C4 File Offset: 0x000066C4
		public static int ToChannelCount(Speakers speakers)
		{
			int num = (int)speakers;
			int num2 = 0;
			while (num != 0)
			{
				if ((num & 1) != 0)
				{
					num2++;
				}
				num >>= 1;
			}
			return num2;
		}
	}
}
