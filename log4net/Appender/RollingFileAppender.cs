using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Threading;
using log4net.Core;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000E8 RID: 232
	public class RollingFileAppender : FileAppender
	{
		// Token: 0x06000726 RID: 1830 RVA: 0x000165E8 File Offset: 0x000155E8
		~RollingFileAppender()
		{
			if (this.m_mutexForRolling != null)
			{
				this.m_mutexForRolling.Dispose();
				this.m_mutexForRolling = null;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000727 RID: 1831 RVA: 0x00016628 File Offset: 0x00015628
		// (set) Token: 0x06000728 RID: 1832 RVA: 0x00016630 File Offset: 0x00015630
		public RollingFileAppender.IDateTime DateTimeStrategy
		{
			get
			{
				return this.m_dateTime;
			}
			set
			{
				this.m_dateTime = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x00016639 File Offset: 0x00015639
		// (set) Token: 0x0600072A RID: 1834 RVA: 0x00016641 File Offset: 0x00015641
		public string DatePattern
		{
			get
			{
				return this.m_datePattern;
			}
			set
			{
				this.m_datePattern = value;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x0001664A File Offset: 0x0001564A
		// (set) Token: 0x0600072C RID: 1836 RVA: 0x00016652 File Offset: 0x00015652
		public int MaxSizeRollBackups
		{
			get
			{
				return this.m_maxSizeRollBackups;
			}
			set
			{
				this.m_maxSizeRollBackups = value;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x0001665B File Offset: 0x0001565B
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00016663 File Offset: 0x00015663
		public long MaxFileSize
		{
			get
			{
				return this.m_maxFileSize;
			}
			set
			{
				this.m_maxFileSize = value;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001666C File Offset: 0x0001566C
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x0001667E File Offset: 0x0001567E
		public string MaximumFileSize
		{
			get
			{
				return this.m_maxFileSize.ToString(NumberFormatInfo.InvariantInfo);
			}
			set
			{
				this.m_maxFileSize = OptionConverter.ToFileSize(value, this.m_maxFileSize + 1L);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x00016695 File Offset: 0x00015695
		// (set) Token: 0x06000732 RID: 1842 RVA: 0x0001669D File Offset: 0x0001569D
		public int CountDirection
		{
			get
			{
				return this.m_countDirection;
			}
			set
			{
				this.m_countDirection = value;
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x000166A6 File Offset: 0x000156A6
		// (set) Token: 0x06000734 RID: 1844 RVA: 0x000166B0 File Offset: 0x000156B0
		public RollingFileAppender.RollingMode RollingStyle
		{
			get
			{
				return this.m_rollingStyle;
			}
			set
			{
				this.m_rollingStyle = value;
				switch (this.m_rollingStyle)
				{
				case RollingFileAppender.RollingMode.Once:
					this.m_rollDate = false;
					this.m_rollSize = false;
					base.AppendToFile = false;
					return;
				case RollingFileAppender.RollingMode.Size:
					this.m_rollDate = false;
					this.m_rollSize = true;
					return;
				case RollingFileAppender.RollingMode.Date:
					this.m_rollDate = true;
					this.m_rollSize = false;
					return;
				case RollingFileAppender.RollingMode.Composite:
					this.m_rollDate = true;
					this.m_rollSize = true;
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x00016724 File Offset: 0x00015724
		// (set) Token: 0x06000736 RID: 1846 RVA: 0x0001672C File Offset: 0x0001572C
		public bool PreserveLogFileNameExtension
		{
			get
			{
				return this.m_preserveLogFileNameExtension;
			}
			set
			{
				this.m_preserveLogFileNameExtension = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x00016735 File Offset: 0x00015735
		// (set) Token: 0x06000738 RID: 1848 RVA: 0x0001673D File Offset: 0x0001573D
		public bool StaticLogFileName
		{
			get
			{
				return this.m_staticLogFileName;
			}
			set
			{
				this.m_staticLogFileName = value;
			}
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x00016746 File Offset: 0x00015746
		protected override void SetQWForFiles(TextWriter writer)
		{
			base.QuietWriter = new CountingQuietTextWriter(writer, this.ErrorHandler);
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0001675A File Offset: 0x0001575A
		protected override void Append(LoggingEvent loggingEvent)
		{
			this.AdjustFileBeforeAppend();
			base.Append(loggingEvent);
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x00016769 File Offset: 0x00015769
		protected override void Append(LoggingEvent[] loggingEvents)
		{
			this.AdjustFileBeforeAppend();
			base.Append(loggingEvents);
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00016778 File Offset: 0x00015778
		protected virtual void AdjustFileBeforeAppend()
		{
			try
			{
				if (this.m_mutexForRolling != null)
				{
					this.m_mutexForRolling.WaitOne();
				}
				if (this.m_rollDate)
				{
					DateTime now = this.m_dateTime.Now;
					if (now >= this.m_nextCheck)
					{
						this.m_now = now;
						this.m_nextCheck = this.NextCheckDate(this.m_now, this.m_rollPoint);
						this.RollOverTime(true);
					}
				}
				if (this.m_rollSize && this.File != null && ((CountingQuietTextWriter)base.QuietWriter).Count >= this.m_maxFileSize)
				{
					this.RollOverSize();
				}
			}
			finally
			{
				if (this.m_mutexForRolling != null)
				{
					this.m_mutexForRolling.ReleaseMutex();
				}
			}
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x00016838 File Offset: 0x00015838
		protected override void OpenFile(string fileName, bool append)
		{
			lock (this)
			{
				fileName = this.GetNextOutputFileName(fileName);
				long count = 0L;
				if (append)
				{
					using (base.SecurityContext.Impersonate(this))
					{
						if (System.IO.File.Exists(fileName))
						{
							count = new FileInfo(fileName).Length;
						}
						goto IL_7A;
					}
				}
				if (LogLog.IsErrorEnabled && this.m_maxSizeRollBackups != 0 && this.FileExists(fileName))
				{
					LogLog.Error(RollingFileAppender.declaringType, "RollingFileAppender: INTERNAL ERROR. Append is False but OutputFile [" + fileName + "] already exists.");
				}
				IL_7A:
				if (!this.m_staticLogFileName)
				{
					this.m_scheduledFilename = fileName;
				}
				base.OpenFile(fileName, append);
				((CountingQuietTextWriter)base.QuietWriter).Count = count;
			}
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x00016910 File Offset: 0x00015910
		protected string GetNextOutputFileName(string fileName)
		{
			if (!this.m_staticLogFileName)
			{
				fileName = fileName.Trim();
				if (this.m_rollDate)
				{
					fileName = this.CombinePath(fileName, this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo));
				}
				if (this.m_countDirection >= 0)
				{
					fileName = this.CombinePath(fileName, "." + this.m_curSizeRollBackups.ToString());
				}
			}
			return fileName;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001697C File Offset: 0x0001597C
		private void DetermineCurSizeRollBackups()
		{
			this.m_curSizeRollBackups = 0;
			string text = null;
			string baseFile = null;
			using (base.SecurityContext.Impersonate(this))
			{
				text = Path.GetFullPath(this.m_baseFileName);
				baseFile = Path.GetFileName(text);
			}
			ArrayList existingFiles = this.GetExistingFiles(text);
			this.InitializeRollBackups(baseFile, existingFiles);
			LogLog.Debug(RollingFileAppender.declaringType, "curSizeRollBackups starts at [" + this.m_curSizeRollBackups.ToString() + "]");
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00016A04 File Offset: 0x00015A04
		private string GetWildcardPatternForFile(string baseFileName)
		{
			if (this.m_preserveLogFileNameExtension)
			{
				return Path.GetFileNameWithoutExtension(baseFileName) + "*" + Path.GetExtension(baseFileName);
			}
			return baseFileName + "*";
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00016A30 File Offset: 0x00015A30
		private ArrayList GetExistingFiles(string baseFilePath)
		{
			ArrayList arrayList = new ArrayList();
			string text = null;
			using (base.SecurityContext.Impersonate(this))
			{
				string fullPath = Path.GetFullPath(baseFilePath);
				text = Path.GetDirectoryName(fullPath);
				if (Directory.Exists(text))
				{
					string fileName = Path.GetFileName(fullPath);
					string[] files = Directory.GetFiles(text, this.GetWildcardPatternForFile(fileName));
					if (files != null)
					{
						for (int i = 0; i < files.Length; i++)
						{
							string fileName2 = Path.GetFileName(files[i]);
							if (fileName2.StartsWith(Path.GetFileNameWithoutExtension(fileName)))
							{
								arrayList.Add(fileName2);
							}
						}
					}
				}
			}
			LogLog.Debug(RollingFileAppender.declaringType, "Searched for existing files in [" + text + "]");
			return arrayList;
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x00016AF4 File Offset: 0x00015AF4
		private void RollOverIfDateBoundaryCrossing()
		{
			if (this.m_staticLogFileName && this.m_rollDate && this.FileExists(this.m_baseFileName))
			{
				DateTime dateTime;
				using (base.SecurityContext.Impersonate(this))
				{
					if (this.DateTimeStrategy is RollingFileAppender.UniversalDateTime)
					{
						dateTime = System.IO.File.GetLastWriteTimeUtc(this.m_baseFileName);
					}
					else
					{
						dateTime = System.IO.File.GetLastWriteTime(this.m_baseFileName);
					}
				}
				LogLog.Debug(RollingFileAppender.declaringType, string.Concat(new string[]
				{
					"[",
					dateTime.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo),
					"] vs. [",
					this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo),
					"]"
				}));
				if (!dateTime.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo).Equals(this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo)))
				{
					this.m_scheduledFilename = this.CombinePath(this.m_baseFileName, dateTime.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo));
					LogLog.Debug(RollingFileAppender.declaringType, "Initial roll over to [" + this.m_scheduledFilename + "]");
					this.RollOverTime(false);
					LogLog.Debug(RollingFileAppender.declaringType, "curSizeRollBackups after rollOver at [" + this.m_curSizeRollBackups.ToString() + "]");
				}
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x00016C70 File Offset: 0x00015C70
		protected void ExistingInit()
		{
			this.DetermineCurSizeRollBackups();
			this.RollOverIfDateBoundaryCrossing();
			if (!base.AppendToFile)
			{
				bool flag = false;
				string nextOutputFileName = this.GetNextOutputFileName(this.m_baseFileName);
				using (base.SecurityContext.Impersonate(this))
				{
					flag = System.IO.File.Exists(nextOutputFileName);
				}
				if (flag)
				{
					if (this.m_maxSizeRollBackups == 0)
					{
						LogLog.Debug(RollingFileAppender.declaringType, "Output file [" + nextOutputFileName + "] already exists. MaxSizeRollBackups is 0; cannot roll. Overwriting existing file.");
						return;
					}
					LogLog.Debug(RollingFileAppender.declaringType, "Output file [" + nextOutputFileName + "] already exists. Not appending to file. Rolling existing file out of the way.");
					this.RollOverRenameFiles(nextOutputFileName);
				}
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x00016D18 File Offset: 0x00015D18
		private void InitializeFromOneFile(string baseFile, string curFileName)
		{
			if (!curFileName.StartsWith(Path.GetFileNameWithoutExtension(baseFile)))
			{
				return;
			}
			if (curFileName.Equals(baseFile))
			{
				return;
			}
			if (this.m_rollDate && !this.m_staticLogFileName)
			{
				string str = this.m_dateTime.Now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo);
				string value = this.m_preserveLogFileNameExtension ? (Path.GetFileNameWithoutExtension(baseFile) + str) : (baseFile + str);
				string value2 = this.m_preserveLogFileNameExtension ? Path.GetExtension(baseFile) : "";
				if (!curFileName.StartsWith(value) || !curFileName.EndsWith(value2))
				{
					LogLog.Debug(RollingFileAppender.declaringType, "Ignoring file [" + curFileName + "] because it is from a different date period");
					return;
				}
			}
			try
			{
				int backUpIndex = this.GetBackUpIndex(curFileName);
				if (backUpIndex > this.m_curSizeRollBackups)
				{
					if (this.m_maxSizeRollBackups != 0)
					{
						if (-1 == this.m_maxSizeRollBackups)
						{
							this.m_curSizeRollBackups = backUpIndex;
						}
						else if (this.m_countDirection >= 0)
						{
							this.m_curSizeRollBackups = backUpIndex;
						}
						else if (backUpIndex <= this.m_maxSizeRollBackups)
						{
							this.m_curSizeRollBackups = backUpIndex;
						}
					}
					LogLog.Debug(RollingFileAppender.declaringType, string.Concat(new string[]
					{
						"File name [",
						curFileName,
						"] moves current count to [",
						this.m_curSizeRollBackups.ToString(),
						"]"
					}));
				}
			}
			catch (FormatException)
			{
				LogLog.Debug(RollingFileAppender.declaringType, "Encountered a backup file not ending in .x [" + curFileName + "]");
			}
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00016E98 File Offset: 0x00015E98
		private int GetBackUpIndex(string curFileName)
		{
			int result = -1;
			string text = curFileName;
			if (this.m_preserveLogFileNameExtension)
			{
				text = Path.GetFileNameWithoutExtension(text);
			}
			int num = text.LastIndexOf(".");
			if (num > 0)
			{
				SystemInfo.TryParse(text.Substring(num + 1), out result);
			}
			return result;
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00016EDC File Offset: 0x00015EDC
		private void InitializeRollBackups(string baseFile, ArrayList arrayFiles)
		{
			if (arrayFiles != null)
			{
				string baseFile2 = baseFile.ToLowerInvariant();
				foreach (object obj in arrayFiles)
				{
					string text = (string)obj;
					this.InitializeFromOneFile(baseFile2, text.ToLowerInvariant());
				}
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00016F40 File Offset: 0x00015F40
		private RollingFileAppender.RollPoint ComputeCheckPeriod(string datePattern)
		{
			string text = RollingFileAppender.s_date1970.ToString(datePattern, DateTimeFormatInfo.InvariantInfo);
			for (int i = 0; i <= 5; i++)
			{
				string text2 = this.NextCheckDate(RollingFileAppender.s_date1970, (RollingFileAppender.RollPoint)i).ToString(datePattern, DateTimeFormatInfo.InvariantInfo);
				LogLog.Debug(RollingFileAppender.declaringType, string.Concat(new string[]
				{
					"Type = [",
					i.ToString(),
					"], r0 = [",
					text,
					"], r1 = [",
					text2,
					"]"
				}));
				if (text != null && text2 != null && !text.Equals(text2))
				{
					return (RollingFileAppender.RollPoint)i;
				}
			}
			return RollingFileAppender.RollPoint.InvalidRollPoint;
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00016FE4 File Offset: 0x00015FE4
		public override void ActivateOptions()
		{
			if (this.m_dateTime == null)
			{
				this.m_dateTime = new RollingFileAppender.LocalDateTime();
			}
			if (this.m_rollDate && this.m_datePattern != null)
			{
				this.m_now = this.m_dateTime.Now;
				this.m_rollPoint = this.ComputeCheckPeriod(this.m_datePattern);
				if (this.m_rollPoint == RollingFileAppender.RollPoint.InvalidRollPoint)
				{
					throw new ArgumentException("Invalid RollPoint, unable to parse [" + this.m_datePattern + "]");
				}
				this.m_nextCheck = this.NextCheckDate(this.m_now, this.m_rollPoint);
			}
			else if (this.m_rollDate)
			{
				this.ErrorHandler.Error("Either DatePattern or rollingStyle options are not set for [" + base.Name + "].");
			}
			if (base.SecurityContext == null)
			{
				base.SecurityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}
			using (base.SecurityContext.Impersonate(this))
			{
				base.File = FileAppender.ConvertToFullPath(base.File.Trim());
				this.m_baseFileName = base.File;
			}
			this.m_mutexForRolling = new Mutex(false, this.m_baseFileName.Replace("\\", "_").Replace(":", "_").Replace("/", "_"));
			if (this.m_rollDate && this.File != null && this.m_scheduledFilename == null)
			{
				this.m_scheduledFilename = this.CombinePath(this.File, this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo));
			}
			this.ExistingInit();
			base.ActivateOptions();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0001718C File Offset: 0x0001618C
		private string CombinePath(string path1, string path2)
		{
			string extension = Path.GetExtension(path1);
			if (this.m_preserveLogFileNameExtension && extension.Length > 0)
			{
				return Path.Combine(Path.GetDirectoryName(path1), Path.GetFileNameWithoutExtension(path1) + path2 + extension);
			}
			return path1 + path2;
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000171D4 File Offset: 0x000161D4
		protected void RollOverTime(bool fileIsOpen)
		{
			if (this.m_staticLogFileName)
			{
				if (this.m_datePattern == null)
				{
					this.ErrorHandler.Error("Missing DatePattern option in rollOver().");
					return;
				}
				string path = this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo);
				if (this.m_scheduledFilename.Equals(this.CombinePath(this.File, path)))
				{
					this.ErrorHandler.Error("Compare " + this.m_scheduledFilename + " : " + this.CombinePath(this.File, path));
					return;
				}
				if (fileIsOpen)
				{
					base.CloseFile();
				}
				for (int i = 1; i <= this.m_curSizeRollBackups; i++)
				{
					string fromFile = this.CombinePath(this.File, "." + i.ToString());
					string toFile = this.CombinePath(this.m_scheduledFilename, "." + i.ToString());
					this.RollFile(fromFile, toFile);
				}
				this.RollFile(this.File, this.m_scheduledFilename);
			}
			this.m_curSizeRollBackups = 0;
			this.m_scheduledFilename = this.CombinePath(this.File, this.m_now.ToString(this.m_datePattern, DateTimeFormatInfo.InvariantInfo));
			if (fileIsOpen)
			{
				this.SafeOpenFile(this.m_baseFileName, false);
			}
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00017314 File Offset: 0x00016314
		protected void RollFile(string fromFile, string toFile)
		{
			if (this.FileExists(fromFile))
			{
				this.DeleteFile(toFile);
				try
				{
					LogLog.Debug(RollingFileAppender.declaringType, string.Concat(new string[]
					{
						"Moving [",
						fromFile,
						"] -> [",
						toFile,
						"]"
					}));
					using (base.SecurityContext.Impersonate(this))
					{
						System.IO.File.Move(fromFile, toFile);
					}
					return;
				}
				catch (Exception e)
				{
					this.ErrorHandler.Error(string.Concat(new string[]
					{
						"Exception while rolling file [",
						fromFile,
						"] -> [",
						toFile,
						"]"
					}), e, ErrorCode.GenericFailure);
					return;
				}
			}
			LogLog.Warn(RollingFileAppender.declaringType, string.Concat(new string[]
			{
				"Cannot RollFile [",
				fromFile,
				"] -> [",
				toFile,
				"]. Source does not exist"
			}));
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00017418 File Offset: 0x00016418
		protected bool FileExists(string path)
		{
			bool result;
			using (base.SecurityContext.Impersonate(this))
			{
				result = System.IO.File.Exists(path);
			}
			return result;
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00017458 File Offset: 0x00016458
		protected void DeleteFile(string fileName)
		{
			if (this.FileExists(fileName))
			{
				string text = fileName;
				string text2 = fileName + "." + Environment.TickCount.ToString() + ".DeletePending";
				try
				{
					using (base.SecurityContext.Impersonate(this))
					{
						System.IO.File.Move(fileName, text2);
					}
					text = text2;
				}
				catch (Exception exception)
				{
					LogLog.Debug(RollingFileAppender.declaringType, string.Concat(new string[]
					{
						"Exception while moving file to be deleted [",
						fileName,
						"] -> [",
						text2,
						"]"
					}), exception);
				}
				try
				{
					using (base.SecurityContext.Impersonate(this))
					{
						System.IO.File.Delete(text);
					}
					LogLog.Debug(RollingFileAppender.declaringType, "Deleted file [" + fileName + "]");
				}
				catch (Exception ex)
				{
					if (text == fileName)
					{
						this.ErrorHandler.Error("Exception while deleting file [" + text + "]", ex, ErrorCode.GenericFailure);
					}
					else
					{
						LogLog.Debug(RollingFileAppender.declaringType, "Exception while deleting temp file [" + text + "]", ex);
					}
				}
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000175AC File Offset: 0x000165AC
		protected void RollOverSize()
		{
			base.CloseFile();
			LogLog.Debug(RollingFileAppender.declaringType, "rolling over count [" + ((CountingQuietTextWriter)base.QuietWriter).Count.ToString() + "]");
			LogLog.Debug(RollingFileAppender.declaringType, "maxSizeRollBackups [" + this.m_maxSizeRollBackups.ToString() + "]");
			LogLog.Debug(RollingFileAppender.declaringType, "curSizeRollBackups [" + this.m_curSizeRollBackups.ToString() + "]");
			LogLog.Debug(RollingFileAppender.declaringType, "countDirection [" + this.m_countDirection.ToString() + "]");
			this.RollOverRenameFiles(this.File);
			if (!this.m_staticLogFileName && this.m_countDirection >= 0)
			{
				this.m_curSizeRollBackups++;
			}
			this.SafeOpenFile(this.m_baseFileName, false);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00017694 File Offset: 0x00016694
		protected void RollOverRenameFiles(string baseFileName)
		{
			if (this.m_maxSizeRollBackups != 0)
			{
				if (this.m_countDirection < 0)
				{
					if (this.m_curSizeRollBackups == this.m_maxSizeRollBackups)
					{
						this.DeleteFile(this.CombinePath(baseFileName, "." + this.m_maxSizeRollBackups.ToString()));
						this.m_curSizeRollBackups--;
					}
					for (int i = this.m_curSizeRollBackups; i >= 1; i--)
					{
						this.RollFile(this.CombinePath(baseFileName, "." + i.ToString()), this.CombinePath(baseFileName, "." + (i + 1).ToString()));
					}
					this.m_curSizeRollBackups++;
					this.RollFile(baseFileName, this.CombinePath(baseFileName, ".1"));
					return;
				}
				if (this.m_curSizeRollBackups >= this.m_maxSizeRollBackups && this.m_maxSizeRollBackups > 0)
				{
					int num = this.m_curSizeRollBackups - this.m_maxSizeRollBackups;
					if (this.m_staticLogFileName)
					{
						num++;
					}
					string text = baseFileName;
					if (!this.m_staticLogFileName)
					{
						if (this.m_preserveLogFileNameExtension)
						{
							string extension = Path.GetExtension(text);
							string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text);
							int num2 = fileNameWithoutExtension.LastIndexOf(".");
							if (num2 >= 0)
							{
								text = fileNameWithoutExtension.Substring(0, num2) + extension;
							}
						}
						else
						{
							int num3 = text.LastIndexOf(".");
							if (num3 >= 0)
							{
								text = text.Substring(0, num3);
							}
						}
					}
					this.DeleteFile(this.CombinePath(text, "." + num.ToString()));
				}
				if (this.m_staticLogFileName)
				{
					this.m_curSizeRollBackups++;
					this.RollFile(baseFileName, this.CombinePath(baseFileName, "." + this.m_curSizeRollBackups.ToString()));
				}
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00017858 File Offset: 0x00016858
		protected DateTime NextCheckDate(DateTime currentDateTime, RollingFileAppender.RollPoint rollPoint)
		{
			DateTime result = currentDateTime;
			switch (rollPoint)
			{
			case RollingFileAppender.RollPoint.TopOfMinute:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes(1.0);
				break;
			case RollingFileAppender.RollPoint.TopOfHour:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes((double)(-(double)result.Minute));
				result = result.AddHours(1.0);
				break;
			case RollingFileAppender.RollPoint.HalfDay:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes((double)(-(double)result.Minute));
				if (result.Hour < 12)
				{
					result = result.AddHours((double)(12 - result.Hour));
				}
				else
				{
					result = result.AddHours((double)(-(double)result.Hour));
					result = result.AddDays(1.0);
				}
				break;
			case RollingFileAppender.RollPoint.TopOfDay:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes((double)(-(double)result.Minute));
				result = result.AddHours((double)(-(double)result.Hour));
				result = result.AddDays(1.0);
				break;
			case RollingFileAppender.RollPoint.TopOfWeek:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes((double)(-(double)result.Minute));
				result = result.AddHours((double)(-(double)result.Hour));
				result = result.AddDays((double)((DayOfWeek)7 - result.DayOfWeek));
				break;
			case RollingFileAppender.RollPoint.TopOfMonth:
				result = result.AddMilliseconds((double)(-(double)result.Millisecond));
				result = result.AddSeconds((double)(-(double)result.Second));
				result = result.AddMinutes((double)(-(double)result.Minute));
				result = result.AddHours((double)(-(double)result.Hour));
				result = result.AddDays((double)(1 - result.Day));
				result = result.AddMonths(1);
				break;
			}
			return result;
		}

		// Token: 0x04000219 RID: 537
		private static readonly Type declaringType = typeof(RollingFileAppender);

		// Token: 0x0400021A RID: 538
		private RollingFileAppender.IDateTime m_dateTime;

		// Token: 0x0400021B RID: 539
		private string m_datePattern = ".yyyy-MM-dd";

		// Token: 0x0400021C RID: 540
		private string m_scheduledFilename;

		// Token: 0x0400021D RID: 541
		private DateTime m_nextCheck = DateTime.MaxValue;

		// Token: 0x0400021E RID: 542
		private DateTime m_now;

		// Token: 0x0400021F RID: 543
		private RollingFileAppender.RollPoint m_rollPoint;

		// Token: 0x04000220 RID: 544
		private long m_maxFileSize = 10485760L;

		// Token: 0x04000221 RID: 545
		private int m_maxSizeRollBackups;

		// Token: 0x04000222 RID: 546
		private int m_curSizeRollBackups;

		// Token: 0x04000223 RID: 547
		private int m_countDirection = -1;

		// Token: 0x04000224 RID: 548
		private RollingFileAppender.RollingMode m_rollingStyle = RollingFileAppender.RollingMode.Composite;

		// Token: 0x04000225 RID: 549
		private bool m_rollDate = true;

		// Token: 0x04000226 RID: 550
		private bool m_rollSize = true;

		// Token: 0x04000227 RID: 551
		private bool m_staticLogFileName = true;

		// Token: 0x04000228 RID: 552
		private bool m_preserveLogFileNameExtension;

		// Token: 0x04000229 RID: 553
		private string m_baseFileName;

		// Token: 0x0400022A RID: 554
		private Mutex m_mutexForRolling;

		// Token: 0x0400022B RID: 555
		private static readonly DateTime s_date1970 = new DateTime(1970, 1, 1);

		// Token: 0x0200011F RID: 287
		public enum RollingMode
		{
			// Token: 0x04000305 RID: 773
			Once,
			// Token: 0x04000306 RID: 774
			Size,
			// Token: 0x04000307 RID: 775
			Date,
			// Token: 0x04000308 RID: 776
			Composite
		}

		// Token: 0x02000120 RID: 288
		protected enum RollPoint
		{
			// Token: 0x0400030A RID: 778
			InvalidRollPoint = -1,
			// Token: 0x0400030B RID: 779
			TopOfMinute,
			// Token: 0x0400030C RID: 780
			TopOfHour,
			// Token: 0x0400030D RID: 781
			HalfDay,
			// Token: 0x0400030E RID: 782
			TopOfDay,
			// Token: 0x0400030F RID: 783
			TopOfWeek,
			// Token: 0x04000310 RID: 784
			TopOfMonth
		}

		// Token: 0x02000121 RID: 289
		public interface IDateTime
		{
			// Token: 0x170001CE RID: 462
			// (get) Token: 0x0600089F RID: 2207
			DateTime Now { get; }
		}

		// Token: 0x02000122 RID: 290
		private class LocalDateTime : RollingFileAppender.IDateTime
		{
			// Token: 0x170001CF RID: 463
			// (get) Token: 0x060008A0 RID: 2208 RVA: 0x00019E7D File Offset: 0x00018E7D
			public DateTime Now
			{
				get
				{
					return DateTime.Now;
				}
			}
		}

		// Token: 0x02000123 RID: 291
		private class UniversalDateTime : RollingFileAppender.IDateTime
		{
			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x060008A2 RID: 2210 RVA: 0x00019E8C File Offset: 0x00018E8C
			public DateTime Now
			{
				get
				{
					return DateTime.UtcNow;
				}
			}
		}
	}
}
