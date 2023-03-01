using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020000FB RID: 251
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gwen", SpellSlot.R, 3)]
	public class DamageGwenR3 : DamageSpell
	{
		// Token: 0x06000900 RID: 2304 RVA: 0x0003811C File Offset: 0x0003631C
		public DamageGwenR3()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
			base.Stage = 3;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0003813C File Offset: 0x0003633C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGwenR3.damages[level] + 0.4 * (double)source.TotalMagicalDamage + (0.05 + (double)(source.TotalMagicalDamage / 100f * 0.04f)) * (double)target.MaxHealth;
		}

		// Token: 0x040005DC RID: 1500
		private static readonly double[] damages = new double[]
		{
			150.0,
			275.0,
			400.0
		};
	}
}
