using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.Win32;

namespace System.IO
{
	/// <summary>Provides access to information on a drive.</summary>
	// Token: 0x0200017F RID: 383
	[ComVisible(true)]
	[Serializable]
	public sealed class DriveInfo : ISerializable
	{
		/// <summary>Provides access to information on the specified drive.</summary>
		/// <param name="driveName">A valid drive path or drive letter. This can be either uppercase or lowercase, 'a' to 'z'. A null value is not valid.</param>
		/// <exception cref="T:System.ArgumentNullException">The drive letter cannot be <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">The first letter of <paramref name="driveName" /> is not an uppercase or lowercase letter from 'a' to 'z'.  
		///  -or-  
		///  <paramref name="driveName" /> does not refer to a valid drive.</exception>
		// Token: 0x06001786 RID: 6022 RVA: 0x0004B61C File Offset: 0x0004981C
		[SecuritySafeCritical]
		public DriveInfo(string driveName)
		{
			if (driveName == null)
			{
				throw new ArgumentNullException("driveName");
			}
			if (driveName.Length == 1)
			{
				this._name = driveName + ":\\";
			}
			else
			{
				Path.CheckInvalidPathChars(driveName, false);
				this._name = Path.GetPathRoot(driveName);
				if (this._name == null || this._name.Length == 0 || this._name.StartsWith("\\\\", StringComparison.Ordinal))
				{
					throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDriveLetterOrRootDir"));
				}
			}
			if (this._name.Length == 2 && this._name[1] == ':')
			{
				this._name += "\\";
			}
			char c = driveName[0];
			if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_MustBeDriveLetterOrRootDir"));
			}
			string path = this._name + ".";
			new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x0004B724 File Offset: 0x00049924
		[SecurityCritical]
		private DriveInfo(SerializationInfo info, StreamingContext context)
		{
			this._name = (string)info.GetValue("_name", typeof(string));
			string path = this._name + ".";
			new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
		}

		/// <summary>Gets the name of a drive, such as C:\.</summary>
		/// <returns>The name of the drive.</returns>
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0004B774 File Offset: 0x00049974
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		/// <summary>Gets the drive type, such as CD-ROM, removable, network, or fixed.</summary>
		/// <returns>One of the enumeration values that specifies a drive type.</returns>
		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x0004B77C File Offset: 0x0004997C
		public DriveType DriveType
		{
			[SecuritySafeCritical]
			get
			{
				return (DriveType)Win32Native.GetDriveType(this.Name);
			}
		}

