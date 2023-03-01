using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000279 RID: 633
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("RekSai", SpellSlot.E, 1)]
	public class DamageRekSaiE1 : DamageSpell
	{
		// Token: 0x06000D84 RID: 3460 RVA: 0x0003FF15 File Offset: 0x0003E115
		public DamageRekSaiE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x0003FF32 File Offset: 0x0003E132
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRekSaiE1.damages[level] + 1.7 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000781 RID: 1921
		private static readonly double[] damages = new double[]
		{
			100.0,
			120.0,
			140.0,
			160.0,
			180.0
		};
	}
}
