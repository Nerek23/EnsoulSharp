using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000D0 RID: 208
	public class AdoNetAppender : BufferingAppenderSkeleton
	{
		// Token: 0x060005DB RID: 1499 RVA: 0x00012DE9 File Offset: 0x00011DE9
		public AdoNetAppender()
		{
			this.ConnectionType = "System.Data.OleDb.OleDbConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
			this.UseTransactions = true;
			this.CommandType = CommandType.Text;
			this.m_parameters = new ArrayList();
			this.ReconnectOnError = false;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060005DC RID: 1500 RVA: 0x00012E1C File Offset: 0x00011E1C
		// (set) Token: 0x060005DD RID: 1501 RVA: 0x00012E24 File Offset: 0x00011E24
		public string ConnectionString
		{
			get
			{
				return this.m_connectionString;
			}
			set
			{
				this.m_connectionString = value;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060005DE RID: 1502 RVA: 0x00012E2D File Offset: 0x00011E2D
		// (set) Token: 0x060005DF RID: 1503 RVA: 0x00012E35 File Offset: 0x00011E35
		public string AppSettingsKey
		{
			get
			{
				return this.m_appSettingsKey;
			}
			set
			{
				this.m_appSettingsKey = value;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060005E0 RID: 1504 RVA: 0x00012E3E File Offset: 0x00011E3E
		// (set) Token: 0x060005E1 RID: 1505 RVA: 0x00012E46 File Offset: 0x00011E46
		public string ConnectionStringName
		{
			get
			{
				return this.m_connectionStringName;
			}
			set
			{
				this.m_connectionStringName = value;
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00012E4F File Offset: 0x00011E4F
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x00012E57 File Offset: 0x00011E57
		public string ConnectionType
		{
			get
			{
				return this.m_connectionType;
			}
			set
			{
				this.m_connectionType = value;
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00012E60 File Offset: 0x00011E60
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00012E68 File Offset: 0x00011E68
		public string CommandText
		{
			get
			{
				return this.m_commandText;
			}
			set
			{
				this.m_commandText = value;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00012E71 File Offset: 0x00011E71
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00012E79 File Offset: 0x00011E79
		public CommandType CommandType
		{
			get
			{
				return this.m_commandType;
			}
			set
			{
				this.m_commandType = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00012E82 File Offset: 0x00011E82
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00012E8A File Offset: 0x00011E8A
		public bool UseTransactions
		{
			get
			{
				return this.m_useTransactions;
			}
			set
			{
				this.m_useTransactions = value;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00012E93 File Offset: 0x00011E93
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x00012E9B File Offset: 0x00011E9B
		public SecurityContext SecurityContext
		{
			get
			{
				return this.m_securityContext;
			}
			set
			{
				this.m_securityContext = value;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00012EA4 File Offset: 0x00011EA4
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x00012EAC File Offset: 0x00011EAC
		public bool ReconnectOnError
		{
			get
			{
				return this.m_reconnectOnError;
			}
			set
			{
				this.m_reconnectOnError = value;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00012EB5 File Offset: 0x00011EB5
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x00012EBD File Offset: 0x00011EBD
		protected IDbConnection Connection
		{
			get
			{
				return this.m_dbConnection;
			}
			set
			{
				this.m_dbConnection = value;
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00012EC6 File Offset: 0x00011EC6
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.SecurityContext == null)
			{
				this.SecurityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}
			this.InitializeDatabaseConnection();
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00012EED File Offset: 0x00011EED
		protected override void OnClose()
		{
			base.OnClose();
			this.DiposeConnection();
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00012EFC File Offset: 0x00011EFC
		protected override void SendBuffer(LoggingEvent[] events)
		{
			if (this.ReconnectOnError && (this.Connection == null || this.Connection.State != ConnectionState.Open))
			{
				LogLog.Debug(AdoNetAppender.declaringType, "Attempting to reconnect to database. Current Connection State: " + ((this.Connection == null) ? SystemInfo.NullText : this.Connection.State.ToString()));
				this.InitializeDatabaseConnection();
			}
			if (this.Connection != null && this.Connection.State == ConnectionState.Open)
			{
				if (this.UseTransactions)
				{
					using (IDbTransaction dbTransaction = this.Connection.BeginTransaction())
					{
						try
						{
							this.SendBuffer(dbTransaction, events);
							dbTransaction.Commit();
							return;
						}
						catch (Exception e)
						{
							try
							{
								dbTransaction.Rollback();
							}
							catch (Exception)
							{
							}
							this.ErrorHandler.Error("Exception while writing to database", e);
							return;
						}
					}
				}
				this.SendBuffer(null, events);
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x00012FFC File Offset: 0x00011FFC
		public void AddParameter(AdoNetAppenderParameter parameter)
		{
			this.m_parameters.Add(parameter);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001300C File Offset: 0x0001200C
		protected virtual void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
		{
			if (this.CommandText != null && this.CommandText.Trim() != "")
			{
				using (IDbCommand dbCommand = this.Connection.CreateCommand())
				{
					dbCommand.CommandText = this.CommandText;
					dbCommand.CommandType = this.CommandType;
					if (dbTran != null)
					{
						dbCommand.Transaction = dbTran;
					}
					dbCommand.Prepare();
					foreach (LoggingEvent loggingEvent in events)
					{
						dbCommand.Parameters.Clear();
						foreach (object obj in this.m_parameters)
						{
							AdoNetAppenderParameter adoNetAppenderParameter = (AdoNetAppenderParameter)obj;
							adoNetAppenderParameter.Prepare(dbCommand);
							adoNetAppenderParameter.FormatValue(dbCommand, loggingEvent);
						}
						dbCommand.ExecuteNonQuery();
					}
					return;
				}
			}
			using (IDbCommand dbCommand2 = this.Connection.CreateCommand())
			{
				if (dbTran != null)
				{
					dbCommand2.Transaction = dbTran;
				}
				foreach (LoggingEvent logEvent in events)
				{
					string logStatement = this.GetLogStatement(logEvent);
					LogLog.Debug(AdoNetAppender.declaringType, "LogStatement [" + logStatement + "]");
					dbCommand2.CommandText = logStatement;
					dbCommand2.ExecuteNonQuery();
				}
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00013188 File Offset: 0x00012188
		protected virtual string GetLogStatement(LoggingEvent logEvent)
		{
			if (this.Layout == null)
			{
				this.ErrorHandler.Error("AdoNetAppender: No Layout specified.");
				return "";
			}
			string result;
			using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
			{
				this.Layout.Format(stringWriter, logEvent);
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x000131F0 File Offset: 0x000121F0
		protected virtual IDbConnection CreateConnection(Type connectionType, string connectionString)
		{
			IDbConnection dbConnection = (IDbConnection)Activator.CreateInstance(connectionType);
			dbConnection.ConnectionString = connectionString;
			return dbConnection;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00013204 File Offset: 0x00012204
		protected virtual string ResolveConnectionString(out string connectionStringContext)
		{
			if (this.ConnectionString != null && this.ConnectionString.Length > 0)
			{
				connectionStringContext = "ConnectionString";
				return this.ConnectionString;
			}
			if (!string.IsNullOrEmpty(this.ConnectionStringName))
			{
				ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[this.ConnectionStringName];
				if (connectionStringSettings != null)
				{
					connectionStringContext = "ConnectionStringName";
					return connectionStringSettings.ConnectionString;
				}
				throw new LogException("Unable to find [" + this.ConnectionStringName + "] ConfigurationManager.ConnectionStrings item");
			}
			else
			{
				if (this.AppSettingsKey == null || this.AppSettingsKey.Length <= 0)
				{
					connectionStringContext = "Unable to resolve connection string from ConnectionString, ConnectionStrings, or AppSettings.";
					return string.Empty;
				}
				connectionStringContext = "AppSettingsKey";
				string appSetting = SystemInfo.GetAppSetting(this.AppSettingsKey);
				if (appSetting == null || appSetting.Length == 0)
				{
					throw new LogException("Unable to find [" + this.AppSettingsKey + "] AppSettings key.");
				}
				return appSetting;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000132DC File Offset: 0x000122DC
		protected virtual Type ResolveConnectionType()
		{
			Type typeFromString;
			try
			{
				typeFromString = SystemInfo.GetTypeFromString(this.ConnectionType, true, false);
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error("Failed to load connection type [" + this.ConnectionType + "]", e);
				throw;
			}
			return typeFromString;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00013330 File Offset: 0x00012330
		private void InitializeDatabaseConnection()
		{
			string text = "Unable to determine connection string context.";
			string text2 = string.Empty;
			try
			{
				this.DiposeConnection();
				text2 = this.ResolveConnectionString(out text);
				this.Connection = this.CreateConnection(this.ResolveConnectionType(), text2);
				using (this.SecurityContext.Impersonate(this))
				{
					this.Connection.Open();
				}
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					"Could not open database connection [",
					text2,
					"]. Connection string context [",
					text,
					"]."
				}), e);
				this.Connection = null;
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x000133F0 File Offset: 0x000123F0
		private void DiposeConnection()
		{
			if (this.Connection != null)
			{
				try
				{
					this.Connection.Close();
				}
				catch (Exception exception)
				{
					LogLog.Warn(AdoNetAppender.declaringType, "Exception while disposing cached connection object", exception);
				}
				this.Connection = null;
			}
		}

		// Token: 0x040001AE RID: 430
		protected ArrayList m_parameters;

		// Token: 0x040001AF RID: 431
		private SecurityContext m_securityContext;

		// Token: 0x040001B0 RID: 432
		private IDbConnection m_dbConnection;

		// Token: 0x040001B1 RID: 433
		private string m_connectionString;

		// Token: 0x040001B2 RID: 434
		private string m_appSettingsKey;

		// Token: 0x040001B3 RID: 435
		private string m_connectionStringName;

		// Token: 0x040001B4 RID: 436
		private string m_connectionType;

		// Token: 0x040001B5 RID: 437
		private string m_commandText;

		// Token: 0x040001B6 RID: 438
		private CommandType m_commandType;

		// Token: 0x040001B7 RID: 439
		private bool m_useTransactions;

		// Token: 0x040001B8 RID: 440
		private bool m_reconnectOnError;

		// Token: 0x040001B9 RID: 441
		private static readonly Type declaringType = typeof(AdoNetAppender);
	}
}
