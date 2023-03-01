using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000252 RID: 594
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nunu", SpellSlot.Q, 0)]
	public class DamageNunuQ : DamageSpell
	{
		// Token: 0x06000D10 RID: 3344 RVA: 0x0003F304 File Offset: 0x0003D504
		public DamageNunuQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0003F31C File Offset: 0x0003D51C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double result = DamageNunuQ.damages[level] + 0.65 * (double)source.TotalMagicalDamage + 0.05 * (double)source.BonusHealth;
			if (target.Type == GameObjectType.AIMinionClient)
			{
				result = DamageNunuQ.maxdamages[level];
			}
			return result;
		}

		// Token: 0x04000758 RID: 1880
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};

		// Token: 0x04000759 RID: 1881
		private static readonly double[] maxdamages = new double[]
		{
			400.0,
			600.0,
			800.0,
			1000.0,
			1200.0
		};
	}
}
