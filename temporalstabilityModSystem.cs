using HarmonyLib;
using System.Diagnostics;
using System.Reflection;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using System;
using Vintagestory.API.MathTools;

namespace temporalstability
{
    public class temporalstabilityModSystem : ModSystem
    {

        //ICoreAPI api;
        private Harmony harmony = new Harmony("spang.GetTemporalStability");

        public override void Start(ICoreAPI api)
        {
            
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override void Dispose()
        {
            this.harmony.UnpatchAll("spang.GetTemporalStability");
            base.Dispose();
        }


        [HarmonyPatch(typeof(SystemTemporalStability), "GetTemporalStability", new Type[] { typeof(double), typeof(double), typeof(double) })]

        public static class GetTemporalStabilityPatch1
        {
            [HarmonyPostfix]
            public static void Postfix(ref float __result )
            {
                //Debug.WriteLine("patch1: " + __result);
                __result = 0f;
            }
        }

        [HarmonyPatch(typeof(SystemTemporalStability), "GetTemporalStability", new Type[] { typeof(Vec3d) })]

        public static class GetTemporalStabilityPatch2
        {
            [HarmonyPostfix]
            public static void Postfix(ref float __result)
            {
                //Debug.WriteLine("patch2: " + __result);
                __result = 0f;
            }
        }

        [HarmonyPatch(typeof(SystemTemporalStability), "GetTemporalStability", new Type[] { typeof(BlockPos) })]

        public static class GetTemporalStabilityPatch3
        {
            [HarmonyPostfix]
            public static void Postfix(ref float __result)
            {
                //Debug.WriteLine("patch3: " + __result);
                __result = 0f;
            }
        }
        
    }
}
