using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000313 RID: 787
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Viktor", SpellSlot.E, 1)]
	public class DamageViktorE1 : DamageSpell
	{
		// Token: 0x06000F52 RID: 3922 RVA: 0x000433C8 File Offset: 0x000415C8
		public DamageViktorE1()
		{
			base.Slot = SpellSlot.E;
			base.DamageType = DamageType.Magical;
			base.Stage = 1;
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x000433E5 File Offset: 0x000415E5
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageViktorE1.damages[level] + 0.8 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x04000833 RID: 2099
		private static readonly double[] damages = new double[]
		{
			20.0,
			50.0,
			80.0,
			100.0,
			140.0
		};
	}
}
