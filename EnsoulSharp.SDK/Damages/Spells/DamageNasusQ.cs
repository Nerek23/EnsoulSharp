using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000242 RID: 578
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Nasus", SpellSlot.Q, 0)]
	public class DamageNasusQ : DamageSpell
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x0003ED94 File Offset: 0x0003CF94
		public DamageNasusQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Physical;
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0003EDAA File Offset: 0x0003CFAA
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return (double)source.GetBuffCount("nasusqstacks") + DamageNasusQ.damages[level] + (double)(1f * source.TotalAttackDamage);
		}

		// Token: 0x04000747 RID: 1863
		private static readonly double[] damages = new double[]
		{
			30.0,
			50.0,
			70.0,
			90.0,
			110.0
		};
	}
}
