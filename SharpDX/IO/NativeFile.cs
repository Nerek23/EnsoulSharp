using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpDX.IO
{
	// Token: 0x02000095 RID: 149
	public static class NativeFile
	{
		// Token: 0x06000316 RID: 790 RVA: 0x000091D0 File Offset: 0x000073D0
		public static bool Exists(string filePath)
		{
			try
			{
				NativeFile.WIN32_FILE_ATTRIBUTE_DATA win32_FILE_ATTRIBUTE_DATA;
				if (NativeFile.GetFileAttributesEx(filePath, 0, out win32_FILE_ATTRIBUTE_DATA))
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00009204 File Offset: 0x00007404
		public static byte[] ReadAllBytes(string path)
		{
			byte[] array;
			using (NativeFileStream nativeFileStream = new NativeFileStream(path, NativeFileMode.Open, (NativeFileAccess)2147483648U, NativeFileShare.Read))
			{
				int num = 0;
				long length = nativeFileStream.Length;
				if (length > 2147483647L)
				{
					throw new IOException("File too long");
				}
				int i = (int)length;
				array = new byte[i];
				while (i > 0)
				{
					int num2 = nativeFileStream.Read(array, num, i);
					if (num2 == 0)
					{
						throw new EndOfStreamException();
					}
					num += num2;
					i -= num2;
				}
			}
			return array;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00009288 File Offset: 0x00007488
		public static string ReadAllText(string path)
		{
			return NativeFile.ReadAllText(path, Encoding.UTF8, NativeFileShare.Read);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00009298 File Offset: 0x00007498
		public static string ReadAllText(string path, Encoding encoding, NativeFileShare sharing = NativeFileShare.Read)
		{
			string result;
			using (NativeFileStream nativeFileStream = new NativeFileStream(path, NativeFileMode.Open, (NativeFileAccess)2147483648U, sharing))
			{
				using (StreamReader streamReader = new StreamReader(nativeFileStream, encoding, true, 1024))
				{
					result = streamReader.ReadToEnd();
				}
			}
			return result;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000092FC File Offset: 0x000074FC
		public static DateTime GetLastWriteTime(string path)
		{
			NativeFile.WIN32_FILE_ATTRIBUTE_DATA win32_FILE_ATTRIBUTE_DATA;
			if (NativeFile.GetFileAttributesEx(path, 0, out win32_FILE_ATTRIBUTE_DATA))
			{
				return win32_FILE_ATTRIBUTE_DATA.LastWriteTime.ToDateTime().ToLocalTime();
			}
			return new DateTime(0L);
		}

		// Token: 0x0600031B RID: 795
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool ReadFile(IntPtr fileHandle, IntPtr buffer, int numberOfBytesToRead, out int numberOfBytesRead, IntPtr overlapped);

		// Token: 0x0600031C RID: 796
		[DllImport("kernel32.dll", SetLastError = true)]
		internal static extern bool FlushFileBuffers(IntPtr hFile);

		// Token: 0x0600031D RID: 797
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool WriteFile(IntPtr fileHandle, IntPtr buffer, int numberOfBytesToRead, out int numberOfBytesRead, IntPtr overlapped);

		// Token: 0x0600031E RID: 798
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool SetFilePointerEx(IntPtr handle, long distanceToMove, out long distanceToMoveHigh, SeekOrigin seekOrigin);

		// Token: 0x0600031F RID: 799
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool SetEndOfFile(IntPtr handle);

		// Token: 0x06000320 RID: 800
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFileAttributesExW", SetLastError = true)]
		internal static extern bool GetFileAttributesEx(string name, int fileInfoLevel, out NativeFile.WIN32_FILE_ATTRIBUTE_DATA lpFileInformation);

		// Token: 0x06000321 RID: 801
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile", SetLastError = true)]
		internal static extern IntPtr Create(string fileName, NativeFileAccess desiredAccess, NativeFileShare shareMode, IntPtr securityAttributes, NativeFileMode mode, NativeFileOptions flagsAndOptions, IntPtr templateFile);

		// Token: 0x06000322 RID: 802
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern bool GetFileSizeEx(IntPtr handle, out long fileSize);

		// Token: 0x0400119A RID: 4506
		private const string KERNEL_FILE = "kernel32.dll";

		// Token: 0x02000096 RID: 150
		internal struct FILETIME
		{
			// Token: 0x06000323 RID: 803 RVA: 0x00009330 File Offset: 0x00007530
			public DateTime ToDateTime()
			{
				return DateTime.FromFileTimeUtc((long)((ulong)this.DateTimeHigh << 32 | (ulong)this.DateTimeLow));
			}

			// Token: 0x0400119B RID: 4507
			public uint DateTimeLow;

			// Token: 0x0400119C RID: 4508
			public uint DateTimeHigh;
		}

		// Token: 0x02000097 RID: 151
		internal struct WIN32_FILE_ATTRIBUTE_DATA
		{
			// Token: 0x0400119D RID: 4509
			public uint FileAttributes;

			// Token: 0x0400119E RID: 4510
			public NativeFile.FILETIME CreationTime;

			// Token: 0x0400119F RID: 4511
			public NativeFile.FILETIME LastAccessTime;

			// Token: 0x040011A0 RID: 4512
			public NativeFile.FILETIME LastWriteTime;

			// Token: 0x040011A1 RID: 4513
			public uint FileSizeHigh;

			// Token: 0x040011A2 RID: 4514
			public uint FileSizeLow;
		}
	}
}
