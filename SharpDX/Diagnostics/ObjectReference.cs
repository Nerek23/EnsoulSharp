using System;
using System.Globalization;
using System.Text;

namespace SharpDX.Diagnostics
{
	// Token: 0x020000AB RID: 171
	public class ObjectReference
	{
		// Token: 0x0600034F RID: 847 RVA: 0x000098DE File Offset: 0x00007ADE
		public ObjectReference(DateTime creationTime, ComObject comObject, string stackTrace)
		{
			this.CreationTime = creationTime;
			this.Object = new WeakReference(comObject, true);
			this.StackTrace = stackTrace;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000350 RID: 848 RVA: 0x00009901 File Offset: 0x00007B01
		// (set) Token: 0x06000351 RID: 849 RVA: 0x00009909 File Offset: 0x00007B09
		public DateTime CreationTime { get; private set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000352 RID: 850 RVA: 0x00009912 File Offset: 0x00007B12
		// (set) Token: 0x06000353 RID: 851 RVA: 0x0000991A File Offset: 0x00007B1A
		public WeakReference Object { get; private set; }

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000354 RID: 852 RVA: 0x00009923 File Offset: 0x00007B23
		// (set) Token: 0x06000355 RID: 853 RVA: 0x0000992B File Offset: 0x00007B2B
		public string StackTrace { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000356 RID: 854 RVA: 0x00009934 File Offset: 0x00007B34
		public bool IsAlive
		{
			get
			{
				return this.Object.IsAlive;
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00009944 File Offset: 0x00007B44
		public override string ToString()
		{
			ComObject comObject = this.Object.Target as ComObject;
			if (comObject == null)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", new object[]
			{
				comObject.NativePointer.ToInt64(),
				comObject.GetType().FullName,
				this.CreationTime,
				this.StackTrace
			}).AppendLine();
			return stringBuilder.ToString();
		}
	}
}
