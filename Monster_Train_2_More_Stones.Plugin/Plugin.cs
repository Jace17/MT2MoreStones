using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using I2.Loc;
using Microsoft.Extensions.Configuration;
using ShinyShoe.Logging;
using SimpleInjector;
using System.Text;
using TrainworksReloaded.Base;
using TrainworksReloaded.Base.Card;
using TrainworksReloaded.Base.CardUpgrade;
using TrainworksReloaded.Base.Character;
using TrainworksReloaded.Base.Class;
using TrainworksReloaded.Base.Effect;
using TrainworksReloaded.Base.Localization;
using TrainworksReloaded.Base.Prefab;
using TrainworksReloaded.Base.Trait;
using TrainworksReloaded.Base.Trigger;
using TrainworksReloaded.Core;
using TrainworksReloaded.Core.Extensions;
using TrainworksReloaded.Core.Impl;
using TrainworksReloaded.Core.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Monster_Train_2_More_Stones.Plugin
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger = new(MyPluginInfo.PLUGIN_GUID);
        public void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;

            var builder = Railhead.GetBuilder();
            builder.Configure(
                MyPluginInfo.PLUGIN_GUID,
                c =>
                {
                    // Be sure to include all of your json files if you add more.
                    // Be sure to update the project configuration if you include more folders
                    //   the project only copies json files in the json folder and not in subdirectories.
                    c.AddMergedJsonFile(
                        "json/plugin.json",
                        "json/global.json",
                        "json/enhancers/tramplestone.json",
                        "json/enhancers/swipestone.json",
                        "json/enhancers/bannerstone.json",
                        "json/enhancers/shellstone.json",
                        "json/enhancers/attunestone.json",
                        "json/enhancers/weakstone.json",
                        "json/enhancers/feeblestone.json",
                        "json/enhancers/bloomstone.json",
                        "json/enhancers/sunstone.json",
                        "json/enhancers/vinestone.json",
                        "json/enhancers/cloudstone.json",
                        "json/enhancers/forgestone.json",
                        "json/enhancers/wingstone.json"
                    );
                }
            );

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            // Uncomment if you need harmony patches, if you are writing your own custom effects.
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(CardState), "SetupCardTriggerBodyUpgradeText")]
    public class AddOnCastTriggerTemporaryUpgradesToSpellText
    {
        public static void Postfix(StringBuilder stringBuilder, List<CardTriggerEffectData> triggerUpgrades, bool areTempModifiers, bool useUpgradeHighlightTextTags, bool highlightEntireUpgrade, CardState __instance)
        {
            foreach (CardTriggerEffectData cardTriggerEffectData in triggerUpgrades)
            {
                string empty = string.Empty;
                CardTriggerTypeMethods.GetLocalizedName(cardTriggerEffectData.GetTrigger(), out empty, true);
                string descriptionKey = cardTriggerEffectData.GetDescriptionKey();
                string description = descriptionKey.HasTranslation() ? descriptionKey.Localize(new CardEffectLocalizationContext(cardTriggerEffectData, null, __instance)) : "NO DESCRIPTION PROVIDED";
                if (__instance.GetCardType() == CardType.Spell && cardTriggerEffectData.GetTrigger() == CardTriggerType.OnCast)
                {
                    string arg = "tempUpgradeHighlight";
                    if (!areTempModifiers)
                    {
                        arg = "upgradeHighlight";
                    }
                    string arg2 = description.Substring(0, 0);
                    string arg3 = description.Substring(0);
                    string text = string.Format("{1}<{0}>{2}</{0}>", arg, arg2, arg3);
                    stringBuilder.Append(text);
                    stringBuilder.Append(Environment.NewLine);
                }
            }
        }
    }

    [HarmonyPatch(typeof(CardState), "SetupOnCastTriggerUpgradeText")]
    public class DisableSetupOnCastTriggerUpgradeText
    {
        public static bool Prefix(StringBuilder stringBuilder, bool useUpgradeHighlightTextTags)
        {
            return false;
        }
    }
}
