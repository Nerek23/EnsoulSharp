using System;
using System.Runtime.InteropServices;

namespace System.Resources
{
	/// <summary>Informs the resource manager of an app's default culture. This class cannot be inherited.</summary>
	// Token: 0x02000366 RID: 870
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class NeutralResourcesLanguageAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.NeutralResourcesLanguageAttribute" /> class.</summary>
		/// <param name="cultureName">The name of the culture that the current assembly's neutral resources were written in.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="cultureName" /> parameter is <see langword="null" />.</exception>
		// Token: 0x06002BEB RID: 11243 RVA: 0x000A578E File Offset: 0x000A398E
		[__DynamicallyInvokable]
		public NeutralResourcesLanguageAttribute(string cultureName)
		{
			if (cultureName == null)
			{
				throw new ArgumentNullException("cultureName");
			}
			this._culture = cultureName;
			this._fallbackLoc = UltimateResourceFallbackLocation.MainAssembly;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Resources.NeutralResourcesLanguageAttribute" /> class with the specified ultimate resource fallback location.</summary>
		/// <param name="cultureName">The name of the culture that the current assembly's neutral resources were written in.</param>
		/// <param name="location">One of the enumeration values that indicates the location from which to retrieve neutral fallback resources.</param>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="cultureName" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="location" /> is not a member of <see cref="T:System.Resources.UltimateResourceFallbackLocation" />.</exception>
		// Token: 0x06002BEC RID: 11244 RVA: 0x000A57B4 File Offset: 0x000A39B4
		public NeutralResourcesLanguageAttribute(string cultureName, UltimateResourceFallbackLocation location)
		{
			if (cultureName == null)
			{
				throw new ArgumentNullException("cultureName");
			}
			if (!Enum.IsDefined(typeof(UltimateResourceFallbackLocation), location))
			{
				throw new ArgumentException(Environment.GetResourceString("Arg_InvalidNeutralResourcesLanguage_FallbackLoc", new object[]
				{
					location
				}));
			}
			this._culture = cultureName;
			this._fallbackLoc = location;
		}

		/// <summary>Gets the culture name.</summary>
		/// <returns>The name of the default culture for the main assembly.</returns>
		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06002BED RID: 11245 RVA: 0x000A5819 File Offset: 0x000A3A19
		[__DynamicallyInvokable]
		public string CultureName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._culture;
			}
		}

		/// <summary>Gets the location for the <see cref="T:System.Resources.ResourceManager" /> class to use to retrieve neutral resources by using the resource fallback process.</summary>
		/// <returns>One of the enumeration values that indicates the location (main assembly or satellite) from which to retrieve neutral resources.</returns>
		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06002BEE RID: 11246 RVA: 0x000A5821 File Offset: 0x000A3A21
		public UltimateResourceFallbackLocation Location
		{
			get
			{
				return this._fallbackLoc;
			}
		}

		// Token: 0x04001173 RID: 4467
		private string _culture;

		// Token: 0x04001174 RID: 4468
		private UltimateResourceFallbackLocation _fallbackLoc;
	}
}
