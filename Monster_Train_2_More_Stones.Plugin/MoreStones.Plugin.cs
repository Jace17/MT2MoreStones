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
        public static ConfigEntry<bool>? addArtistone;
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

        public static ConfigEntry<bool>? addSteelstone;
        public static ConfigEntry<bool>? addForgestone;
        public static ConfigEntry<bool>? addSmeltstone;
        public static ConfigEntry<bool>? addHearthstone;
        public static ConfigEntry<bool>? addFusionstone;
        public static ConfigEntry<bool>? addReapstone;
        public static ConfigEntry<bool>? addInspirestone;
        public static ConfigEntry<bool>? addEtchstone;
        public static ConfigEntry<bool>? addSnipestone;

        internal static new ManualLogSource Logger = new(MyPluginInfo.PLUGIN_GUID);
        public void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;

            addBloomstone = Config.Bind("General", "Bloomstone", true, "Enable Bloomstone. (Add Rejuvenate: +4 Attack, +4 Health)\n启用盛开石（单位获得'复原: +4 攻击力，+4 生命值。'）");
            addHealstone = Config.Bind("General", "Healstone", true, "Enable Healstone. (Restore 5 HP to all allies.)\n启用回血石（法术获得'使本层所有友方单位恢复 5 点生命值。'）");
            addSunstone = Config.Bind("General", "Sunstone", true, "Enable Sunstone. (Draw +1 next turn.)\n启用太阳石（法术获得'下个回合抽 +1 张牌。'）");
            addVinestone = Config.Bind("General", "Vinestone", true, "Enable Vinestone. (Apply Rooted 1 to all enemies.)\n启用藤蔓石（法术获得'对本层所有敌方单位施加缠绕 1。'）");
            addBackstone = Config.Bind("General", "Backstone", true, "Enable Backstone. (Add Retreat. (Targeted spells only.))\n启用后移石（指定目标法术获得'后退。'）");
            addCloudstone = Config.Bind("General", "Cloudstone", true, "Enable Cloudstone. (Add Shift: +2 Attack, +2 Health)\n启用腾云石（单位获得'转移: +2 攻击力，+2 生命值。'）");
            addWeakstone = Config.Bind("General", "Weakstone", true, "Enable Weakstone. (Apply Melee Weakness 1 to all enemies.)\n启用破防石（法术获得'对本层所有敌方单位施加近战易伤 1。'）");
            addWingstone = Config.Bind("General", "Wingstone", true, "Enable Wingstone. (Add Ability: Flight)\n启用添翼石（单位获得能力: 飞行。）");
            addBannerstone = Config.Bind("General", "Bannerstone", true, "Enable Bannerstone. (Add Deployable. Attack +10.)\n启用战旗石（单位获得可部署，+10 攻击力。）");
            addBoomstone = Config.Bind("General", "Boomstone", true, "Enable Boomstone. (Add Explosive. Spell Power +5.)\n启用爆破石（法术获得爆炸，+5 魔法强度。）");
            addCurestone = Config.Bind("General", "Curestone", true, "Enable Curestone. (Remove all debuff effects from friendly units.)\n启用洗涤石（法术获得'移除本层所有友方单位身上的所有减益效果。'）");
            addExtremestone = Config.Bind("General", "Extremestone", true, "Enable Extremestone. (Spell Power +30.)\n启用极限石（法术获得 +30 魔法强度。）");
            addShellstone = Config.Bind("General", "Shellstone", true, "Enable Shellstone. (Add Titanskin 2.)\n启用甲壳石（单位获得泰坦皮肤 2。）");
            addTramplestone = Config.Bind("General", "Tramplestone", true, "Enable Stompstone. (Add Trample.)\n启用蹂躏石（单位获得践踏。）");
            addSwipestone = Config.Bind("General", "Swipestone", true, "Enable Swipestone. (Add Sweep. Attack -10.)\n启用拍击石（单位获得横扫，-10 攻击力。）");
            addTrainstone = Config.Bind("General", "Trainstone", true, "Enable Trainstone. (Ember cost is 0.)\n启用火车石（单位费用变成 0 余烬。）");
            addPiercestone = Config.Bind("General", "Piercestone", true, "Enable Truestone. (Add Piercing. Spell Power +5.)\n启用真言石（法术获得穿刺，+5 魔法强度。）");
            addAttunestone = Config.Bind("General", "Attunestone", true, "Enable Tunestone. (Add Attuned.)\n启用调音石（法术获得调和。）");
            addValuestone = Config.Bind("General", "Valuestone", true, "Enable Valuestone. (Ember cost -3.)\n启用价值石（法术费用 -3 余烬。）");
            addVilestone = Config.Bind("General", "Vilestone", true, "Enable Vilestone. (Apply Corruption 20 to all enemies.)\n启用腐败石（法术获得'对本层所有敌方单位施加腐化 20。'）");
            addApexstone = Config.Bind("General", "Apexstone", true, "Enable Apexstone. (Add Armored: +4 Attack.)\n启用巅峰石（单位获得'带甲: +4 攻击力。'）");
            addArmorstone = Config.Bind("General", "Armorstone", true, "Enable Armorstone. (Add Armor 25.)\n启用护甲石（单位获得护甲 25。）");
            addImpstone = Config.Bind("General", "Impstone", true, "Enable Impstone. (Add a common or uncommon Imp unit to your hand.)\n启用碎尾石（法术获得'将一个普通或高级小鬼单位加入你的手牌。'）");
            addUpstone = Config.Bind("General", "Upstone", true, "Enable Upstone. (Add Ascend. (Targeted spells only.))\n启用上移石（指定目标法术获得'上升。'）");
            addFlaskstone = Config.Bind("General", "Flaskstone", true, "Enable Flaskstone. (Add Mix.)\n启用试剂石（法术获得'调配。'）");
            addArtistone = Config.Bind("General", "Artistone", true, "Enable Artistone. (Add Artificer: +8 Attack, +8 Health)");
            addWeirdstone = Config.Bind("General", "Weirdstone", true, "Enable Madstone. (Add Unstable 20.)\n启用癫狂石（单位获得不稳定 20。）");
            addRadiostone = Config.Bind("General", "Radiostone", true, "Enable Radstone. (Apply Unstable 10 to all enemies.)\n启用辐射石（法术获得'对本层所有敌方单位施加不稳定 10。'）");
            addBladestone = Config.Bind("General", "Bladestone", true, "Enable Bladestone. (Add Mageblade 2.)\n启用刀刃石（单位获得魔刃 2。）");
            addCyclestone = Config.Bind("General", "Cyclestone", true, "Enable Cyclestone. (Add Mooncycle: +2 Attack, +2 Health)\n启用朔望石（单位获得'月相循环: +2 攻击力，+2 生命值。'）");
            addFeeblestone = Config.Bind("General", "Feeblestone", true, "Enable Feeblestone. (Apply Spell Weakness 1 to all enemies.)\n启用破魔石（法术获得'对本层所有敌方单位施加法术易伤 1。'）");
            addLunestone = Config.Bind("General", "Lunestone", true, "Enable Lunestone. (Add Phase. Ember cost -1.)\n启用月相石（法术获得'月相变化'，费用 -1 余烬。）");
            addDazestone = Config.Bind("General", "Dazestone", true, "Enable Dazestone. (Apply Dazed 1 to all enemies.)\n启用眩晕石（法术获得'对本层所有敌方单位施加眩晕 1。'）");
            addReformstone = Config.Bind("General", "Reformstone", true, "Enable Formstone. (Reform a random unit.)\n启用塑造石（法术获得'随机改造一个单位。'）");
            addScourstone = Config.Bind("General", "Scourstone", true, "Enable Scourstone. (Remove all buff effects from enemy units.)\n启用冲刷石（法术获得'移除本层所有敌方单位身上的所有增益效果。'）");
            addSmokestone = Config.Bind("General", "Smokestone", true, "Enable Smokestone. (Add Stealth 3. +10 attack.)\n启用烟雾石（单位获得潜行 3，+10 攻击力。）");
            addBrimstone = Config.Bind("General", "Brimstone", true, "Enable Brimstone. (Deal 3 Damage to all enemies.)\n启用硫黄石（法术获得'对本层所有敌方单位造成 3 点伤害。'）");
            addHoardstone = Config.Bind("General", "Hoardstone", true, "Enable Hoardstone. (Gain 1 Dragon's Hoard.)\n启用龙藏石（法术获得'获得 1 龙族宝藏。'）");
            addLootstone = Config.Bind("General", "Lootstone", true, "Enable Lootstone. (Gain 10 Gold.)\n启用财宝石（法术获得'获得 10 金币。'）");
            addPyrestone = Config.Bind("General", "Pyrestone", true, "Enable Pyrestone. (Apply Pyregel 5 to all enemies.)\n启用（法术获得'对本层所有敌方单位施加薪火熔胶 5。'）");
            addFroststone = Config.Bind("General", "Froststone", true, "Enable Froststone. (Apply Frostbite 10  to all enemies.)\n启用霜冻石（法术获得'对本层所有敌方单位施加霜冻 10。'）");
            addMeekstone = Config.Bind("General", "Meekstone", true, "Enable Meekstone. (Apply Sap 2 to all enemies.)\n启用驯化石（法术获得'对本层所有敌方单位施加弱化 2。'）");
            addMutestone = Config.Bind("General", "Mutestone", true, "Enable Mutestone. (Apply Mute 3 to all enemies.)\n启用沉默石（法术获得'对本层所有敌方单位施加沉默 3。'）");
            addOfferstone = Config.Bind("General", "Offerstone", true, "Enable Offerstone. (Add Offering. Ember cost -1. (Targetless spells only.))\n启用献祭石（非指定目标法术获得献祭，费用 -1 余烬。）");
            addDownstone = Config.Bind("General", "Downstone", true, "Enable Downstone. (Add Descend. (Targeted spells only.))\n启用下移石（指定目标法术获得'下降。'）");
            addGorgestone = Config.Bind("General", "Gorgestone", true, "Enable Gorgestone. (Add Gorge: +2 Attack, +2 Health)\n启用暴食石（单位获得'暴食: +2 攻击力，+2 生命值。'）");
            addLeechstone = Config.Bind("General", "Leechstone", true, "Enable Leechstone. (Add Lifesteal 3. +10 Attack.)\n启用水蛭石（单位获得吸血 3，+10 攻击力。）");
            addMorselstone = Config.Bind("General", "Morselstone", true, "Enable Morselstone. (Add a common or uncommon Morsel unit to your hand.)\n启用影裔石（法术获得'将一个普通或高级影裔单位加入你的手牌。'）");
            addFrontstone = Config.Bind("General", "Frontstone", true, "Enable Frontstone. (Add Advance. (Targeted spells only.))\n启用前移石（指定目标法术获得'前进。'）");
            addGrowstone = Config.Bind("General", "Growstone", true, "Enable Growstone. (Propagate 1 on all units.)\n启用生长石（法术获得'使本层所有单位散播 1。'）");
            addPlaguestone = Config.Bind("General", "Plaguestone", true, "Enable Plaguestone. (Apply Decay 4 to all enemies.)\n启用瘟疫石（法术获得'对本层所有敌方单位施加腐朽 4。'）");
            addSpawnstone = Config.Bind("General", "Spawnstone", true, "Enable Spawnstone. (Add Spawn 1.)\n启用孢子石（法术获得'生成 1。'）");

            addSteelstone = Config.Bind("General", "Steelstone", true, "Enable Steelstone. (Add Steelguard and Armor 15.)");
            addForgestone = Config.Bind("General", "Forgestone", true, "Enable Forgestone. (Add Forge 5.)");
            addSmeltstone = Config.Bind("General", "Smeltstone", true, "Enable Smeltstone. (Smelt a card in hand.)");
            addHearthstone = Config.Bind("General", "Hearthstone", true, "Enable Hearthstone. (Add Refined 3.)");
            addFusionstone = Config.Bind("General", "Fusionstone", true, "Enable Fusionstone. (Add Infused.)");
            addReapstone = Config.Bind("General", "Reapstone", true, "Enable Reapstone. (Apply Reap 4 to all enemies.)");
            addInspirestone = Config.Bind("General", "Inspirestone", true, "Enable Inspirestone. (Add Inspire: +2 Attack, +2 Health)");
            addEtchstone = Config.Bind("General", "Etchstone", true, "Enable Etchstone. (Add Etch: +6 Attack, +6 Health)");
            addSnipestone = Config.Bind("General", "Snipestone", true, "Enable Snipestone. (Add Sniper.)");

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
            if (addArtistone.Value) paths.Add("json/enhancers/artistone.json");
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

            if (addSteelstone.Value) paths.Add("json/enhancers/steelstone.json");
            if (addForgestone.Value) paths.Add("json/enhancers/forgestone.json");
            if (addSmeltstone.Value) paths.Add("json/enhancers/smeltstone.json");
            if (addHearthstone.Value) paths.Add("json/enhancers/hearthstone.json");
            if (addFusionstone.Value) paths.Add("json/enhancers/fusionstone.json");
            if (addReapstone.Value) paths.Add("json/enhancers/reapstone.json");
            if (addInspirestone.Value) paths.Add("json/enhancers/inspirestone.json");
            if (addEtchstone.Value) paths.Add("json/enhancers/etchstone.json");
            if (addSnipestone.Value) paths.Add("json/enhancers/snipestone.json");

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

    [HarmonyPatch(typeof(SaveManager), "SetupRun")]
    public class LogForDebug
    {
        public static readonly ManualLogSource Log = Logger.CreateLogSource("LogForDebug");
        public static void Postfix(SaveManager __instance, AllGameData ___allGameData)
        {
            List<EnhancerData> enhancers = ___allGameData.GetAllEnhancerData().ToList();
            enhancers.Sort((x, y) => x.Cheat_GetNameEnglish().CompareTo(y.Cheat_GetNameEnglish())); // Sort enhancers by Name
            foreach (EnhancerData enhancerData in enhancers)
            {
                Log.LogInfo($"Enhancer Name: {enhancerData.Cheat_GetNameEnglish()}, Debug Name: {enhancerData.GetDebugName()}, ID: {enhancerData.GetID()}"); // Log all enhancer IDs
            }
        }
    }
}
