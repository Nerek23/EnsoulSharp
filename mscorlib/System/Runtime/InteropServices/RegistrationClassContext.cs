using System;

namespace System.Runtime.InteropServices
{
	/// <summary>Specifies the set of execution contexts in which a class object will be made available for requests to construct instances.</summary>
	// Token: 0x02000947 RID: 2375
	[Flags]
	public enum RegistrationClassContext
	{
		/// <summary>The code that creates and manages objects of this class is a DLL that runs in the same process as the caller of the function specifying the class context.</summary>
		// Token: 0x04002B00 RID: 11008
		InProcessServer = 1,
		/// <summary>The code that manages objects of this class is an in-process handler.</summary>
		// Token: 0x04002B01 RID: 11009
		InProcessHandler = 2,
		/// <summary>The EXE code that creates and manages objects of this class runs on same machine but is loaded in a separate process space.</summary>
		// Token: 0x04002B02 RID: 11010
		LocalServer = 4,
		/// <summary>Not used.</summary>
		// Token: 0x04002B03 RID: 11011
		InProcessServer16 = 8,
		/// <summary>A remote machine context.</summary>
		// Token: 0x04002B04 RID: 11012
		RemoteServer = 16,
		/// <summary>Not used.</summary>
		// Token: 0x04002B05 RID: 11013
		InProcessHandler16 = 32,
		/// <summary>Not used.</summary>
		// Token: 0x04002B06 RID: 11014
		Reserved1 = 64,
		/// <summary>Not used.</summary>
		// Token: 0x04002B07 RID: 11015
		Reserved2 = 128,
		/// <summary>Not used.</summary>
		// Token: 0x04002B08 RID: 11016
		Reserved3 = 256,
		/// <summary>Not used.</summary>
		// Token: 0x04002B09 RID: 11017
		Reserved4 = 512,
		/// <summary>Disallows the downloading of code from the Directory Service or the Internet.</summary>
		// Token: 0x04002B0A RID: 11018
		NoCodeDownload = 1024,
		/// <summary>Not used.</summary>
		// Token: 0x04002B0B RID: 11019
		Reserved5 = 2048,
		/// <summary>Specifies whether activation fails if it uses custom marshaling.</summary>
		// Token: 0x04002B0C RID: 11020
		NoCustomMarshal = 4096,
		/// <summary>Allows the downloading of code from the Directory Service or the Internet.</summary>
		// Token: 0x04002B0D RID: 11021
		EnableCodeDownload = 8192,
		/// <summary>Overrides the logging of failures.</summary>
		// Token: 0x04002B0E RID: 11022
		NoFailureLog = 16384,
		/// <summary>Disables activate-as-activator (AAA) activations for this activation only.</summary>
		// Token: 0x04002B0F RID: 11023
		DisableActivateAsActivator = 32768,
		/// <summary>Enables activate-as-activator (AAA) activations for this activation only.</summary>
		// Token: 0x04002B10 RID: 11024
		EnableActivateAsActivator = 65536,
		/// <summary>Begin this activation from the default context of the current apartment.</summary>
		// Token: 0x04002B11 RID: 11025
		FromDefaultContext = 131072
	}
}
