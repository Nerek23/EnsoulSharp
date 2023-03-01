using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200033D RID: 829
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Zoe", SpellSlot.Q, 0)]
	public class DamageZoeQ : DamageSpell
	{
		// Token: 0x06000FD0 RID: 4048 RVA: 0x0004412C File Offset: 0x0004232C
		public DamageZoeQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x00044142 File Offset: 0x00042342
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageZoeQ.damages[level] + DamageZoeQ.extradamages[Math.Min(17, source.Level - 1)] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000860 RID: 2144
		private static readonly double[] damages = new double[]
		{
			50.0,
			80.0,
			110.0,
			140.0,
			170.0
		};

		// Token: 0x04000861 RID: 2145
		private static readonly double[] extradamages = new double[]
		{
			7.0,
			8.0,
			10.0,
			12.0,
			14.0,
			16.0,
			18.0,
			20.0,
			22.0,
			24.0,
			26.0,
			29.0,
			32.0,
			35.0,
			38.0,
			42.0,
			46.0,
			50.0
		};
	}
}
