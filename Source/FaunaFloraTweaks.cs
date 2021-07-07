using Verse;

namespace FaunaFloraTweaks {
    public class FaunaFloraTweaks : Mod {
        FaunaFloraTweaks(ModContentPack content) : base(content) {
        }
    }

    [StaticConstructorOnStartup]
    public static class FaunaFloraTweaksStartup {
        static FaunaFloraTweaksStartup() {
        }
    }
}