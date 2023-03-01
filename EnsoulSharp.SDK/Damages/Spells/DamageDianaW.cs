using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000164 RID: 356
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Diana", SpellSlot.W, 0)]
	public class DamageDianaW : DamageSpell
	{
		// Token: 0x06000A44 RID: 2628 RVA: 0x0003A53F File Offset: 0x0003873F
		public DamageDianaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x0003A555 File Offset: 0x00038755
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageDianaW.damages[level] + 0.15 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000658 RID: 1624
		private static readonly double[] damages = new double[]
		{
			18.0,
			30.0,
			42.0,
			54.0,
			66.0
		};
	}
}
