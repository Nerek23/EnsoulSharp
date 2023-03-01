using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000194 RID: 404
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.Q, 1)]
	public class DamageGnarQ1 : DamageSpell
	{
		// Token: 0x06000AD4 RID: 2772 RVA: 0x0003B57F File Offset: 0x0003977F
		public DamageGnarQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x0003B59C File Offset: 0x0003979C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarQ1.damages[level] + 1.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000692 RID: 1682
		private static readonly double[] damages = new double[]
		{
			25.0,
			70.0,
			115.0,
			160.0,
			205.0
		};
	}
}
