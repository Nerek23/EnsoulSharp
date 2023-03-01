using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace EnsoulSharp.SDK.Properties
{
	// Token: 0x0200005B RID: 91
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000399 RID: 921 RVA: 0x00019F7A File Offset: 0x0001817A
		internal Resources()
		{
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00019F82 File Offset: 0x00018182
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("EnsoulSharp.SDK.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00019FAE File Offset: 0x000181AE
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00019FB5 File Offset: 0x000181B5
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600039D RID: 925 RVA: 0x00019FBD File Offset: 0x000181BD
		internal static Bitmap notifications_arrow
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_arrow", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600039E RID: 926 RVA: 0x00019FD8 File Offset: 0x000181D8
		internal static Bitmap notifications_check
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_check", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600039F RID: 927 RVA: 0x00019FF3 File Offset: 0x000181F3
		internal static Bitmap notifications_error
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_error", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0001A00E File Offset: 0x0001820E
		internal static Bitmap notifications_select
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_select", Resources.resourceCulture);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0001A029 File Offset: 0x00018229
		internal static Bitmap notifications_star
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_star", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0001A044 File Offset: 0x00018244
		internal static Bitmap notifications_warning
		{
			get
			{
				return (Bitmap)Resources.ResourceManager.GetObject("notifications_warning", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0001A05F File Offset: 0x0001825F
		internal static byte[] pl_PL
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("pl_PL", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0001A07A File Offset: 0x0001827A
		internal static byte[] tr_TR
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("tr_TR", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0001A095 File Offset: 0x00018295
		internal static byte[] vi_VN
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("vi_VN", Resources.resourceCulture);
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0001A0B0 File Offset: 0x000182B0
		internal static byte[] zh_CN
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("zh_CN", Resources.resourceCulture);
			}
		}

		// Token: 0x040001F6 RID: 502
		private static ResourceManager resourceMan;

		// Token: 0x040001F7 RID: 503
		private static CultureInfo resourceCulture;
	}
}
