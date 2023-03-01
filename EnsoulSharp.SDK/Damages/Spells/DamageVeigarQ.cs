using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x0200030B RID: 779
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Veigar", SpellSlot.Q, 0)]
	public class DamageVeigarQ : DamageSpell
	{
		// Token: 0x06000F3A RID: 3898 RVA: 0x000430DB File Offset: 0x000412DB
		public DamageVeigarQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x000430F1 File Offset: 0x000412F1
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageVeigarQ.damages[level] + 0.6 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400082A RID: 2090
		private static readonly double[] damages = new double[]
		{
			80.0,
			120.0,
			160.0,
			200.0,
			240.0
		};
	}
}
