using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FB RID: 763
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Varus", SpellSlot.R, 0)]
	public class DamageVarusR : DamageSpell
	{
		// Token: 0x06000F0A RID: 3850 RVA: 0x00042B91 File Offset: 0x00040D91
		public DamageVarusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F0B RID: 3851 RVA: 0x00042BA7 File Offset: 0x00040DA7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVarusR.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x04000818 RID: 2072
		private static readonly double[] damages = new double[]
		{
			150.0,
			250.0,
			350.0
		};
	}
}
