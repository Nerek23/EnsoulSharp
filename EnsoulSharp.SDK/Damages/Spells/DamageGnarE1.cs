using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000192 RID: 402
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.E, 1)]
	public class DamageGnarE1 : DamageSpell
	{
		// Token: 0x06000ACE RID: 2766 RVA: 0x0003B4E6 File Offset: 0x000396E6
		public DamageGnarE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000ACF RID: 2767 RVA: 0x0003B503 File Offset: 0x00039703
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarE1.damages[level] + (double)source.MaxHealth * 0.06;
		}

		// Token: 0x04000690 RID: 1680
		private static readonly double[] damages = new double[]
		{
			80.0,
			115.0,
			150.0,
			185.0,
			220.0
		};
	}
}
