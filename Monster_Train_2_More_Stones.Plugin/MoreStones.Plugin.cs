using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Text;
using TrainworksReloaded.Core;
using TrainworksReloaded.Core.Extensions;

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
                        "json/enhancers/wingstone.json",
                        "json/enhancers/apexstone.json",
                        "json/enhancers/armorstone.json",
                        "json/enhancers/flaskstone.json",
                        "json/enhancers/piercestone.json",
                        "json/enhancers/radiostone.json",
                        "json/enhancers/weirdstone.json",
                        "json/enhancers/impstone.json",
                        "json/enhancers/bladestone.json",
                        "json/enhancers/cyclestone.json",
                        "json/enhancers/dazestone.json",
                        "json/enhancers/lunestone.json",
                        "json/enhancers/reformstone.json",
                        "json/enhancers/smokestone.json",
                        "json/enhancers/boomstone.json",
                        "json/enhancers/froststone.json",
                        "json/enhancers/hoardstone.json",
                        "json/enhancers/lootstone.json",
                        "json/enhancers/meekstone.json",
                        "json/enhancers/mutestone.json",
                        "json/enhancers/pyrestone.json",
                        "json/enhancers/gorgestone.json",
                        "json/enhancers/growstone.json",
                        "json/enhancers/leechstone.json",
                        "json/enhancers/morselstone.json",
                        "json/enhancers/plaguestone.json",
                        "json/enhancers/spawnstone.json",
                        "json/enhancers/vilestone.json",
                        "json/enhancers/trainstone.json",
                        "json/enhancers/offerstone.json",
                        "json/enhancers/upstone.json",
                        "json/enhancers/downstone.json",
                        "json/enhancers/frontstone.json",
                        "json/enhancers/backstone.json",
                        "json/enhancers/healstone.json",
                        "json/enhancers/curestone.json",
                        "json/enhancers/scourstone.json"
                    );
                }
            );

            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            // Uncomment if you need harmony patches, if you are writing your own custom effects.
            var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            harmony.PatchAll();
        }
    }

    // Append upgrade preview text when a cast trigger is added to a spell
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
                if (__instance.GetCardType() == CardType.Spell && cardTriggerEffectData.GetTrigger() == CardTriggerType.OnCast && areTempModifiers)
                {
                    string arg = "tempUpgradeHighlight";
                    string arg2 = description.Substring(0, 0);
                    string arg3 = description.Substring(0);
                    string text = string.Format("{1}<{0}>{2}</{0}>", arg, arg2, arg3);
                    stringBuilder.Append(text);
                    stringBuilder.Append(Environment.NewLine);
                }
            }
        }
    }
}
