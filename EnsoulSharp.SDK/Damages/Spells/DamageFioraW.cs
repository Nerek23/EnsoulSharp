using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000181 RID: 385
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Fiora", SpellSlot.W, 0)]
	public class DamageFioraW : DamageSpell
	{
		// Token: 0x06000A9B RID: 2715 RVA: 0x0003AF93 File Offset: 0x00039193
		public DamageFioraW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0003AFA9 File Offset: 0x000391A9
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageFioraW.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400067C RID: 1660
		private static readonly double[] damages = new double[]
		{
			110.0,
			150.0,
			190.0,
			230.0,
			270.0
		};
	}
}
