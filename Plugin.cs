using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using SpeedMod.Patches;
using Reptile;

namespace SpeedMod
{

    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class SpeedMod : BaseUnityPlugin
    {
        private const string MyGUID = "com.thiliporace.SpeedMod";
        private const string PluginName = "SpeedMod";
        private const string VersionString = "1.0.0";

        private Harmony harmony;
        public static Player player;
        //harmony.PatchAll(typeof(WallrunLineAbilityOnStartAbilityTranspiler));

        private void Awake()
        {
            harmony = new Harmony(MyGUID);
            harmony.PatchAll(typeof(PlayerPatch));
            harmony.PatchAll(typeof(ChangeSpeed));
        }

        class ChangeSpeed
        {
            [HarmonyPatch(typeof(MovementStats), nameof(MovementStats))]
            [HarmonyPostfix]

            public static void Postfix(MovementStats stats)
            {
                stats.walkSpeed = 150;
                stats.slideDeccHighSpeed = 200;
                stats.grindSpeed = 200;
                stats.groundAcc = 4;
                stats.airAcc = 4;
                stats.runSpeed = 300;
                stats.rotSpeedInAir = 8;
            }
        }
    }
}
