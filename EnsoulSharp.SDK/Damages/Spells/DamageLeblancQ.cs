using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FE RID: 510
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.Q, 0)]
	public class DamageLeblancQ : DamageSpell
	{
		// Token: 0x06000C15 RID: 3093 RVA: 0x0003D887 File Offset: 0x0003BA87
		public DamageLeblancQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0003D89D File Offset: 0x0003BA9D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancQ.damages[level] + 0.4 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000702 RID: 1794
		private static readonly double[] damages = new double[]
		{
			65.0,
			90.0,
			115.0,
			140.0,
			165.0
		};
	}
}
