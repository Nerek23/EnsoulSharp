using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200015F RID: 351
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Darius", SpellSlot.R, 0)]
	public class DamageDariusR : DamageSpell
	{
		// Token: 0x06000A35 RID: 2613 RVA: 0x0003A395 File Offset: 0x00038595
		public DamageDariusR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0003A3AC File Offset: 0x000385AC
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageDariusR.damages[level] + 0.75 * (double)source.GetBonusAaDamage();
			if (target.HasBuff("DariusHemo"))
			{
				num += num * (double)((target.GetBuffCount("DariusHemo") > 0) ? target.GetBuffCount("DariusHemo") : 0) * 0.2;
			}
			return num;
		}

		// Token: 0x04000653 RID: 1619
		private static readonly double[] damages = new double[]
		{
			125.0,
			250.0,
			375.0
		};
	}
}
