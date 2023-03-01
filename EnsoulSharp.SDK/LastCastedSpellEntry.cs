using System;

namespace EnsoulSharp.SDK
{
	// Token: 0x02000052 RID: 82
	public class LastCastedSpellEntry
	{
		// Token: 0x06000348 RID: 840 RVA: 0x00018DA0 File Offset: 0x00016FA0
		internal LastCastedSpellEntry()
		{
			this.Name = string.Empty;
			this.Target = null;
			this.StartTime = 0f;
			this.EndTime = 0f;
			this.SpellData = null;
			this.IsValid = false;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00018DE0 File Offset: 0x00016FE0
		internal LastCastedSpellEntry(AIBaseClientProcessSpellCastEventArgs args)
		{
			this.Name = args.SData.Name;
			this.Target = (args.Target as AIBaseClient);
			this.StartTime = (float)Variables.GameTimeTickCount;
			this.EndTime = (float)Variables.GameTimeTickCount + args.TotalTime * 1000f;
			this.SpellData = args.SData;
			this.IsValid = true;
		}

		// Token: 0x040001E4 RID: 484
		public float EndTime;

		// Token: 0x040001E5 RID: 485
		public bool IsValid;

		// Token: 0x040001E6 RID: 486
		public string Name;

		// Token: 0x040001E7 RID: 487
		public SpellData SpellData;

		// Token: 0x040001E8 RID: 488
		public float StartTime;

		// Token: 0x040001E9 RID: 489
		public AIBaseClient Target;
	}
}
