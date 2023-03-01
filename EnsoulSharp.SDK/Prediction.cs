using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.MenuUI;
using EnsoulSharp.SDK.Utility;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200001E RID: 30
	public class Prediction
	{
		// Token: 0x06000137 RID: 311 RVA: 0x00008E54 File Offset: 0x00007054
		internal static void Initialize()
		{
			if (Prediction._initialize)
			{
				return;
			}
			Prediction._initialize = true;
			Collisions.Attach();
			Prediction.Menu = new Menu("Prediction", "Prediction", true).Attach();
			Prediction.Menu.Add<MenuList>(new MenuList("PredictionSelected", "Prediction Selected:", new string[]
			{
				"SDK Prediction"
			}, 0)).ValueChanged += Prediction.Prediction_ValueChanged;
			Prediction.Implementations.Add("SDK Prediction", new PredictionSDK());
			Prediction.Implementation = Prediction.Implementations["SDK Prediction"];
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00008EEF File Offset: 0x000070EF
		private static void Prediction_ValueChanged(MenuList menuItem, EventArgs args)
		{
			Prediction.Implementation = Prediction.Implementations[menuItem.SelectedValue];
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00008F08 File Offset: 0x00007108
		public static void AddPrediction(string name, IPrediction pred)
		{
			if (Prediction.Implementations.ContainsKey(name))
			{
				Logging.Write(false, true, "AddPrediction")(LogLevel.Error, "Cant not Add " + name + " Prediction bcz already have it!", Array.Empty<object>());
				return;
			}
			List<string> list = Prediction.Menu["PredictionSelected"].GetValue<MenuList>().Items.ToList<string>();
			list.Add(name);
			Prediction.Menu["PredictionSelected"].GetValue<MenuList>().Items = list.ToArray();
			Logging.Write(false, true, "AddPrediction")(LogLevel.Info, "Add " + name + " Prediction", Array.Empty<object>());
			Prediction.Implementations.Add(name, pred);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00008FC4 File Offset: 0x000071C4
		public static void SetPrediction(string name)
		{
			if (Prediction.Implementations.ContainsKey(name))
			{
				int index = Array.IndexOf<string>(Prediction.Menu["PredictionSelected"].GetValue<MenuList>().Items, name);
				Prediction.Menu["PredictionSelected"].GetValue<MenuList>().Index = index;
				Logging.Write(false, true, "SetPrediction")(LogLevel.Info, "Set " + name + " to Default Prediction", Array.Empty<object>());
				Prediction.Implementation = Prediction.Implementations[name];
				return;
			}
			Logging.Write(false, true, "SetPrediction")(LogLevel.Error, "Cant not Set " + name + " to Default Prediction", Array.Empty<object>());
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00009077 File Offset: 0x00007277
		public static IPrediction GetPrediction(string name)
		{
			if (Prediction.Implementations.ContainsKey(name))
			{
				return Prediction.Implementations[name];
			}
			return null;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00009093 File Offset: 0x00007293
		public static IPrediction GetSDKPrediction()
		{
			return Prediction.Implementations["SDK Prediction"];
		}

		// Token: 0x0600013D RID: 317 RVA: 0x000090A4 File Offset: 0x000072A4
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay
			});
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00009100 File Offset: 0x00007300
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay, float radius)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = radius
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay,
				Radius = radius
			});
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00009168 File Offset: 0x00007368
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay, float radius, float speed)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = radius,
					Speed = speed
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay,
				Radius = radius,
				Speed = speed
			});
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000091E0 File Offset: 0x000073E0
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay, float radius, float speed, bool addHitBox)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = radius,
					Speed = speed,
					AddHitBox = addHitBox
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay,
				Radius = radius,
				Speed = speed,
				AddHitBox = addHitBox
			});
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00009268 File Offset: 0x00007468
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay, float radius, float speed, CollisionObjects[] collisionable)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = radius,
					Speed = speed,
					CollisionObjects = collisionable
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay,
				Radius = radius,
				Speed = speed,
				CollisionObjects = collisionable
			});
		}

		// Token: 0x06000142 RID: 322 RVA: 0x000092F0 File Offset: 0x000074F0
		public static PredictionOutput GetPrediction(AIBaseClient unit, float delay, float radius, float speed, bool addHitBox, CollisionObjects[] collisionable)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(new PredictionInput
				{
					Unit = unit,
					Delay = delay,
					Radius = radius,
					Speed = speed,
					AddHitBox = addHitBox,
					CollisionObjects = collisionable
				});
			}
			return Prediction.Implementation.GetPrediction(new PredictionInput
			{
				Unit = unit,
				Delay = delay,
				Radius = radius,
				Speed = speed,
				AddHitBox = addHitBox,
				CollisionObjects = collisionable
			});
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00009385 File Offset: 0x00007585
		public static PredictionOutput GetPrediction(PredictionInput input)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(input);
			}
			return Prediction.Implementation.GetPrediction(input);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000093AF File Offset: 0x000075AF
		public static PredictionOutput GetPrediction(PredictionInput input, bool ft, bool checkCollision)
		{
			if (Prediction.Implementation == null)
			{
				return Prediction.Implementations.Values.FirstOrDefault<IPrediction>().GetPrediction(input, ft, checkCollision);
			}
			return Prediction.Implementation.GetPrediction(input, ft, checkCollision);
		}

		// Token: 0x0400009B RID: 155
		private static bool _initialize;

		// Token: 0x0400009C RID: 156
		private static IPrediction Implementation;

		// Token: 0x0400009D RID: 157
		private static readonly Dictionary<string, IPrediction> Implementations = new Dictionary<string, IPrediction>();

		// Token: 0x0400009E RID: 158
		public static Menu Menu;
	}
}
