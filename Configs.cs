using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace GlobalTrinkets
{
	[Label("Limitations")]
	public class GT_Configs : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		
		[Header("[i:3619] [c/ffeb6e:Discount, Construction and Wiring]")]

		[DefaultValue(true)]
		[Label("Allow Discount Card")]
		public bool CheckForDiscount;

		[DefaultValue(true)]
		[Label("Allow Construction/Wiring Tools")]
		public bool CheckForTools;

		[DefaultValue(1)]
		private int InformationalTrinkets;

		[Header("[i:3123] [c/ffeb6e:Informational]")]
		
		[BackgroundColor(0, 64, 32)]
		[DefaultValue(true)]
		[Label("Allow Informational Gadgets")]
		[Tooltip("If disabled, configs below are ignored")]
		public bool CheckForInfo;
		
		[BackgroundColor(0, 100, 32)]
		[DefaultValue(false)]
		[Label("Only PDA and Cellphones work")]
		public bool PDAOnly
		{
			get { return InformationalTrinkets == 0; }
			set { if (value) InformationalTrinkets = 0; }
		}

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(true)]
		[Label("Direct components of the PDA work")]
		[Tooltip("Includes GPS, REK, Goblin Tech, and Fish Finder")]
		public bool PDAComponents
		{
			get { return InformationalTrinkets == 1; }
			set { if (value) InformationalTrinkets = 1; }
		}

		[BackgroundColor(0, 100, 32)]
		[DefaultValue(false)]
		[Label("All components towards the PDA work")]
		[Tooltip("Includes all the ingrdients of GPS, REK, Goblin Tech, and Fish Finder")]
		public bool AllComponents
		{
			get { return InformationalTrinkets == 2; }
			set { if (value) InformationalTrinkets = 2; }
		}

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
		{
			if (IsPlayerLocalServerOwner(Main.player[whoAmI])) {
				message = "Only the host is allowed to change this config.";
				return false;
			}
			return true;
		}

		// Code created by Jopojelly, for the Cheatsheet Mod.
		private bool IsPlayerLocalServerOwner(Player player)
		{
			if (Main.netMode == NetmodeID.MultiplayerClient) {
				return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();
			}
			for (int plr = 0; plr < Main.maxPlayers; plr++) {
				RemoteClient NetPlayer = Netplay.Clients[plr];
				if (NetPlayer.State == 10 && Main.player[plr] == player && NetPlayer.Socket.GetRemoteAddress().IsLocalHost()) {
					return true;
				}
			}
			return false;
		}
	}
}
