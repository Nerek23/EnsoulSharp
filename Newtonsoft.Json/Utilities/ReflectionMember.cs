using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities
{
	// Token: 0x02000066 RID: 102
	[NullableContext(2)]
	[Nullable(0)]
	internal class ReflectionMember
	{
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00017A0E File Offset: 0x00015C0E
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x00017A16 File Offset: 0x00015C16
		public Type MemberType { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x00017A1F File Offset: 0x00015C1F
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x00017A27 File Offset: 0x00015C27
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		public Func<object, object> Getter { [return: Nullable(new byte[]
		{
			2,
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			2
		})] set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x00017A30 File Offset: 0x00015C30
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x00017A38 File Offset: 0x00015C38
		[Nullable(new byte[]
		{
			2,
			1,
			2
		})]
		public Action<object, object> Setter { [return: Nullable(new byte[]
		{
			2,
			1,
			2
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			2
		})] set; }
	}
}
