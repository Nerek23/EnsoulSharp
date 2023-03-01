using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000202 RID: 514
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Leblanc", SpellSlot.W, 0)]
	public class DamageLeblancW : DamageSpell
	{
		// Token: 0x06000C21 RID: 3105 RVA: 0x0003D9F6 File Offset: 0x0003BBF6
		public DamageLeblancW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0003DA0C File Offset: 0x0003BC0C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageLeblancW.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000706 RID: 1798
		private static readonly double[] damages = new double[]
		{
			75.0,
			115.0,
			155.0,
			195.0,
			235.0
		};
	}
}
