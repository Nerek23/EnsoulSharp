using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000314 RID: 788
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viktor", SpellSlot.Q, 0)]
	public class DamageViktorQ : DamageSpell
	{
		// Token: 0x06000F55 RID: 3925 RVA: 0x00043418 File Offset: 0x00041618
		public DamageViktorQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x0004342E File Offset: 0x0004162E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViktorQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000834 RID: 2100
		private static readonly double[] damages = new double[]
		{
			60.0,
			75.0,
			90.0,
			105.0,
			120.0
		};
	}
}
