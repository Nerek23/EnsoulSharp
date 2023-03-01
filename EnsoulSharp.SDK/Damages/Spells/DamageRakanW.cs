using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000273 RID: 627
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rakan", SpellSlot.W, 0)]
	public class DamageRakanW : DamageSpell
	{
		// Token: 0x06000D72 RID: 3442 RVA: 0x0003FD63 File Offset: 0x0003DF63
		public DamageRakanW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x0003FD79 File Offset: 0x0003DF79
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRakanW.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400077B RID: 1915
		private static readonly double[] damages = new double[]
		{
			70.0,
			125.0,
			180.0,
			235.0,
			290.0
		};
	}
}
