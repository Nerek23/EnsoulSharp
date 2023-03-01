using System;

namespace EnsoulSharp.SDK.Utility
{
	// Token: 0x02000084 RID: 132
	public static class Version
	{
		// Token: 0x060004E1 RID: 1249 RVA: 0x00024760 File Offset: 0x00022960
		static Version()
		{
			Version.Build = Version.GameVersion.Build;
			Version.Revision = Version.GameVersion.Revision;
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x000247B8 File Offset: 0x000229B8
		public static bool IsEqual(string version)
		{
			return Version.GameVersion == new Version(version);
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x000247CA File Offset: 0x000229CA
		public static bool IsNewer(string version)
		{
			return Version.GameVersion > new Version(version);
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x000247DC File Offset: 0x000229DC
		public static bool IsOlder(string version)
		{
			return Version.GameVersion < new Version(version);
		}

		// Token: 0x040002B5 RID: 693
		public static Version GameVersion = new Version(Game.Version);

		// Token: 0x040002B6 RID: 694
		public static int Build;

		// Token: 0x040002B7 RID: 695
		public static int MajorVersion = Version.GameVersion.Major;

		// Token: 0x040002B8 RID: 696
		public static int MinorVersion = Version.GameVersion.Minor;

		// Token: 0x040002B9 RID: 697
		public static int Revision;
	}
}
