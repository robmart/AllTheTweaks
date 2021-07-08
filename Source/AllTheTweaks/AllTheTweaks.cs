using AllTheTweaks.References;
using HugsLib;
using HugsLib.Settings;
using Verse;

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
                "_canThrumbosBeMilked_title", 
                "_canThrumbosBeMilked_desc", 
                true
                );
            _canThrumboMildBeCheese = Settings.GetHandle<bool>(
                "_canThrumboMildBeCheese", 
                "_canThrumboMildBeCheese_title", 
                "_canThrumboMildBeCheese_desc", 
                true
                );
            _canThrumbosGrowWool = Settings.GetHandle<bool>(
                "_canThrumbosGrowWool", 
                "_canThrumbosGrowWool_title", 
                "_canThrumboMildBeCheese_desc", 
                true
                );
            _canAmbrosiaBeGrown = Settings.GetHandle<bool>(
                "_canAmbrosiaBeGrown", 
                "_canAmbrosiaBeGrown_title", 
                "_canAmbrosiaBeGrown_desc", 
                true
                );
            _doesAmbrosiaNeedToBeResearched = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedToBeResearched", 
                "_doesAmbrosiaNeedToBeResearched_title", 
                "_doesAmbrosiaNeedToBeResearched_desc", 
                true
                );
            _doesAmbrosiaNeedHydroponics = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedHydroponics", 
                "_doesAmbrosiaNeedHydroponics_title", 
                "_doesAmbrosiaNeedHydroponics_desc", 
                true
                ); 
            _reqAmbrosiaGrowLevel = Settings.GetHandle<int>(
                "_reqAmbrosiaGrowLevel", 
                "_reqAmbrosiaGrowLevel_title", 
                "_reqAmbrosiaGrowLevel_desc", 
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