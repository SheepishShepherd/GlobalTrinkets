using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace GlobalTrinkets
{
	/*
	public class GTConfigs : ModConfig
    {
		public override void OnLoaded() => GlobalTrinkets.Config = this;
        public override ConfigScope Mode => ConfigScope.ServerSide;

		public List<ItemDefinition> CheckedItems = new List<ItemDefinition>() {
			new ItemDefinition(ItemID.DiscountCard), // discount
			new ItemDefinition(ItemID.GreedyRing),

			new ItemDefinition(ItemID.MechanicalLens), // tools
			new ItemDefinition(ItemID.WireKite),
			new ItemDefinition(ItemID.LaserRuler),
			new ItemDefinition(ItemID.ActuationAccessory),
			new ItemDefinition(ItemID.PaintSprayer),
			new ItemDefinition(ItemID.ArchitectGizmoPack),

			new ItemDefinition(ItemID.DontHurtComboBook), // critter & nature
			new ItemDefinition(ItemID.DontHurtCrittersBook),
			new ItemDefinition(ItemID.DontHurtCrittersBook),

			new ItemDefinition(ItemID.PDA), // PDA
			new ItemDefinition(ItemID.CellPhone),
			new ItemDefinition(ItemID.Shellphone),
			new ItemDefinition(ItemID.ShellphoneDummy),
			new ItemDefinition(ItemID.ShellphoneHell),
			new ItemDefinition(ItemID.ShellphoneOcean),
			new ItemDefinition(ItemID.ShellphoneSpawn),

			new ItemDefinition(ItemID.GPS), // PDA Components
			new ItemDefinition(ItemID.REK),
			new ItemDefinition(ItemID.GoblinTech),
			new ItemDefinition(ItemID.FishFinder),
			new ItemDefinition(ItemID.CopperWatch),
			new ItemDefinition(ItemID.TinWatch),
			new ItemDefinition(ItemID.SilverWatch),
			new ItemDefinition(ItemID.TungstenWatch),
			new ItemDefinition(ItemID.GoldWatch),
			new ItemDefinition(ItemID.PlatinumWatch),
			new ItemDefinition(ItemID.DepthMeter),
			new ItemDefinition(ItemID.Compass),
			new ItemDefinition(ItemID.Radar),
			new ItemDefinition(ItemID.LifeformAnalyzer),
			new ItemDefinition(ItemID.TallyCounter),
			new ItemDefinition(ItemID.MetalDetector),
			new ItemDefinition(ItemID.Stopwatch),
			new ItemDefinition(ItemID.DPSMeter),
			new ItemDefinition(ItemID.FishermansGuide),
			new ItemDefinition(ItemID.WeatherRadio),
			new ItemDefinition(ItemID.Sextant)
		};

		[Header("Description")]

		//[DefaultValue(true)]
		public bool CheckForDiscount { get; set; }

		//[DefaultValue(true)]
		public bool CheckForCoexistence { get; set; }

		//[DefaultValue(true)]
		public bool CheckForTools { get; set; }

		[DefaultValue(-1)]
		private int InformationalTrinkets { get; set; }

		[Header("PDAOption")]

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(true)]
		//[Tooltip("If disabled, configs below are ignored")]
		public bool NoInfo {
			get => InformationalTrinkets == -1;
			set {
				if (value)
					InformationalTrinkets = -1;
			}
		}

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(false)]
		//[Label("[i:3123] [i:3124] PDA or Cellphone are needed to gain informational benefits")]
		public bool PDAOnly {
			get => InformationalTrinkets == 0;
			set { 
				if (value)
					InformationalTrinkets = 0;
			}
		}

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(false)]
		//[Label("[i:395] [i:3122] [i:3121] [i:3036] Direct components of the PDA are needed to gain informational benefits")]
		public bool PDAComponents {
			get => InformationalTrinkets == 1;
			set {
				if (value)
					InformationalTrinkets = 1;
			}
		}

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(false)]
		//[Label("[i:17] [i:18] [i:393] [i:3084] [i:3118] [i:3095] [i:3102] [i:3099] [i:3119] [i:3120] [i:3037] [i:3096] Allow all components of the PDA")]
		public bool AllComponents {
			get => InformationalTrinkets == 2;
			set {
				if (value)
					InformationalTrinkets = 2;
			}
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (IsPlayerLocalServerOwner(Main.player[whoAmI])) {
				message = "Only the host is allowed to change this config.";
				return false;
			}
			return true;
		}

		// Code created by Jopojelly, for the Cheatsheet Mod.
		private bool IsPlayerLocalServerOwner(Player player) {
			if (Main.netMode == NetmodeID.MultiplayerClient)
				return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();

			for (int plr = 0; plr < Main.maxPlayers; plr++) {
				RemoteClient NetPlayer = Netplay.Clients[plr];
				if (NetPlayer.State == 10 && Main.player[plr] == player && NetPlayer.Socket.GetRemoteAddress().IsLocalHost())
					return true;
			}
			return false;
		}
	}
	*/
}
