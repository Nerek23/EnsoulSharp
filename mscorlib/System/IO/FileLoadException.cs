using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;

namespace System.IO
{
	/// <summary>The exception that is thrown when a managed assembly is found but cannot be loaded.</summary>
	// Token: 0x02000185 RID: 389
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public class FileLoadException : IOException
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class, setting the <see cref="P:System.Exception.Message" /> property of the new instance to a system-supplied message that describes the error, such as "Could not load the specified file." This message takes into account the current system culture.</summary>
		// Token: 0x06001811 RID: 6161 RVA: 0x0004D3F4 File Offset: 0x0004B5F4
		[__DynamicallyInvokable]
		public FileLoadException() : base(Environment.GetResourceString("IO.FileLoad"))
		{
			base.SetErrorCode(-2146232799);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class with the specified error message.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		// Token: 0x06001812 RID: 6162 RVA: 0x0004D411 File Offset: 0x0004B611
		[__DynamicallyInvokable]
		public FileLoadException(string message) : base(message)
		{
			base.SetErrorCode(-2146232799);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06001813 RID: 6163 RVA: 0x0004D425 File Offset: 0x0004B625
		[__DynamicallyInvokable]
		public FileLoadException(string message, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232799);
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class with a specified error message and the name of the file that could not be loaded.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		/// <param name="fileName">A <see cref="T:System.String" /> containing the name of the file that was not loaded.</param>
		// Token: 0x06001814 RID: 6164 RVA: 0x0004D43A File Offset: 0x0004B63A
		[__DynamicallyInvokable]
		public FileLoadException(string message, string fileName) : base(message)
		{
			base.SetErrorCode(-2146232799);
			this._fileName = fileName;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class with a specified error message, the name of the file that could not be loaded, and a reference to the inner exception that is the cause of this exception.</summary>
		/// <param name="message">A <see cref="T:System.String" /> that describes the error. The content of <paramref name="message" /> is intended to be understood by humans. The caller of this constructor is required to ensure that this string has been localized for the current system culture.</param>
		/// <param name="fileName">A <see cref="T:System.String" /> containing the name of the file that was not loaded.</param>
		/// <param name="inner">The exception that is the cause of the current exception. If the <paramref name="inner" /> parameter is not <see langword="null" />, the current exception is raised in a <see langword="catch" /> block that handles the inner exception.</param>
		// Token: 0x06001815 RID: 6165 RVA: 0x0004D455 File Offset: 0x0004B655
		[__DynamicallyInvokable]
		public FileLoadException(string message, string fileName, Exception inner) : base(message, inner)
		{
			base.SetErrorCode(-2146232799);
			this._fileName = fileName;
		}

		/// <summary>Gets the error message and the name of the file that caused this exception.</summary>
		/// <returns>A string containing the error message and the name of the file that caused this exception.</returns>
		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x0004D471 File Offset: 0x0004B671
		[__DynamicallyInvokable]
		public override string Message
		{
			[__DynamicallyInvokable]
			get
			{
				this.SetMessageField();
				return this._message;
			}
		}

		// Token: 0x06001817 RID: 6167 RVA: 0x0004D47F File Offset: 0x0004B67F
		private void SetMessageField()
		{
			if (this._message == null)
			{
				this._message = FileLoadException.FormatFileLoadExceptionMessage(this._fileName, base.HResult);
			}
		}

		/// <summary>Gets the name of the file that causes this exception.</summary>
		/// <returns>A <see cref="T:System.String" /> containing the name of the file with the invalid image, or a null reference if no file name was passed to the constructor for the current instance.</returns>
		// Token: 0x17000297 RID: 663
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x0004D4A0 File Offset: 0x0004B6A0
		[__DynamicallyInvokable]
		public string FileName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._fileName;
			}
		}

		/// <summary>Returns the fully qualified name of the current exception, and possibly the error message, the name of the inner exception, and the stack trace.</summary>
		/// <returns>A string containing the fully qualified name of this exception, and possibly the error message, the name of the inner exception, and the stack trace, depending on which <see cref="T:System.IO.FileLoadException" /> constructor is used.</returns>
		// Token: 0x06001819 RID: 6169 RVA: 0x0004D4A8 File Offset: 0x0004B6A8
		[__DynamicallyInvokable]
		public override string ToString()
		{
			string text = base.GetType().FullName + ": " + this.Message;
			if (this._fileName != null && this._fileName.Length != 0)
			{
				text = text + Environment.NewLine + Environment.GetResourceString("IO.FileName_Name", new object[]
				{
					this._fileName
				});
			}
			if (base.InnerException != null)
			{
				text = text + " ---> " + base.InnerException.ToString();
			}
			if (this.StackTrace != null)
			{
				text = text + Environment.NewLine + this.StackTrace;
			}
			try
			{
				if (this.FusionLog != null)
				{
					if (text == null)
					{
						text = " ";
					}
					text += Environment.NewLine;
					text += Environment.NewLine;
					text += this.FusionLog;
				}
			}
			catch (SecurityException)
			{
			}
			return text;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.IO.FileLoadException" /> class with serialized data.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		// Token: 0x0600181A RID: 6170 RVA: 0x0004D594 File Offset: 0x0004B794
		protected FileLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this._fileName = info.GetString("FileLoad_FileName");
			try
			{
				this._fusionLog = info.GetString("FileLoad_FusionLog");
			}
			catch
			{
				this._fusionLog = null;
			}
		}

		// Token: 0x0600181B RID: 6171 RVA: 0x0004D5E8 File Offset: 0x0004B7E8
		private FileLoadException(string fileName, string fusionLog, int hResult) : base(null)
		{
			base.SetErrorCode(hResult);
			this._fileName = fileName;
			this._fusionLog = fusionLog;
			this.SetMessageField();
		}

		/// <summary>Gets the log file that describes why an assembly load failed.</summary>
		/// <returns>A string containing errors reported by the assembly cache.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600181C RID: 6172 RVA: 0x0004D60C File Offset: 0x0004B80C
		public string FusionLog
		{
			[SecuritySafeCritical]
			[SecurityPermission(SecurityAction.Demand, Flags = (SecurityPermissionFlag.ControlEvidence | SecurityPermissionFlag.ControlPolicy))]
			get
			{
				return this._fusionLog;
			}
		}

		/// <summary>Sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the file name and additional exception information.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x0600181D RID: 6173 RVA: 0x0004D614 File Offset: 0x0004B814
		[SecurityCritical]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("FileLoad_FileName", this._fileName, typeof(string));
			try
			{
				info.AddValue("FileLoad_FusionLog", this.FusionLog, typeof(string));
			}
			catch (SecurityException)
			{
			}
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x0004D674 File Offset: 0x0004B874
		[SecuritySafeCritical]
		internal static string FormatFileLoadExceptionMessage(string fileName, int hResult)
		{
			string format = null;
			FileLoadException.GetFileLoadExceptionMessage(hResult, JitHelpers.GetStringHandleOnStack(ref format));
			string arg = null;
			FileLoadException.GetMessageForHR(hResult, JitHelpers.GetStringHandleOnStack(ref arg));
			return string.Format(CultureInfo.CurrentCulture, format, fileName, arg);
		}

		// Token: 0x0600181F RID: 6175
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetFileLoadExceptionMessage(int hResult, StringHandleOnStack retString);

		// Token: 0x06001820 RID: 6176
		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport("QCall", CharSet = CharSet.Unicode)]
		private static extern void GetMessageForHR(int hresult, StringHandleOnStack retString);

		// Token: 0x04000835 RID: 2101
		private string _fileName;

		// Token: 0x04000836 RID: 2102
		private string _fusionLog;
	}
}
