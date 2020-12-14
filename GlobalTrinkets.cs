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
		bool SkipPDAComponents = ModContent.GetInstance<GT_Configs>().PDAOnly;

		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
		{
			base.UpdateEquips(ref wallSpeedBuff, ref tileSpeedBuff, ref tileRangeBuff);

			Item[] PiggyBank = player.bank.item;
			Item[] Safe = player.bank2.item;
			Item[] Forge = player.bank3.item;
			
			for (int i = 0; i < PiggyBank.Length; i++) {
				CheckTrinkets(PiggyBank[i].type);
			}
			for (int i = 0; i < Safe.Length; i++) {
				CheckTrinkets(Safe[i].type);
			}
			for (int i = 0; i < Forge.Length; i++) {
				CheckTrinkets(Forge[i].type);
			}
			SkipPDAComponents = ModContent.GetInstance<GT_Configs>().PDAOnly; // Reset bool after checks
		}

		private void CheckTrinkets(int itemType)
		{
			GT_Configs config = ModContent.GetInstance<GT_Configs>();

			// Discount Card
			if (config.CheckForDiscount && (itemType == ItemID.DiscountCard || itemType == ItemID.GreedyRing)) {
				player.discount = true;
				return;
			}

			// Construction and Wiring
			if (config.CheckForTools) {
				if (itemType == ItemID.MechanicalLens || itemType == ItemID.WireKite) {
					player.InfoAccMechShowWires = true;
					return;
				}
				if (itemType == ItemID.Ruler || itemType == ItemID.WireKite) {
					player.rulerLine = true;
					return;
				}
				if (itemType == ItemID.LaserRuler) {
					player.rulerGrid = true;
					return;
				}
				if (itemType == ItemID.ActuationAccessory) {
					player.autoActuator = true;
					return;
				}
				if (itemType == ItemID.PaintSprayer || itemType == ItemID.ArchitectGizmoPack) {
					player.autoPaint = true;
					return;
				}
			}

			// Informational Accessories
			if (!config.CheckForInfo) {
				return;
			}

			if (itemType == ItemID.PDA || itemType == ItemID.CellPhone) {
				player.accWatch = 3;
				player.accDepthMeter = 1;
				player.accCompass = 1;
				player.accThirdEye = true;
				player.accCritterGuide = true;
				player.accJarOfSouls = true;
				player.accOreFinder = true;
				player.accStopwatch = true;
				player.accDreamCatcher = true;
				player.accFishFinder = true;
				player.accWeatherRadio = true;
				player.accCalendar = true;
				
				SkipPDAComponents = true; // We found a PDA/Cellphone. No need to check for components in future checks.
				return;
			}

			// If a cellphone or PDA has been found, no need to check for each part
			// If neither have been found yet and it remains false, the PDAOnly config must not be true, so check the components
			if (!SkipPDAComponents) {
				if (itemType == ItemID.GPS) {
					player.accWatch = 3;
					player.accDepthMeter = 1;
					player.accCompass = 1;
					return;
				}
				if (itemType == ItemID.REK) {
					player.accThirdEye = true;
					player.accCritterGuide = true;
					player.accJarOfSouls = true;
					return;
				}
				if (itemType == ItemID.GoblinTech) {
					player.accOreFinder = true;
					player.accStopwatch = true;
					player.accDreamCatcher = true;
					return;
				}
				if (itemType == ItemID.FishFinder) {
					player.accFishFinder = true;
					player.accWeatherRadio = true;
					player.accCalendar = true;
					return;
				}

				// Check each individual component if the config allows it
				if (config.AllComponents) {
					if (ModContent.GetInstance<GT_Configs>().AllComponents) {
						if ((itemType == ItemID.CopperWatch || itemType == ItemID.TinWatch) && player.accWatch < 1) {
							player.accWatch = 1;
							return;
						}
						if ((itemType == ItemID.SilverWatch || itemType == ItemID.TungstenWatch) && player.accWatch < 2) {
							player.accWatch = 2;
							return;
						}
						if (itemType == ItemID.GoldWatch || itemType == ItemID.PlatinumWatch) {
							player.accWatch = 3;
							return;
						}
						if (itemType == ItemID.DepthMeter) {
							player.accDepthMeter = 1;
							return;
						}
						if (itemType == ItemID.Compass) {
							player.accCompass = 1;
							return;
						}
						if (itemType == ItemID.Radar) {
							player.accThirdEye = true;
							return;
						}
						if (itemType == ItemID.LifeformAnalyzer) {
							player.accCritterGuide = true;
							return;
						}
						if (itemType == ItemID.TallyCounter) {
							player.accJarOfSouls = true;
							return;
						}
						if (itemType == ItemID.MetalDetector) {
							player.accOreFinder = true;
							return;
						}
						if (itemType == ItemID.Stopwatch) {
							player.accStopwatch = true;
							return;
						}
						if (itemType == ItemID.DPSMeter) {
							player.accDreamCatcher = true;
							return;
						}
						if (itemType == ItemID.FishermansGuide) {
							player.accFishFinder = true;
							return;
						}
						if (itemType == ItemID.WeatherRadio) {
							player.accWeatherRadio = true;
							return;
						}
						if (itemType == ItemID.Sextant) {
							player.accCalendar = true;
							return;
						}
					}
				}
			}
		}
	}
}