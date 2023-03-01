using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000235 RID: 565
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("MonkeyKing", SpellSlot.Q, 0)]
	public class DamageMonkeyKingQ : DamageSpell
	{
		// Token: 0x06000CB9 RID: 3257 RVA: 0x0003E9C6 File Offset: 0x0003CBC6
		public DamageMonkeyKingQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x0003E9DC File Offset: 0x0003CBDC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageMonkeyKingQ.damages[level] + 0.45 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x0400073A RID: 1850
		private static readonly double[] damages = new double[]
		{
			20.0,
			45.0,
			70.0,
			95.0,
			120.0
		};
	}
}
