using AllTheTweaks.References;
using HugsLib;
using HugsLib.Settings;
using Verse;
using VFECore;

namespace AllTheTweaks {
    public class AllTheTweaks : ModBase {
        private SettingHandle<bool> _canThrumbosBeMilked;
        private SettingHandle<bool> _canThrumboMildBeCheese;
        private SettingHandle<bool> _canThrumbosGrowWool;
        private SettingHandle<bool> _canAmbrosiaBeGrown;
        private SettingHandle<bool> _doesAmbrosiaNeedToBeResearched;
        private SettingHandle<bool> _doesAmbrosiaNeedHydroponics;
        private SettingHandle<int> _reqAmbrosiaGrowLevel;
        public override void DefsLoaded() {
            _canThrumbosBeMilked = Settings.GetHandle<bool>(
                "_canThrumbosBeMilked", 
                "_canThrumbosBeMilked_title".Translate(), 
                "_canThrumbosBeMilked_desc".Translate(), 
                true
                );
            _canThrumboMildBeCheese = Settings.GetHandle<bool>(
                "_canThrumboMildBeCheese", 
                "_canThrumboMildBeCheese_title".Translate(), 
                "_canThrumboMildBeCheese_desc".Translate(), 
                true
                );
            _canThrumbosGrowWool = Settings.GetHandle<bool>(
                "_canThrumbosGrowWool", 
                "_canThrumbosGrowWool_title".Translate(), 
                "_canThrumboMildBeCheese_desc".Translate(), 
                true
                );
            _canAmbrosiaBeGrown = Settings.GetHandle<bool>(
                "_canAmbrosiaBeGrown", 
                "_canAmbrosiaBeGrown_title".Translate(), 
                "_canAmbrosiaBeGrown_desc".Translate(), 
                true
                );
            _doesAmbrosiaNeedToBeResearched = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedToBeResearched", 
                "_doesAmbrosiaNeedToBeResearched_title".Translate(), 
                "_doesAmbrosiaNeedToBeResearched_desc".Translate(), 
                true
                );
            _doesAmbrosiaNeedHydroponics = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedHydroponics", 
                "_doesAmbrosiaNeedHydroponics_title".Translate(), 
                "_doesAmbrosiaNeedHydroponics_desc".Translate(), 
                true
                ); 
            _reqAmbrosiaGrowLevel = Settings.GetHandle<int>(
                "_reqAmbrosiaGrowLevel", 
                "_reqAmbrosiaGrowLevel_title".Translate(), 
                "_reqAmbrosiaGrowLevel_desc".Translate(), 
                18
                );
        }
        
        public AllTheTweaks() {
        }
    }

    [StaticConstructorOnStartup]
    public static class AllTheTweaksStartup {
        static AllTheTweaksStartup() {
        }
    }
}