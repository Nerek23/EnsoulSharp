using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000111 RID: 273
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Aatrox", SpellSlot.W, 0)]
	public class DamageAatroxW : DamageSpell
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x00038970 File Offset: 0x00036B70
		public DamageAatroxW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00038986 File Offset: 0x00036B86
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageAatroxW.damages[level] + 0.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x040005F8 RID: 1528
		private static readonly double[] damages = new double[]
		{
			30.0,
			40.0,
			50.0,
			60.0,
			70.0
		};
	}
}
