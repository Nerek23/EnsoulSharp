using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000283 RID: 643
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.W, 0)]
	public class DamageRenektonW : DamageSpell
	{
		// Token: 0x06000DA2 RID: 3490 RVA: 0x00040252 File Offset: 0x0003E452
		public DamageRenektonW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00040268 File Offset: 0x0003E468
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonW.damages[level] + 0.75 * (double)source.TotalAttackDamage + (double)(2f * source.TotalAttackDamage);
		}

		// Token: 0x0400078C RID: 1932
		private static readonly double[] damages = new double[]
		{
			10.0,
			40.0,
			70.0,
			110.0,
			130.0
		};
	}
}
