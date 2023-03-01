using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002DB RID: 731
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Talon", SpellSlot.W, 1)]
	public class DamageTalonW1 : DamageSpell
	{
		// Token: 0x06000EAA RID: 3754 RVA: 0x00041FE5 File Offset: 0x000401E5
		public DamageTalonW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x00042002 File Offset: 0x00040202
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageTalonW1.damages[level] + 0.8 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x040007F2 RID: 2034
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};
	}
}
