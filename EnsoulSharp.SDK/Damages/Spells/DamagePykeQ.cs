using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200026E RID: 622
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pyke", SpellSlot.Q, 0)]
	public class DamagePykeQ : DamageSpell
	{
		// Token: 0x06000D64 RID: 3428 RVA: 0x0003FB9E File Offset: 0x0003DD9E
		public DamagePykeQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D65 RID: 3429 RVA: 0x0003FBB4 File Offset: 0x0003DDB4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePykeQ.damages[level] + (double)(0.6f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000776 RID: 1910
		private static readonly double[] damages = new double[]
		{
			85.0,
			135.0,
			185.0,
			235.0,
			285.0
		};
	}
}
