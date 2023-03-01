using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000312 RID: 786
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viktor", SpellSlot.E, 0)]
	public class DamageViktorE : DamageSpell
	{
		// Token: 0x06000F4F RID: 3919 RVA: 0x0004337F File Offset: 0x0004157F
		public DamageViktorE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00043395 File Offset: 0x00041595
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViktorE.damages[level] + 0.5 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000832 RID: 2098
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
