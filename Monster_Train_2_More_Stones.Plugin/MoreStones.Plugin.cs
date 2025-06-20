using BepInEx;
using BepInEx.Configuration;
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
        public static ConfigEntry<bool>? addBloomstone;
        public static ConfigEntry<bool>? addHealstone;
        public static ConfigEntry<bool>? addSunstone;
        public static ConfigEntry<bool>? addVinestone;
        public static ConfigEntry<bool>? addBackstone;
        public static ConfigEntry<bool>? addCloudstone;
        public static ConfigEntry<bool>? addWeakstone;
        public static ConfigEntry<bool>? addWingstone;
        public static ConfigEntry<bool>? addBannerstone;
        public static ConfigEntry<bool>? addBoomstone;
        public static ConfigEntry<bool>? addCurestone;
        public static ConfigEntry<bool>? addExtremestone;
        public static ConfigEntry<bool>? addShellstone;
        public static ConfigEntry<bool>? addTramplestone;
        public static ConfigEntry<bool>? addSwipestone;
        public static ConfigEntry<bool>? addTrainstone;
        public static ConfigEntry<bool>? addPiercestone;
        public static ConfigEntry<bool>? addAttunestone;
        public static ConfigEntry<bool>? addValuestone;
        public static ConfigEntry<bool>? addVilestone;
        public static ConfigEntry<bool>? addApexstone;
        public static ConfigEntry<bool>? addArmorstone;
        public static ConfigEntry<bool>? addImpstone;
        public static ConfigEntry<bool>? addUpstone;
        public static ConfigEntry<bool>? addFlaskstone;
        public static ConfigEntry<bool>? addForgestone;
        public static ConfigEntry<bool>? addWeirdstone;
        public static ConfigEntry<bool>? addRadiostone;
        public static ConfigEntry<bool>? addBladestone;
        public static ConfigEntry<bool>? addCyclestone;
        public static ConfigEntry<bool>? addFeeblestone;
        public static ConfigEntry<bool>? addLunestone;
        public static ConfigEntry<bool>? addDazestone;
        public static ConfigEntry<bool>? addReformstone;
        public static ConfigEntry<bool>? addScourstone;
        public static ConfigEntry<bool>? addSmokestone;
        public static ConfigEntry<bool>? addBrimstone;
        public static ConfigEntry<bool>? addHoardstone;
        public static ConfigEntry<bool>? addLootstone;
        public static ConfigEntry<bool>? addPyrestone;
        public static ConfigEntry<bool>? addFroststone;
        public static ConfigEntry<bool>? addMeekstone;
        public static ConfigEntry<bool>? addMutestone;
        public static ConfigEntry<bool>? addOfferstone;
        public static ConfigEntry<bool>? addDownstone;
        public static ConfigEntry<bool>? addGorgestone;
        public static ConfigEntry<bool>? addLeechstone;
        public static ConfigEntry<bool>? addMorselstone;
        public static ConfigEntry<bool>? addFrontstone;
        public static ConfigEntry<bool>? addGrowstone;
        public static ConfigEntry<bool>? addPlaguestone;
        public static ConfigEntry<bool>? addSpawnstone;

        internal static new ManualLogSource Logger = new(MyPluginInfo.PLUGIN_GUID);
        public void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;

            addBloomstone = Config.Bind("General", "Bloomstone", true, "Enable Bloomstone. (Add Rejuvenate: +4 Attack, +4 Health)");
            addHealstone = Config.Bind("General", "Healstone", true, "Enable Healstone. (Restore 5 HP to all allies.)");
            addSunstone = Config.Bind("General", "Sunstone", true, "Enable Sunstone. (Draw +1 next turn.)");
            addVinestone = Config.Bind("General", "Vinestone", true, "Enable Vinestone. (Apply Rooted 1 to all enemies.)");
            addBackstone = Config.Bind("General", "Backstone", true, "Enable Backstone. (Add Retreat. (Targeted spells only.))");
            addCloudstone = Config.Bind("General", "Cloudstone", true, "Enable Cloudstone. (Add Shift: +2 Attack, +2 Health)");
            addWeakstone = Config.Bind("General", "Weakstone", true, "Enable Weakstone. (Apply Melee Weakness 1 to all enemies.)");
            addWingstone = Config.Bind("General", "Wingstone", true, "Enable Wingstone. (Add Ability: Flight)");
            addBannerstone = Config.Bind("General", "Bannerstone", true, "Enable Bannerstone. (Add Deployable. Attack +10.)");
            addBoomstone = Config.Bind("General", "Boomstone", true, "Enable Boomstone. (Add Explosive. Spell Power +5.)");
            addCurestone = Config.Bind("General", "Curestone", true, "Enable Curestone. (Remove all debuff effects from friendly units.)");
            addExtremestone = Config.Bind("General", "Extremestone", true, "Enable Extremestone. (Spell Power +30.)");
            addShellstone = Config.Bind("General", "Shellstone", true, "Enable Shellstone. (Add Titanskin 2.)");
            addTramplestone = Config.Bind("General", "Tramplestone", true, "Enable Stompstone. (Add Trample.)");
            addSwipestone = Config.Bind("General", "Swipestone", true, "Enable Swipestone. (Add Sweep. Attack -10.)");
            addTrainstone = Config.Bind("General", "Trainstone", true, "Enable Trainstone. (Ember cost is 0.)");
            addPiercestone = Config.Bind("General", "Piercestone", true, "Enable Truestone. (Add Piercing. Spell Power +5.)");
            addAttunestone = Config.Bind("General", "Attunestone", true, "Enable Tunestone. (Add Attuned.)");
            addValuestone = Config.Bind("General", "Valuestone", true, "Enable Valuestone. (Ember cost -3.)");
            addVilestone = Config.Bind("General", "Vilestone", true, "Enable Vilestone. (Apply Corruption 20 to all enemies.)");
            addApexstone = Config.Bind("General", "Apexstone", true, "Enable Apexstone. (Add Armored: +4 Attack.)");
            addArmorstone = Config.Bind("General", "Armorstone", true, "Enable Armorstone. (Add Armor 25.)");
            addImpstone = Config.Bind("General", "Impstone", true, "Enable Impstone. (Add a common or uncommon Imp unit to your hand.)");
            addUpstone = Config.Bind("General", "Upstone", true, "Enable Upstone. (Add Ascend. (Targeted spells only.))");
            addFlaskstone = Config.Bind("General", "Flaskstone", true, "Enable Flaskstone. (Add Mix.)");
            addForgestone = Config.Bind("General", "Forgestone", true, "Enable Forgestone. (Add Artificer: +8 Attack, +8 Health)");
            addWeirdstone = Config.Bind("General", "Weirdstone", true, "Enable Madstone. (Add Unstable 20.)");
            addRadiostone = Config.Bind("General", "Radiostone", true, "Enable Radstone. (Apply Unstable 10 to all enemies.)");
            addBladestone = Config.Bind("General", "Bladestone", true, "Enable Bladestone. (Add Mageblade 2.)");
            addCyclestone = Config.Bind("General", "Cyclestone", true, "Enable Cyclestone. (Add Mooncycle: +2 Attack, +2 Health)");
            addFeeblestone = Config.Bind("General", "Feeblestone", true, "Enable Feeblestone. (Apply Spell Weakness 1 to all enemies.)");
            addLunestone = Config.Bind("General", "Lunestone", true, "Enable Lunestone. (Add Phase. Ember cost -1.)");
            addDazestone = Config.Bind("General", "Dazestone", true, "Enable Dazestone. (Apply Dazed 1 to all enemies.)");
            addReformstone = Config.Bind("General", "Reformstone", true, "Enable Formstone. (Reform a random unit.)");
            addScourstone = Config.Bind("General", "Scourstone", true, "Enable Scourstone. (Remove all buff effects from enemy units.)");
            addSmokestone = Config.Bind("General", "Smokestone", true, "Enable Smokestone. (Add Stealth 3. +10 attack.)");
            addBrimstone = Config.Bind("General", "Brimstone", true, "Enable Brimstone. (Deal 3 Damage to all enemies.)");
            addHoardstone = Config.Bind("General", "Hoardstone", true, "Enable Hoardstone. (Gain 1 Dragon's Hoard.)");
            addLootstone = Config.Bind("General", "Lootstone", true, "Enable Lootstone. (Gain 10 Gold.)");
            addPyrestone = Config.Bind("General", "Pyrestone", true, "Enable Pyrestone. (Apply Pyregel 5  to all enemies.)");
            addFroststone = Config.Bind("General", "Froststone", true, "Enable Froststone. (Apply Frostbite 10  to all enemies.)");
            addMeekstone = Config.Bind("General", "Meekstone", true, "Enable Meekstone. (Apply Sap 2 to all enemies.)");
            addMutestone = Config.Bind("General", "Mutestone", true, "Enable Mutestone. (Apply Mute 3 to all enemies.)");
            addOfferstone = Config.Bind("General", "Offerstone", true, "Enable Offerstone. (Add Offering. Ember cost -1. (Targetless spells only.))");
            addDownstone = Config.Bind("General", "Downstone", true, "Enable Downstone. (Add Descend. (Targeted spells only.))");
            addGorgestone = Config.Bind("General", "Gorgestone", true, "Enable Gorgestone. (Add Gorge: +2 Attack, +2 Health)");
            addLeechstone = Config.Bind("General", "Leechstone", true, "Enable Leechstone. (Add Lifesteal 3. +10 Attack.)");
            addMorselstone = Config.Bind("General", "Morselstone", true, "Enable Morselstone. (Add a common or uncommon Morsel unit to your hand.)");
            addFrontstone = Config.Bind("General", "Frontstone", true, "Enable Frontstone. (Add Advance. (Targeted spells only.))");
            addGrowstone = Config.Bind("General", "Growstone", true, "Enable Growstone. (Propagate 1 on all units.)");
            addPlaguestone = Config.Bind("General", "Plaguestone", true, "Enable Plaguestone. (Apply Decay 4 to all enemies.)");
            addSpawnstone = Config.Bind("General", "Spawnstone", true, "Enable Spawnstone. (Add Spawn 1.)");

            List<String> paths = new List<string>
            {
                "json/plugin.json",
                "json/global.json",
            };

            if (addBloomstone.Value) paths.Add("json/enhancers/bloomstone.json");
            if (addHealstone.Value) paths.Add("json/enhancers/healstone.json");
            if (addSunstone.Value) paths.Add("json/enhancers/sunstone.json");
            if (addVinestone.Value) paths.Add("json/enhancers/vinestone.json");
            if (addBackstone.Value) paths.Add("json/enhancers/backstone.json");
            if (addCloudstone.Value) paths.Add("json/enhancers/cloudstone.json");
            if (addWeakstone.Value) paths.Add("json/enhancers/weakstone.json");
            if (addWingstone.Value) paths.Add("json/enhancers/wingstone.json");
            if (addBannerstone.Value) paths.Add("json/enhancers/bannerstone.json");
            if (addBoomstone.Value) paths.Add("json/enhancers/boomstone.json");
            if (addCurestone.Value) paths.Add("json/enhancers/curestone.json");
            if (addExtremestone.Value) paths.Add("json/enhancers/extremestone.json");
            if (addShellstone.Value) paths.Add("json/enhancers/shellstone.json");
            if (addTramplestone.Value) paths.Add("json/enhancers/tramplestone.json");
            if (addSwipestone.Value) paths.Add("json/enhancers/swipestone.json");
            if (addTrainstone.Value) paths.Add("json/enhancers/trainstone.json");
            if (addPiercestone.Value) paths.Add("json/enhancers/piercestone.json");
            if (addAttunestone.Value) paths.Add("json/enhancers/attunestone.json");
            if (addValuestone.Value) paths.Add("json/enhancers/valuestone.json");
            if (addVilestone.Value) paths.Add("json/enhancers/vilestone.json");
            if (addApexstone.Value) paths.Add("json/enhancers/apexstone.json");
            if (addArmorstone.Value) paths.Add("json/enhancers/armorstone.json");
            if (addImpstone.Value) paths.Add("json/enhancers/impstone.json");
            if (addUpstone.Value) paths.Add("json/enhancers/upstone.json");
            if (addFlaskstone.Value) paths.Add("json/enhancers/flaskstone.json");
            if (addForgestone.Value) paths.Add("json/enhancers/forgestone.json");
            if (addWeirdstone.Value) paths.Add("json/enhancers/weirdstone.json");
            if (addRadiostone.Value) paths.Add("json/enhancers/radiostone.json");
            if (addBladestone.Value) paths.Add("json/enhancers/bladestone.json");
            if (addCyclestone.Value) paths.Add("json/enhancers/cyclestone.json");
            if (addFeeblestone.Value) paths.Add("json/enhancers/feeblestone.json");
            if (addLunestone.Value) paths.Add("json/enhancers/lunestone.json");
            if (addDazestone.Value) paths.Add("json/enhancers/dazestone.json");
            if (addReformstone.Value) paths.Add("json/enhancers/reformstone.json");
            if (addScourstone.Value) paths.Add("json/enhancers/scourstone.json");
            if (addSmokestone.Value) paths.Add("json/enhancers/smokestone.json");
            if (addBrimstone.Value) paths.Add("json/enhancers/brimstone.json");
            if (addHoardstone.Value) paths.Add("json/enhancers/hoardstone.json");
            if (addLootstone.Value) paths.Add("json/enhancers/lootstone.json");
            if (addPyrestone.Value) paths.Add("json/enhancers/pyrestone.json");
            if (addFroststone.Value) paths.Add("json/enhancers/froststone.json");
            if (addMeekstone.Value) paths.Add("json/enhancers/meekstone.json");
            if (addMutestone.Value) paths.Add("json/enhancers/mutestone.json");
            if (addOfferstone.Value) paths.Add("json/enhancers/offerstone.json");
            if (addDownstone.Value) paths.Add("json/enhancers/downstone.json");
            if (addGorgestone.Value) paths.Add("json/enhancers/gorgestone.json");
            if (addLeechstone.Value) paths.Add("json/enhancers/leechstone.json");
            if (addMorselstone.Value) paths.Add("json/enhancers/morselstone.json");
            if (addFrontstone.Value) paths.Add("json/enhancers/frontstone.json");
            if (addGrowstone.Value) paths.Add("json/enhancers/growstone.json");
            if (addPlaguestone.Value) paths.Add("json/enhancers/plaguestone.json");
            if (addSpawnstone.Value) paths.Add("json/enhancers/spawnstone.json"); 

            var builder = Railhead.GetBuilder();
            builder.Configure(
                MyPluginInfo.PLUGIN_GUID,
                c =>
                {
                    // Be sure to include all of your json files if you add more.
                    // Be sure to update the project configuration if you include more folders
                    //   the project only copies json files in the json folder and not in subdirectories.
                    c.AddMergedJsonFile(paths);
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
