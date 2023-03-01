using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using log4net.Repository;
using log4net.Util;

namespace log4net.Core
{
	// Token: 0x020000BA RID: 186
	[Serializable]
	public class LoggingEvent : ISerializable
	{
		// Token: 0x06000510 RID: 1296 RVA: 0x000102D0 File Offset: 0x0000F2D0
		public LoggingEvent(Type callerStackBoundaryDeclaringType, ILoggerRepository repository, string loggerName, Level level, object message, Exception exception)
		{
			this.m_callerStackBoundaryDeclaringType = callerStackBoundaryDeclaringType;
			this.m_message = message;
			this.m_repository = repository;
			this.m_thrownException = exception;
			this.m_data.LoggerName = loggerName;
			this.m_data.Level = level;
			this.m_data.TimeStampUtc = DateTime.UtcNow;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00010331 File Offset: 0x0000F331
		public LoggingEvent(Type callerStackBoundaryDeclaringType, ILoggerRepository repository, LoggingEventData data, FixFlags fixedData)
		{
			this.m_callerStackBoundaryDeclaringType = callerStackBoundaryDeclaringType;
			this.m_repository = repository;
			this.m_data = data;
			this.m_fixFlags = fixedData;
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001035D File Offset: 0x0000F35D
		public LoggingEvent(Type callerStackBoundaryDeclaringType, ILoggerRepository repository, LoggingEventData data) : this(callerStackBoundaryDeclaringType, repository, data, FixFlags.All)
		{
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001036D File Offset: 0x0000F36D
		public LoggingEvent(LoggingEventData data) : this(null, null, data)
		{
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x00010378 File Offset: 0x0000F378
		protected LoggingEvent(SerializationInfo info, StreamingContext context)
		{
			this.m_data.LoggerName = info.GetString("LoggerName");
			this.m_data.Level = (Level)info.GetValue("Level", typeof(Level));
			this.m_data.Message = info.GetString("Message");
			this.m_data.ThreadName = info.GetString("ThreadName");
			this.m_data.TimeStampUtc = info.GetDateTime("TimeStamp").ToUniversalTime();
			this.m_data.LocationInfo = (LocationInfo)info.GetValue("LocationInfo", typeof(LocationInfo));
			this.m_data.UserName = info.GetString("UserName");
			this.m_data.ExceptionString = info.GetString("ExceptionString");
			this.m_data.Properties = (PropertiesDictionary)info.GetValue("Properties", typeof(PropertiesDictionary));
			this.m_data.Domain = info.GetString("Domain");
			this.m_data.Identity = info.GetString("Identity");
			this.m_fixFlags = FixFlags.All;
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x000104C4 File Offset: 0x0000F4C4
		public static DateTime StartTime
		{
			get
			{
				return SystemInfo.ProcessStartTimeUtc.ToLocalTime();
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x000104DE File Offset: 0x0000F4DE
		public static DateTime StartTimeUtc
		{
			get
			{
				return SystemInfo.ProcessStartTimeUtc;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x000104E5 File Offset: 0x0000F4E5
		public Level Level
		{
			get
			{
				return this.m_data.Level;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x000104F4 File Offset: 0x0000F4F4
		public DateTime TimeStamp
		{
			get
			{
				return this.m_data.TimeStampUtc.ToLocalTime();
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x00010514 File Offset: 0x0000F514
		public DateTime TimeStampUtc
		{
			get
			{
				return this.m_data.TimeStampUtc;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00010521 File Offset: 0x0000F521
		public string LoggerName
		{
			get
			{
				return this.m_data.LoggerName;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001052E File Offset: 0x0000F52E
		public LocationInfo LocationInformation
		{
			get
			{
				if (this.m_data.LocationInfo == null && this.m_cacheUpdatable)
				{
					this.m_data.LocationInfo = new LocationInfo(this.m_callerStackBoundaryDeclaringType);
				}
				return this.m_data.LocationInfo;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00010566 File Offset: 0x0000F566
		public object MessageObject
		{
			get
			{
				return this.m_message;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0001056E File Offset: 0x0000F56E
		public Exception ExceptionObject
		{
			get
			{
				return this.m_thrownException;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00010576 File Offset: 0x0000F576
		public ILoggerRepository Repository
		{
			get
			{
				return this.m_repository;
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001057E File Offset: 0x0000F57E
		internal void EnsureRepository(ILoggerRepository repository)
		{
			if (repository != null)
			{
				this.m_repository = repository;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x0001058C File Offset: 0x0000F58C
		public string RenderedMessage
		{
			get
			{
				if (this.m_data.Message == null && this.m_cacheUpdatable)
				{
					if (this.m_message == null)
					{
						this.m_data.Message = "";
					}
					else if (this.m_message is string)
					{
						this.m_data.Message = (this.m_message as string);
					}
					else if (this.m_repository != null)
					{
						this.m_data.Message = this.m_repository.RendererMap.FindAndRender(this.m_message);
					}
					else
					{
						this.m_data.Message = this.m_message.ToString();
					}
				}
				return this.m_data.Message;
			}
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00010640 File Offset: 0x0000F640
		public void WriteRenderedMessage(TextWriter writer)
		{
			if (this.m_data.Message != null)
			{
				writer.Write(this.m_data.Message);
				return;
			}
			if (this.m_message != null)
			{
				if (this.m_message is string)
				{
					writer.Write(this.m_message as string);
					return;
				}
				if (this.m_repository != null)
				{
					this.m_repository.RendererMap.FindAndRender(this.m_message, writer);
					return;
				}
				writer.Write(this.m_message.ToString());
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x000106C4 File Offset: 0x0000F6C4
		public string ThreadName
		{
			get
			{
				if (this.m_data.ThreadName == null && this.m_cacheUpdatable)
				{
					this.m_data.ThreadName = Thread.CurrentThread.Name;
					if (this.m_data.ThreadName == null || this.m_data.ThreadName.Length == 0)
					{
						try
						{
							this.m_data.ThreadName = SystemInfo.CurrentThreadId.ToString(NumberFormatInfo.InvariantInfo);
						}
						catch (SecurityException)
						{
							LogLog.Debug(LoggingEvent.declaringType, "Security exception while trying to get current thread ID. Error Ignored. Empty thread name.");
							this.m_data.ThreadName = Thread.CurrentThread.GetHashCode().ToString(CultureInfo.InvariantCulture);
						}
					}
				}
				return this.m_data.ThreadName;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x00010790 File Offset: 0x0000F790
		public string UserName
		{
			get
			{
				ref string ptr = ref this.m_data.UserName;
				string result;
				if ((result = ptr) == null)
				{
					string text;
					ptr = (text = (LoggingEvent.TryGetCurrentUserName() ?? SystemInfo.NotAvailableText));
					result = text;
				}
				return result;
			}
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x000107C4 File Offset: 0x0000F7C4
		private static string TryGetCurrentUserName()
		{
			string result;
			try
			{
				WindowsIdentity current = WindowsIdentity.GetCurrent();
				result = (((current != null) ? current.Name : null) ?? "");
			}
			catch (PlatformNotSupportedException)
			{
				result = Environment.UserName;
			}
			catch (SecurityException)
			{
				LogLog.Debug(LoggingEvent.declaringType, "Security exception while trying to get current windows identity. Error Ignored.");
				result = Environment.UserName;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x00010840 File Offset: 0x0000F840
		public string Identity
		{
			get
			{
				if (this.m_data.Identity == null && this.m_cacheUpdatable)
				{
					try
					{
						if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.Name != null)
						{
							this.m_data.Identity = Thread.CurrentPrincipal.Identity.Name;
						}
						else
						{
							this.m_data.Identity = "";
						}
					}
					catch (ObjectDisposedException)
					{
						LogLog.Debug(LoggingEvent.declaringType, "Object disposed exception while trying to get current thread principal. Error Ignored. Empty identity name.");
						this.m_data.Identity = "";
					}
					catch (SecurityException)
					{
						LogLog.Debug(LoggingEvent.declaringType, "Security exception while trying to get current thread principal. Error Ignored. Empty identity name.");
						this.m_data.Identity = "";
					}
				}
				return this.m_data.Identity;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x00010928 File Offset: 0x0000F928
		public string Domain
		{
			get
			{
				if (this.m_data.Domain == null && this.m_cacheUpdatable)
				{
					this.m_data.Domain = SystemInfo.ApplicationFriendlyName;
				}
				return this.m_data.Domain;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0001095A File Offset: 0x0000F95A
		public PropertiesDictionary Properties
		{
			get
			{
				if (this.m_data.Properties != null)
				{
					return this.m_data.Properties;
				}
				if (this.m_eventProperties == null)
				{
					this.m_eventProperties = new PropertiesDictionary();
				}
				return this.m_eventProperties;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0001098E File Offset: 0x0000F98E
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x00010996 File Offset: 0x0000F996
		public FixFlags Fix
		{
			get
			{
				return this.m_fixFlags;
			}
			set
			{
				this.FixVolatileData(value);
			}
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x000109A0 File Offset: 0x0000F9A0
		[SecurityCritical]
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("LoggerName", this.m_data.LoggerName);
			info.AddValue("Level", this.m_data.Level);
			info.AddValue("Message", this.m_data.Message);
			info.AddValue("ThreadName", this.m_data.ThreadName);
			info.AddValue("TimeStamp", this.m_data.TimeStamp);
			info.AddValue("LocationInfo", this.m_data.LocationInfo);
			info.AddValue("UserName", this.m_data.UserName);
			info.AddValue("ExceptionString", this.m_data.ExceptionString);
			info.AddValue("Properties", this.m_data.Properties);
			info.AddValue("Domain", this.m_data.Domain);
			info.AddValue("Identity", this.m_data.Identity);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00010A9F File Offset: 0x0000FA9F
		public LoggingEventData GetLoggingEventData()
		{
			return this.GetLoggingEventData(FixFlags.Partial);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00010AAC File Offset: 0x0000FAAC
		public LoggingEventData GetLoggingEventData(FixFlags fixFlags)
		{
			this.Fix = fixFlags;
			return this.m_data;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00010ABB File Offset: 0x0000FABB
		[Obsolete("Use GetExceptionString instead")]
		public string GetExceptionStrRep()
		{
			return this.GetExceptionString();
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00010AC4 File Offset: 0x0000FAC4
		public string GetExceptionString()
		{
			if (this.m_data.ExceptionString == null && this.m_cacheUpdatable)
			{
				if (this.m_thrownException != null)
				{
					if (this.m_repository != null)
					{
						this.m_data.ExceptionString = this.m_repository.RendererMap.FindAndRender(this.m_thrownException);
					}
					else
					{
						this.m_data.ExceptionString = this.m_thrownException.ToString();
					}
				}
				else
				{
					this.m_data.ExceptionString = "";
				}
			}
			return this.m_data.ExceptionString;
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00010B4C File Offset: 0x0000FB4C
		[Obsolete("Use Fix property")]
		public void FixVolatileData()
		{
			this.Fix = FixFlags.All;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00010B59 File Offset: 0x0000FB59
		[Obsolete("Use Fix property")]
		public void FixVolatileData(bool fastButLoose)
		{
			if (fastButLoose)
			{
				this.Fix = FixFlags.Partial;
				return;
			}
			this.Fix = FixFlags.All;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00010B78 File Offset: 0x0000FB78
		protected void FixVolatileData(FixFlags flags)
		{
			this.m_cacheUpdatable = true;
			FixFlags fixFlags = (flags ^ this.m_fixFlags) & flags;
			if (fixFlags > FixFlags.None)
			{
				if ((fixFlags & FixFlags.Message) != FixFlags.None)
				{
					object obj = this.RenderedMessage;
					this.m_fixFlags |= FixFlags.Message;
				}
				if ((fixFlags & FixFlags.ThreadName) != FixFlags.None)
				{
					object obj = this.ThreadName;
					this.m_fixFlags |= FixFlags.ThreadName;
				}
				if ((fixFlags & FixFlags.LocationInfo) != FixFlags.None)
				{
					object obj = this.LocationInformation;
					this.m_fixFlags |= FixFlags.LocationInfo;
				}
				if ((fixFlags & FixFlags.UserName) != FixFlags.None)
				{
					object obj = this.UserName;
					this.m_fixFlags |= FixFlags.UserName;
				}
				if ((fixFlags & FixFlags.Domain) != FixFlags.None)
				{
					object obj = this.Domain;
					this.m_fixFlags |= FixFlags.Domain;
				}
				if ((fixFlags & FixFlags.Identity) != FixFlags.None)
				{
					object obj = this.Identity;
					this.m_fixFlags |= FixFlags.Identity;
				}
				if ((fixFlags & FixFlags.Exception) != FixFlags.None)
				{
					object obj = this.GetExceptionString();
					this.m_fixFlags |= FixFlags.Exception;
				}
				if ((fixFlags & FixFlags.Properties) != FixFlags.None)
				{
					this.CacheProperties();
					this.m_fixFlags |= FixFlags.Properties;
				}
			}
			this.m_cacheUpdatable = false;
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00010C98 File Offset: 0x0000FC98
		private void CreateCompositeProperties()
		{
			CompositeProperties compositeProperties = new CompositeProperties();
			if (this.m_eventProperties != null)
			{
				compositeProperties.Add(this.m_eventProperties);
			}
			PropertiesDictionary properties = LogicalThreadContext.Properties.GetProperties(false);
			if (properties != null)
			{
				compositeProperties.Add(properties);
			}
			PropertiesDictionary properties2 = ThreadContext.Properties.GetProperties(false);
			if (properties2 != null)
			{
				compositeProperties.Add(properties2);
			}
			PropertiesDictionary propertiesDictionary = new PropertiesDictionary();
			propertiesDictionary["log4net:UserName"] = this.UserName;
			propertiesDictionary["log4net:Identity"] = this.Identity;
			compositeProperties.Add(propertiesDictionary);
			compositeProperties.Add(GlobalContext.Properties.GetReadOnlyProperties());
			this.m_compositeProperties = compositeProperties;
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00010D34 File Offset: 0x0000FD34
		private void CacheProperties()
		{
			if (this.m_data.Properties == null && this.m_cacheUpdatable)
			{
				if (this.m_compositeProperties == null)
				{
					this.CreateCompositeProperties();
				}
				IEnumerable enumerable = this.m_compositeProperties.Flatten();
				PropertiesDictionary propertiesDictionary = new PropertiesDictionary();
				foreach (object obj in enumerable)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					string text = dictionaryEntry.Key as string;
					if (text != null)
					{
						object obj2 = dictionaryEntry.Value;
						IFixingRequired fixingRequired = obj2 as IFixingRequired;
						if (fixingRequired != null)
						{
							obj2 = fixingRequired.GetFixedObject();
						}
						if (obj2 != null)
						{
							propertiesDictionary[text] = obj2;
						}
					}
				}
				this.m_data.Properties = propertiesDictionary;
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00010E08 File Offset: 0x0000FE08
		public object LookupProperty(string key)
		{
			if (this.m_data.Properties != null)
			{
				return this.m_data.Properties[key];
			}
			if (this.m_compositeProperties == null)
			{
				this.CreateCompositeProperties();
			}
			return this.m_compositeProperties[key];
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00010E43 File Offset: 0x0000FE43
		public PropertiesDictionary GetProperties()
		{
			if (this.m_data.Properties != null)
			{
				return this.m_data.Properties;
			}
			if (this.m_compositeProperties == null)
			{
				this.CreateCompositeProperties();
			}
			return this.m_compositeProperties.Flatten();
		}

		// Token: 0x0400017A RID: 378
		private static readonly Type declaringType = typeof(LoggingEvent);

		// Token: 0x0400017B RID: 379
		private LoggingEventData m_data;

		// Token: 0x0400017C RID: 380
		private CompositeProperties m_compositeProperties;

		// Token: 0x0400017D RID: 381
		private PropertiesDictionary m_eventProperties;

		// Token: 0x0400017E RID: 382
		private readonly Type m_callerStackBoundaryDeclaringType;

		// Token: 0x0400017F RID: 383
		private readonly object m_message;

		// Token: 0x04000180 RID: 384
		private readonly Exception m_thrownException;

		// Token: 0x04000181 RID: 385
		private ILoggerRepository m_repository;

		// Token: 0x04000182 RID: 386
		private FixFlags m_fixFlags;

		// Token: 0x04000183 RID: 387
		private bool m_cacheUpdatable = true;

		// Token: 0x04000184 RID: 388
		public const string HostNameProperty = "log4net:HostName";

		// Token: 0x04000185 RID: 389
		public const string IdentityProperty = "log4net:Identity";

		// Token: 0x04000186 RID: 390
		public const string UserNameProperty = "log4net:UserName";
	}
}
