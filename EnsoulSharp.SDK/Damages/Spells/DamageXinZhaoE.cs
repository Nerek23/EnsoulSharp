using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000330 RID: 816
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("XinZhao", SpellSlot.E, 0)]
	public class DamageXinZhaoE : DamageSpell
	{
		// Token: 0x06000FA9 RID: 4009 RVA: 0x00043CD1 File Offset: 0x00041ED1
		public DamageXinZhaoE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x00043CE7 File Offset: 0x00041EE7
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageXinZhaoE.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000852 RID: 2130
		private static readonly double[] damages = new double[]
		{
			50.0,
			75.0,
			100.0,
			125.0,
			150.0
		};
	}
}
