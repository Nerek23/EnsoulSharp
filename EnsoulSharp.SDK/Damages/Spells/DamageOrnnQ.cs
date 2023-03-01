using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200025B RID: 603
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Ornn", SpellSlot.Q, 0)]
	public class DamageOrnnQ : DamageSpell
	{
		// Token: 0x06000D2B RID: 3371 RVA: 0x0003F5E7 File Offset: 0x0003D7E7
		public DamageOrnnQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x0003F5FD File Offset: 0x0003D7FD
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageOrnnQ.damages[level] + 1.1 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000762 RID: 1890
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
