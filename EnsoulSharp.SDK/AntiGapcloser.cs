using System;
using System.Collections.Generic;
using System.Linq;
using EnsoulSharp.SDK.MenuUI;
using SharpDX;

namespace EnsoulSharp.SDK
{
	// Token: 0x0200002F RID: 47
	public static class AntiGapcloser
	{
		// Token: 0x06000255 RID: 597 RVA: 0x0000D428 File Offset: 0x0000B628
		static AntiGapcloser()
		{
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Aatrox",
				DisplayName = "Aatrox E",
				Slot = SpellSlot.E,
				SpellName = "aatroxe",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 300f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Ahri",
				DisplayName = "Ahri R",
				Slot = SpellSlot.R,
				SpellName = "ahritumble",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 500f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Ahri",
				DisplayName = "Ahri R",
				Slot = SpellSlot.R,
				SpellName = "ahritumble",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 500f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Akali",
				DisplayName = "Akali E2",
				Slot = SpellSlot.E,
				SpellName = "akalieb",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Akali",
				DisplayName = "Akali R",
				Slot = SpellSlot.R,
				SpellName = "akalir",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Akali",
				DisplayName = "Akali R",
				Slot = SpellSlot.R,
				SpellName = "akalir",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Akali",
				DisplayName = "Akali R2",
				Slot = SpellSlot.R,
				SpellName = "akalirb",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Akali",
				DisplayName = "Akali R2",
				Slot = SpellSlot.R,
				SpellName = "akalirb",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Alistar",
				DisplayName = "Alistar W",
				Slot = SpellSlot.W,
				SpellName = "headbutt",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Azir",
				DisplayName = "Azir E",
				Slot = SpellSlot.E,
				SpellName = "azire",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 950f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Caitlyn",
				DisplayName = "Caitlyn E",
				Slot = SpellSlot.E,
				SpellName = "caitlynentrapment",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Reverse = true,
				Range = 350f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Camille",
				DisplayName = "Camille E2",
				Slot = SpellSlot.E,
				SpellName = "camilleedash2",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 800f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Corki",
				DisplayName = "Corki W",
				Slot = SpellSlot.W,
				SpellName = "carpetbomb",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Corki",
				DisplayName = "Corki W Big",
				Slot = SpellSlot.W,
				SpellName = "carpetbombmega",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1950f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Diana",
				DisplayName = "Diana E",
				Slot = SpellSlot.E,
				SpellName = "dianateleport",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Ekko",
				DisplayName = "Ekko E",
				Slot = SpellSlot.E,
				SpellName = "ekkoeattack",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Elise",
				DisplayName = "Elise Q",
				Slot = SpellSlot.Q,
				SpellName = "elisespiderqcast",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Elise",
				DisplayName = "Elise E",
				Slot = SpellSlot.E,
				SpellName = "elisespideredescent",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Fiora",
				DisplayName = "Fiora Q",
				Slot = SpellSlot.Q,
				SpellName = "fioraq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 400f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Fizz",
				DisplayName = "Fizz Q",
				Slot = SpellSlot.Q,
				SpellName = "fizzq",
				SpellType = AntiGapcloser.GapcloserType.Targeted,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Galio",
				DisplayName = "Galio E",
				Slot = SpellSlot.E,
				SpellName = "galioe",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Gnar",
				DisplayName = "Gnar E",
				Slot = SpellSlot.E,
				SpellName = "gnare",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 425f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Gnar",
				DisplayName = "Gnar Big E",
				Slot = SpellSlot.E,
				SpellName = "gnarbige",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 545f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Gragas",
				DisplayName = "Gragas E",
				Slot = SpellSlot.E,
				SpellName = "gragase",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Graves",
				DisplayName = "Graves E",
				Slot = SpellSlot.E,
				SpellName = "gravesmove",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 425f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Hecarim",
				DisplayName = "Hecarim E",
				Slot = SpellSlot.E,
				SpellName = "hecarimrampattack",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Hecarim",
				DisplayName = "Hecarim R",
				Slot = SpellSlot.R,
				SpellName = "hecarimult",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 950f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Hecarim",
				DisplayName = "Hecarim R",
				Slot = SpellSlot.R,
				SpellName = "hecarimult",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 950f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Illaoi",
				DisplayName = "Illaoi W",
				Slot = SpellSlot.W,
				SpellName = "illaoiwattack",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Irelia",
				DisplayName = "Irelia Q",
				Slot = SpellSlot.Q,
				SpellName = "ireliaq",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "JarvanIV",
				DisplayName = "JarvanIV R",
				Slot = SpellSlot.R,
				SpellName = "jarvanivcataclysm",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "JarvanIV",
				DisplayName = "JarvanIV R",
				Slot = SpellSlot.R,
				SpellName = "jarvanivcataclysm",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Jax",
				DisplayName = "Jax Q",
				Slot = SpellSlot.Q,
				SpellName = "jaxleapstrike",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Jayce",
				DisplayName = "Jayce Q",
				Slot = SpellSlot.Q,
				SpellName = "jaycetotheskies",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kaisa",
				DisplayName = "Kaisa R",
				Slot = SpellSlot.R,
				SpellName = "kaisar",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				UseEndPosition = true
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Kaisa",
				DisplayName = "Kaisa R",
				Slot = SpellSlot.R,
				SpellName = "kaisar",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				UseEndPosition = true
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kassadin",
				DisplayName = "Kassadin R",
				Slot = SpellSlot.R,
				SpellName = "riftwalk",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Kassadin",
				DisplayName = "Kassadin R",
				Slot = SpellSlot.R,
				SpellName = "riftwalk",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Katarina",
				DisplayName = "Katarina E",
				Slot = SpellSlot.E,
				SpellName = "katarinae",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 725f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Katarina",
				DisplayName = "Katarina E Dagger",
				Slot = SpellSlot.E,
				SpellName = "katarinaedagger",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 725f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kayn",
				DisplayName = "Kayn Q",
				Slot = SpellSlot.Q,
				SpellName = "kaynq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 300f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Khazix",
				DisplayName = "Khazix E",
				Slot = SpellSlot.E,
				SpellName = "khazixe",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 500f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Khazix",
				DisplayName = "Khazix E Long",
				Slot = SpellSlot.E,
				SpellName = "khazixelong",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 630f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kindred",
				DisplayName = "Kindred Q",
				Slot = SpellSlot.Q,
				SpellName = "kindredq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 330f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kled",
				DisplayName = "Kled Q",
				Slot = SpellSlot.Q,
				SpellName = "kledriderq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Reverse = true,
				Range = 250f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Kled",
				DisplayName = "Kled E",
				Slot = SpellSlot.E,
				SpellName = "klede",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Leblanc",
				DisplayName = "Leblanc W",
				Slot = SpellSlot.W,
				SpellName = "leblancw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 525f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Leblanc",
				DisplayName = "Leblanc RW",
				Slot = SpellSlot.R,
				SpellName = "leblancrw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 525f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Leblanc",
				DisplayName = "Leblanc RW",
				Slot = SpellSlot.R,
				SpellName = "leblancrw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 525f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "LeeSin",
				DisplayName = "LeeSin Q2",
				Slot = SpellSlot.Q,
				SpellName = "blindmonkqtwo",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Lucian",
				DisplayName = "Lucian E",
				Slot = SpellSlot.E,
				SpellName = "luciane",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 425f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Malphite",
				DisplayName = "Malphite R",
				Slot = SpellSlot.R,
				SpellName = "ufslash",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1000f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Malphite",
				DisplayName = "Malphite R",
				Slot = SpellSlot.R,
				SpellName = "ufslash",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1000f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Maokai",
				DisplayName = "Maokai W",
				DelayTime = 750,
				Slot = SpellSlot.W,
				SpellName = "maokaiw",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "MasterYi",
				DisplayName = "MasterYi Q",
				Slot = SpellSlot.Q,
				SpellName = "alphastrike",
				SpellType = AntiGapcloser.GapcloserType.Targeted,
				DelayTime = 1250
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "MonkeyKing",
				DisplayName = "MonkeyKing E",
				Slot = SpellSlot.E,
				SpellName = "monkeykingnimbus",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Nidalee",
				DisplayName = "Nidalee W",
				Slot = SpellSlot.W,
				SpellName = "pounce",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 325f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Ornn",
				DisplayName = "Ornn E",
				Slot = SpellSlot.E,
				SpellName = "ornne",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 425f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Pantheon",
				DisplayName = "Pantheon W",
				Slot = SpellSlot.W,
				SpellName = "pantheonw",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Poppy",
				DisplayName = "Poppy E",
				Slot = SpellSlot.E,
				SpellName = "poppye",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Pyke",
				DisplayName = "Pyke E",
				Slot = SpellSlot.E,
				SpellName = "pykee",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Quinn",
				DisplayName = "Quinn E",
				Slot = SpellSlot.E,
				SpellName = "quinne",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Rakan",
				DisplayName = "Rakan W",
				Slot = SpellSlot.W,
				SpellName = "rakanw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 550f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "RekSai",
				DisplayName = "RekSai E",
				Slot = SpellSlot.E,
				SpellName = "reksaieburrowed",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 650f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Renekton",
				DisplayName = "Renekton E",
				Slot = SpellSlot.E,
				SpellName = "renektonsliceanddice",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 350f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Renekton",
				DisplayName = "Renekton E2",
				Slot = SpellSlot.E,
				SpellName = "renektonpreexecute",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 350f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Renekton",
				DisplayName = "Renekton Super E",
				Slot = SpellSlot.E,
				SpellName = "renektonsuperexecute",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 350f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Rengar",
				DisplayName = "Rengar Bush Attack",
				Slot = SpellSlot.Unknown,
				SpellName = "rengarpassivebuffdash",
				SpellType = AntiGapcloser.GapcloserType.SkillShot
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Rengar",
				DisplayName = "Rengar R",
				Slot = SpellSlot.Unknown,
				SpellName = "rengarpassivebuffdashaadummy",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Riven",
				DisplayName = "Riven Q",
				Slot = SpellSlot.Q,
				SpellName = "riventricleave",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 300f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Riven",
				DisplayName = "Riven E",
				Slot = SpellSlot.E,
				SpellName = "rivenfeint",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 375f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sejuani",
				DisplayName = "Sejuani Q",
				Slot = SpellSlot.Q,
				SpellName = "sejuaniq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 375f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Shen",
				DisplayName = "Shen E",
				Slot = SpellSlot.E,
				SpellName = "shene",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 500f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Shyvana",
				DisplayName = "Shyvana R",
				Slot = SpellSlot.R,
				SpellName = "shyvanatransformcast",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 600f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Shyvana",
				DisplayName = "Shyvana R",
				Slot = SpellSlot.R,
				SpellName = "shyvanatransformcast",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 600f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				DisplayName = "Sylas W",
				Slot = SpellSlot.W,
				SpellName = "sylasw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 350f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				DisplayName = "Sylas E",
				Slot = SpellSlot.E,
				SpellName = "sylase",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 425f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Talon",
				DisplayName = "Talon Q",
				Slot = SpellSlot.Q,
				SpellName = "talonq",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Tristana",
				DisplayName = "Tristana W",
				Slot = SpellSlot.W,
				SpellName = "tristanaw",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 800f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Tryndamere",
				DisplayName = "Tryndamere E",
				Slot = SpellSlot.E,
				SpellName = "tryndameree",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 525f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Urgot",
				DisplayName = "Urgot E",
				Slot = SpellSlot.E,
				SpellName = "urgote",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 325f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Vayne",
				DisplayName = "Vayne Q",
				Slot = SpellSlot.Q,
				SpellName = "vaynetumble",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 325f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Vi",
				DisplayName = "Vi Q",
				Slot = SpellSlot.Q,
				SpellName = "viq",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 850f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Warwick",
				DisplayName = "Warwick R",
				Slot = SpellSlot.R,
				SpellName = "warwickr",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1100f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Warwick",
				DisplayName = "Warwick R",
				Slot = SpellSlot.R,
				SpellName = "warwickr",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1100f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "XinZhao",
				DisplayName = "XinZhao E",
				Slot = SpellSlot.E,
				SpellName = "xinzhaoespellcasttrigger",
				SpellType = AntiGapcloser.GapcloserType.Targeted
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Yasuo",
				DisplayName = "Yasuo E",
				Slot = SpellSlot.E,
				SpellName = "yasuoe",
				SpellType = AntiGapcloser.GapcloserType.Targeted,
				Range = 475f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Zac",
				DisplayName = "Zac E",
				Slot = SpellSlot.E,
				SpellName = "zace",
				SpellType = AntiGapcloser.GapcloserType.SkillShot,
				Range = 1200f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Zed",
				DisplayName = "Zed R",
				Slot = SpellSlot.R,
				SpellName = "zedr",
				SpellType = AntiGapcloser.GapcloserType.Targeted,
				DelayTime = 1200,
				Reverse = true,
				Range = 100f
			});
			AntiGapcloser.Spells.Add(new AntiGapcloser.SpellData
			{
				ChampionName = "Sylas",
				OriginChampionName = "Zed",
				DisplayName = "Zed R",
				Slot = SpellSlot.R,
				SpellName = "zedr",
				SpellType = AntiGapcloser.GapcloserType.Targeted,
				DelayTime = 1200,
				Reverse = true,
				Range = 100f
			});
			List<string> name = (from x in GameObjects.Heroes
			select x.CharacterName).Distinct<string>().ToList<string>();
			AntiGapcloser.Spells.RemoveAll((AntiGapcloser.SpellData x) => name.All((string b) => b != x.ChampionName));
			AIBaseClient.OnDoCast += AntiGapcloser.OnDoCast;
			AIBaseClient.OnNewPath += AntiGapcloser.OnNewPath;
			Game.OnUpdate += AntiGapcloser.OnUpdate;
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000256 RID: 598 RVA: 0x0000EE14 File Offset: 0x0000D014
		// (remove) Token: 0x06000257 RID: 599 RVA: 0x0000EE48 File Offset: 0x0000D048
		public static event AntiGapcloser.OnGapcloserEvent OnGapcloser;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000258 RID: 600 RVA: 0x0000EE7C File Offset: 0x0000D07C
		// (remove) Token: 0x06000259 RID: 601 RVA: 0x0000EEB0 File Offset: 0x0000D0B0
		public static event AntiGapcloser.OnGapcloserEvent OnAllGapcloser;

