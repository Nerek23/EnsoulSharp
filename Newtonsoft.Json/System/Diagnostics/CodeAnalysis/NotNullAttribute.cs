﻿using System;

namespace System.Diagnostics.CodeAnalysis
{
	// Token: 0x02000006 RID: 6
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
	internal sealed class NotNullAttribute : Attribute
	{
	}
}
