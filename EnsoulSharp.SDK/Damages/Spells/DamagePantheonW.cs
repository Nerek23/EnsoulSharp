using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000267 RID: 615
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Pantheon", SpellSlot.W, 0)]
	public class DamagePantheonW : DamageSpell
	{
		// Token: 0x06000D4F RID: 3407 RVA: 0x0003F992 File Offset: 0x0003DB92
		public DamagePantheonW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x0003F9A8 File Offset: 0x0003DBA8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamagePantheonW.damages[level] + (double)(1f * source.TotalMagicalDamage);
		}

		// Token: 0x0400076F RID: 1903
		private static readonly double[] damages = new double[]
		{
			60.0,
			100.0,
			140.0,
			180.0,
			220.0
		};
	}
}
