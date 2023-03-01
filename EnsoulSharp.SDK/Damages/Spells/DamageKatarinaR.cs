using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001DC RID: 476
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Katarina", SpellSlot.R, 0)]
	public class DamageKatarinaR : DamageSpell
	{
		// Token: 0x06000BB1 RID: 2993 RVA: 0x0003CD56 File Offset: 0x0003AF56
		public DamageKatarinaR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x0003CD6C File Offset: 0x0003AF6C
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageKatarinaR.damages[level] + 2.85 * (double)source.TotalMagicalDamage + (2.25 + 1.485 * (double)(1f / source.AttackDelay)) * (double)source.GetBonusAaDamage();
		}

		// Token: 0x040006E0 RID: 1760
		private static readonly double[] damages = new double[]
		{
			375.0,
			562.5,
			750.0
		};
	}
}
