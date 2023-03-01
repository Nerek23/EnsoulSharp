using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace SharpDX.Win32
{
	// Token: 0x0200004D RID: 77
	internal class ComStringEnumerator : IEnumerator<string>, IDisposable, IEnumerator, IEnumerable<string>, IEnumerable
	{
		// Token: 0x06000238 RID: 568 RVA: 0x000069D8 File Offset: 0x00004BD8
		public ComStringEnumerator(IntPtr ptrToIEnumString)
		{
			this.enumString = (IEnumString)Marshal.GetObjectForIUnknown(ptrToIEnumString);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x000022F0 File Offset: 0x000004F0
		public void Dispose()
		{
		}

		// Token: 0x0600023A RID: 570 RVA: 0x000069F4 File Offset: 0x00004BF4
		public unsafe bool MoveNext()
		{
			string[] array = new string[1];
			int num = 0;
			bool flag = this.enumString.Next(1, array, new IntPtr((void*)(&num))) == Result.Ok.Code;
			this.current = (flag ? array[0] : null);
			return flag;
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00006A3F File Offset: 0x00004C3F
		public void Reset()
		{
			this.enumString.Reset();
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00006A4C File Offset: 0x00004C4C
		public string Current
		{
			get
			{
				return this.current;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00006A54 File Offset: 0x00004C54
		object IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x000041A4 File Offset: 0x000023A4
		public IEnumerator<string> GetEnumerator()
		{
			return this;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00006A5C File Offset: 0x00004C5C
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x040000A3 RID: 163
		private readonly IEnumString enumString;

		// Token: 0x040000A4 RID: 164
		private string current;
	}
}
