using System;
using System.Linq;
using EnsoulSharp.SDK.Rendering.Caches;
using SharpDX;

namespace EnsoulSharp.SDK.Rendering
{
	// Token: 0x02000093 RID: 147
	public static class DamageRender
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x00025606 File Offset: 0x00023806
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0002560D File Offset: 0x0002380D
		public static DamageRender.GetDamageDelegate GetDamage
		{
			get
			{
				return DamageRender._getDamage;
			}
			set
			{
				if (DamageRender._getDamage == null)
				{
					Render.OnPresent += DamageRender.OnPresent;
				}
				DamageRender._getDamage = value;
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00025630 File Offset: 0x00023830
		private static void OnPresent(EventArgs args)
		{
			if (!DamageRender.Enabled || DamageRender._getDamage == null)
			{
				return;
			}
			foreach (AIHeroClient aiheroClient in from h in GameObjects.EnemyHeroes
			where h.IsValid && h.IsVisible
			select h)
			{
				double num = DamageRender._getDamage(aiheroClient);
				if (num > 2.0)
				{
					Vector2 vector = aiheroClient.HPBarPosition - new Vector2(55f, 45f);
					double num2 = Math.Max(0.0, (double)aiheroClient.Health - num) / (double)aiheroClient.MaxHealth;
					float num3 = vector.Y + 20f;
					double num4 = (double)(vector.X + 10f) + 103.0 * num2;
					double num5 = (double)(vector.X + 10f + 103f * aiheroClient.Health / aiheroClient.MaxHealth);
					DamageRender.Line.Draw(new Vector2((float)num4, num3), new Vector2((float)num4, num3 + 11f), Color.Lime, 0);
					double num6 = num5 - num4;
					double num7 = (double)(vector.X + 9f) + 107.0 * num2;
					int num8 = 0;
					while ((double)num8 < num6)
					{
						DamageRender.Line.Draw(new Vector2((float)num7 + (float)num8, num3), new Vector2((float)num7 + (float)num8, num3 + 11f), Color.Goldenrod, 0);
						num8++;
					}
				}
			}
		}

		// Token: 0x040002EC RID: 748
		private const int XOffset = 10;

		// Token: 0x040002ED RID: 749
		private const int YOffset = 20;

		// Token: 0x040002EE RID: 750
		private const int Width = 103;

		// Token: 0x040002EF RID: 751
		private const int Height = 11;

		// Token: 0x040002F0 RID: 752
		private static DamageRender.GetDamageDelegate _getDamage;

		// Token: 0x040002F1 RID: 753
		private static readonly LineCache Line = LineRender.CreateLine(1f, false, false);

		// Token: 0x040002F2 RID: 754
		public static bool Enabled = true;

		// Token: 0x020004D5 RID: 1237
		// (Invoke) Token: 0x06001671 RID: 5745
		public delegate double GetDamageDelegate(AIBaseClient hero);
	}
}
