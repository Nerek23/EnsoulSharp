using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FC RID: 508
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KogMaw", SpellSlot.W, 0)]
	public class DamageKogMawW : DamageSpell
	{
		// Token: 0x06000C0F RID: 3087 RVA: 0x0003D7E7 File Offset: 0x0003B9E7
		public DamageKogMawW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x0003D7FD File Offset: 0x0003B9FD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageKogMawW.damages[level] + 0.01 * (double)(source.TotalMagicalDamage / 100f)) * (double)target.MaxHealth;
		}

		// Token: 0x04000700 RID: 1792
		private static readonly double[] damages = new double[]
		{
			0.035,
			0.0425,
			0.05,
			0.0575,
			0.065
		};
	}
}
