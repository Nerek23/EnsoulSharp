using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DC RID: 732
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Talon", SpellSlot.W, 0)]
	public class DamageTalonW : DamageSpell
	{
		// Token: 0x06000EAD RID: 3757 RVA: 0x00042035 File Offset: 0x00040235
		public DamageTalonW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x0004204B File Offset: 0x0004024B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTalonW.damages[level] + 0.4 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007F3 RID: 2035
		private static readonly double[] damages = new double[]
		{
			40.0,
			50.0,
			60.0,
			70.0,
			80.0
		};
	}
}
