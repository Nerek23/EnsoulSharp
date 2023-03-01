using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001F9 RID: 505
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KogMaw", SpellSlot.E, 0)]
	public class DamageKogMawE : DamageSpell
	{
		// Token: 0x06000C06 RID: 3078 RVA: 0x0003D6CA File Offset: 0x0003B8CA
		public DamageKogMawE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C07 RID: 3079 RVA: 0x0003D6E0 File Offset: 0x0003B8E0
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKogMawE.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006FD RID: 1789
		private static readonly double[] damages = new double[]
		{
			75.0,
			120.0,
			165.0,
			210.0,
			255.0
		};
	}
}
