using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000100 RID: 256
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KSante", SpellSlot.W, 0)]
	public class DamageKSanteW : DamageSpell
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0003835E File Offset: 0x0003655E
		public DamageKSanteW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00038374 File Offset: 0x00036574
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			if (target.Type == GameObjectType.AIHeroClient)
			{
				return DamageKSanteW.damages[level] * (double)target.MaxHealth;
			}
			return (double)(25 + 25 * source.Level);
		}

		// Token: 0x040005E1 RID: 1505
		private static readonly double[] damages = new double[]
		{
			0.02,
			0.0225,
			0.025,
			0.03,
			0.03
		};
	}
}
