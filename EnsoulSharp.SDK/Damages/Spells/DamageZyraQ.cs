using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200034C RID: 844
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zyra", SpellSlot.Q, 0)]
	public class DamageZyraQ : DamageSpell
	{
		// Token: 0x06000FFC RID: 4092 RVA: 0x000445BC File Offset: 0x000427BC
		public DamageZyraQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FFD RID: 4093 RVA: 0x000445D2 File Offset: 0x000427D2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZyraQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000870 RID: 2160
		private static readonly double[] damages = new double[]
		{
			60.0,
			95.0,
			130.0,
			165.0,
			200.0
		};
	}
}
