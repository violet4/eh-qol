namespace EH_QOL_No_Quest_Lockout;

using System.Collections.Generic;
using HarmonyLib;
using System.Linq;
using System.Reflection.Emit;

public class API : IModApi {
    public void InitMod(Mod mod) {
        var harmony = new Harmony("EH_QOL_No_Quest_Lockout");
        harmony.PatchAll();
    }

    [HarmonyPatch(typeof (QuestLockInstance))]
    [HarmonyPatch("SetUnlocked")]
    public class EH_QOL_No_Quest_Lockout {
        private static IEnumerable<CodeInstruction> Transpiler(
            IEnumerable<CodeInstruction> instructions)
        {
            Log.Out( "Removing Quest Lock timeout (QuestLockInstance.SetUnlocked)");
            List<CodeInstruction> source = new List<CodeInstruction>(instructions);
            for (int index = 0; index < source.Count; ++index) {
                if (source[index].opcode == OpCodes.Ldc_I4 && source[index].operand.ToString() == "2000") {
                    source[index].operand = (object) 0;
                    Log.Out("Disabling quest lockout (replace 2000UL with 0)");
                    break;
                }
            }
            return ((IEnumerable<CodeInstruction>) source).AsEnumerable<CodeInstruction>();
        }
    }

}
