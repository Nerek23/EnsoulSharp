using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F3 RID: 755
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Udyr", SpellSlot.Q, 0)]
	public class DamageUdyrQ : DamageSpell
	{
		// Token: 0x06000EF2 RID: 3826 RVA: 0x0004290A File Offset: 0x00040B0A
		public DamageUdyrQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EF3 RID: 3827 RVA: 0x00042920 File Offset: 0x00040B20
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageUdyrQ.damages[Math.Min(level, 5)] + 0.01 * (double)source.GetBonusPhysicalDamage() * 0.04) * (double)target.MaxHealth;
		}

		// Token: 0x0400080E RID: 2062
		private static readonly double[] damages = new double[]
		{
			0.03,
			0.042,
			0.054,
			0.066,
			0.078,
			0.09
		};
	}
}
