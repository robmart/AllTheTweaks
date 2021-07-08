using Verse;

namespace AllTheTweaks {
	public class ATTSettings : ModSettings {
		public bool useThrumboMilk;
		public bool useThrumboCheese;
		public bool useThrumboWool;
		public bool isAmbrosiaGrowable;

		public override void ExposeData()
		{
			Scribe_Values.Look(ref useThrumboMilk, "useThrumboMilk", true);
			Scribe_Values.Look(ref useThrumboCheese, "useThrumboCheese", true);
			Scribe_Values.Look(ref useThrumboWool, "useThrumboWool", true);
			Scribe_Values.Look(ref isAmbrosiaGrowable, "isAmbrosiaGrowable", true);
			base.ExposeData();
		}
	}
}