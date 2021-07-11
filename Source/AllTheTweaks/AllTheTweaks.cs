using System.IO;
using System.Linq;
using System.Xml;
using AllTheTweaks.PatchOperation;
using AllTheTweaks.References;
using AllTheTweaks.Utilities;
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

        private bool _oldCheeseValue;
        public override void DefsLoaded() {
            _canThrumbosBeMilked = Settings.GetHandle<bool>(
                "_canThrumbosBeMilked", 
                "_canThrumbosBeMilked_title".Translate(), 
                "_canThrumbosBeMilked_desc".Translate(), 
                true
                );
            _canThrumbosBeMilked.OnValueChanged = newValue => {
                OnConfigValueToggleableChanged(_canThrumbosBeMilked, newValue);
                switch (newValue) {
                    case false:
                        _oldCheeseValue = _canThrumboMilkBeCheese;
                        _canThrumboMilkBeCheese.Value =
                            false; //If you can't milk Thrumbos you shouldn't be able to make cheese from them either
                        _canThrumboMilkBeCheese.HasUnsavedChanges = true; 
                        break;
                    case true:
                        _canThrumboMilkBeCheese.Value = _oldCheeseValue; 
                        _canThrumboMilkBeCheese.HasUnsavedChanges = true;
                        break;
                }
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
			_canThrumboMilkBeCheese.VisibilityPredicate = () =>
				_canThrumbosBeMilked && LoadedModManager.RunningMods.Any(pack => pack.Name == ModNameConstants.VCE);
            
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

        /// <summary>
        /// Copied from VFECore
        /// </summary>
        /// <see cref="VFEGlobal.AddButton"/>
        /// <param name="settingHandle"></param>
        /// <param name="newValue"></param>
        private void OnConfigValueToggleableChanged(SettingHandle<bool> settingHandle, bool newValue) {
            var modContentPack = ModContentPack;
            if (modContentPack == null) {
                return;
            }

            foreach (Verse.PatchOperation patch in modContentPack.Patches) {
                if (patch != null && patch is ATTPatchOperationToggleable operationToggable1) {
                    var flag = false;
                    for (var index = 0; index < operationToggable1.mods.Count; ++index) {
                        if (ModLister.HasActiveModWithName(operationToggable1.mods[index])) {
                            flag = true;
                        }
                        else {
                            flag = false;
                            break;
                        }
                    }
                    
                    if (flag && operationToggable1.label == settingHandle.Name) {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(operationToggable1.sourceFile);
                        string xpath = "Patch/Operation[@Class=\"AllTheTweaks.PatchOperation.ATTPatchOperationToggleable\" and label=\"" + operationToggable1.label + "\"]/enabled/text()";
                        Logger.Warning(xmlDocument.SelectSingleNode(xpath).ToString());
                        if (!newValue) {
                            xmlDocument.SelectSingleNode(xpath).Value = "False";
                            operationToggable1.enabled = false;
                        }
                        else {
                            xmlDocument.SelectSingleNode(xpath).Value = "True";
                            operationToggable1.enabled = true;
                        }
                        File.WriteAllText(operationToggable1.sourceFile, GlobalSettingsUtilities.PrettyXml(xmlDocument.OuterXml));
                    }
                }
            }
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