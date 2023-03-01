using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX
{
	// Token: 0x0200001C RID: 28
	[StructLayout(LayoutKind.Sequential)]
	internal class FunctionCallback
	{
		// Token: 0x060000D5 RID: 213 RVA: 0x00003CBB File Offset: 0x00001EBB
		public FunctionCallback(IntPtr pointer)
		{
			this.Pointer = pointer;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003CCA File Offset: 0x00001ECA
		public unsafe FunctionCallback(void* pointer)
		{
			this.Pointer = new IntPtr(pointer);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00003CDE File Offset: 0x00001EDE
		public static explicit operator IntPtr(FunctionCallback value)
		{
			return value.Pointer;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00003CE6 File Offset: 0x00001EE6
		public static implicit operator FunctionCallback(IntPtr value)
		{
			return new FunctionCallback(value);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00003CEE File Offset: 0x00001EEE
		public unsafe static implicit operator void*(FunctionCallback value)
		{
			return (void*)value.Pointer;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003CFB File Offset: 0x00001EFB
		public unsafe static explicit operator FunctionCallback(void* value)
		{
			return new FunctionCallback(value);
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00003D03 File Offset: 0x00001F03
		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}", new object[]
			{
				this.Pointer
			});
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00003D28 File Offset: 0x00001F28
		public string ToString(string format)
		{
			if (format == null)
			{
				return this.ToString();
			}
			return string.Format(CultureInfo.CurrentCulture, "{0}", new object[]
			{
				this.Pointer.ToString(format)
			});
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00003D58 File Offset: 0x00001F58
		public override int GetHashCode()
		{
			return this.Pointer.ToInt32();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00003D65 File Offset: 0x00001F65
		public bool Equals(FunctionCallback other)
		{
			return this.Pointer == other.Pointer;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00003D78 File Offset: 0x00001F78
		public override bool Equals(object value)
		{
			return value != null && value.GetType() == typeof(FunctionCallback) && this.Equals((FunctionCallback)value);
		}

		// Token: 0x04000032 RID: 50
		public IntPtr Pointer;
	}
}
