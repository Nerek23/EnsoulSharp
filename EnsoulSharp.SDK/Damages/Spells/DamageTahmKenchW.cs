using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D6 RID: 726
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("TahmKench", SpellSlot.W, 0)]
	public class DamageTahmKenchW : DamageSpell
	{
		// Token: 0x06000E9B RID: 3739 RVA: 0x00041E6E File Offset: 0x0004006E
		public DamageTahmKenchW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x00041E84 File Offset: 0x00040084
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTahmKenchW.damages[level] + (double)(1.5f * source.TotalMagicalDamage);
		}

		// Token: 0x040007ED RID: 2029
		private static readonly double[] damages = new double[]
		{
			100.0,
			135.0,
			170.0,
			205.0,
			240.0
		};
	}
}
