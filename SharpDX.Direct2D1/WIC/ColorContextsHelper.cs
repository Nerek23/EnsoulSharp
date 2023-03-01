using System;

namespace SharpDX.WIC
{
	// Token: 0x02000014 RID: 20
	public static class ColorContextsHelper
	{
		// Token: 0x060000FF RID: 255 RVA: 0x00004B10 File Offset: 0x00002D10
		internal static Result TryGetColorContexts(ColorContextsProvider getColorContexts, ImagingFactory imagingFactory, out ColorContext[] colorContexts)
		{
			colorContexts = null;
			int num;
			Result result = getColorContexts(0, null, out num);
			if (result.Success)
			{
				colorContexts = new ColorContext[num];
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						colorContexts[i] = new ColorContext(imagingFactory);
					}
					int num2;
					getColorContexts(num, colorContexts, out num2);
				}
			}
			return result;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004B64 File Offset: 0x00002D64
		internal static ColorContext[] TryGetColorContexts(ColorContextsProvider getColorContexts, ImagingFactory imagingFactory)
		{
			ColorContext[] result;
			Result right = ColorContextsHelper.TryGetColorContexts(getColorContexts, imagingFactory, out result);
			if (ResultCode.UnsupportedOperation != right)
			{
				right.CheckError();
			}
			return result;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004B90 File Offset: 0x00002D90
		internal static ColorContext[] GetColorContexts(ColorContextsProvider getColorContexts, ImagingFactory imagingFactory)
		{
			ColorContext[] result;
			ColorContextsHelper.TryGetColorContexts(getColorContexts, imagingFactory, out result).CheckError();
			return result;
		}
	}
}
