using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200029B RID: 667
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rumble", SpellSlot.Q, 0)]
	public class DamageRumbleQ : DamageSpell
	{
		// Token: 0x06000DEA RID: 3562 RVA: 0x00040A9C File Offset: 0x0003EC9C
		public DamageRumbleQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00040AB2 File Offset: 0x0003ECB2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRumbleQ.damages[level] + 1.1 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007AA RID: 1962
		private static readonly double[] damages = new double[]
		{
			180.0,
			220.0,
			260.0,
			300.0,
			340.0
		};
	}
}
