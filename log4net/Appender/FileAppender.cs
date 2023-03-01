using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net.Core;
using log4net.Layout;
using log4net.Util;

namespace log4net.Appender
{
	// Token: 0x020000DC RID: 220
	public class FileAppender : TextWriterAppender
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x0001533F File Offset: 0x0001433F
		public FileAppender()
		{
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00015368 File Offset: 0x00014368
		[Obsolete("Instead use the default constructor and set the Layout, File & AppendToFile properties")]
		public FileAppender(ILayout layout, string filename, bool append)
		{
			this.Layout = layout;
			this.File = filename;
			this.AppendToFile = append;
			this.ActivateOptions();
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x000153B4 File Offset: 0x000143B4
		[Obsolete("Instead use the default constructor and set the Layout & File properties")]
		public FileAppender(ILayout layout, string filename) : this(layout, filename, true)
		{
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x000153BF File Offset: 0x000143BF
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x000153C7 File Offset: 0x000143C7
		public virtual string File
		{
			get
			{
				return this.m_fileName;
			}
			set
			{
				this.m_fileName = value;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x000153D0 File Offset: 0x000143D0
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x000153D8 File Offset: 0x000143D8
		public bool AppendToFile
		{
			get
			{
				return this.m_appendToFile;
			}
			set
			{
				this.m_appendToFile = value;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000153E1 File Offset: 0x000143E1
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000153E9 File Offset: 0x000143E9
		public Encoding Encoding
		{
			get
			{
				return this.m_encoding;
			}
			set
			{
				this.m_encoding = value;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060006BD RID: 1725 RVA: 0x000153F2 File Offset: 0x000143F2
		// (set) Token: 0x060006BE RID: 1726 RVA: 0x000153FA File Offset: 0x000143FA
		public log4net.Core.SecurityContext SecurityContext
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

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060006BF RID: 1727 RVA: 0x00015403 File Offset: 0x00014403
		// (set) Token: 0x060006C0 RID: 1728 RVA: 0x0001540B File Offset: 0x0001440B
		public FileAppender.LockingModelBase LockingModel
		{
			get
			{
				return this.m_lockingModel;
			}
			set
			{
				this.m_lockingModel = value;
			}
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00015414 File Offset: 0x00014414
		public override void ActivateOptions()
		{
			base.ActivateOptions();
			if (this.m_securityContext == null)
			{
				this.m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext(this);
			}
			if (this.m_lockingModel == null)
			{
				this.m_lockingModel = new FileAppender.ExclusiveLock();
			}
			this.m_lockingModel.CurrentAppender = this;
			this.m_lockingModel.ActivateOptions();
			if (this.m_fileName != null)
			{
				using (this.SecurityContext.Impersonate(this))
				{
					this.m_fileName = FileAppender.ConvertToFullPath(this.m_fileName.Trim());
				}
				this.SafeOpenFile(this.m_fileName, this.m_appendToFile);
				return;
			}
			LogLog.Warn(FileAppender.declaringType, "FileAppender: File option not set for appender [" + base.Name + "].");
			LogLog.Warn(FileAppender.declaringType, "FileAppender: Are you using FileAppender instead of ConsoleAppender?");
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000154F4 File Offset: 0x000144F4
		protected override void Reset()
		{
			base.Reset();
			this.m_fileName = null;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00015503 File Offset: 0x00014503
		protected override void OnClose()
		{
			base.OnClose();
			this.m_lockingModel.OnClose();
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00015516 File Offset: 0x00014516
		protected override void PrepareWriter()
		{
			this.SafeOpenFile(this.m_fileName, this.m_appendToFile);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x0001552C File Offset: 0x0001452C
		protected override void Append(LoggingEvent loggingEvent)
		{
			if (this.m_stream.AcquireLock())
			{
				try
				{
					base.Append(loggingEvent);
				}
				finally
				{
					this.m_stream.ReleaseLock();
				}
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0001556C File Offset: 0x0001456C
		protected override void Append(LoggingEvent[] loggingEvents)
		{
			if (this.m_stream.AcquireLock())
			{
				try
				{
					base.Append(loggingEvents);
				}
				finally
				{
					this.m_stream.ReleaseLock();
				}
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000155AC File Offset: 0x000145AC
		protected override void WriteFooter()
		{
			if (this.m_stream != null)
			{
				this.m_stream.AcquireLock();
				try
				{
					base.WriteFooter();
				}
				finally
				{
					this.m_stream.ReleaseLock();
				}
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x000155F4 File Offset: 0x000145F4
		protected override void WriteHeader()
		{
			if (this.m_stream != null && this.m_stream.AcquireLock())
			{
				try
				{
					base.WriteHeader();
				}
				finally
				{
					this.m_stream.ReleaseLock();
				}
			}
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001563C File Offset: 0x0001463C
		protected override void CloseWriter()
		{
			if (this.m_stream != null)
			{
				this.m_stream.AcquireLock();
				try
				{
					base.CloseWriter();
				}
				finally
				{
					this.m_stream.ReleaseLock();
				}
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00015684 File Offset: 0x00014684
		protected void CloseFile()
		{
			this.WriteFooterAndCloseWriter();
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001568C File Offset: 0x0001468C
		protected virtual void SafeOpenFile(string fileName, bool append)
		{
			try
			{
				this.OpenFile(fileName, append);
			}
			catch (Exception e)
			{
				this.ErrorHandler.Error(string.Concat(new string[]
				{
					"OpenFile(",
					fileName,
					",",
					append.ToString(),
					") call failed."
				}), e, ErrorCode.FileOpenFailure);
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x000156F4 File Offset: 0x000146F4
		protected virtual void OpenFile(string fileName, bool append)
		{
			if (LogLog.IsErrorEnabled)
			{
				bool flag = false;
				using (this.SecurityContext.Impersonate(this))
				{
					flag = Path.IsPathRooted(fileName);
				}
				if (!flag)
				{
					LogLog.Error(FileAppender.declaringType, "INTERNAL ERROR. OpenFile(" + fileName + "): File name is not fully qualified.");
				}
			}
			lock (this)
			{
				this.Reset();
				LogLog.Debug(FileAppender.declaringType, string.Concat(new string[]
				{
					"Opening file for writing [",
					fileName,
					"] append [",
					append.ToString(),
					"]"
				}));
				this.m_fileName = fileName;
				this.m_appendToFile = append;
				this.LockingModel.CurrentAppender = this;
				this.LockingModel.OpenFile(fileName, append, this.m_encoding);
				this.m_stream = new FileAppender.LockingStream(this.LockingModel);
				if (this.m_stream != null)
				{
					this.m_stream.AcquireLock();
					try
					{
						this.SetQWForFiles(this.m_stream);
					}
					finally
					{
						this.m_stream.ReleaseLock();
					}
				}
				this.WriteHeader();
			}
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001583C File Offset: 0x0001483C
		protected virtual void SetQWForFiles(Stream fileStream)
		{
			StreamWriter qwforFiles = new StreamWriter(fileStream, this.m_encoding);
			this.SetQWForFiles(qwforFiles);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001585D File Offset: 0x0001485D
		protected virtual void SetQWForFiles(TextWriter writer)
		{
			base.QuietWriter = new QuietTextWriter(writer, this.ErrorHandler);
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00015871 File Offset: 0x00014871
		protected static string ConvertToFullPath(string path)
		{
			return SystemInfo.ConvertToFullPath(path);
		}

		// Token: 0x040001F9 RID: 505
		private bool m_appendToFile = true;

		// Token: 0x040001FA RID: 506
		private string m_fileName;

		// Token: 0x040001FB RID: 507
		private Encoding m_encoding = Encoding.GetEncoding(0);

		// Token: 0x040001FC RID: 508
		private log4net.Core.SecurityContext m_securityContext;

		// Token: 0x040001FD RID: 509
		private FileAppender.LockingStream m_stream;

		// Token: 0x040001FE RID: 510
		private FileAppender.LockingModelBase m_lockingModel = new FileAppender.ExclusiveLock();

		// Token: 0x040001FF RID: 511
		private static readonly Type declaringType = typeof(FileAppender);

		// Token: 0x02000112 RID: 274
		private sealed class LockingStream : Stream, IDisposable
		{
			// Token: 0x06000858 RID: 2136 RVA: 0x00019760 File Offset: 0x00018760
			public LockingStream(FileAppender.LockingModelBase locking)
			{
				if (locking == null)
				{
					throw new ArgumentException("Locking model may not be null", "locking");
				}
				this.m_lockingModel = locking;
			}

			// Token: 0x06000859 RID: 2137 RVA: 0x0001978C File Offset: 0x0001878C
			public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
			{
				this.AssertLocked();
				IAsyncResult asyncResult = this.m_realStream.BeginRead(buffer, offset, count, callback, state);
				this.m_readTotal = this.EndRead(asyncResult);
				return asyncResult;
			}

			// Token: 0x0600085A RID: 2138 RVA: 0x000197C0 File Offset: 0x000187C0
			public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
			{
				this.AssertLocked();
				IAsyncResult asyncResult = this.m_realStream.BeginWrite(buffer, offset, count, callback, state);
				this.EndWrite(asyncResult);
				return asyncResult;
			}

			// Token: 0x0600085B RID: 2139 RVA: 0x000197EE File Offset: 0x000187EE
			public override void Close()
			{
				this.m_lockingModel.CloseFile();
			}

			// Token: 0x0600085C RID: 2140 RVA: 0x000197FB File Offset: 0x000187FB
			public override int EndRead(IAsyncResult asyncResult)
			{
				this.AssertLocked();
				return this.m_readTotal;
			}

			// Token: 0x0600085D RID: 2141 RVA: 0x00019809 File Offset: 0x00018809
			public override void EndWrite(IAsyncResult asyncResult)
			{
			}

			// Token: 0x0600085E RID: 2142 RVA: 0x0001980B File Offset: 0x0001880B
			public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				this.AssertLocked();
				return this.m_realStream.ReadAsync(buffer, offset, count, cancellationToken);
			}

			// Token: 0x0600085F RID: 2143 RVA: 0x00019823 File Offset: 0x00018823
			public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
			{
				this.AssertLocked();
				return base.WriteAsync(buffer, offset, count, cancellationToken);
			}

			// Token: 0x06000860 RID: 2144 RVA: 0x00019836 File Offset: 0x00018836
			public override void Flush()
			{
				this.AssertLocked();
				this.m_realStream.Flush();
			}

			// Token: 0x06000861 RID: 2145 RVA: 0x00019849 File Offset: 0x00018849
			public override int Read(byte[] buffer, int offset, int count)
			{
				return this.m_realStream.Read(buffer, offset, count);
			}

			// Token: 0x06000862 RID: 2146 RVA: 0x00019859 File Offset: 0x00018859
			public override int ReadByte()
			{
				return this.m_realStream.ReadByte();
			}

			// Token: 0x06000863 RID: 2147 RVA: 0x00019866 File Offset: 0x00018866
			public override long Seek(long offset, SeekOrigin origin)
			{
				this.AssertLocked();
				return this.m_realStream.Seek(offset, origin);
			}

			// Token: 0x06000864 RID: 2148 RVA: 0x0001987B File Offset: 0x0001887B
			public override void SetLength(long value)
			{
				this.AssertLocked();
				this.m_realStream.SetLength(value);
			}

			// Token: 0x06000865 RID: 2149 RVA: 0x0001988F File Offset: 0x0001888F
			void IDisposable.Dispose()
			{
				this.Close();
			}

			// Token: 0x06000866 RID: 2150 RVA: 0x00019897 File Offset: 0x00018897
			public override void Write(byte[] buffer, int offset, int count)
			{
				this.AssertLocked();
				this.m_realStream.Write(buffer, offset, count);
			}

			// Token: 0x06000867 RID: 2151 RVA: 0x000198AD File Offset: 0x000188AD
			public override void WriteByte(byte value)
			{
				this.AssertLocked();
				this.m_realStream.WriteByte(value);
			}

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06000868 RID: 2152 RVA: 0x000198C1 File Offset: 0x000188C1
			public override bool CanRead
			{
				get
				{
					return false;
				}
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06000869 RID: 2153 RVA: 0x000198C4 File Offset: 0x000188C4
			public override bool CanSeek
			{
				get
				{
					this.AssertLocked();
					return this.m_realStream.CanSeek;
				}
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x0600086A RID: 2154 RVA: 0x000198D7 File Offset: 0x000188D7
			public override bool CanWrite
			{
				get
				{
					this.AssertLocked();
					return this.m_realStream.CanWrite;
				}
			}

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x0600086B RID: 2155 RVA: 0x000198EA File Offset: 0x000188EA
			public override long Length
			{
				get
				{
					this.AssertLocked();
					return this.m_realStream.Length;
				}
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x0600086C RID: 2156 RVA: 0x000198FD File Offset: 0x000188FD
			// (set) Token: 0x0600086D RID: 2157 RVA: 0x00019910 File Offset: 0x00018910
			public override long Position
			{
				get
				{
					this.AssertLocked();
					return this.m_realStream.Position;
				}
				set
				{
					this.AssertLocked();
					this.m_realStream.Position = value;
				}
			}

			// Token: 0x0600086E RID: 2158 RVA: 0x00019924 File Offset: 0x00018924
			private void AssertLocked()
			{
				if (this.m_realStream == null)
				{
					throw new FileAppender.LockingStream.LockStateException("The file is not currently locked");
				}
			}

			// Token: 0x0600086F RID: 2159 RVA: 0x0001993C File Offset: 0x0001893C
			public bool AcquireLock()
			{
				bool result = false;
				lock (this)
				{
					if (this.m_lockLevel == 0)
					{
						this.m_realStream = this.m_lockingModel.AcquireLock();
					}
					if (this.m_realStream != null)
					{
						this.m_lockLevel++;
						result = true;
					}
				}
				return result;
			}

			// Token: 0x06000870 RID: 2160 RVA: 0x000199A8 File Offset: 0x000189A8
			public void ReleaseLock()
			{
				lock (this)
				{
					this.m_lockLevel--;
					if (this.m_lockLevel == 0)
					{
						this.m_lockingModel.ReleaseLock();
						this.m_realStream = null;
					}
				}
			}

			// Token: 0x040002AE RID: 686
			private Stream m_realStream;

			// Token: 0x040002AF RID: 687
			private FileAppender.LockingModelBase m_lockingModel;

			// Token: 0x040002B0 RID: 688
			private int m_lockLevel;

			// Token: 0x040002B1 RID: 689
			private int m_readTotal = -1;

			// Token: 0x02000127 RID: 295
			[Serializable]
			public sealed class LockStateException : LogException
			{
				// Token: 0x060008AC RID: 2220 RVA: 0x0001A1CC File Offset: 0x000191CC
				public LockStateException(string message) : base(message)
				{
				}

				// Token: 0x060008AD RID: 2221 RVA: 0x0001A1D5 File Offset: 0x000191D5
				public LockStateException()
				{
				}

				// Token: 0x060008AE RID: 2222 RVA: 0x0001A1DD File Offset: 0x000191DD
				public LockStateException(string message, Exception innerException) : base(message, innerException)
				{
				}

				// Token: 0x060008AF RID: 2223 RVA: 0x0001A1E7 File Offset: 0x000191E7
				private LockStateException(SerializationInfo info, StreamingContext context) : base(info, context)
				{
				}
			}
		}

		// Token: 0x02000113 RID: 275
		public abstract class LockingModelBase
		{
			// Token: 0x06000871 RID: 2161
			public abstract void OpenFile(string filename, bool append, Encoding encoding);

			// Token: 0x06000872 RID: 2162
			public abstract void CloseFile();

			// Token: 0x06000873 RID: 2163
			public abstract void ActivateOptions();

			// Token: 0x06000874 RID: 2164
			public abstract void OnClose();

			// Token: 0x06000875 RID: 2165
			public abstract Stream AcquireLock();

			// Token: 0x06000876 RID: 2166
			public abstract void ReleaseLock();

			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x06000877 RID: 2167 RVA: 0x00019A08 File Offset: 0x00018A08
			// (set) Token: 0x06000878 RID: 2168 RVA: 0x00019A10 File Offset: 0x00018A10
			public FileAppender CurrentAppender
			{
				get
				{
					return this.m_appender;
				}
				set
				{
					this.m_appender = value;
				}
			}

			// Token: 0x06000879 RID: 2169 RVA: 0x00019A1C File Offset: 0x00018A1C
			protected Stream CreateStream(string filename, bool append, FileShare fileShare)
			{
				Stream result;
				using (this.CurrentAppender.SecurityContext.Impersonate(this))
				{
					string directoryName = Path.GetDirectoryName(filename);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					FileMode mode = append ? FileMode.Append : FileMode.Create;
					result = new FileStream(filename, mode, FileAccess.Write, fileShare);
				}
				return result;
			}

			// Token: 0x0600087A RID: 2170 RVA: 0x00019A80 File Offset: 0x00018A80
			protected void CloseStream(Stream stream)
			{
				using (this.CurrentAppender.SecurityContext.Impersonate(this))
				{
					stream.Dispose();
				}
			}

			// Token: 0x040002B2 RID: 690
			private FileAppender m_appender;
		}

		// Token: 0x02000114 RID: 276
		public class ExclusiveLock : FileAppender.LockingModelBase
		{
			// Token: 0x0600087C RID: 2172 RVA: 0x00019ACC File Offset: 0x00018ACC
			public override void OpenFile(string filename, bool append, Encoding encoding)
			{
				try
				{
					this.m_stream = base.CreateStream(filename, append, FileShare.Read);
				}
				catch (Exception ex)
				{
					base.CurrentAppender.ErrorHandler.Error("Unable to acquire lock on file " + filename + ". " + ex.Message);
				}
			}

			// Token: 0x0600087D RID: 2173 RVA: 0x00019B24 File Offset: 0x00018B24
			public override void CloseFile()
			{
				base.CloseStream(this.m_stream);
				this.m_stream = null;
			}

			// Token: 0x0600087E RID: 2174 RVA: 0x00019B39 File Offset: 0x00018B39
			public override Stream AcquireLock()
			{
				return this.m_stream;
			}

			// Token: 0x0600087F RID: 2175 RVA: 0x00019B41 File Offset: 0x00018B41
			public override void ReleaseLock()
			{
			}

			// Token: 0x06000880 RID: 2176 RVA: 0x00019B43 File Offset: 0x00018B43
			public override void ActivateOptions()
			{
			}

			// Token: 0x06000881 RID: 2177 RVA: 0x00019B45 File Offset: 0x00018B45
			public override void OnClose()
			{
			}

			// Token: 0x040002B3 RID: 691
			private Stream m_stream;
		}

		// Token: 0x02000115 RID: 277
		public class MinimalLock : FileAppender.LockingModelBase
		{
			// Token: 0x06000883 RID: 2179 RVA: 0x00019B4F File Offset: 0x00018B4F
			public override void OpenFile(string filename, bool append, Encoding encoding)
			{
				this.m_filename = filename;
				this.m_append = append;
			}

			// Token: 0x06000884 RID: 2180 RVA: 0x00019B5F File Offset: 0x00018B5F
			public override void CloseFile()
			{
			}

			// Token: 0x06000885 RID: 2181 RVA: 0x00019B64 File Offset: 0x00018B64
			public override Stream AcquireLock()
			{
				if (this.m_stream == null)
				{
					try
					{
						this.m_stream = base.CreateStream(this.m_filename, this.m_append, FileShare.Read);
						this.m_append = true;
					}
					catch (Exception ex)
					{
						base.CurrentAppender.ErrorHandler.Error("Unable to acquire lock on file " + this.m_filename + ". " + ex.Message);
					}
				}
				return this.m_stream;
			}

			// Token: 0x06000886 RID: 2182 RVA: 0x00019BE0 File Offset: 0x00018BE0
			public override void ReleaseLock()
			{
				base.CloseStream(this.m_stream);
				this.m_stream = null;
			}

			// Token: 0x06000887 RID: 2183 RVA: 0x00019BF5 File Offset: 0x00018BF5
			public override void ActivateOptions()
			{
			}

			// Token: 0x06000888 RID: 2184 RVA: 0x00019BF7 File Offset: 0x00018BF7
			public override void OnClose()
			{
			}

			// Token: 0x040002B4 RID: 692
			private string m_filename;

			// Token: 0x040002B5 RID: 693
			private bool m_append;

			// Token: 0x040002B6 RID: 694
			private Stream m_stream;
		}

		// Token: 0x02000116 RID: 278
		public class InterProcessLock : FileAppender.LockingModelBase
		{
			// Token: 0x0600088A RID: 2186 RVA: 0x00019C04 File Offset: 0x00018C04
			[SecuritySafeCritical]
			public override void OpenFile(string filename, bool append, Encoding encoding)
			{
				try
				{
					this.m_stream = base.CreateStream(filename, append, FileShare.ReadWrite);
				}
				catch (Exception ex)
				{
					base.CurrentAppender.ErrorHandler.Error("Unable to acquire lock on file " + filename + ". " + ex.Message);
				}
			}

			// Token: 0x0600088B RID: 2187 RVA: 0x00019C5C File Offset: 0x00018C5C
			public override void CloseFile()
			{
				try
				{
					base.CloseStream(this.m_stream);
					this.m_stream = null;
				}
				finally
				{
					this.ReleaseLock();
				}
			}

			// Token: 0x0600088C RID: 2188 RVA: 0x00019C98 File Offset: 0x00018C98
			public override Stream AcquireLock()
			{
				if (this.m_mutex != null)
				{
					this.m_mutex.WaitOne();
					this.m_recursiveWatch++;
					if (this.m_stream != null && this.m_stream.CanSeek)
					{
						this.m_stream.Seek(0L, SeekOrigin.End);
					}
				}
				else
				{
					base.CurrentAppender.ErrorHandler.Error("Programming error, no mutex available to acquire lock! From here on things will be dangerous!");
				}
				return this.m_stream;
			}

			// Token: 0x0600088D RID: 2189 RVA: 0x00019D08 File Offset: 0x00018D08
			public override void ReleaseLock()
			{
				if (this.m_mutex != null)
				{
					if (this.m_recursiveWatch > 0)
					{
						this.m_recursiveWatch--;
						this.m_mutex.ReleaseMutex();
						return;
					}
				}
				else
				{
					base.CurrentAppender.ErrorHandler.Error("Programming error, no mutex available to release the lock!");
				}
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x00019D58 File Offset: 0x00018D58
			public override void ActivateOptions()
			{
				if (this.m_mutex == null)
				{
					string name = base.CurrentAppender.File.Replace("\\", "_").Replace(":", "_").Replace("/", "_");
					this.m_mutex = new Mutex(false, name);
					return;
				}
				base.CurrentAppender.ErrorHandler.Error("Programming error, mutex already initialized!");
			}

			// Token: 0x0600088F RID: 2191 RVA: 0x00019DC9 File Offset: 0x00018DC9
			public override void OnClose()
			{
				if (this.m_mutex != null)
				{
					this.m_mutex.Dispose();
					this.m_mutex = null;
					return;
				}
				base.CurrentAppender.ErrorHandler.Error("Programming error, mutex not initialized!");
			}

			// Token: 0x040002B7 RID: 695
			private Mutex m_mutex;

			// Token: 0x040002B8 RID: 696
			private Stream m_stream;

			// Token: 0x040002B9 RID: 697
			private int m_recursiveWatch;
		}
	}
}
