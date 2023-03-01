using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001FA RID: 506
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("KogMaw", SpellSlot.Q, 0)]
	public class DamageKogMawQ : DamageSpell
	{
		// Token: 0x06000C09 RID: 3081 RVA: 0x0003D713 File Offset: 0x0003B913
		public DamageKogMawQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x0003D729 File Offset: 0x0003B929
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKogMawQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006FE RID: 1790
		private static readonly double[] damages = new double[]
		{
			90.0,
			140.0,
			190.0,
			240.0,
			290.0
		};
	}
}
