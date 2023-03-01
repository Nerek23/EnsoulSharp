using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000288 RID: 648
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rengar", SpellSlot.Q, 1)]
	public class DamageRengarQ1 : DamageSpell
	{
		// Token: 0x06000DB1 RID: 3505 RVA: 0x0004040E File Offset: 0x0003E60E
		public DamageRengarQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x0004042B File Offset: 0x0003E62B
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRengarQ1.damages[Math.Min(17, source.Level - 1)] + 0.4 * (double)source.TotalAttackDamage;
		}

		// Token: 0x04000791 RID: 1937
		private static readonly double[] damages = new double[]
		{
			30.0,
			45.0,
			60.0,
			75.0,
			90.0,
			105.0,
			120.0,
			135.0,
			150.0,
			160.0,
			170.0,
			180.0,
			190.0,
			200.0,
			210.0,
			220.0,
			230.0,
			240.0
		};
	}
}
