using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200021D RID: 541
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Lucian", SpellSlot.W, 0)]
	public class DamageLucianW : DamageSpell
	{
		// Token: 0x06000C72 RID: 3186 RVA: 0x0003E261 File Offset: 0x0003C461
		public DamageLucianW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x0003E277 File Offset: 0x0003C477
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLucianW.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000722 RID: 1826
		private static readonly double[] damages = new double[]
		{
			75.0,
			110.0,
			145.0,
			180.0,
			215.0
		};
	}
}
