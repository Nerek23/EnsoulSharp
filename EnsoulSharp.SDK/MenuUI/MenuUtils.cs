using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using EnsoulSharp.SDK.Core;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000C3 RID: 195
	internal static class MenuUtils
	{
		// Token: 0x0600076C RID: 1900 RVA: 0x0002CAD4 File Offset: 0x0002ACD4
		public static Vector2 GetCenter(this Rectangle rectangle, Rectangle dimensions, CenteredFlags flags)
		{
			int num = 0;
			int num2 = 0;
			if (flags.HasFlag(CenteredFlags.HorizontalLeft))
			{
				num = rectangle.Left;
			}
			else if (flags.HasFlag(CenteredFlags.HorizontalCenter))
			{
				num = rectangle.Left + (rectangle.Width - dimensions.Width) / 2;
			}
			else if (flags.HasFlag(CenteredFlags.HorizontalRight))
			{
				num = rectangle.Left - dimensions.Width;
			}
			if (flags.HasFlag(CenteredFlags.VerticalUp))
			{
				num2 = rectangle.Top;
			}
			else if (flags.HasFlag(CenteredFlags.VerticalCenter))
			{
				num2 = rectangle.Top + (rectangle.Height - dimensions.Height) / 2;
			}
			else if (flags.HasFlag(CenteredFlags.VerticalDown))
			{
				num2 = rectangle.Bottom - dimensions.Height;
			}
			return new Vector2((float)num, (float)num2);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0002CBC8 File Offset: 0x0002ADC8
		public static Vector2 GetCenteredText(this Rectangle rectangle, string text, CenteredFlags flags)
		{
			return rectangle.GetCenter(Config.EnsoulSharpFont.MeasureText(text, FontCache.DrawFontFlags.Left), flags);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0002CBE2 File Offset: 0x0002ADE2
		public static Vector2 GetCenteredText(this Rectangle rectangle, FontCache font, string text, CenteredFlags flags)
		{
			if (font != null)
			{
				return rectangle.GetCenter(font.MeasureText(text, FontCache.DrawFontFlags.Left), flags);
			}
			return rectangle.GetCenteredText(text, flags);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0002CC04 File Offset: 0x0002AE04
		public static T DeserializeMenu<T>(byte[] arrBytes)
		{
			T result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(arrBytes, 0, arrBytes.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				result = (T)((object)MenuUtils.MenuBinaryFormatter.Deserialize(memoryStream));
			}
			return result;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0002CC5C File Offset: 0x0002AE5C
		public static T3 DeserializeMenuItem<T3>(byte[] arrBytes)
		{
			T3 result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				memoryStream.Write(arrBytes, 0, arrBytes.Length);
				memoryStream.Seek(0L, SeekOrigin.Begin);
				result = (T3)((object)MenuUtils.MenuItemBinaryFormatter.Deserialize(memoryStream));
			}
			return result;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0002CCB4 File Offset: 0x0002AEB4
		public static byte[] SerializeMenuItem(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				MenuUtils.MenuBinaryFormatter.Serialize(memoryStream, obj);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x04000577 RID: 1399
		private static readonly BinaryFormatter MenuBinaryFormatter = new BinaryFormatter();

		// Token: 0x04000578 RID: 1400
		private static readonly BinaryFormatter MenuItemBinaryFormatter = new BinaryFormatter
		{
			Binder = new AllowAllAssemblyVersionsDeserializationBinder()
		};

		// Token: 0x04000579 RID: 1401
		internal static ColorBGRA AlphaColor = new ColorBGRA(0, 0, 0, 0);
	}
}
