using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000197 RID: 407
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Gnar", SpellSlot.W, 1)]
	public class DamageGnarW1 : DamageSpell
	{
		// Token: 0x06000ADD RID: 2781 RVA: 0x0003B6B4 File Offset: 0x000398B4
		public DamageGnarW1()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0003B6D1 File Offset: 0x000398D1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageGnarW1.damages[level] + 1.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000696 RID: 1686
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
