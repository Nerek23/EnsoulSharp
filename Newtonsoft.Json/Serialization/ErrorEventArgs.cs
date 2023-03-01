﻿using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization
{
	// Token: 0x0200007B RID: 123
	[NullableContext(1)]
	[Nullable(0)]
	public class ErrorEventArgs : EventArgs
	{
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0001BC57 File Offset: 0x00019E57
		[Nullable(2)]
		public object CurrentObject { [NullableContext(2)] get; }

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x0001BC5F File Offset: 0x00019E5F
		public ErrorContext ErrorContext { get; }

		// Token: 0x06000674 RID: 1652 RVA: 0x0001BC67 File Offset: 0x00019E67
		public ErrorEventArgs([Nullable(2)] object currentObject, ErrorContext errorContext)
		{
			this.CurrentObject = currentObject;
			this.ErrorContext = errorContext;
		}
	}
}
