using System;
using System.ComponentModel.Composition;

namespace EnsoulSharp.SDK.Damages.Spells
{
	// Token: 0x02000274 RID: 628
	[Export(typeof(IDamageSpell))]
	[ExportDamageMetadata("Rakan", SpellSlot.Q, 0)]
	public class DamageRakanQ : DamageSpell
	{
		// Token: 0x06000D75 RID: 3445 RVA: 0x0003FDAC File Offset: 0x0003DFAC
		public DamageRakanQ()
		{
			base.Slot = SpellSlot.Q;
			base.DamageType = DamageType.Magical;
		}

		// Token: 0x06000D76 RID: 3446 RVA: 0x0003FDC2 File Offset: 0x0003DFC2
		protected override double GetDamage(AIHeroClient source, AIBaseClient target, int level)
		{
			return DamageRakanQ.damages[level] + 0.7 * (double)source.TotalMagicalDamage;
		}

		// Token: 0x0400077C RID: 1916
		private static readonly double[] damages = new double[]
		{
			70.0,
			115.0,
			160.0,
			205.0,
			250.0
		};
	}
}
