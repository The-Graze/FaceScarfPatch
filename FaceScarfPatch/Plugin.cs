using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Comments provided for C# beginners
namespace FaceScarfPatch
{
    [BepInPlugin("dev.gorillascarfpatch", "GorillaScarfPatch", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {

        void Start()
        {
            GorillaTagger.OnPlayerSpawned(delegate { CosmeticsV2Spawner_Dirty.OnPostInstantiateAllPrefabs += WaWa; });
        }
        public static void WaWa()
        {
            foreach (var cos in VRRig.LocalRig.cosmetics)
            {
                if (cos.name == "LFAAW." || cos.name == "LFACC.")
                {
                    if (cos.transform.parent.name == "head")
                    {
                        cos.SetActive(false);
                    }
                }
            }
        }
    }
}
