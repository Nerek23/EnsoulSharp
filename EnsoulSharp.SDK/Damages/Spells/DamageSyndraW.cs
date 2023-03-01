using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002D4 RID: 724
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Syndra", SpellSlot.W, 0)]
	public class DamageSyndraW : DamageSpell
	{
		// Token: 0x06000E95 RID: 3733 RVA: 0x00041DE6 File Offset: 0x0003FFE6
		public DamageSyndraW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00041DFC File Offset: 0x0003FFFC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageSyndraW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040007EB RID: 2027
		private static readonly double[] damages = new double[]
		{
			70.0,
			110.0,
			150.0,
			190.0,
			230.0
		};
	}
}
