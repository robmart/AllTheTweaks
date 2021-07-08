using Verse;

namespace AllTheTweaks {
    public class AllTheTweaks : Mod {
        AllTheTweaks(ModContentPack content) : base(content) {
        }
    }

    [StaticConstructorOnStartup]
    public static class AllTheTweaksStartup {
        static AllTheTweaksStartup() {
        }
    }
}