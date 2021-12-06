using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace GlobalTrinkets
{
	public class GlobalTrinkets : Mod
	{
		///TODO: Include an items that modders may have the PDA/Cellphone as materials for
	}

	public class ModdedPlayer : ModPlayer
	{
		/// <summary>
		/// If true, either the PDA and Cellphone are the only items accepted OR a PDA or Cellphone was found. 
		/// Either case, it is desired to skip the checks for other components.
		/// </summary>
		bool SkipPDAComponents = ModContent.GetInstance<GTConfigs>().PDAOnly;

        public override void UpdateEquips()
        {
			base.UpdateEquips();

			Item[] PiggyBank = Player.bank.item;
			Item[] Safe = Player.bank2.item;
			Item[] Forge = Player.bank3.item;
			Item[] Void = Player.bank4.item;
			
			for (int i = 0; i < PiggyBank.Length; i++) {
				CheckTrinkets(PiggyBank[i].type);
			}
			for (int i = 0; i < Safe.Length; i++) {
				CheckTrinkets(Safe[i].type);
			}
			for (int i = 0; i < Forge.Length; i++) {
				CheckTrinkets(Forge[i].type);
			}
			for (int i = 0; i < Void.Length; i++)
			{
				CheckTrinkets(Void[i].type);
			}
			SkipPDAComponents = ModContent.GetInstance<GTConfigs>().PDAOnly; // Reset bool after checks
		}

		private void CheckTrinkets(int itemType)
		{
			GTConfigs config = ModContent.GetInstance<GTConfigs>();

			// Discount Card
			if (config.CheckForDiscount && (itemType == ItemID.DiscountCard || itemType == ItemID.GreedyRing)) {
				Player.discount = true;
				return;
			}

			// Construction and Wiring
			if (config.CheckForTools) {
				if (itemType == ItemID.MechanicalLens || itemType == ItemID.WireKite) {
					Player.InfoAccMechShowWires = true;
					return;
				}/*
				if (itemType == ItemID.Ruler || itemType == ItemID.WireKite) {
					Player.rulerLine = true;
					return;
				}
				*/
				if (itemType == ItemID.LaserRuler) {
					Player.rulerGrid = true;
					return;
				}
				if (itemType == ItemID.ActuationAccessory) {
					Player.autoActuator = true;
					return;
				}
				if (itemType == ItemID.PaintSprayer || itemType == ItemID.ArchitectGizmoPack) {
					Player.autoPaint = true;
					return;
				}
			}

			// Informational Accessories
			if (!config.CheckForInfo) {
				return;
			}

			if (itemType == ItemID.PDA || itemType == ItemID.CellPhone) {
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
				
				SkipPDAComponents = true; // We found a PDA/Cellphone. No need to check for components in future checks.
				return;
			}

			// If a cellphone or PDA has been found, no need to check for each part
			// If neither have been found yet and it remains false, the PDAOnly config must not be true, so check the components
			if (!SkipPDAComponents) {
				if (itemType == ItemID.GPS) {
					Player.accWatch = 3;
					Player.accDepthMeter = 1;
					Player.accCompass = 1;
					return;
				}
				if (itemType == ItemID.REK) {
					Player.accThirdEye = true;
					Player.accCritterGuide = true;
					Player.accJarOfSouls = true;
					return;
				}
				if (itemType == ItemID.GoblinTech) {
					Player.accOreFinder = true;
					Player.accStopwatch = true;
					Player.accDreamCatcher = true;
					return;
				}
				if (itemType == ItemID.FishFinder) {
					Player.accFishFinder = true;
					Player.accWeatherRadio = true;
					Player.accCalendar = true;
					return;
				}

				// Check each individual component if the config allows it
				if (config.AllComponents) {
					if (ModContent.GetInstance<GTConfigs>().AllComponents) {
						if ((itemType == ItemID.CopperWatch || itemType == ItemID.TinWatch) && Player.accWatch < 1) {
							Player.accWatch = 1;
							return;
						}
						if ((itemType == ItemID.SilverWatch || itemType == ItemID.TungstenWatch) && Player.accWatch < 2) {
							Player.accWatch = 2;
							return;
						}
						if (itemType == ItemID.GoldWatch || itemType == ItemID.PlatinumWatch) {
							Player.accWatch = 3;
							return;
						}
						if (itemType == ItemID.DepthMeter) {
							Player.accDepthMeter = 1;
							return;
						}
						if (itemType == ItemID.Compass) {
							Player.accCompass = 1;
							return;
						}
						if (itemType == ItemID.Radar) {
							Player.accThirdEye = true;
							return;
						}
						if (itemType == ItemID.LifeformAnalyzer) {
							Player.accCritterGuide = true;
							return;
						}
						if (itemType == ItemID.TallyCounter) {
							Player.accJarOfSouls = true;
							return;
						}
						if (itemType == ItemID.MetalDetector) {
							Player.accOreFinder = true;
							return;
						}
						if (itemType == ItemID.Stopwatch) {
							Player.accStopwatch = true;
							return;
						}
						if (itemType == ItemID.DPSMeter) {
							Player.accDreamCatcher = true;
							return;
						}
						if (itemType == ItemID.FishermansGuide) {
							Player.accFishFinder = true;
							return;
						}
						if (itemType == ItemID.WeatherRadio) {
							Player.accWeatherRadio = true;
							return;
						}
						if (itemType == ItemID.Sextant) {
							Player.accCalendar = true;
							return;
						}
					}
				}
			}
		}
	}
}