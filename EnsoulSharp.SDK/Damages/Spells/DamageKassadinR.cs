using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x020001D8 RID: 472
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Kassadin", SpellSlot.R, 0)]
	public class DamageKassadinR : DamageSpell
	{
		// Token: 0x06000BA5 RID: 2981 RVA: 0x0003CBB1 File Offset: 0x0003ADB1
		public DamageKassadinR()
		{
			base.Slot = SpellSlot.R;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000BA6 RID: 2982 RVA: 0x0003CBC8 File Offset: 0x0003ADC8
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			double num = DamageKassadinR.damages[level] + 0.4 * (double)source.TotalMagicalDamage + 0.02 * (double)source.MaxMana;
			double num2 = DamageKassadinR.buffdamages[level] + 0.1 * (double)source.TotalMagicalDamage + 0.02 * (double)source.MaxMana;
			return num + (double)source.GetBuffCount("RiftWalk") * num2;
		}

		// Token: 0x040006DB RID: 1755
		private static readonly double[] damages = new double[]
		{
			70.0,
			90.0,
			110.0
		};

		// Token: 0x040006DC RID: 1756
		private static readonly double[] buffdamages = new double[]
		{
			35.0,
			45.0,
			55.0
		};
	}
}
