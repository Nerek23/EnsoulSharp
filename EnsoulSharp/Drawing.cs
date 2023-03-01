using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using EnsoulSharp.Native;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct3D9;
using SharpDX.DXGI;

namespace EnsoulSharp
{
	/// <summary>
	/// 	This class contains everything we can offer related to drawing.
	/// </summary>
	// Token: 0x02000101 RID: 257
	public class Drawing
	{
		// Token: 0x060005AD RID: 1453 RVA: 0x000091B4 File Offset: 0x000085B4
		static Drawing()
		{
			AppDomain.CurrentDomain.DomainUnload += Drawing.DomainUnloadEventHandler;
			Drawing.m_DrawNativeDelegate = new Drawing.OnDrawNativeDelegate(Drawing.OnDrawNative);
			Drawing.m_DrawNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnDrawNativeDelegate>(Drawing.m_DrawNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingDrawHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_DrawNative.ToPointer());
			Drawing.m_BeginSceneNativeDelegate = new Drawing.OnBeginSceneNativeDelegate(Drawing.OnBeginSceneNative);
			Drawing.m_BeginSceneNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnBeginSceneNativeDelegate>(Drawing.m_BeginSceneNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingBeginSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_BeginSceneNative.ToPointer());
			Drawing.m_EndSceneNativeDelegate = new Drawing.OnEndSceneNativeDelegate(Drawing.OnEndSceneNative);
			Drawing.m_EndSceneNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnEndSceneNativeDelegate>(Drawing.m_EndSceneNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingEndSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_EndSceneNative.ToPointer());
			Drawing.m_FlushDrawNativeDelegate = new Drawing.OnFlushDrawNativeDelegate(Drawing.OnFlushDrawNative);
			Drawing.m_FlushDrawNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnFlushDrawNativeDelegate>(Drawing.m_FlushDrawNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingFlushDrawHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_FlushDrawNative.ToPointer());
			Drawing.m_FlushEndSceneNativeDelegate = new Drawing.OnFlushEndSceneNativeDelegate(Drawing.OnFlushEndSceneNative);
			Drawing.m_FlushEndSceneNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnFlushEndSceneNativeDelegate>(Drawing.m_FlushEndSceneNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingFlushEndSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_FlushEndSceneNative.ToPointer());
			Drawing.m_PreResetNativeDelegate = new Drawing.OnPreResetNativeDelegate(Drawing.OnPreResetNative);
			Drawing.m_PreResetNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnPreResetNativeDelegate>(Drawing.m_PreResetNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPreResetHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PreResetNative.ToPointer());
			Drawing.m_PostResetNativeDelegate = new Drawing.OnPostResetNativeDelegate(Drawing.OnPostResetNative);
			Drawing.m_PostResetNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnPostResetNativeDelegate>(Drawing.m_PostResetNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPostResetHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PostResetNative.ToPointer());
			Drawing.m_PresentNativeDelegate = new Drawing.OnPresentNativeDelegate(Drawing.OnPresentNative);
			Drawing.m_PresentNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnPresentNativeDelegate>(Drawing.m_PresentNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPresentHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PresentNative.ToPointer());
			Drawing.m_RenderMouseOversNativeDelegate = new Drawing.OnRenderMouseOversNativeDelegate(Drawing.OnRenderMouseOversNative);
			Drawing.m_RenderMouseOversNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnRenderMouseOversNativeDelegate>(Drawing.m_RenderMouseOversNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingRenderMouseOversHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_RenderMouseOversNative.ToPointer());
			Drawing.m_D3D11PresentNativeDelegate = new Drawing.OnD3D11PresentNativeDelegate(Drawing.OnD3D11PresentNative);
			Drawing.m_D3D11PresentNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnD3D11PresentNativeDelegate>(Drawing.m_D3D11PresentNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PresentHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PresentNative.ToPointer());
			Drawing.m_D3D11PreResizeBuffersNativeDelegate = new Drawing.OnD3D11PreResizeBuffersNativeDelegate(Drawing.OnD3D11PreResizeBuffersNative);
			Drawing.m_D3D11PreResizeBuffersNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnD3D11PreResizeBuffersNativeDelegate>(Drawing.m_D3D11PreResizeBuffersNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PreResizeBuffersHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PreResizeBuffersNative.ToPointer());
			Drawing.m_D3D11PostResizeBuffersNativeDelegate = new Drawing.OnD3D11PostResizeBuffersNativeDelegate(Drawing.OnD3D11PostResizeBuffersNative);
			Drawing.m_D3D11PostResizeBuffersNative = Marshal.GetFunctionPointerForDelegate<Drawing.OnD3D11PostResizeBuffersNativeDelegate>(Drawing.m_D3D11PostResizeBuffersNativeDelegate);
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Add(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PostResizeBuffersHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PostResizeBuffersNative.ToPointer());
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x000067E4 File Offset: 0x00005BE4
		internal static void DomainUnloadEventHandler(object sender, EventArgs e)
		{
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingDrawHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_DrawNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingBeginSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_BeginSceneNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingEndSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_EndSceneNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingFlushDrawHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_FlushDrawNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingFlushEndSceneHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_FlushEndSceneNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPreResetHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PreResetNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPostResetHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PostResetNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingPresentHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_PresentNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingRenderMouseOversHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_RenderMouseOversNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PresentHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PresentNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PreResizeBuffersHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PreResizeBuffersNative.ToPointer());
			<Module>.EnsoulSharp.Native.EventHandler<void\u0020(__cdecl*)(void)>.Remove(<Module>.EnsoulSharp.Native.EventAdapter.GetDrawingD3D11PostResizeBuffersHandler(<Module>.EnsoulSharp.Native.EventAdapter.GetInstance()), Drawing.m_D3D11PostResizeBuffersNative.ToPointer());
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00006920 File Offset: 0x00005D20
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnDrawNative()
		{
			DrawingDraw[] array = null;
			try
			{
				foreach (DrawingDraw drawingDraw in Drawing.DrawHandlers.ToArray())
				{
					try
					{
						drawingDraw(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00006BCC File Offset: 0x00005FCC
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnBeginSceneNative()
		{
			DrawingBeginScene[] array = null;
			try
			{
				foreach (DrawingBeginScene drawingBeginScene in Drawing.BeginSceneHandlers.ToArray())
				{
					try
					{
						drawingBeginScene(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00006E78 File Offset: 0x00006278
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnEndSceneNative()
		{
			DrawingEndScene[] array = null;
			try
			{
				foreach (DrawingEndScene drawingEndScene in Drawing.EndSceneHandlers.ToArray())
				{
					try
					{
						drawingEndScene(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00007124 File Offset: 0x00006524
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal static void OnFlushDrawNative()
		{
			DrawingFlushDraw[] array = null;
			try
			{
				foreach (DrawingFlushDraw drawingFlushDraw in Drawing.FlushDrawHandlers.ToArray())
				{
					try
					{
						drawingFlushDraw(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x000073D0 File Offset: 0x000067D0
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal static void OnFlushEndSceneNative()
		{
			DrawingFlushEndScene[] array = null;
			try
			{
				foreach (DrawingFlushEndScene drawingFlushEndScene in Drawing.FlushEndSceneHandlers.ToArray())
				{
					try
					{
						drawingFlushEndScene(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0000767C File Offset: 0x00006A7C
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnPreResetNative()
		{
			DrawingPreReset[] array = null;
			try
			{
				foreach (DrawingPreReset drawingPreReset in Drawing.PreResetHandlers.ToArray())
				{
					try
					{
						drawingPreReset(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00007928 File Offset: 0x00006D28
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal static void OnPostResetNative()
		{
			DrawingPostReset[] array = null;
			try
			{
				foreach (DrawingPostReset drawingPostReset in Drawing.PostResetHandlers.ToArray())
				{
					try
					{
						drawingPostReset(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00007BD4 File Offset: 0x00006FD4
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnPresentNative()
		{
			DrawingPresent[] array = null;
			try
			{
				foreach (DrawingPresent drawingPresent in Drawing.PresentHandlers.ToArray())
				{
					try
					{
						drawingPresent(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00007E80 File Offset: 0x00007280
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnRenderMouseOversNative()
		{
			DrawingRenderMouseOvers[] array = null;
			try
			{
				foreach (DrawingRenderMouseOvers drawingRenderMouseOvers in Drawing.RenderMouseOversHandlers.ToArray())
				{
					try
					{
						drawingRenderMouseOvers(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0000812C File Offset: 0x0000752C
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal static void OnD3D11PresentNative()
		{
			DrawingD3D11Present[] array = null;
			try
			{
				foreach (DrawingD3D11Present drawingD3D11Present in Drawing.D3D11PresentHandlers.ToArray())
				{
					try
					{
						drawingD3D11Present(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x000083D8 File Offset: 0x000077D8
		[SecurityCritical]
		[HandleProcessCorruptedStateExceptions]
		internal static void OnD3D11PreResizeBuffersNative()
		{
			DrawingD3D11PreResizeBuffers[] array = null;
			try
			{
				foreach (DrawingD3D11PreResizeBuffers drawingD3D11PreResizeBuffers in Drawing.D3D11PreResizeBuffersHandlers.ToArray())
				{
					try
					{
						drawingD3D11PreResizeBuffers(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00008684 File Offset: 0x00007A84
		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal static void OnD3D11PostResizeBuffersNative()
		{
			DrawingD3D11PostResizeBuffers[] array = null;
			try
			{
				foreach (DrawingD3D11PostResizeBuffers drawingD3D11PostResizeBuffers in Drawing.D3D11PostResizeBuffersHandlers.ToArray())
				{
					try
					{
						drawingD3D11PostResizeBuffers(EventArgs.Empty);
					}
					catch (Exception ex)
					{
						Console.WriteLine();
						Console.WriteLine("========================================");
						Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
						Console.WriteLine();
						Console.WriteLine("Type: {0}", ex.GetType().FullName);
						Console.WriteLine("Message: {0}", ex.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(ex.StackTrace);
						Exception innerException = ex.InnerException;
						if (innerException != null)
						{
							Console.WriteLine();
							Console.WriteLine("InnerException(s):");
							do
							{
								Console.WriteLine("----------------------------------------");
								Console.WriteLine("Type: {0}", innerException.GetType().FullName);
								Console.WriteLine("Message: {0}", innerException.Message);
								Console.WriteLine();
								Console.WriteLine("Stracktrace:");
								Console.WriteLine(innerException.StackTrace);
								innerException = innerException.InnerException;
							}
							while (innerException != null);
							Console.WriteLine("----------------------------------------");
						}
						Console.WriteLine("========================================");
						Console.WriteLine();
						string newValue = "";
						Log.Error(ex.ToString().Replace("\r", newValue).Replace("\n", newValue));
					}
				}
			}
			catch (Exception ex2)
			{
				Console.WriteLine();
				Console.WriteLine("========================================");
				Console.WriteLine("Exception detected in EnsoulSharp .NET Wrapper");
				Console.WriteLine();
				Console.WriteLine("Type: {0}", ex2.GetType().FullName);
				Console.WriteLine("Message: {0}", ex2.Message);
				Console.WriteLine();
				Console.WriteLine("Stracktrace:");
				Console.WriteLine(ex2.StackTrace);
				Exception innerException2 = ex2.InnerException;
				if (innerException2 != null)
				{
					Console.WriteLine();
					Console.WriteLine("InnerException(s):");
					do
					{
						Console.WriteLine("----------------------------------------");
						Console.WriteLine("Type: {0}", innerException2.GetType().FullName);
						Console.WriteLine("Message: {0}", innerException2.Message);
						Console.WriteLine();
						Console.WriteLine("Stracktrace:");
						Console.WriteLine(innerException2.StackTrace);
						innerException2 = innerException2.InnerException;
					}
					while (innerException2 != null);
					Console.WriteLine("----------------------------------------");
				}
				Console.WriteLine("========================================");
				Console.WriteLine();
				string newValue = "";
				Log.Error(ex2.ToString().Replace("\r", newValue).Replace("\n", newValue));
			}
		}

		/// <summary>
		/// 	This event is fired before game hud and menu gui draw.
		/// </summary>
		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060005BB RID: 1467 RVA: 0x00008930 File Offset: 0x00007D30
		// (remove) Token: 0x060005BC RID: 1468 RVA: 0x00008948 File Offset: 0x00007D48
		public static event DrawingDraw OnDraw
		{
			add
			{
				Drawing.DrawHandlers.Add(value);
			}
			remove
			{
				Drawing.DrawHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after D3D9.BeginScene.
		/// </summary>
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060005BD RID: 1469 RVA: 0x00008964 File Offset: 0x00007D64
		// (remove) Token: 0x060005BE RID: 1470 RVA: 0x0000897C File Offset: 0x00007D7C
		public static event DrawingBeginScene OnBeginScene
		{
			add
			{
				Drawing.BeginSceneHandlers.Add(value);
			}
			remove
			{
				Drawing.BeginSceneHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before D3D9.EndScene.
		/// </summary>
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060005BF RID: 1471 RVA: 0x00008998 File Offset: 0x00007D98
		// (remove) Token: 0x060005C0 RID: 1472 RVA: 0x000089B0 File Offset: 0x00007DB0
		public static event DrawingEndScene OnEndScene
		{
			add
			{
				Drawing.EndSceneHandlers.Add(value);
			}
			remove
			{
				Drawing.EndSceneHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after game draw and isn't controlled by Hacks.DisableDrawings and Hacks.HideDrawingsFromCapture.
		/// </summary>
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060005C1 RID: 1473 RVA: 0x000089CC File Offset: 0x00007DCC
		// (remove) Token: 0x060005C2 RID: 1474 RVA: 0x000089E4 File Offset: 0x00007DE4
		public static event DrawingFlushDraw OnFlushDraw
		{
			add
			{
				Drawing.FlushDrawHandlers.Add(value);
			}
			remove
			{
				Drawing.FlushDrawHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after OnEndScene and isn't controlled by Hacks.DisableDrawings and Hacks.HideDrawingsFromCapture.
		/// </summary>
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060005C3 RID: 1475 RVA: 0x00008A00 File Offset: 0x00007E00
		// (remove) Token: 0x060005C4 RID: 1476 RVA: 0x00008A18 File Offset: 0x00007E18
		[Obsolete("This event doesn't work on Direct3D11. Please use Drawing.OnFlushDraw instead.", false)]
		public static event DrawingFlushEndScene OnFlushEndScene
		{
			add
			{
				Drawing.FlushEndSceneHandlers.Add(value);
			}
			remove
			{
				Drawing.FlushEndSceneHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before D3D9.Reset.
		/// </summary>
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060005C5 RID: 1477 RVA: 0x00008A34 File Offset: 0x00007E34
		// (remove) Token: 0x060005C6 RID: 1478 RVA: 0x00008A4C File Offset: 0x00007E4C
		public static event DrawingPreReset OnPreReset
		{
			add
			{
				Drawing.PreResetHandlers.Add(value);
			}
			remove
			{
				Drawing.PreResetHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after D3D9.Reset.
		/// </summary>
		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060005C7 RID: 1479 RVA: 0x00008A68 File Offset: 0x00007E68
		// (remove) Token: 0x060005C8 RID: 1480 RVA: 0x00008A80 File Offset: 0x00007E80
		public static event DrawingPostReset OnPostReset
		{
			add
			{
				Drawing.PostResetHandlers.Add(value);
			}
			remove
			{
				Drawing.PostResetHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before D3D9.Present.
		/// </summary>
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060005C9 RID: 1481 RVA: 0x00008A9C File Offset: 0x00007E9C
		// (remove) Token: 0x060005CA RID: 1482 RVA: 0x00008AB4 File Offset: 0x00007EB4
		public static event DrawingPresent OnPresent
		{
			add
			{
				Drawing.PresentHandlers.Add(value);
			}
			remove
			{
				Drawing.PresentHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after game render mouse overs and it's only used for AttackableUnit.Glow.
		/// </summary>
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060005CB RID: 1483 RVA: 0x00008AD0 File Offset: 0x00007ED0
		// (remove) Token: 0x060005CC RID: 1484 RVA: 0x00008AE8 File Offset: 0x00007EE8
		public static event DrawingRenderMouseOvers OnRenderMouseOvers
		{
			add
			{
				Drawing.RenderMouseOversHandlers.Add(value);
			}
			remove
			{
				Drawing.RenderMouseOversHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before D3D11.Present.
		/// </summary>
		// Token: 0x1400001C RID: 28
		// (add) Token: 0x060005CD RID: 1485 RVA: 0x00008B04 File Offset: 0x00007F04
		// (remove) Token: 0x060005CE RID: 1486 RVA: 0x00008B1C File Offset: 0x00007F1C
		public static event DrawingD3D11Present OnD3D11Present
		{
			add
			{
				Drawing.D3D11PresentHandlers.Add(value);
			}
			remove
			{
				Drawing.D3D11PresentHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired before D3D11.ResizeBuffers.
		/// </summary>
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x060005CF RID: 1487 RVA: 0x00008B38 File Offset: 0x00007F38
		// (remove) Token: 0x060005D0 RID: 1488 RVA: 0x00008B50 File Offset: 0x00007F50
		public static event DrawingD3D11PreResizeBuffers OnD3D11PreResizeBuffers
		{
			add
			{
				Drawing.D3D11PreResizeBuffersHandlers.Add(value);
			}
			remove
			{
				Drawing.D3D11PreResizeBuffersHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	This event is fired after D3D11.ResizeBuffers.
		/// </summary>
		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060005D1 RID: 1489 RVA: 0x00008B6C File Offset: 0x00007F6C
		// (remove) Token: 0x060005D2 RID: 1490 RVA: 0x00008B84 File Offset: 0x00007F84
		public static event DrawingD3D11PostResizeBuffers OnD3D11PostResizeBuffers
		{
			add
			{
				Drawing.D3D11PostResizeBuffersHandlers.Add(value);
			}
			remove
			{
				Drawing.D3D11PostResizeBuffersHandlers.Remove(value);
			}
		}

		/// <summary>
		/// 	Gets the x3d platform of the game.
		/// </summary>
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x00008BA0 File Offset: 0x00007FA0
		public unsafe static X3DPlatform Platform
		{
			get
			{
				r3dRenderLayer* ptr = <Module>.EnsoulSharp.Native.r3dRenderLayer.GetInstance();
				if (ptr != null)
				{
					return (X3DPlatform)(*<Module>.EnsoulSharp.Native.r3dRenderLayer.GetPlatform(ptr));
				}
				return X3DPlatform.Unknown;
			}
		}

		/// <summary>
		/// 	Gets the direct3d9 device of the game.
		/// </summary>
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00008BC0 File Offset: 0x00007FC0
		public unsafe static SharpDX.Direct3D9.Device Direct3DDevice9
		{
			get
			{
				DX9Device* ptr = <Module>.EnsoulSharp.Native.DX9Device.GetInstance();
				if (ptr != null)
				{
					IDirect3DDevice9* ptr2 = *<Module>.EnsoulSharp.Native.DX9Device.GetDevice(ptr);
					if (ptr2 != null)
					{
						IntPtr nativePtr = new IntPtr((void*)ptr2);
						return new SharpDX.Direct3D9.Device(nativePtr);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the direct3d11 device of the game.
		/// </summary>
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x00008BF4 File Offset: 0x00007FF4
		public unsafe static SharpDX.Direct3D11.Device Direct3DDevice11
		{
			get
			{
				DX11Device* ptr = <Module>.EnsoulSharp.Native.DX11Device.GetInstance();
				if (ptr != null)
				{
					ID3D11Device* ptr2 = *<Module>.EnsoulSharp.Native.DX11Device.GetDevice(ptr);
					if (ptr2 != null)
					{
						IntPtr nativePtr = new IntPtr((void*)ptr2);
						return new SharpDX.Direct3D11.Device(nativePtr);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the direct3d11 device context of the game.
		/// </summary>
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060005D6 RID: 1494 RVA: 0x00008C28 File Offset: 0x00008028
		public unsafe static DeviceContext Direct3DDevice11Context
		{
			get
			{
				DX11Device* ptr = <Module>.EnsoulSharp.Native.DX11Device.GetInstance();
				if (ptr != null)
				{
					ID3D11DeviceContext* ptr2 = *<Module>.EnsoulSharp.Native.PerThreadState.GetDeviceContext(<Module>.EnsoulSharp.Native.DX11Device.GetMainThreadState(ptr));
					if (ptr2 != null)
					{
						IntPtr nativePtr = new IntPtr((void*)ptr2);
						return new DeviceContext(nativePtr);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the dxgi swap chain of the game.
		/// </summary>
		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00008C60 File Offset: 0x00008060
		public unsafe static SharpDX.DXGI.SwapChain SwapChain
		{
			get
			{
				DX11Device* ptr = <Module>.EnsoulSharp.Native.DX11Device.GetInstance();
				if (ptr != null)
				{
					IDXGISwapChain* ptr2 = *<Module>.EnsoulSharp.Native.WindowSwapChain.GetSwapChain(<Module>.EnsoulSharp.Native.DX11Device.GetDefaultWindowSwapChain(ptr));
					if (ptr2 != null)
					{
						IntPtr nativePtr = new IntPtr((void*)ptr2);
						return new SharpDX.DXGI.SwapChain(nativePtr);
					}
				}
				return null;
			}
		}

		/// <summary>
		/// 	Gets the projection of the game.
		/// </summary>
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060005D8 RID: 1496 RVA: 0x00008C98 File Offset: 0x00008098
		public unsafe static Matrix Projection
		{
			get
			{
				r3dRenderLayer* ptr = <Module>.EnsoulSharp.Native.r3dRenderLayer.GetInstance();
				if (ptr != null)
				{
					_D3DMATRIX m;
					<Module>.EnsoulSharp.Native.r3dRenderLayer.GetProj(ptr, &m);
					Matrix result = new Matrix(m, *(ref m + 4), *(ref m + 8), *(ref m + 12), *(ref m + 16), *(ref m + 20), *(ref m + 24), *(ref m + 28), *(ref m + 32), *(ref m + 36), *(ref m + 40), *(ref m + 44), *(ref m + 48), *(ref m + 52), *(ref m + 56), *(ref m + 60));
					return result;
				}
				return Matrix.Zero;
			}
		}

		/// <summary>
		/// 	Gets the view of the game.
		/// </summary>
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00008D20 File Offset: 0x00008120
		public unsafe static Matrix View
		{
			get
			{
				r3dRenderLayer* ptr = <Module>.EnsoulSharp.Native.r3dRenderLayer.GetInstance();
				if (ptr != null)
				{
					_D3DMATRIX m;
					<Module>.EnsoulSharp.Native.r3dRenderLayer.GetCamera(ptr, &m);
					Matrix result = new Matrix(m, *(ref m + 4), *(ref m + 8), *(ref m + 12), *(ref m + 16), *(ref m + 20), *(ref m + 24), *(ref m + 28), *(ref m + 32), *(ref m + 36), *(ref m + 40), *(ref m + 44), *(ref m + 48), *(ref m + 52), *(ref m + 56), *(ref m + 60));
					return result;
				}
				return Matrix.Zero;
			}
		}

		/// <summary>
		/// 	Gets the width of the game.
		/// </summary>
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00008DA8 File Offset: 0x000081A8
		public unsafe static int Width
		{
			get
			{
				r3dRenderLayer* ptr = <Module>.EnsoulSharp.Native.r3dRenderLayer.GetInstance();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.X3DPresentParams.GetBackBufferWidth(<Module>.EnsoulSharp.Native.r3dRenderLayer.Getr3dpp(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Gets the height of the game.
		/// </summary>
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00008DCC File Offset: 0x000081CC
		public unsafe static int Height
		{
			get
			{
				r3dRenderLayer* ptr = <Module>.EnsoulSharp.Native.r3dRenderLayer.GetInstance();
				if (ptr != null)
				{
					return *<Module>.EnsoulSharp.Native.X3DPresentParams.GetBackBufferHeight(<Module>.EnsoulSharp.Native.r3dRenderLayer.Getr3dpp(ptr));
				}
				return 0;
			}
		}

		/// <summary>
		/// 	Draws a 3d circle by algorithm.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="segments">The segments.</param>
		/// <param name="centerZ">A value indicating whether use center z as default.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005DC RID: 1500 RVA: 0x00008E88 File Offset: 0x00008288
		public static void DrawCircle(Vector3 position, float radius, float thickness, int segments, [MarshalAs(UnmanagedType.U1)] bool centerZ, System.Drawing.Color color)
		{
			byte b = (!centerZ) ? 1 : 0;
			<Module>.EnsoulSharp.Native.Drawing.DrawCircle(position.X, position.Y, position.Z, radius, thickness, segments, false, b != 0, color.ToArgb());
		}

		/// <summary>
		/// 	Draws a 3d circle by logic.
		/// </summary>
		/// <param name="position">The world position.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005DD RID: 1501 RVA: 0x00008E54 File Offset: 0x00008254
		public static void DrawCircle(Vector3 position, float radius, float thickness, System.Drawing.Color color)
		{
			<Module>.EnsoulSharp.Native.Drawing.DrawCircle(position.X, position.Y, position.Z, radius, thickness, false, color.ToArgb());
		}

		/// <summary>
		/// 	Draws a 2d circle by algorithm.
		/// </summary>
		/// <param name="position">The screen position.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="segments">The segments.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005DE RID: 1502 RVA: 0x00008E20 File Offset: 0x00008220
		public static void DrawCircle(Vector2 position, float radius, float thickness, int segments, System.Drawing.Color color)
		{
			<Module>.EnsoulSharp.Native.Drawing.DrawCircle(position.X, position.Y, 0f, radius, thickness, segments, true, false, color.ToArgb());
		}

		/// <summary>
		/// 	Draws a 2d circle by logic.
		/// </summary>
		/// <param name="position">The screen position.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005DF RID: 1503 RVA: 0x00008DF0 File Offset: 0x000081F0
		public static void DrawCircle(Vector2 position, float radius, float thickness, System.Drawing.Color color)
		{
			<Module>.EnsoulSharp.Native.Drawing.DrawCircle(position.X, position.Y, 0f, radius, thickness, true, color.ToArgb());
		}

		/// <summary>
		/// 	Draws a circular range indicator at the given 3D position with the given radius in the specified color.
		/// </summary>
		/// <param name="position">The 3D world position.</param>
		/// <param name="radius">The radius.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005E0 RID: 1504 RVA: 0x00008EC4 File Offset: 0x000082C4
		public static void DrawCircleIndicator(Vector3 position, float radius, System.Drawing.Color color)
		{
			Vector3f vector3f;
			<Module>.EnsoulSharp.Native.r3dRenderLayer.DrawCircularRangeIndicator(<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, position.X, position.Z, position.Y), radius, color.ToArgb());
		}

		/// <summary>
		/// 	Draws a line on the screen with specified thickness and color.
		/// </summary>
		/// <param name="start">The screen start position.</param>
		/// <param name="end">The screen end position.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005E1 RID: 1505 RVA: 0x00008F1C File Offset: 0x0000831C
		public static void DrawLine(Vector2 start, Vector2 end, float thickness, System.Drawing.Color color)
		{
			Drawing.DrawLine(start.X, start.Y, end.X, end.Y, thickness, color);
		}

		/// <summary>
		/// 	Draws a line on the screen with specified thickness and color.
		/// </summary>
		/// <param name="startX">The screen start x.</param>
		/// <param name="startY">The screen start y.</param>
		/// <param name="endX">The screen end x.</param>
		/// <param name="endY">The scrren end y.</param>
		/// <param name="thickness">The thickness.</param>
		/// <param name="color">The color.</param>
		// Token: 0x060005E2 RID: 1506 RVA: 0x00008EFC File Offset: 0x000082FC
		public static void DrawLine(float startX, float startY, float endX, float endY, float thickness, System.Drawing.Color color)
		{
			<Module>.EnsoulSharp.Native.Drawing.DrawLine(startX, startY, endX, endY, thickness, color.ToArgb());
		}

		/// <summary>
		/// 	Draws text on the screen.
		/// </summary>
		/// <param name="position">The screen position.</param>
		/// <param name="color">The color.</param>
		/// <param name="format">The format.</param>
		/// <param name="params">The params.</param>
		// Token: 0x060005E3 RID: 1507 RVA: 0x00008FCC File Offset: 0x000083CC
		public static void DrawText(Vector2 position, System.Drawing.Color color, string format, params object[] @params)
		{
			Drawing.DrawText(position.X, position.Y, color, format, @params);
		}

		/// <summary>
		/// 	Draws text on the screen.
		/// </summary>
		/// <param name="x">The screen x.</param>
		/// <param name="y">The screen y.</param>
		/// <param name="color">The color.</param>
		/// <param name="format">The format.</param>
		/// <param name="params">The params.</param>
		// Token: 0x060005E4 RID: 1508 RVA: 0x00008FA0 File Offset: 0x000083A0
		public static void DrawText(float x, float y, System.Drawing.Color color, string format, params object[] @params)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(format, @params);
			Drawing.DrawText(x, y, color, stringBuilder.ToString());
		}

		/// <summary>
		/// 	Draws text on the screen.
		/// </summary>
		/// <param name="position">The screen position.</param>
		/// <param name="color">The color.</param>
		/// <param name="text">The text.</param>
		// Token: 0x060005E5 RID: 1509 RVA: 0x00008F7C File Offset: 0x0000837C
		public static void DrawText(Vector2 position, System.Drawing.Color color, string text)
		{
			Drawing.DrawText(position.X, position.Y, color, text);
		}

		/// <summary>
		/// 	Draws text on the screen.
		/// </summary>
		/// <param name="x">The screen x.</param>
		/// <param name="y">The screen y.</param>
		/// <param name="color">The color.</param>
		/// <param name="text">The text.</param>
		// Token: 0x060005E6 RID: 1510 RVA: 0x00008F4C File Offset: 0x0000834C
		public unsafe static void DrawText(float x, float y, System.Drawing.Color color, string text)
		{
			IntPtr hglobal = Marshal.StringToHGlobalUni(text);
			<Module>.EnsoulSharp.Native.Drawing.DrawText(x, y, (char*)hglobal.ToPointer(), color.ToArgb());
			Marshal.FreeHGlobal(hglobal);
		}

		/// <summary>
		/// 	Retrieves text extent.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <returns>The size of the given text.</returns>
		// Token: 0x060005E7 RID: 1511 RVA: 0x00008FF0 File Offset: 0x000083F0
		public unsafe static Size GetTextExtent(string text)
		{
			IntPtr hglobal = Marshal.StringToHGlobalUni(text);
			tagSIZE width = <Module>.EnsoulSharp.Native.Drawing.MeasureText((char*)hglobal.ToPointer());
			Marshal.FreeHGlobal(hglobal);
			Size result = new Size(width, *(ref width + 4));
			return result;
		}

		/// <summary>
		/// 	Converts the given minimap coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="position">The minimap position.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x060005E8 RID: 1512 RVA: 0x00009074 File Offset: 0x00008474
		public static Vector3 MinimapToWorld(Vector2 position)
		{
			return Drawing.MinimapToWorld(position.X, position.Y);
		}

		/// <summary>
		/// 	Converts the given minimap coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="x">The minimap x.</param>
		/// <param name="y">The minimap y.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x060005E9 RID: 1513 RVA: 0x00009028 File Offset: 0x00008428
		public unsafe static Vector3 MinimapToWorld(float x, float y)
		{
			TacticalMap* ptr = <Module>.EnsoulSharp.Native.TacticalMap.GetInstance();
			if (ptr != null)
			{
				Vector3f vector3f;
				<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f);
				<Module>.EnsoulSharp.Native.TacticalMap.ToWorldCoord(ptr, x, y, &vector3f);
				Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetY(ref vector3f));
				return result;
			}
			return Vector3.Zero;
		}

		/// <summary>
		/// 	Converts the given screen coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="position">The screen position.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x060005EA RID: 1514 RVA: 0x000090D0 File Offset: 0x000084D0
		public static Vector3 ScreenToWorld(Vector2 position)
		{
			return Drawing.ScreenToWorld(position.X, position.Y);
		}

		/// <summary>
		/// 	Converts the given screen coordinates into 3D world coordinates.
		/// </summary>
		/// <param name="x">The screen x.</param>
		/// <param name="y">The screen y.</param>
		/// <returns>The 3D world coordinates result.</returns>
		// Token: 0x060005EB RID: 1515 RVA: 0x00009094 File Offset: 0x00008494
		public unsafe static Vector3 ScreenToWorld(float x, float y)
		{
			Vector3f vector3f;
			<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f);
			<Module>.EnsoulSharp.Native.r3dRenderLayer.ScreenToWorld(x, y, &vector3f);
			Vector3 result = new Vector3(<Module>.EnsoulSharp.Native.Vector3f.GetX(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetZ(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetY(ref vector3f));
			return result;
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into minimap coordinates.
		/// </summary>
		/// <param name="worldCoord">The world position.</param>
		/// <param name="mapCoord">The minimap position result.</param>
		/// <returns>A value indicating whether the conversion is successful and whether the coordinates is valid.</returns>
		// Token: 0x060005EC RID: 1516 RVA: 0x000090F0 File Offset: 0x000084F0
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool WorldToMinimap(Vector3 worldCoord, out Vector2 mapCoord)
		{
			bool flag = false;
			float x = 0f;
			float y = 0f;
			TacticalMap* ptr = <Module>.EnsoulSharp.Native.TacticalMap.GetInstance();
			if (ptr != null)
			{
				Vector3f vector3f;
				flag = (<Module>.EnsoulSharp.Native.TacticalMap.ToMapCoord(ptr, <Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f, worldCoord.X, worldCoord.Z, worldCoord.Y), &x, &y) != 0 || flag);
			}
			mapCoord.X = x;
			mapCoord.Y = y;
			return flag;
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into minimap coordinates no matter valid or not.
		/// </summary>
		/// <param name="worldCoord">The world position.</param>
		/// <returns>The minimap coordinates result.</returns>
		// Token: 0x060005ED RID: 1517 RVA: 0x00009574 File Offset: 0x00008974
		public static Vector2 WorldToMinimap(Vector3 worldCoord)
		{
			Vector2 zero = Vector2.Zero;
			Drawing.WorldToMinimap(worldCoord, out zero);
			return zero;
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into screen coordinates.
		/// </summary>
		/// <param name="worldCoord">The world position.</param>
		/// <param name="screenCoord">The screen position result.</param>
		/// <returns>A value indicating whether the conversion is successful and whether the coordinates is valid.</returns>
		// Token: 0x060005EE RID: 1518 RVA: 0x00009154 File Offset: 0x00008554
		[return: MarshalAs(UnmanagedType.U1)]
		public unsafe static bool WorldToScreen(Vector3 worldCoord, out Vector2 screenCoord)
		{
			bool flag = false;
			Vector3f vector3f;
			<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f);
			Vector3f vector3f2;
			flag = (<Module>.EnsoulSharp.Native.r3dRenderLayer.r3dProjectToScreen(<Module>.EnsoulSharp.Native.Vector3f.{ctor}(ref vector3f2, worldCoord.X, worldCoord.Z, worldCoord.Y), &vector3f) != 0 || flag);
			Vector2 vector = new Vector2(<Module>.EnsoulSharp.Native.Vector3f.GetX(ref vector3f), <Module>.EnsoulSharp.Native.Vector3f.GetY(ref vector3f));
			screenCoord = vector;
			return flag;
		}

		/// <summary>
		/// 	Converts the given 3D world coordinates into screen coordinates no matter valid or not.
		/// </summary>
		/// <param name="worldCoord">The world position.</param>
		/// <returns>The screen coordinates result.</returns>
		// Token: 0x060005EF RID: 1519 RVA: 0x00009594 File Offset: 0x00008994
		public static Vector2 WorldToScreen(Vector3 worldCoord)
		{
			Vector2 zero = Vector2.Zero;
			Drawing.WorldToScreen(worldCoord, out zero);
			return zero;
		}

		// Token: 0x040003E3 RID: 995
		internal static Drawing.OnDrawNativeDelegate m_DrawNativeDelegate;

		// Token: 0x040003E4 RID: 996
		internal static Drawing.OnBeginSceneNativeDelegate m_BeginSceneNativeDelegate;

		// Token: 0x040003E5 RID: 997
		internal static Drawing.OnEndSceneNativeDelegate m_EndSceneNativeDelegate;

		// Token: 0x040003E6 RID: 998
		internal static Drawing.OnFlushDrawNativeDelegate m_FlushDrawNativeDelegate;

		// Token: 0x040003E7 RID: 999
		internal static Drawing.OnFlushEndSceneNativeDelegate m_FlushEndSceneNativeDelegate;

		// Token: 0x040003E8 RID: 1000
		internal static Drawing.OnPreResetNativeDelegate m_PreResetNativeDelegate;

		// Token: 0x040003E9 RID: 1001
		internal static Drawing.OnPostResetNativeDelegate m_PostResetNativeDelegate;

		// Token: 0x040003EA RID: 1002
		internal static Drawing.OnPresentNativeDelegate m_PresentNativeDelegate;

		// Token: 0x040003EB RID: 1003
		internal static Drawing.OnRenderMouseOversNativeDelegate m_RenderMouseOversNativeDelegate;

		// Token: 0x040003EC RID: 1004
		internal static Drawing.OnD3D11PresentNativeDelegate m_D3D11PresentNativeDelegate;

		// Token: 0x040003ED RID: 1005
		internal static Drawing.OnD3D11PreResizeBuffersNativeDelegate m_D3D11PreResizeBuffersNativeDelegate;

		// Token: 0x040003EE RID: 1006
		internal static Drawing.OnD3D11PostResizeBuffersNativeDelegate m_D3D11PostResizeBuffersNativeDelegate;

		// Token: 0x040003EF RID: 1007
		internal static IntPtr m_DrawNative = IntPtr.Zero;

		// Token: 0x040003F0 RID: 1008
		internal static IntPtr m_BeginSceneNative = IntPtr.Zero;

		// Token: 0x040003F1 RID: 1009
		internal static IntPtr m_EndSceneNative = IntPtr.Zero;

		// Token: 0x040003F2 RID: 1010
		internal static IntPtr m_FlushDrawNative = IntPtr.Zero;

		// Token: 0x040003F3 RID: 1011
		internal static IntPtr m_FlushEndSceneNative = IntPtr.Zero;

		// Token: 0x040003F4 RID: 1012
		internal static IntPtr m_PreResetNative = IntPtr.Zero;

		// Token: 0x040003F5 RID: 1013
		internal static IntPtr m_PostResetNative = IntPtr.Zero;

		// Token: 0x040003F6 RID: 1014
		internal static IntPtr m_PresentNative = IntPtr.Zero;

		// Token: 0x040003F7 RID: 1015
		internal static IntPtr m_RenderMouseOversNative = IntPtr.Zero;

		// Token: 0x040003F8 RID: 1016
		internal static IntPtr m_D3D11PresentNative = IntPtr.Zero;

		// Token: 0x040003F9 RID: 1017
		internal static IntPtr m_D3D11PreResizeBuffersNative = IntPtr.Zero;

		// Token: 0x040003FA RID: 1018
		internal static IntPtr m_D3D11PostResizeBuffersNative = IntPtr.Zero;

		// Token: 0x040003FB RID: 1019
		internal static List<DrawingDraw> DrawHandlers = new List<DrawingDraw>();

		// Token: 0x040003FC RID: 1020
		internal static List<DrawingBeginScene> BeginSceneHandlers = new List<DrawingBeginScene>();

		// Token: 0x040003FD RID: 1021
		internal static List<DrawingEndScene> EndSceneHandlers = new List<DrawingEndScene>();

		// Token: 0x040003FE RID: 1022
		internal static List<DrawingFlushDraw> FlushDrawHandlers = new List<DrawingFlushDraw>();

		// Token: 0x040003FF RID: 1023
		internal static List<DrawingFlushEndScene> FlushEndSceneHandlers = new List<DrawingFlushEndScene>();

		// Token: 0x04000400 RID: 1024
		internal static List<DrawingPreReset> PreResetHandlers = new List<DrawingPreReset>();

		// Token: 0x04000401 RID: 1025
		internal static List<DrawingPostReset> PostResetHandlers = new List<DrawingPostReset>();

		// Token: 0x04000402 RID: 1026
		internal static List<DrawingPresent> PresentHandlers = new List<DrawingPresent>();

		// Token: 0x04000403 RID: 1027
		internal static List<DrawingRenderMouseOvers> RenderMouseOversHandlers = new List<DrawingRenderMouseOvers>();

		// Token: 0x04000404 RID: 1028
		internal static List<DrawingD3D11Present> D3D11PresentHandlers = new List<DrawingD3D11Present>();

		// Token: 0x04000405 RID: 1029
		internal static List<DrawingD3D11PreResizeBuffers> D3D11PreResizeBuffersHandlers = new List<DrawingD3D11PreResizeBuffers>();

		// Token: 0x04000406 RID: 1030
		internal static List<DrawingD3D11PostResizeBuffers> D3D11PostResizeBuffersHandlers = new List<DrawingD3D11PostResizeBuffers>();

		// Token: 0x02000102 RID: 258
		// (Invoke) Token: 0x060005F2 RID: 1522
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnDrawNativeDelegate();

		// Token: 0x02000103 RID: 259
		// (Invoke) Token: 0x060005F6 RID: 1526
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnBeginSceneNativeDelegate();

		// Token: 0x02000104 RID: 260
		// (Invoke) Token: 0x060005FA RID: 1530
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnEndSceneNativeDelegate();

		// Token: 0x02000105 RID: 261
		// (Invoke) Token: 0x060005FE RID: 1534
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnFlushDrawNativeDelegate();

		// Token: 0x02000106 RID: 262
		// (Invoke) Token: 0x06000602 RID: 1538
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnFlushEndSceneNativeDelegate();

		// Token: 0x02000107 RID: 263
		// (Invoke) Token: 0x06000606 RID: 1542
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnPreResetNativeDelegate();

		// Token: 0x02000108 RID: 264
		// (Invoke) Token: 0x0600060A RID: 1546
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnPostResetNativeDelegate();

		// Token: 0x02000109 RID: 265
		// (Invoke) Token: 0x0600060E RID: 1550
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnPresentNativeDelegate();

		// Token: 0x0200010A RID: 266
		// (Invoke) Token: 0x06000612 RID: 1554
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnRenderMouseOversNativeDelegate();

		// Token: 0x0200010B RID: 267
		// (Invoke) Token: 0x06000616 RID: 1558
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnD3D11PresentNativeDelegate();

		// Token: 0x0200010C RID: 268
		// (Invoke) Token: 0x0600061A RID: 1562
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnD3D11PreResizeBuffersNativeDelegate();

		// Token: 0x0200010D RID: 269
		// (Invoke) Token: 0x0600061E RID: 1566
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void OnD3D11PostResizeBuffersNativeDelegate();
	}
}