		// Token: 0x0600025A RID: 602 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		public static Menu Attach(Menu MainMenu, bool HealthCheck = false, string MenuInternalName = "Gapcloser", string MenuDisplayName = "Anti Gapcloser")
		{
			AntiGapcloser._initialize = true;
			AntiGapcloser.Menu = MainMenu.Add<Menu>(new Menu(MenuInternalName, MenuDisplayName, false));
			using (IEnumerator<AIHeroClient> enumerator = GameObjects.EnemyHeroes.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					AIHeroClient hero = enumerator.Current;
					if (AntiGapcloser.Menu[hero.CharacterName] == null)
					{
						AntiGapcloser.Menu.Add<Menu>(new Menu(hero.CharacterName, hero.CharacterName, false));
					}
					Menu menu;
					if ((menu = (AntiGapcloser.Menu[hero.CharacterName] as Menu)) != null)
					{
						using (List<AntiGapcloser.SpellData>.Enumerator enumerator2 = AntiGapcloser.Spells.FindAll((AntiGapcloser.SpellData x) => x.ChampionName == hero.CharacterName).GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								AntiGapcloser.SpellData spell = enumerator2.Current;
								string text = hero.CharacterName + "_" + spell.SpellName;
								if (menu[text] == null)
								{
									if (hero.CharacterName == "Sylas")
									{
										if (string.IsNullOrEmpty(spell.OriginChampionName))
										{
											menu.Add<MenuBool>(new MenuBool(text, spell.DisplayName, true));
											if (HealthCheck)
											{
												menu.Add<MenuSlider>(new MenuSlider(text + "_hp", "^ Player HealthPercent <= x%", 100, 0, 100));
											}
										}
										else if (!string.IsNullOrEmpty(spell.OriginChampionName) && GameObjects.AllyHeroes.Any((AIHeroClient x) => x.CharacterName == spell.OriginChampionName))
										{
											menu.Add<MenuBool>(new MenuBool(text, spell.DisplayName, true));
											if (HealthCheck)
											{
												menu.Add<MenuSlider>(new MenuSlider(text + "_hp", "^ Player HealthPercent <= x%", 100, 0, 100));
											}
										}
									}
									else
									{
										menu.Add<MenuBool>(new MenuBool(text, spell.DisplayName, true));
										if (HealthCheck)
										{
											menu.Add<MenuSlider>(new MenuSlider(text + "_hp", "^ Player HealthPercent <= x%", 100, 0, 100));
										}
									}
								}
							}
						}
						string text2 = hero.CharacterName + "_normaldash";
						if (menu[text2] == null)
						{
							menu.Add<MenuBool>(new MenuBool(text2, "Normal Dash", false));
							if (HealthCheck)
							{
								menu.Add<MenuSlider>(new MenuSlider(text2 + "_hp", "^ Player HealthPercent <= x%", 100, 0, 100));
							}
						}
					}
				}
			}
			return AntiGapcloser.Menu;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000F1E0 File Offset: 0x0000D3E0
		public static AntiGapcloser.GapcloserArgs GetGapcloserInfo(this AIBaseClient source)
		{
			AntiGapcloser.GapcloserArgs gapcloserArgs = new AntiGapcloser.GapcloserArgs
			{
				SpellName = "NullDash"
			};
			return AntiGapcloser.Gapclosers.FirstOrDefault(delegate(KeyValuePair<int, AntiGapcloser.GapcloserArgs> x)
			{
				AntiGapcloser.GapcloserArgs value = x.Value;
				return ((value != null) ? value.Unit : null) != null && x.Value.Unit.IsValid && source != null && source.IsValid && x.Value.Unit.Compare(source);
			}).Value ?? gapcloserArgs;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000F230 File Offset: 0x0000D430
		private static bool IsEnabled(AntiGapcloser.GapcloserArgs args)
		{
			if (args == null)
			{
				return false;
			}
			AIHeroClient unit = args.Unit;
			if (unit == null || !unit.IsValid)
			{
				return false;
			}
			if (unit.HasBuff("rocketgrab2") || unit.HasBuff("ThreshQ") || unit.HasBuffOfType(BuffType.Knockback))
			{
				return false;
			}
			if (args.DelayTime > 0 && Variables.GameTimeTickCount - args.StartTick < args.DelayTime)
			{
				return false;
			}
			if (!AntiGapcloser._initialize)
			{
				return true;
			}
			Menu menu = AntiGapcloser.Menu;
			if (((menu != null) ? menu[unit.CharacterName] : null) == null)
			{
				return false;
			}
			if (args.SpellData == null)
			{
				string text = unit.CharacterName + "_normaldash";
				return AntiGapcloser.Menu[unit.CharacterName][text] != null && AntiGapcloser.Menu[unit.CharacterName][text].GetValue<MenuBool>().Enabled && (AntiGapcloser.Menu[unit.CharacterName][text + "_hp"] == null || GameObjects.Player.HealthPercent <= (float)AntiGapcloser.Menu[unit.CharacterName][text + "_hp"].GetValue<MenuSlider>().Value);
			}
			string text2 = unit.CharacterName + "_" + args.SpellData.SpellName;
			return AntiGapcloser.Menu[unit.CharacterName][text2] != null && AntiGapcloser.Menu[unit.CharacterName][text2].GetValue<MenuBool>().Enabled && (AntiGapcloser.Menu[unit.CharacterName][text2 + "_hp"] == null || GameObjects.Player.HealthPercent <= (float)AntiGapcloser.Menu[unit.CharacterName][text2 + "_hp"].GetValue<MenuSlider>().Value);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000F438 File Offset: 0x0000D638
		private static void OnUpdate(EventArgs args)
		{
			foreach (KeyValuePair<int, AntiGapcloser.GapcloserArgs> keyValuePair in AntiGapcloser.Gapclosers.ToList<KeyValuePair<int, AntiGapcloser.GapcloserArgs>>())
			{
				if (Variables.GameTimeTickCount - keyValuePair.Value.StartTick - keyValuePair.Value.DelayTime > 300)
				{
					AntiGapcloser.Gapclosers.Remove(keyValuePair.Key);
				}
				else
				{
					AntiGapcloser.OnGapcloserEvent onAllGapcloser = AntiGapcloser.OnAllGapcloser;
					if (onAllGapcloser != null)
					{
						onAllGapcloser(keyValuePair.Value.Unit, keyValuePair.Value);
					}
					if (AntiGapcloser.IsEnabled(keyValuePair.Value))
					{
						AntiGapcloser.OnGapcloserEvent onGapcloser = AntiGapcloser.OnGapcloser;
						if (onGapcloser != null)
						{
							onGapcloser(keyValuePair.Value.Unit, keyValuePair.Value);
						}
					}
				}
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000F51C File Offset: 0x0000D71C
		private static void OnNewPath(AIBaseClient sender, AIBaseClientNewPathEventArgs args)
		{
			if (sender == null || !sender.IsValid || !args.IsDash)
			{
				return;
			}
			AIHeroClient aiheroClient = sender as AIHeroClient;
			if (aiheroClient == null || !aiheroClient.IsValid || !aiheroClient.IsEnemy)
			{
				return;
			}
			if (aiheroClient.CharacterName == "Vi" || aiheroClient.CharacterName == "Sion" || aiheroClient.CharacterName == "Kayn" || aiheroClient.CharacterName == "Fizz")
			{
				return;
			}
			if (aiheroClient.HasBuff("rocketgrab2") || aiheroClient.HasBuff("ThreshQ") || aiheroClient.HasBuffOfType(BuffType.Knockback) || aiheroClient.HasBuff("Knockback"))
			{
				return;
			}
			List<Vector3> list = new List<Vector3>
			{
				aiheroClient.ServerPosition
			};
			list.AddRange(args.Path.ToList<Vector3>());
			if (AntiGapcloser.Gapclosers.ContainsKey(aiheroClient.NetworkId))
			{
				AntiGapcloser.GapcloserArgs gapcloserArgs = AntiGapcloser.Gapclosers[aiheroClient.NetworkId];
				gapcloserArgs.StartPosition = aiheroClient.ServerPosition;
				gapcloserArgs.EndPosition = list.LastOrDefault<Vector3>();
				gapcloserArgs.Speed = args.Speed;
				AntiGapcloser.Gapclosers[aiheroClient.NetworkId] = gapcloserArgs;
				AntiGapcloser.OnGapcloserEvent onAllGapcloser = AntiGapcloser.OnAllGapcloser;
				if (onAllGapcloser != null)
				{
					onAllGapcloser(gapcloserArgs.Unit, gapcloserArgs);
				}
				if (AntiGapcloser.IsEnabled(gapcloserArgs))
				{
					AntiGapcloser.OnGapcloserEvent onGapcloser = AntiGapcloser.OnGapcloser;
					if (onGapcloser == null)
					{
						return;
					}
					onGapcloser(gapcloserArgs.Unit, gapcloserArgs);
					return;
				}
			}
			else
			{
				AntiGapcloser.GapcloserArgs gapcloserArgs2 = new AntiGapcloser.GapcloserArgs
				{
					Unit = aiheroClient,
					Slot = SpellSlot.Unknown,
					Type = AntiGapcloser.GapcloserType.UnknowDash,
					SpellName = "Dash",
					Target = null,
					StartPosition = aiheroClient.ServerPosition,
					EndPosition = list.LastOrDefault<Vector3>(),
					StartTick = Variables.GameTimeTickCount,
					HaveShield = aiheroClient.HaveSpellShield(),
					DelayTime = 0,
					SpellData = null,
					Speed = args.Speed
				};
				AntiGapcloser.Gapclosers[aiheroClient.NetworkId] = gapcloserArgs2;
				AntiGapcloser.OnGapcloserEvent onAllGapcloser2 = AntiGapcloser.OnAllGapcloser;
				if (onAllGapcloser2 != null)
				{
					onAllGapcloser2(gapcloserArgs2.Unit, gapcloserArgs2);
				}
				if (AntiGapcloser.IsEnabled(gapcloserArgs2))
				{
					AntiGapcloser.OnGapcloserEvent onGapcloser2 = AntiGapcloser.OnGapcloser;
					if (onGapcloser2 == null)
					{
						return;
					}
					onGapcloser2(gapcloserArgs2.Unit, gapcloserArgs2);
				}
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000F750 File Offset: 0x0000D950
		private static void OnDoCast(AIBaseClient sender, AIBaseClientProcessSpellCastEventArgs args)
		{
			if (sender == null || !sender.IsValid)
			{
				return;
			}
			AIHeroClient aiheroClient = sender as AIHeroClient;
			if (aiheroClient == null || !aiheroClient.IsValid || !aiheroClient.IsEnemy)
			{
				return;
			}
			if (aiheroClient.HasBuff("rocketgrab2") || aiheroClient.HasBuff("ThreshQ") || aiheroClient.HasBuffOfType(BuffType.Knockback))
			{
				return;
			}
			AntiGapcloser.SpellData spellData = AntiGapcloser.Spells.Find((AntiGapcloser.SpellData x) => args.SData.Name.ToLower() == x.SpellName);
			if (spellData == null)
			{
				return;
			}
			AntiGapcloser.GapcloserType gapcloserType = AntiGapcloser.GapcloserType.SkillShot;
			AIBaseClient aibaseClient = args.Target as AIBaseClient;
			if (spellData.SpellType == AntiGapcloser.GapcloserType.Targeted && aibaseClient != null && aibaseClient.IsValid && !aibaseClient.IsDead)
			{
				gapcloserType = AntiGapcloser.GapcloserType.Targeted;
			}
			Vector3 startPosition = aiheroClient.ServerPosition;
			if (args.Start.IsValid())
			{
				startPosition = args.Start;
			}
			Vector3 endPosition = args.To;
			if (gapcloserType == AntiGapcloser.GapcloserType.Targeted)
			{
				endPosition = ((spellData.Range > 0f) ? args.Start.Extend(aibaseClient.ServerPosition, spellData.Reverse ? (-spellData.Range) : spellData.Range) : aibaseClient.ServerPosition);
			}
			else if (spellData.Range > 0f && (args.Start.Distance(args.To) > spellData.Range * 1.5f || spellData.Reverse))
			{
				endPosition = args.Start.Extend(args.To, spellData.Reverse ? (-spellData.Range) : spellData.Range);
			}
			else if (spellData.UseEndPosition)
			{
				endPosition = args.End;
			}
			AntiGapcloser.GapcloserArgs gapcloserArgs = new AntiGapcloser.GapcloserArgs
			{
				Unit = aiheroClient,
				Slot = args.Slot,
				Type = gapcloserType,
				Target = aibaseClient,
				SpellName = args.SData.Name,
				StartPosition = startPosition,
				EndPosition = endPosition,
				StartTick = Variables.GameTimeTickCount,
				HaveShield = aiheroClient.HaveSpellShield(),
				DelayTime = spellData.DelayTime,
				SpellData = spellData,
				Speed = args.SData.MissileSpeed
			};
			AntiGapcloser.Gapclosers[aiheroClient.NetworkId] = gapcloserArgs;
			AntiGapcloser.OnGapcloserEvent onAllGapcloser = AntiGapcloser.OnAllGapcloser;
			if (onAllGapcloser != null)
			{
				onAllGapcloser(gapcloserArgs.Unit, gapcloserArgs);
			}
			if (AntiGapcloser.IsEnabled(gapcloserArgs))
			{
				AntiGapcloser.OnGapcloserEvent onGapcloser = AntiGapcloser.OnGapcloser;
				if (onGapcloser == null)
				{
					return;
				}
				onGapcloser(gapcloserArgs.Unit, gapcloserArgs);
			}
		}

		// Token: 0x04000113 RID: 275
		public static List<AntiGapcloser.SpellData> Spells = new List<AntiGapcloser.SpellData>();

		// Token: 0x04000114 RID: 276
		private static bool _initialize;

		// Token: 0x04000115 RID: 277
		private static Menu Menu;

		// Token: 0x04000116 RID: 278
		private static readonly Dictionary<int, AntiGapcloser.GapcloserArgs> Gapclosers = new Dictionary<int, AntiGapcloser.GapcloserArgs>();

		// Token: 0x02000465 RID: 1125
		// (Invoke) Token: 0x060014D7 RID: 5335
		public delegate void OnGapcloserEvent(AIHeroClient sender, AntiGapcloser.GapcloserArgs args);

		// Token: 0x02000466 RID: 1126
		public enum GapcloserType
		{
			// Token: 0x04000B54 RID: 2900
			SkillShot,
			// Token: 0x04000B55 RID: 2901
			Targeted,
			// Token: 0x04000B56 RID: 2902
			UnknowDash
		}

		// Token: 0x02000467 RID: 1127
		public class SpellData
		{
			// Token: 0x04000B57 RID: 2903
			public string ChampionName;

			// Token: 0x04000B58 RID: 2904
			public int DelayTime;

			// Token: 0x04000B59 RID: 2905
			public string DisplayName;

			// Token: 0x04000B5A RID: 2906
			public string OriginChampionName = string.Empty;

			// Token: 0x04000B5B RID: 2907
			public SpellSlot Slot;

			// Token: 0x04000B5C RID: 2908
			public string SpellName;

			// Token: 0x04000B5D RID: 2909
			public AntiGapcloser.GapcloserType SpellType;

			// Token: 0x04000B5E RID: 2910
			public bool Reverse;

			// Token: 0x04000B5F RID: 2911
			public float Range = -1f;

			// Token: 0x04000B60 RID: 2912
			public bool UseEndPosition;
		}

		// Token: 0x02000468 RID: 1128
		public class GapcloserArgs
		{
			// Token: 0x04000B61 RID: 2913
			internal int DelayTime;

			// Token: 0x04000B62 RID: 2914
			internal AntiGapcloser.SpellData SpellData;

			// Token: 0x04000B63 RID: 2915
			internal AIHeroClient Unit;

			// Token: 0x04000B64 RID: 2916
			public Vector3 EndPosition;

			// Token: 0x04000B65 RID: 2917
			public bool HaveShield;

			// Token: 0x04000B66 RID: 2918
			public SpellSlot Slot;

			// Token: 0x04000B67 RID: 2919
			public float Speed;

			// Token: 0x04000B68 RID: 2920
			public string SpellName;

			// Token: 0x04000B69 RID: 2921
			public Vector3 StartPosition;

			// Token: 0x04000B6A RID: 2922
			public int StartTick;

			// Token: 0x04000B6B RID: 2923
			public AIBaseClient Target;

			// Token: 0x04000B6C RID: 2924
			public AntiGapcloser.GapcloserType Type;
		}
	}
}
