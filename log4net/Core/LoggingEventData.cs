using System;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000B8 RID: 184
	public struct LoggingEventData
	{
		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00010268 File Offset: 0x0000F268
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x000102B3 File Offset: 0x0000F2B3
		public DateTime TimeStampUtc
		{
			get
			{
				if (this.TimeStamp != default(DateTime) && this._timeStampUtc == default(DateTime))
				{
					return this.TimeStamp.ToUniversalTime();
				}
				return this._timeStampUtc;
			}
			set
			{
				this._timeStampUtc = value;
				this.TimeStamp = this._timeStampUtc.ToLocalTime();
			}
		}

		// Token: 0x04000160 RID: 352
		public string LoggerName;

		// Token: 0x04000161 RID: 353
		public Level Level;

		// Token: 0x04000162 RID: 354
		public string Message;

		// Token: 0x04000163 RID: 355
		public string ThreadName;

		// Token: 0x04000164 RID: 356
		[Obsolete("Prefer using TimeStampUtc, since local time can be ambiguous in time zones with daylight savings time.")]
		public DateTime TimeStamp;

		// Token: 0x04000165 RID: 357
		private DateTime _timeStampUtc;

		// Token: 0x04000166 RID: 358
		public LocationInfo LocationInfo;

		// Token: 0x04000167 RID: 359
		public string UserName;

		// Token: 0x04000168 RID: 360
		public string Identity;

		// Token: 0x04000169 RID: 361
		public string ExceptionString;

		// Token: 0x0400016A RID: 362
		public string Domain;

		// Token: 0x0400016B RID: 363
		public PropertiesDictionary Properties;
	}
}
