using System;
using System.IO;
using System.Text;

namespace log4net.Util
{
	// Token: 0x0200002C RID: 44
	public class ReusableStringWriter : StringWriter
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x00005EFD File Offset: 0x00004EFD
		public ReusableStringWriter(IFormatProvider formatProvider) : base(formatProvider)
		{
		}

		// Token: 0x060001CA RID: 458 RVA: 0x00005F06 File Offset: 0x00004F06
		protected override void Dispose(bool disposing)
		{
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00005F08 File Offset: 0x00004F08
		public void Reset(int maxCapacity, int defaultSize)
		{
			StringBuilder stringBuilder = this.GetStringBuilder();
			stringBuilder.Length = 0;
			if (stringBuilder.Capacity > maxCapacity)
			{
				stringBuilder.Capacity = defaultSize;
			}
		}
	}
}
