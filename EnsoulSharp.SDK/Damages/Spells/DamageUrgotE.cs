using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F6 RID: 758
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Urgot", SpellSlot.E, 0)]
	public class DamageUrgotE : DamageSpell
	{
		// Token: 0x06000EFB RID: 3835 RVA: 0x000429FD File Offset: 0x00040BFD
		public DamageUrgotE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x00042A13 File Offset: 0x00040C13
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageUrgotE.damages[level] + (double)(1f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000811 RID: 2065
		private static readonly double[] damages = new double[]
		{
			90.0,
			120.0,
			150.0,
			180.0,
			210.0
		};
	}
}
