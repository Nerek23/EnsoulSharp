using System;

namespace SharpDX
{
	// Token: 0x02000021 RID: 33
	public static class RandomUtil
	{
		// Token: 0x06000566 RID: 1382 RVA: 0x0001B6DE File Offset: 0x000198DE
		public static float NextFloat(this Random random, float min, float max)
		{
			return MathUtil.Lerp(min, max, (float)random.NextDouble());
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0001B6EE File Offset: 0x000198EE
		public static double NextDouble(this Random random, double min, double max)
		{
			return MathUtil.Lerp(min, max, random.NextDouble());
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0001B700 File Offset: 0x00019900
		public static long NextLong(this Random random)
		{
			byte[] array = new byte[8];
			random.NextBytes(array);
			return BitConverter.ToInt64(array, 0);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0001B724 File Offset: 0x00019924
		public static long NextLong(this Random random, long min, long max)
		{
			byte[] array = new byte[8];
			random.NextBytes(array);
			return Math.Abs(BitConverter.ToInt64(array, 0) % (max - min + 1L)) + min;
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0001B754 File Offset: 0x00019954
		public static Vector2 NextVector2(this Random random, Vector2 min, Vector2 max)
		{
			return new Vector2(random.NextFloat(min.X, max.X), random.NextFloat(min.Y, max.Y));
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0001B77F File Offset: 0x0001997F
		public static Vector3 NextVector3(this Random random, Vector3 min, Vector3 max)
		{
			return new Vector3(random.NextFloat(min.X, max.X), random.NextFloat(min.Y, max.Y), random.NextFloat(min.Z, max.Z));
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001B7BC File Offset: 0x000199BC
		public static Vector4 NextVector4(this Random random, Vector4 min, Vector4 max)
		{
			return new Vector4(random.NextFloat(min.X, max.X), random.NextFloat(min.Y, max.Y), random.NextFloat(min.Z, max.Z), random.NextFloat(min.W, max.W));
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0001B816 File Offset: 0x00019A16
		public static Color NextColor(this Random random)
		{
			return new Color(random.NextFloat(0f, 1f), random.NextFloat(0f, 1f), random.NextFloat(0f, 1f), 1f);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0001B852 File Offset: 0x00019A52
		public static Color NextColor(this Random random, float minBrightness, float maxBrightness)
		{
			return new Color(random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), 1f);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0001B876 File Offset: 0x00019A76
		public static Color NextColor(this Random random, float minBrightness, float maxBrightness, float alpha)
		{
			return new Color(random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), alpha);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0001B896 File Offset: 0x00019A96
		public static Color NextColor(this Random random, float minBrightness, float maxBrightness, float minAlpha, float maxAlpha)
		{
			return new Color(random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minBrightness, maxBrightness), random.NextFloat(minAlpha, maxAlpha));
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0001B8BE File Offset: 0x00019ABE
		public static Point NextPoint(this Random random, Point min, Point max)
		{
			return new Point(random.Next(min.X, max.X), random.Next(min.Y, max.Y));
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0001B8E9 File Offset: 0x00019AE9
		public static TimeSpan NextTime(this Random random, TimeSpan min, TimeSpan max)
		{
			return TimeSpan.FromTicks(random.NextLong(min.Ticks, max.Ticks));
		}
	}
}
