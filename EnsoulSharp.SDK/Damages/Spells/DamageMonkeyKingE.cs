using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000234 RID: 564
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MonkeyKing", SpellSlot.E, 0)]
	public class DamageMonkeyKingE : DamageSpell
	{
		// Token: 0x06000CB6 RID: 3254 RVA: 0x0003E987 File Offset: 0x0003CB87
		public DamageMonkeyKingE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x0003E99D File Offset: 0x0003CB9D
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMonkeyKingE.damages[level] + (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000739 RID: 1849
		private static readonly double[] damages = new double[]
		{
			80.0,
			110.0,
			140.0,
			170.0,
			200.0
		};
	}
}
