using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200027D RID: 637
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.W, 0)]
	public class DamageRekSaiW : DamageSpell
	{
		// Token: 0x06000D90 RID: 3472 RVA: 0x00040086 File Offset: 0x0003E286
		public DamageRekSaiW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0004009C File Offset: 0x0003E29C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiW.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000786 RID: 1926
		private static readonly double[] damages = new double[]
		{
			55.0,
			70.0,
			85.0,
			100.0,
			115.0
		};
	}
}
