using System;
using System.Collections.Generic;
using HarmonyLib;
using System.Linq;
using System.Reflection.Emit;

public class API : IModApi {

    public void InitMod() {
    //    ModEvents.ChatMessage.RegisterHandler(ChatMessage);
    }

    public void InitMod(Mod mod) {
       Log.Out("fkjasoefjaeoidfkjaodkfjaokjfdaokjdfoakjd kj violet loaded!!!!!!!!! ################## new version yay");
       var harmony = new Harmony("violet0");
       harmony.PatchAll();
       //    ModEvents.ChatMessage.RegisterHandler(ChatMessage);
    }

  [HarmonyPatch(typeof (QuestLockInstance))]
  [HarmonyPatch("SetUnlocked")]
  public class Violet_DisableQuestLockout {
    private static IEnumerable<CodeInstruction> Transpiler(
      IEnumerable<CodeInstruction> instructions)
    {
      Log.Out( "Patching QuestLockInstance.SetUnlocked()j aewktjalkf jalkwjf gaoiwj oaijf oiawjf oaiwjefoiaj foija wgoiljhaw tiuoha oitu");
      List<CodeInstruction> source = new List<CodeInstruction>(instructions);
      for (int index = 0; index < source.Count; ++index)
      {
        if (source[index].opcode == OpCodes.Ldc_I4 && source[index].operand.ToString() == "2000")
        {
          source[index].operand = (object) 0;
          Log.Out("Adjusting 2000 to 0 to avoid quest lockout aklsjdf lkajsdflkaj sdflkjasldkfja sldkfja lskfjawoiuhrtapwi jfpaoiwhj fpaoiwj foia");
          break;
        }
      }
      return ((IEnumerable<CodeInstruction>) source).AsEnumerable<CodeInstruction>();
    }
  }

}
