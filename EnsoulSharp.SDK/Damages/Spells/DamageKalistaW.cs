using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001CE RID: 462
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kalista", SpellSlot.W, 0)]
	public class DamageKalistaW : DamageSpell
	{
		// Token: 0x06000B87 RID: 2951 RVA: 0x0003C83E File Offset: 0x0003AA3E
		public DamageKalistaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x0003C854 File Offset: 0x0003AA54
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageKalistaW.damages[level] * (double)target.MaxHealth;
			if (target.Type != GameObjectType.AIMinionClient)
			{
				return num;
			}
			return Math.Min(DamageKalistaW.mindamages[level], num);
		}

		// Token: 0x040006CF RID: 1743
		private static readonly double[] damages = new double[]
		{
			0.14,
			0.15,
			0.16,
			0.17,
			0.18
		};

		// Token: 0x040006D0 RID: 1744
		private static readonly double[] mindamages = new double[]
		{
			75.0,
			125.0,
			150.0,
			175.0,
			200.0
		};
	}
}
