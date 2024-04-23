using HarmonyLib;
using Reptile;

namespace SpeedMod.Patches
{
    internal static class PlayerPatch
    {
        [HarmonyPatch(typeof(Player), nameof(Player.Init))]
        [HarmonyPostfix]
        private static void Player_Init_Postfix(Player __instance)
        {
        if (!__instance.isAI) { SpeedMod.player = __instance; }
    }
    }
}