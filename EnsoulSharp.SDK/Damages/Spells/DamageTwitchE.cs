using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020002F2 RID: 754
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Twitch", SpellSlot.E, 0)]
	public class DamageTwitchE : DamageSpell
	{
		// Token: 0x06000EEF RID: 3823 RVA: 0x00042861 File Offset: 0x00040A61
		public DamageTwitchE()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.True;
		}

		// Token: 0x06000EF0 RID: 3824 RVA: 0x00042878 File Offset: 0x00040A78
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageTwitchE.buffdamages[level] + 0.35 * (double)source.GetBonusPhysicalDamage();
			int buffCount = target.GetBuffCount("twitchdeadlyvenom");
			double num2 = source.CalculatePhysicalDamage(target, DamageTwitchE.damages[level] + num * (double)buffCount);
			double num3 = source.CalculateMagicDamage(target, 0.3 * (double)source.TotalMagicalDamage * (double)buffCount);
			return num2 + num3;
		}

		// Token: 0x0400080C RID: 2060
		private static readonly double[] damages = new double[]
		{
			20.0,
			30.0,
			40.0,
			50.0,
			60.0
		};

		// Token: 0x0400080D RID: 2061
		private static readonly double[] buffdamages = new double[]
		{
			15.0,
			20.0,
			25.0,
			30.0,
			35.0
		};
	}
}
