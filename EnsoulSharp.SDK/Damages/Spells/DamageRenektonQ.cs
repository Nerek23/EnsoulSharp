using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000280 RID: 640
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Renekton", SpellSlot.Q, 0)]
	public class DamageRenektonQ : DamageSpell
	{
		// Token: 0x06000D99 RID: 3481 RVA: 0x00040168 File Offset: 0x0003E368
		public DamageRenektonQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x0004017E File Offset: 0x0003E37E
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRenektonQ.damages[level] + (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000789 RID: 1929
		private static readonly double[] damages = new double[]
		{
			60.0,
			90.0,
			120.0,
			150.0,
			180.0
		};
	}
}
