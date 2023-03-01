using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000260 RID: 608
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Qiyana", SpellSlot.Q, 1)]
	public class DamageQiyanaQ1 : DamageSpell
	{
		// Token: 0x06000D3A RID: 3386 RVA: 0x0003F742 File Offset: 0x0003D942
		public DamageQiyanaQ1()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
			base.Stage = 1;
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0003F75F File Offset: 0x0003D95F
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageQiyanaQ1.damages[level] + 1.44 * (double)source.GetBonusPhysicalDamage();
		}

		// Token: 0x04000767 RID: 1895
		private static readonly double[] damages = new double[]
		{
			128.0,
			160.0,
			192.0,
			224.0,
			256.0
		};
	}
}
