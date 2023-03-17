﻿using System;
using System.Runtime.InteropServices;

namespace System
{
	/// <summary>Used to set the default loader optimization policy for the main method of an executable application.</summary>
	// Token: 0x020000A1 RID: 161
	[AttributeUsage(AttributeTargets.Method)]
	[ComVisible(true)]
	public sealed class LoaderOptimizationAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.LoaderOptimizationAttribute" /> class to the specified value.</summary>
		/// <param name="value">A value equivalent to a <see cref="T:System.LoaderOptimization" /> constant.</param>
		// Token: 0x06000960 RID: 2400 RVA: 0x0001E8CA File Offset: 0x0001CACA
		public LoaderOptimizationAttribute(byte value)
		{
			this._val = value;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.LoaderOptimizationAttribute" /> class to the specified value.</summary>
		/// <param name="value">A <see cref="T:System.LoaderOptimization" /> constant.</param>
		// Token: 0x06000961 RID: 2401 RVA: 0x0001E8D9 File Offset: 0x0001CAD9
		public LoaderOptimizationAttribute(LoaderOptimization value)
		{
			this._val = (byte)value;
		}

		/// <summary>Gets the current <see cref="T:System.LoaderOptimization" /> value for this instance.</summary>
		/// <returns>A <see cref="T:System.LoaderOptimization" /> constant.</returns>
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x0001E8E9 File Offset: 0x0001CAE9
		public LoaderOptimization Value
		{
			get
			{
				return (LoaderOptimization)this._val;
			}
		}

		// Token: 0x040003BE RID: 958
		internal byte _val;
	}
}
