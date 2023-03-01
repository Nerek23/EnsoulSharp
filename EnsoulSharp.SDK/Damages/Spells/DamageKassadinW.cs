using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D9 RID: 473
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kassadin", SpellSlot.W, 0)]
	public class DamageKassadinW : DamageSpell
	{
		// Token: 0x06000BA8 RID: 2984 RVA: 0x0003CC69 File Offset: 0x0003AE69
		public DamageKassadinW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BA9 RID: 2985 RVA: 0x0003CC7F File Offset: 0x0003AE7F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKassadinW.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x040006DD RID: 1757
		private static readonly double[] damages = new double[]
		{
			70.0,
			95.0,
			120.0,
			145.0,
			170.0
		};
	}
}
