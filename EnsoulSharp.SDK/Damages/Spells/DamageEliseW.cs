using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000170 RID: 368
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Elise", SpellSlot.W, 0)]
	public class DamageEliseW : DamageSpell
	{
		// Token: 0x06000A67 RID: 2663 RVA: 0x0003A9BE File Offset: 0x00038BBE
		public DamageEliseW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0003A9D4 File Offset: 0x00038BD4
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageEliseW.damages[level] + 0.95 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000667 RID: 1639
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