		/// <summary>Gets the name of the file system, such as NTFS or FAT32.</summary>
		/// <returns>The name of the file system on the specified drive.</returns>
		/// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
		/// <exception cref="T:System.IO.DriveNotFoundException">The drive does not exist or is not mapped.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0004B78C File Offset: 0x0004998C
		public string DriveFormat
		{
			[SecuritySafeCritical]
			get
			{
				StringBuilder volumeName = new StringBuilder(50);
				StringBuilder stringBuilder = new StringBuilder(50);
				int errorMode = Win32Native.SetErrorMode(1);
				try
				{
					int num;
					int num2;
					int num3;
					if (!Win32Native.GetVolumeInformation(this.Name, volumeName, 50, out num, out num2, out num3, stringBuilder, 50))
					{
						int lastWin32Error = Marshal.GetLastWin32Error();
						__Error.WinIODriveError(this.Name, lastWin32Error);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
				return stringBuilder.ToString();
			}
		}

		/// <summary>Gets a value that indicates whether a drive is ready.</summary>
		/// <returns>
		///   <see langword="true" /> if the drive is ready; <see langword="false" /> if the drive is not ready.</returns>
		// Token: 0x1700028A RID: 650
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x0004B804 File Offset: 0x00049A04
		public bool IsReady
		{
			[SecuritySafeCritical]
			get
			{
				return Directory.InternalExists(this.Name);
			}
		}

		/// <summary>Indicates the amount of available free space on a drive, in bytes.</summary>
		/// <returns>The amount of free space available on the drive, in bytes.</returns>
		/// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		// Token: 0x1700028B RID: 651
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x0004B814 File Offset: 0x00049A14
		public long AvailableFreeSpace
		{
			[SecuritySafeCritical]
			get
			{
				int errorMode = Win32Native.SetErrorMode(1);
				long result;
				try
				{
					long num;
					long num2;
					if (!Win32Native.GetDiskFreeSpaceEx(this.Name, out result, out num, out num2))
					{
						__Error.WinIODriveError(this.Name);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
				return result;
			}
		}

		/// <summary>Gets the total amount of free space available on a drive, in bytes.</summary>
		/// <returns>The total free space available on a drive, in bytes.</returns>
		/// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
		/// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x0600178D RID: 6029 RVA: 0x0004B868 File Offset: 0x00049A68
		public long TotalFreeSpace
		{
			[SecuritySafeCritical]
			get
			{
				int errorMode = Win32Native.SetErrorMode(1);
				long result;
				try
				{
					long num;
					long num2;
					if (!Win32Native.GetDiskFreeSpaceEx(this.Name, out num, out num2, out result))
					{
						__Error.WinIODriveError(this.Name);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
				return result;
			}
		}

		/// <summary>Gets the total size of storage space on a drive, in bytes.</summary>
		/// <returns>The total size of the drive, in bytes.</returns>
		/// <exception cref="T:System.UnauthorizedAccessException">Access to the drive information is denied.</exception>
		/// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist.</exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x0004B8BC File Offset: 0x00049ABC
		public long TotalSize
		{
			[SecuritySafeCritical]
			get
			{
				int errorMode = Win32Native.SetErrorMode(1);
				long result;
				try
				{
					long num;
					long num2;
					if (!Win32Native.GetDiskFreeSpaceEx(this.Name, out num, out result, out num2))
					{
						__Error.WinIODriveError(this.Name);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
				return result;
			}
		}

		/// <summary>Retrieves the drive names of all logical drives on a computer.</summary>
		/// <returns>An array of type <see cref="T:System.IO.DriveInfo" /> that represents the logical drives on a computer.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The caller does not have the required permission.</exception>
		// Token: 0x0600178F RID: 6031 RVA: 0x0004B910 File Offset: 0x00049B10
		public static DriveInfo[] GetDrives()
		{
			string[] logicalDrives = Directory.GetLogicalDrives();
			DriveInfo[] array = new DriveInfo[logicalDrives.Length];
			for (int i = 0; i < logicalDrives.Length; i++)
			{
				array[i] = new DriveInfo(logicalDrives[i]);
			}
			return array;
		}

		/// <summary>Gets the root directory of a drive.</summary>
		/// <returns>An object that contains the root directory of the drive.</returns>
		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x0004B946 File Offset: 0x00049B46
		public DirectoryInfo RootDirectory
		{
			get
			{
				return new DirectoryInfo(this.Name);
			}
		}

		/// <summary>Gets or sets the volume label of a drive.</summary>
		/// <returns>The volume label.</returns>
		/// <exception cref="T:System.IO.IOException">An I/O error occurred (for example, a disk error or a drive was not ready).</exception>
		/// <exception cref="T:System.IO.DriveNotFoundException">The drive is not mapped or does not exist.</exception>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		/// <exception cref="T:System.UnauthorizedAccessException">The volume label is being set on a network or CD-ROM drive.  
		///  -or-  
		///  Access to the drive information is denied.</exception>
		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x0004B954 File Offset: 0x00049B54
		// (set) Token: 0x06001792 RID: 6034 RVA: 0x0004B9D8 File Offset: 0x00049BD8
		public string VolumeLabel
		{
			[SecuritySafeCritical]
			get
			{
				StringBuilder stringBuilder = new StringBuilder(50);
				StringBuilder fileSystemName = new StringBuilder(50);
				int errorMode = Win32Native.SetErrorMode(1);
				try
				{
					int num;
					int num2;
					int num3;
					if (!Win32Native.GetVolumeInformation(this.Name, stringBuilder, 50, out num, out num2, out num3, fileSystemName, 50))
					{
						int num4 = Marshal.GetLastWin32Error();
						if (num4 == 13)
						{
							num4 = 15;
						}
						__Error.WinIODriveError(this.Name, num4);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
				return stringBuilder.ToString();
			}
			[SecuritySafeCritical]
			set
			{
				string path = this._name + ".";
				new FileIOPermission(FileIOPermissionAccess.Write, path).Demand();
				int errorMode = Win32Native.SetErrorMode(1);
				try
				{
					if (!Win32Native.SetVolumeLabel(this.Name, value))
					{
						int lastWin32Error = Marshal.GetLastWin32Error();
						if (lastWin32Error == 5)
						{
							throw new UnauthorizedAccessException(Environment.GetResourceString("InvalidOperation_SetVolumeLabelFailed"));
						}
						__Error.WinIODriveError(this.Name, lastWin32Error);
					}
				}
				finally
				{
					Win32Native.SetErrorMode(errorMode);
				}
			}
		}

		/// <summary>Returns a drive name as a string.</summary>
		/// <returns>The name of the drive.</returns>
		// Token: 0x06001793 RID: 6035 RVA: 0x0004BA5C File Offset: 0x00049C5C
		public override string ToString()
		{
			return this.Name;
		}

		/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> object with the data needed to serialize the target object.</summary>
		/// <param name="info">The object to populate with data.</param>
		/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
		// Token: 0x06001794 RID: 6036 RVA: 0x0004BA64 File Offset: 0x00049C64
		[SecurityCritical]
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_name", this._name, typeof(string));
		}

		// Token: 0x0400082B RID: 2091
		private string _name;

		// Token: 0x0400082C RID: 2092
		private const string NameField = "_name";
	}
}
