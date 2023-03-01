using System;

namespace EnsoulSharp.SDK.MenuUI
{
	// Token: 0x020000AC RID: 172
	[Flags]
	public enum Keys
	{
		// Token: 0x04000333 RID: 819
		KeyCode = 65535,
		// Token: 0x04000334 RID: 820
		Modifiers = -65536,
		// Token: 0x04000335 RID: 821
		None = 0,
		// Token: 0x04000336 RID: 822
		LButton = 1,
		// Token: 0x04000337 RID: 823
		RButton = 2,
		// Token: 0x04000338 RID: 824
		Cancel = 3,
		// Token: 0x04000339 RID: 825
		MButton = 4,
		// Token: 0x0400033A RID: 826
		XButton1 = 5,
		// Token: 0x0400033B RID: 827
		XButton2 = 6,
		// Token: 0x0400033C RID: 828
		Back = 8,
		// Token: 0x0400033D RID: 829
		Tab = 9,
		// Token: 0x0400033E RID: 830
		LineFeed = 10,
		// Token: 0x0400033F RID: 831
		Clear = 12,
		// Token: 0x04000340 RID: 832
		Return = 13,
		// Token: 0x04000341 RID: 833
		Enter = 13,
		// Token: 0x04000342 RID: 834
		ShiftKey = 16,
		// Token: 0x04000343 RID: 835
		ControlKey = 17,
		// Token: 0x04000344 RID: 836
		Menu = 18,
		// Token: 0x04000345 RID: 837
		Pause = 19,
		// Token: 0x04000346 RID: 838
		Capital = 20,
		// Token: 0x04000347 RID: 839
		CapsLock = 20,
		// Token: 0x04000348 RID: 840
		KanaMode = 21,
		// Token: 0x04000349 RID: 841
		HanguelMode = 21,
		// Token: 0x0400034A RID: 842
		HangulMode = 21,
		// Token: 0x0400034B RID: 843
		JunjaMode = 23,
		// Token: 0x0400034C RID: 844
		FinalMode = 24,
		// Token: 0x0400034D RID: 845
		HanjaMode = 25,
		// Token: 0x0400034E RID: 846
		KanjiMode = 25,
		// Token: 0x0400034F RID: 847
		Escape = 27,
		// Token: 0x04000350 RID: 848
		IMEConvert = 28,
		// Token: 0x04000351 RID: 849
		IMENonconvert = 29,
		// Token: 0x04000352 RID: 850
		IMEAccept = 30,
		// Token: 0x04000353 RID: 851
		IMEAceept = 30,
		// Token: 0x04000354 RID: 852
		IMEModeChange = 31,
		// Token: 0x04000355 RID: 853
		Space = 32,
		// Token: 0x04000356 RID: 854
		Prior = 33,
		// Token: 0x04000357 RID: 855
		PageUp = 33,
		// Token: 0x04000358 RID: 856
		Next = 34,
		// Token: 0x04000359 RID: 857
		PageDown = 34,
		// Token: 0x0400035A RID: 858
		End = 35,
		// Token: 0x0400035B RID: 859
		Home = 36,
		// Token: 0x0400035C RID: 860
		Left = 37,
		// Token: 0x0400035D RID: 861
		Up = 38,
		// Token: 0x0400035E RID: 862
		Right = 39,
		// Token: 0x0400035F RID: 863
		Down = 40,
		// Token: 0x04000360 RID: 864
		Select = 41,
		// Token: 0x04000361 RID: 865
		Print = 42,
		// Token: 0x04000362 RID: 866
		Execute = 43,
		// Token: 0x04000363 RID: 867
		Snapshot = 44,
		// Token: 0x04000364 RID: 868
		PrintScreen = 44,
		// Token: 0x04000365 RID: 869
		Insert = 45,
		// Token: 0x04000366 RID: 870
		Delete = 46,
		// Token: 0x04000367 RID: 871
		Help = 47,
		// Token: 0x04000368 RID: 872
		D0 = 48,
		// Token: 0x04000369 RID: 873
		D1 = 49,
		// Token: 0x0400036A RID: 874
		D2 = 50,
		// Token: 0x0400036B RID: 875
		D3 = 51,
		// Token: 0x0400036C RID: 876
		D4 = 52,
		// Token: 0x0400036D RID: 877
		D5 = 53,
		// Token: 0x0400036E RID: 878
		D6 = 54,
		// Token: 0x0400036F RID: 879
		D7 = 55,
		// Token: 0x04000370 RID: 880
		D8 = 56,
		// Token: 0x04000371 RID: 881
		D9 = 57,
		// Token: 0x04000372 RID: 882
		A = 65,
		// Token: 0x04000373 RID: 883
		B = 66,
		// Token: 0x04000374 RID: 884
		C = 67,
		// Token: 0x04000375 RID: 885
		D = 68,
		// Token: 0x04000376 RID: 886
		E = 69,
		// Token: 0x04000377 RID: 887
		F = 70,
		// Token: 0x04000378 RID: 888
		G = 71,
		// Token: 0x04000379 RID: 889
		H = 72,
		// Token: 0x0400037A RID: 890
		I = 73,
		// Token: 0x0400037B RID: 891
		J = 74,
		// Token: 0x0400037C RID: 892
		K = 75,
		// Token: 0x0400037D RID: 893
		L = 76,
		// Token: 0x0400037E RID: 894
		M = 77,
		// Token: 0x0400037F RID: 895
		N = 78,
		// Token: 0x04000380 RID: 896
		O = 79,
		// Token: 0x04000381 RID: 897
		P = 80,
		// Token: 0x04000382 RID: 898
		Q = 81,
		// Token: 0x04000383 RID: 899
		R = 82,
		// Token: 0x04000384 RID: 900
		S = 83,
		// Token: 0x04000385 RID: 901
		T = 84,
		// Token: 0x04000386 RID: 902
		U = 85,
		// Token: 0x04000387 RID: 903
		V = 86,
		// Token: 0x04000388 RID: 904
		W = 87,
		// Token: 0x04000389 RID: 905
		X = 88,
		// Token: 0x0400038A RID: 906
		Y = 89,
		// Token: 0x0400038B RID: 907
		Z = 90,
		// Token: 0x0400038C RID: 908
		LWin = 91,
		// Token: 0x0400038D RID: 909
		RWin = 92,
		// Token: 0x0400038E RID: 910
		Apps = 93,
		// Token: 0x0400038F RID: 911
		Sleep = 95,
		// Token: 0x04000390 RID: 912
		NumPad0 = 96,
		// Token: 0x04000391 RID: 913
		NumPad1 = 97,
		// Token: 0x04000392 RID: 914
		NumPad2 = 98,
		// Token: 0x04000393 RID: 915
		NumPad3 = 99,
		// Token: 0x04000394 RID: 916
		NumPad4 = 100,
		// Token: 0x04000395 RID: 917
		NumPad5 = 101,
		// Token: 0x04000396 RID: 918
		NumPad6 = 102,
		// Token: 0x04000397 RID: 919
		NumPad7 = 103,
		// Token: 0x04000398 RID: 920
		NumPad8 = 104,
		// Token: 0x04000399 RID: 921
		NumPad9 = 105,
		// Token: 0x0400039A RID: 922
		Multiply = 106,
		// Token: 0x0400039B RID: 923
		Add = 107,
		// Token: 0x0400039C RID: 924
		Separator = 108,
		// Token: 0x0400039D RID: 925
		Subtract = 109,
		// Token: 0x0400039E RID: 926
		Decimal = 110,
		// Token: 0x0400039F RID: 927
		Divide = 111,
		// Token: 0x040003A0 RID: 928
		F1 = 112,
		// Token: 0x040003A1 RID: 929
		F2 = 113,
		// Token: 0x040003A2 RID: 930
		F3 = 114,
		// Token: 0x040003A3 RID: 931
		F4 = 115,
		// Token: 0x040003A4 RID: 932
		F5 = 116,
		// Token: 0x040003A5 RID: 933
		F6 = 117,
		// Token: 0x040003A6 RID: 934
		F7 = 118,
		// Token: 0x040003A7 RID: 935
		F8 = 119,
		// Token: 0x040003A8 RID: 936
		F9 = 120,
		// Token: 0x040003A9 RID: 937
		F10 = 121,
		// Token: 0x040003AA RID: 938
		F11 = 122,
		// Token: 0x040003AB RID: 939
		F12 = 123,
		// Token: 0x040003AC RID: 940
		F13 = 124,
		// Token: 0x040003AD RID: 941
		F14 = 125,
		// Token: 0x040003AE RID: 942
		F15 = 126,
		// Token: 0x040003AF RID: 943
		F16 = 127,
		// Token: 0x040003B0 RID: 944
		F17 = 128,
		// Token: 0x040003B1 RID: 945
		F18 = 129,
		// Token: 0x040003B2 RID: 946
		F19 = 130,
		// Token: 0x040003B3 RID: 947
		F20 = 131,
		// Token: 0x040003B4 RID: 948
		F21 = 132,
		// Token: 0x040003B5 RID: 949
		F22 = 133,
		// Token: 0x040003B6 RID: 950
		F23 = 134,
		// Token: 0x040003B7 RID: 951
		F24 = 135,
		// Token: 0x040003B8 RID: 952
		NumLock = 144,
		// Token: 0x040003B9 RID: 953
		Scroll = 145,
		// Token: 0x040003BA RID: 954
		LShiftKey = 160,
		// Token: 0x040003BB RID: 955
		RShiftKey = 161,
		// Token: 0x040003BC RID: 956
		LControlKey = 162,
		// Token: 0x040003BD RID: 957
		RControlKey = 163,
		// Token: 0x040003BE RID: 958
		LMenu = 164,
		// Token: 0x040003BF RID: 959
		RMenu = 165,
		// Token: 0x040003C0 RID: 960
		BrowserBack = 166,
		// Token: 0x040003C1 RID: 961
		BrowserForward = 167,
		// Token: 0x040003C2 RID: 962
		BrowserRefresh = 168,
		// Token: 0x040003C3 RID: 963
		BrowserStop = 169,
		// Token: 0x040003C4 RID: 964
		BrowserSearch = 170,
		// Token: 0x040003C5 RID: 965
		BrowserFavorites = 171,
		// Token: 0x040003C6 RID: 966
		BrowserHome = 172,
		// Token: 0x040003C7 RID: 967
		VolumeMute = 173,
		// Token: 0x040003C8 RID: 968
		VolumeDown = 174,
		// Token: 0x040003C9 RID: 969
		VolumeUp = 175,
		// Token: 0x040003CA RID: 970
		MediaNextTrack = 176,
		// Token: 0x040003CB RID: 971
		MediaPreviousTrack = 177,
		// Token: 0x040003CC RID: 972
		MediaStop = 178,
		// Token: 0x040003CD RID: 973
		MediaPlayPause = 179,
		// Token: 0x040003CE RID: 974
		LaunchMail = 180,
		// Token: 0x040003CF RID: 975
		SelectMedia = 181,
		// Token: 0x040003D0 RID: 976
		LaunchApplication1 = 182,
		// Token: 0x040003D1 RID: 977
		LaunchApplication2 = 183,
		// Token: 0x040003D2 RID: 978
		OemSemicolon = 186,
		// Token: 0x040003D3 RID: 979
		Oem1 = 186,
		// Token: 0x040003D4 RID: 980
		Oemplus = 187,
		// Token: 0x040003D5 RID: 981
		Oemcomma = 188,
		// Token: 0x040003D6 RID: 982
		OemMinus = 189,
		// Token: 0x040003D7 RID: 983
		OemPeriod = 190,
		// Token: 0x040003D8 RID: 984
		OemQuestion = 191,
		// Token: 0x040003D9 RID: 985
		Oem2 = 191,
		// Token: 0x040003DA RID: 986
		Oemtilde = 192,
		// Token: 0x040003DB RID: 987
		Oem3 = 192,
		// Token: 0x040003DC RID: 988
		OemOpenBrackets = 219,
		// Token: 0x040003DD RID: 989
		Oem4 = 219,
		// Token: 0x040003DE RID: 990
		OemPipe = 220,
		// Token: 0x040003DF RID: 991
		Oem5 = 220,
		// Token: 0x040003E0 RID: 992
		OemCloseBrackets = 221,
		// Token: 0x040003E1 RID: 993
		Oem6 = 221,
		// Token: 0x040003E2 RID: 994
		OemQuotes = 222,
		// Token: 0x040003E3 RID: 995
		Oem7 = 222,
		// Token: 0x040003E4 RID: 996
		Oem8 = 223,
		// Token: 0x040003E5 RID: 997
		OemBackslash = 226,
		// Token: 0x040003E6 RID: 998
		Oem102 = 226,
		// Token: 0x040003E7 RID: 999
		ProcessKey = 229,
		// Token: 0x040003E8 RID: 1000
		Packet = 231,
		// Token: 0x040003E9 RID: 1001
		Attn = 246,
		// Token: 0x040003EA RID: 1002
		Crsel = 247,
		// Token: 0x040003EB RID: 1003
		Exsel = 248,
		// Token: 0x040003EC RID: 1004
		EraseEof = 249,
		// Token: 0x040003ED RID: 1005
		Play = 250,
		// Token: 0x040003EE RID: 1006
		Zoom = 251,
		// Token: 0x040003EF RID: 1007
		NoName = 252,
		// Token: 0x040003F0 RID: 1008
		Pa1 = 253,
		// Token: 0x040003F1 RID: 1009
		OemClear = 254,
		// Token: 0x040003F2 RID: 1010
		Shift = 65536,
		// Token: 0x040003F3 RID: 1011
		Control = 131072,
		// Token: 0x040003F4 RID: 1012
		Alt = 262144
	}
}
