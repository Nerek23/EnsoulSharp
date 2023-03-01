using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200022E RID: 558
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MasterYi", SpellSlot.E, 0)]
	public class DamageMasterYiE : DamageSpell
	{
		// Token: 0x06000CA5 RID: 3237 RVA: 0x0003E7C6 File Offset: 0x0003C9C6
		public DamageMasterYiE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x0003E7DC File Offset: 0x0003C9DC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMasterYiE.damages[level] + 0.3 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000734 RID: 1844
		private static readonly double[] damages = new double[]
		{
			30.0,
			35.0,
			40.0,
			45.0,
			50.0
		};
	}
}
