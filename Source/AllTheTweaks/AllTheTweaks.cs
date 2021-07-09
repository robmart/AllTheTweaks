using AllTheTweaks.References;
using HugsLib;
using HugsLib.Settings;
using Verse;
using VFECore;

namespace AllTheTweaks {
    public class AllTheTweaks : ModBase {
        #region Config

        private SettingHandle<bool> _canThrumbosBeMilked;
        private SettingHandle<bool> _canThrumboMilkBeCheese;
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
            _canThrumbosBeMilked.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_canThrumbosBeMilked, newValue);
            };
            _canThrumboMilkBeCheese = Settings.GetHandle<bool>(
                "_canThrumboMilkBeCheese", 
                "_canThrumboMilkBeCheese_title".Translate(), 
                "_canThrumboMilkBeCheese_desc".Translate(), 
                true
                );
            _canThrumboMilkBeCheese.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_canThrumboMilkBeCheese, newValue);
            };
            _canThrumbosGrowWool = Settings.GetHandle<bool>(
                "_canThrumbosGrowWool", 
                "_canThrumbosGrowWool_title".Translate(), 
                "_canThrumbosGrowWool_desc".Translate(), 
                true
                );
            _canThrumbosGrowWool.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_canThrumbosGrowWool, newValue);
            };
            _canAmbrosiaBeGrown = Settings.GetHandle<bool>(
                "_canAmbrosiaBeGrown", 
                "_canAmbrosiaBeGrown_title".Translate(), 
                "_canAmbrosiaBeGrown_desc".Translate(), 
                true
                );
            _canAmbrosiaBeGrown.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_canAmbrosiaBeGrown, newValue);
            };
            _doesAmbrosiaNeedToBeResearched = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedToBeResearched", 
                "_doesAmbrosiaNeedToBeResearched_title".Translate(), 
                "_doesAmbrosiaNeedToBeResearched_desc".Translate(), 
                true
                );
            _doesAmbrosiaNeedToBeResearched.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_doesAmbrosiaNeedToBeResearched, newValue);
            };
            _doesAmbrosiaNeedHydroponics = Settings.GetHandle<bool>(
                "_doesAmbrosiaNeedHydroponics", 
                "_doesAmbrosiaNeedHydroponics_title".Translate(), 
                "_doesAmbrosiaNeedHydroponics_desc".Translate(), 
                true
                );
            _doesAmbrosiaNeedHydroponics.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_doesAmbrosiaNeedHydroponics, newValue);
            }; 
            _reqAmbrosiaGrowLevel = Settings.GetHandle<int>(
                "_reqAmbrosiaGrowLevel", 
                "_reqAmbrosiaGrowLevel_title".Translate(), 
                "_reqAmbrosiaGrowLevel_desc".Translate(), 
                18,
                Validators.IntRangeValidator(0, 20)
                );
        }

        private void OnConfigValueToggleableChanged(SettingHandle<bool> settingHandle, bool newValue) {
            
        }
        
        #endregion

        public AllTheTweaks() {
        }
    }

    [StaticConstructorOnStartup]
    public static class AllTheTweaksStartup {
        static AllTheTweaksStartup() {
        }
    }
}