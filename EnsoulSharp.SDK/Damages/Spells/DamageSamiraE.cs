using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200028B RID: 651
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Samira", SpellSlot.E, 0)]
	public class DamageSamiraE : DamageSpell
	{
		// Token: 0x06000DBA RID: 3514 RVA: 0x00040513 File Offset: 0x0003E713
		public DamageSamiraE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x00040529 File Offset: 0x0003E729
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSamiraE.damages[level] + (double)(0.2f * source.GetBonusPhysicalDamage());
		}

		// Token: 0x04000795 RID: 1941
		private static readonly double[] damages = new double[]
		{
			50.0,
			60.0,
			70.0,
			80.0,
			90.0
		};
	}
}
