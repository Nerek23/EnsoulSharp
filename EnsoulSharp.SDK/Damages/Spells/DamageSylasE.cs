using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002C8 RID: 712
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sylas", SpellSlot.E, 0)]
	public class DamageSylasE : DamageSpell
	{
		// Token: 0x06000E71 RID: 3697 RVA: 0x00041A5D File Offset: 0x0003FC5D
		public DamageSylasE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x00041A73 File Offset: 0x0003FC73
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSylasE.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x040007DF RID: 2015
		private static readonly double[] damages = new double[]
		{
			80.0,
			130.0,
			180.0,
			230.0,
			280.0
		};
	}
}
