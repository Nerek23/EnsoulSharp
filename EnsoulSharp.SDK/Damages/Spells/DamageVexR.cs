using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000300 RID: 768
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vex", SpellSlot.R, 0)]
	public class DamageVexR : DamageSpell
	{
		// Token: 0x06000F19 RID: 3865 RVA: 0x00042D27 File Offset: 0x00040F27
		public DamageVexR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F1A RID: 3866 RVA: 0x00042D3D File Offset: 0x00040F3D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVexR.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400081E RID: 2078
		private static readonly double[] damages = new double[]
		{
			225.0,
			375.0,
			525.0
		};
	}
}
