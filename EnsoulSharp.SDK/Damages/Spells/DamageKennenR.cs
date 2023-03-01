using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001EF RID: 495
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kennen", SpellSlot.R, 0)]
	public class DamageKennenR : DamageSpell
	{
		// Token: 0x06000BE8 RID: 3048 RVA: 0x0003D3C0 File Offset: 0x0003B5C0
		public DamageKennenR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x0003D3D6 File Offset: 0x0003B5D6
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKennenR.damages[level] + 1.6875 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006F2 RID: 1778
		private static readonly double[] damages = new double[]
		{
			300.0,
			562.5,
			825.0
		};
	}
}
