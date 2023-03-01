using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031A RID: 794
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vi", SpellSlot.W, 0)]
	public class DamageViW : DamageSpell
	{
		// Token: 0x06000F67 RID: 3943 RVA: 0x000435E7 File Offset: 0x000417E7
		public DamageViW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x000435FD File Offset: 0x000417FD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (DamageViW.damages[level] + 0.0286 * (double)source.GetBonusPhysicalDamage() / 100.0) * (double)target.MaxHealth;
		}

		// Token: 0x0400083A RID: 2106
		private static readonly double[] damages = new double[]
		{
			0.04,
			0.055,
			0.07,
			0.085,
			0.1
		};
	}
}
