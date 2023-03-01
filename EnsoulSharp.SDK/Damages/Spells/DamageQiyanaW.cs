using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000262 RID: 610
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Qiyana", SpellSlot.W, 0)]
	public class DamageQiyanaW : DamageSpell
	{
		// Token: 0x06000D40 RID: 3392 RVA: 0x0003F801 File Offset: 0x0003DA01
		public DamageQiyanaW()
		{
			base.Slot = SpellSlot.W;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0003F817 File Offset: 0x0003DA17
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQiyanaW.damages[level] + 0.2 * (double)source.GetBonusPhysicalDamage() + 0.45 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400076A RID: 1898
		private static readonly double[] damages = new double[]
		{
			8.0,
			22.0,
			36.0,
			50.0,
			64.0
		};
	}
}
