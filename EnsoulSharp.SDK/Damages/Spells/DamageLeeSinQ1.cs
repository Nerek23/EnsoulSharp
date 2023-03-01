using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000205 RID: 517
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("LeeSin", SpellSlot.Q, 1)]
	public class DamageLeeSinQ1 : DamageSpell
	{
		// Token: 0x06000C2A RID: 3114 RVA: 0x0003DACD File Offset: 0x0003BCCD
		public DamageLeeSinQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0003DAEA File Offset: 0x0003BCEA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeeSinQ1.damages[level] + 1.1 * (double)source.GetBonusPhysicalDamage() + 0.01 * (double)(target.MaxHealth - target.Health);
		}

		// Token: 0x04000709 RID: 1801
		private static readonly double[] damages = new double[]
		{
			55.0,
			80.0,
			105.0,
			130.0,
			155.0
		};
	}
}
