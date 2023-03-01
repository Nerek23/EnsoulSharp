using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000286 RID: 646
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.E, 1)]
	public class DamageRengarE1 : DamageSpell
	{
		// Token: 0x06000DAB RID: 3499 RVA: 0x00040350 File Offset: 0x0003E550
		public DamageRengarE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x0004036D File Offset: 0x0003E56D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarE1.damages[Math.Min(17, source.Level - 1)] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400078F RID: 1935
		private static readonly double[] damages = new double[]
		{
			50.0,
			65.0,
			80.0,
			95.0,
			110.0,
			125.0,
			140.0,
			155.0,
			170.0,
			185.0,
			200.0,
			215.0,
			230.0,
			245.0,
			260.0,
			275.0,
			290.0,
			305.0
		};
	}
}
