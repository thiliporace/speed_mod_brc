using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using SpeedMod.Patches;
using Reptile;
using System;

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
            /*[HarmonyPatch(typeof(MovementStats), nameof(MovementStats))]
            [HarmonyPrefix]

            public static void Prefix(MovementStats stats)
            {
                stats.walkSpeed = 999;
                stats.slideDeccHighSpeed = 999;
                stats.grindSpeed = 999;
                stats.groundAcc = 8;
                stats.airAcc = 8;
                stats.runSpeed = 999;
                stats.rotSpeedInAir = 8;
            }*/

            //TODO: Continuar depois
            [HarmonyPatch(typeof(Player), nameof(Player.Move))]
            [HarmonyPrefix]

           public static void Prefix(Player __instance)
            {
                if (__instance.targetMovement == global::Reptile.Player.MovementType.RUNNING)
                {
                    __instance.SetForwardSpeed(1000);
                }
                

            }
        }
    }
}
