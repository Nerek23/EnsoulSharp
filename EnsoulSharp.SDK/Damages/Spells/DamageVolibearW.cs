using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000323 RID: 803
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Volibear", SpellSlot.W, 0)]
	public class DamageVolibearW : DamageSpell
	{
		// Token: 0x06000F82 RID: 3970 RVA: 0x000438DD File Offset: 0x00041ADD
		public DamageVolibearW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F83 RID: 3971 RVA: 0x000438F3 File Offset: 0x00041AF3
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVolibearW.damages[level] + (double)(1f * source.TotalAttackDamage) + 0.05 * (double)source.BonusHealth;
		}

		// Token: 0x04000844 RID: 2116
		private static readonly double[] damages = new double[]
		{
			5.0,
			30.0,
			55.0,
			80.0,
			105.0
		};
	}
}
