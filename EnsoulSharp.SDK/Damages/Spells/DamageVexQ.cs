using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002FF RID: 767
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vex", SpellSlot.Q, 0)]
	public class DamageVexQ : DamageSpell
	{
		// Token: 0x06000F16 RID: 3862 RVA: 0x00042CDE File Offset: 0x00040EDE
		public DamageVexQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F17 RID: 3863 RVA: 0x00042CF4 File Offset: 0x00040EF4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVexQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400081D RID: 2077
		private static readonly double[] damages = new double[]
		{
			60.0,
			105.0,
			150.0,
			195.0,
			240.0
		};
	}
}
