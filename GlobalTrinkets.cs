using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlobalTrinkets
{
	public class GlobalTrinkets : Mod
	{
		///TODO: Include any items that modders may have the PDA/Cellphone as materials for??
		internal static GlobalTrinkets instance;
		//internal static GTConfigs Config;

		internal readonly List<int> ValidItems = new List<int>() {
			ItemID.DiscountCard, // discount
			ItemID.GreedyRing,

			ItemID.MechanicalLens, // tools
			ItemID.WireKite,
			ItemID.LaserRuler,
			ItemID.ActuationAccessory,
			ItemID.PaintSprayer,
			ItemID.ArchitectGizmoPack,

			ItemID.DontHurtComboBook, // critter & nature
			ItemID.DontHurtCrittersBook,
			ItemID.DontHurtCrittersBook,

			ItemID.PDA, // PDA
			ItemID.CellPhone,
			ItemID.Shellphone,
			ItemID.ShellphoneDummy,
			ItemID.ShellphoneHell,
			ItemID.ShellphoneOcean,
			ItemID.ShellphoneSpawn,

			ItemID.GPS, // PDA Components
			ItemID.REK,
			ItemID.GoblinTech,
			ItemID.FishFinder,
			ItemID.CopperWatch,
			ItemID.TinWatch,
			ItemID.SilverWatch,
			ItemID.TungstenWatch,
			ItemID.GoldWatch,
			ItemID.PlatinumWatch,
			ItemID.DepthMeter,
			ItemID.Compass,
			ItemID.Radar,
			ItemID.LifeformAnalyzer,
			ItemID.TallyCounter,
			ItemID.MetalDetector,
			ItemID.Stopwatch,
			ItemID.DPSMeter,
			ItemID.FishermansGuide,
			ItemID.WeatherRadio,
			ItemID.Sextant
		};
	}

	public class ModdedPlayer : ModPlayer
	{
		readonly List<int> ContainsPDA = new List<int>() {
			ItemID.PDA,
			ItemID.CellPhone,
			ItemID.Shellphone,
			ItemID.ShellphoneDummy,
			ItemID.ShellphoneHell,
			ItemID.ShellphoneOcean,
			ItemID.ShellphoneSpawn
		};

        public override void UpdateEquips() {
			base.UpdateEquips();

			// Discount Card
			if (Player.HasItemInAnyInventory(ItemID.DiscountCard) || Player.HasItemInAnyInventory(ItemID.GreedyRing))
				Player.discountEquipped = true;

			// Construction and Wiring
			if (Player.HasItemInAnyInventory(ItemID.MechanicalLens) || Player.HasItemInAnyInventory(ItemID.WireKite))
				Player.InfoAccMechShowWires = true;

			if (Player.HasItemInAnyInventory(ItemID.LaserRuler))
				Player.rulerGrid = true;

			if (Player.HasItemInAnyInventory(ItemID.ActuationAccessory))
				Player.autoActuator = true;

			if (Player.HasItemInAnyInventory(ItemID.PaintSprayer) || Player.HasItemInAnyInventory(ItemID.ArchitectGizmoPack) || Player.HasItemInAnyInventory(ItemID.HandOfCreation))
				Player.autoPaint = true;

			// Prevent critter/nature interactions
			if (Player.HasItemInAnyInventory(ItemID.DontHurtCrittersBook) || Player.HasItemInAnyInventory(ItemID.DontHurtComboBook))
				Player.dontHurtCritters = true;

			if (Player.HasItemInAnyInventory(ItemID.DontHurtNatureBook) || Player.HasItemInAnyInventory(ItemID.DontHurtComboBook))
				Player.dontHurtNature = true;

			// Informational Accessories
			bool HasPDAorEquivalent = false;
			foreach (int item in ContainsPDA) {
				if (Player.HasItemInAnyInventory(item)) {
					HasPDAorEquivalent = true;
					break;
				}
			}

			if (HasPDAorEquivalent) {
				Player.accWatch = 3;
				Player.accDepthMeter = 1;
				Player.accCompass = 1;
				Player.accThirdEye = true;
				Player.accCritterGuide = true;
				Player.accJarOfSouls = true;
				Player.accOreFinder = true;
				Player.accStopwatch = true;
				Player.accDreamCatcher = true;
				Player.accFishFinder = true;
				Player.accWeatherRadio = true;
				Player.accCalendar = true;
			}
			else {
				// GPS
				if (Player.HasItemInAnyInventory(ItemID.GPS)) {
					Player.accWatch = 3;
					Player.accDepthMeter = 1;
					Player.accCompass = 1;
				}
				else {
					if ((Player.HasItemInAnyInventory(ItemID.CopperWatch) || Player.HasItemInAnyInventory(ItemID.TinWatch)) && Player.accWatch < 1)
						Player.accWatch = 1;

					if ((Player.HasItemInAnyInventory(ItemID.SilverWatch) || Player.HasItemInAnyInventory(ItemID.TungstenWatch)) && Player.accWatch < 2)
						Player.accWatch = 2;

					if (Player.HasItemInAnyInventory(ItemID.GoldWatch) || Player.HasItemInAnyInventory(ItemID.PlatinumWatch))
						Player.accWatch = 3;

					if (Player.HasItemInAnyInventory(ItemID.DepthMeter))
						Player.accDepthMeter = 1;

					if (Player.HasItemInAnyInventory(ItemID.Compass))
						Player.accCompass = 1;
				}

				// REK
				bool hasRek = Player.HasItemInAnyInventory(ItemID.REK);
				if (hasRek || Player.HasItemInAnyInventory(ItemID.Radar))
					Player.accThirdEye = true;

				if (hasRek || Player.HasItemInAnyInventory(ItemID.LifeformAnalyzer))
					Player.accCritterGuide = true;

				if (hasRek || Player.HasItemInAnyInventory(ItemID.TallyCounter))
					Player.accJarOfSouls = true;

				// Goblin Tech
				bool hasGoblinTech = Player.HasItemInAnyInventory(ItemID.GoblinTech);
				if (hasGoblinTech || Player.HasItemInAnyInventory(ItemID.MetalDetector))
					Player.accOreFinder = true;

				if (hasGoblinTech || Player.HasItemInAnyInventory(ItemID.Stopwatch))
					Player.accStopwatch = true;

				if (hasGoblinTech || Player.HasItemInAnyInventory(ItemID.DPSMeter))
					Player.accDreamCatcher = true;

				//Fish Finder
				bool hasFishFinder = Player.HasItemInAnyInventory(ItemID.FishFinder);
				if (hasFishFinder || Player.HasItemInAnyInventory(ItemID.FishermansGuide))
					Player.accFishFinder = true;

				if (hasFishFinder || Player.HasItemInAnyInventory(ItemID.WeatherRadio))
					Player.accWeatherRadio = true;

				if (hasFishFinder || Player.HasItemInAnyInventory(ItemID.Sextant))
					Player.accCalendar = true;
			}
		}
	}
}