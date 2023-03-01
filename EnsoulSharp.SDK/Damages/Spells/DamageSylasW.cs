using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002CB RID: 715
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Sylas", SpellSlot.W, 0)]
	public class DamageSylasW : DamageSpell
	{
		// Token: 0x06000E7A RID: 3706 RVA: 0x00041B3B File Offset: 0x0003FD3B
		public DamageSylasW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00041B51 File Offset: 0x0003FD51
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSylasW.damages[level] + 0.9 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007E2 RID: 2018
		private static readonly double[] damages = new double[]
		{
			70.0,
			105.0,
			140.0,
			175.0,
			210.0
		};
	}
}
