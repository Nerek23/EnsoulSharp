using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200010C RID: 268
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rell", SpellSlot.W, 0)]
	public class DamageRellW1 : DamageSpell
	{
		// Token: 0x06000933 RID: 2355 RVA: 0x0003874A File Offset: 0x0003694A
		public DamageRellW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00038767 File Offset: 0x00036967
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRellW1.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040005F0 RID: 1520
		private static readonly double[] damages = new double[]
		{
			10.0,
			25.0,
			40.0,
			55.0,
			70.0
		};
	}
}
