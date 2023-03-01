using System;
using System.Data;
using log4net.Core;
using log4net.Layout;

namespace log4net.Appender
{
	// Token: 0x020000D1 RID: 209
	public class AdoNetAppenderParameter
	{
		// Token: 0x060005FC RID: 1532 RVA: 0x0001344D File Offset: 0x0001244D
		public AdoNetAppenderParameter()
		{
			this.Precision = 0;
			this.Scale = 0;
			this.Size = 0;
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x00013471 File Offset: 0x00012471
		// (set) Token: 0x060005FE RID: 1534 RVA: 0x00013479 File Offset: 0x00012479
		public string ParameterName
		{
			get
			{
				return this.m_parameterName;
			}
			set
			{
				this.m_parameterName = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060005FF RID: 1535 RVA: 0x00013482 File Offset: 0x00012482
		// (set) Token: 0x06000600 RID: 1536 RVA: 0x0001348A File Offset: 0x0001248A
		public DbType DbType
		{
			get
			{
				return this.m_dbType;
			}
			set
			{
				this.m_dbType = value;
				this.m_inferType = false;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000601 RID: 1537 RVA: 0x0001349A File Offset: 0x0001249A
		// (set) Token: 0x06000602 RID: 1538 RVA: 0x000134A2 File Offset: 0x000124A2
		public byte Precision
		{
			get
			{
				return this.m_precision;
			}
			set
			{
				this.m_precision = value;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x000134AB File Offset: 0x000124AB
		// (set) Token: 0x06000604 RID: 1540 RVA: 0x000134B3 File Offset: 0x000124B3
		public byte Scale
		{
			get
			{
				return this.m_scale;
			}
			set
			{
				this.m_scale = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x000134BC File Offset: 0x000124BC
		// (set) Token: 0x06000606 RID: 1542 RVA: 0x000134C4 File Offset: 0x000124C4
		public int Size
		{
			get
			{
				return this.m_size;
			}
			set
			{
				this.m_size = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x000134CD File Offset: 0x000124CD
		// (set) Token: 0x06000608 RID: 1544 RVA: 0x000134D5 File Offset: 0x000124D5
		public IRawLayout Layout
		{
			get
			{
				return this.m_layout;
			}
			set
			{
				this.m_layout = value;
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000134E0 File Offset: 0x000124E0
		public virtual void Prepare(IDbCommand command)
		{
			IDbDataParameter dbDataParameter = command.CreateParameter();
			dbDataParameter.ParameterName = this.ParameterName;
			if (!this.m_inferType)
			{
				dbDataParameter.DbType = this.DbType;
			}
			if (this.Precision != 0)
			{
				dbDataParameter.Precision = this.Precision;
			}
			if (this.Scale != 0)
			{
				dbDataParameter.Scale = this.Scale;
			}
			if (this.Size != 0)
			{
				dbDataParameter.Size = this.Size;
			}
			command.Parameters.Add(dbDataParameter);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00013560 File Offset: 0x00012560
		public virtual void FormatValue(IDbCommand command, LoggingEvent loggingEvent)
		{
			IDataParameter dataParameter = (IDbDataParameter)command.Parameters[this.ParameterName];
			object obj = this.Layout.Format(loggingEvent);
			if (obj == null)
			{
				obj = DBNull.Value;
			}
			dataParameter.Value = obj;
		}

		// Token: 0x040001BA RID: 442
		private string m_parameterName;

		// Token: 0x040001BB RID: 443
		private DbType m_dbType;

		// Token: 0x040001BC RID: 444
		private bool m_inferType = true;

		// Token: 0x040001BD RID: 445
		private byte m_precision;

		// Token: 0x040001BE RID: 446
		private byte m_scale;

		// Token: 0x040001BF RID: 447
		private int m_size;

		// Token: 0x040001C0 RID: 448
		private IRawLayout m_layout;
	}
}
