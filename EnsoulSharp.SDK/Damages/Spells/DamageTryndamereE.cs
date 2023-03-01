using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002EC RID: 748
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Tryndamere", SpellSlot.E, 0)]
	public class DamageTryndamereE : DamageSpell
	{
		// Token: 0x06000EDD RID: 3805 RVA: 0x00042661 File Offset: 0x00040861
		public DamageTryndamereE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x00042677 File Offset: 0x00040877
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTryndamereE.damages[level] + 1.3 * (double)source.GetBonusPhysicalDamage() + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000806 RID: 2054
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
