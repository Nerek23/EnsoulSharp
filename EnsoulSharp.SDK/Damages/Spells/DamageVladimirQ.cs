using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200031D RID: 797
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Vladimir", SpellSlot.Q, 0)]
	public class DamageVladimirQ : DamageSpell
	{
		// Token: 0x06000F70 RID: 3952 RVA: 0x000436ED File Offset: 0x000418ED
		public DamageVladimirQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x00043703 File Offset: 0x00041903
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVladimirQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400083D RID: 2109
		private static readonly double[] damages = new double[]
		{
			80.0,
			100.0,
			120.0,
			140.0,
			160.0
		};
	}
}
