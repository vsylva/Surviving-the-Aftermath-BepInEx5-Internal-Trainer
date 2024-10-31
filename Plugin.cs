using BepInEx;
using HarmonyLib;
using UnityEngine;
using Aftermath.Cheats;
using Aftermath.Behaviour;
using Aftermath.Data;
using Aftermath.Sim;
using Aftermath;
using System.Collections.Generic;

namespace InternalTrainer
{

    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "InternalTrainer";
        public const string PLUGIN_NAME = "InternalTrainer";
        public const string PLUGIN_VERSION = "1.0.0";


        public bool ShowMenuState = true;

        BepInEx.Configuration.KeyboardShortcut ShowMenuKey = new BepInEx.Configuration.KeyboardShortcut(KeyCode.F9);

        // Rect   窗口位置 X Y    窗口宽度 窗口宽度
        static readonly uint UIBaseX = 50;
        static readonly uint UIBaseY = 150;
        static Rect UIRect0 = new Rect(UIBaseX + 300, UIBaseY, 300, 200);
        static Rect UIRect1 = new Rect(UIBaseX + UIRect0.width, UIBaseY, 300, 200);
        static Rect UIRect2 = new Rect(UIBaseX + UIRect0.width + UIRect1.width, UIBaseY, 300, 200);
        // static Rect UIRect3 = new Rect(UIBaseX + UIRect0.width, UIBaseY + UIRect0.height, 300, 200);

        const int UI_ID0 = 125_0;
        const int UI_ID1 = 125_1;
        const int UI_ID2 = 125_2;
        //const int UI_ID3 = 125_3;

        static Vector2 UI1Scroll;

        static int ResourceCount = 10;

        static Vector2 UI2Scroll;

        private void Awake()
        {

            var harmony = new Harmony(PLUGIN_GUID);
            harmony.PatchAll();
        }

        // 启动按键
        public void Update()
        {
            // 监听脚本按键按下
            if (ShowMenuKey.IsDown())
            {
                ShowMenuState = !ShowMenuState;
            }
        }

        void OnGUI()
        {
            if (ShowMenuState && Aftermath.Behaviour.IngameScene.ActiveState == Aftermath.Behaviour.IngameState.WorldView)
            {
                GUI.Window(UI_ID0, UIRect0, UiFunc0, "世界地图");
            }
            if (ShowMenuState && Aftermath.Behaviour.IngameScene.ActiveState == Aftermath.Behaviour.IngameState.CityView)
            {
                GUI.Window(UI_ID1, UIRect1, UiFunc1, "资源生成--" + "当前数量已设为: " + ResourceCount);
            }
            if (ShowMenuState && Aftermath.Behaviour.IngameScene.ActiveState == Aftermath.Behaviour.IngameState.CityView)
            {
                GUI.Window(UI_ID2, UIRect2, UiFunc2, "某些功能");
            }
            //if (ShowMenuState && Aftermath.Behaviour.IngameScene.ActiveState == /Aftermath.Behaviour.IngameState.CityView)
            //  {
            //     GUI.Window(UI_ID3, UIRect3, UiFunc3, "勾选功能");
            //  }
        }

        void UiFunc0(int ID)
        {

            if (GUILayout.Button("探索世界地图"))
            {
                CheatManager.RevealAllSectors();
            }
            if (GUILayout.Button("伤害所选对象"))
            {
                CheatManager.DamageSelectedTeam();
            }
            if (GUILayout.Button("治愈所选车辆"))
            {
                CheatManager.HealSelectedVehicle();
            }
            if (GUILayout.Button("生成强盗"))
            {
                CheatManager.CreateMovingWorldmapBandit();
            }
        }
        void UiFunc1(int ID)
        {
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("数量设为: 10"))
            {
                ResourceCount = 10;
            }
            if (GUILayout.Button("数量设为: 50"))
            {
                ResourceCount = 50;
            }
            if (GUILayout.Button("数量设为: 100"))
            {
                ResourceCount = 100;
            }
            GUILayout.EndHorizontal();
            UI1Scroll = GUILayout.BeginScrollView(
                        UI1Scroll, GUILayout.Width(UIRect1.width - 20), GUILayout.Height(UIRect1.height - 60));
            if (GUILayout.Button("0.基础工具"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Tools, ResourceCount);
            }
            if (GUILayout.Button("1.原木"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Wood, ResourceCount);
            }
            if (GUILayout.Button("2.鱼"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Fish, ResourceCount);
            }
            if (GUILayout.Button("3.废料"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Debris, ResourceCount);
            }
            if (GUILayout.Button("4.垃圾"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Trash, ResourceCount);
            }
            if (GUILayout.Button("5.野味"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Venison, ResourceCount);
            }
            if (GUILayout.Button("6.木材"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Plank, ResourceCount);
            }
            if (GUILayout.Button("7.混凝土块"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Concrete, ResourceCount);
            }
            if (GUILayout.Button("8.金属"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Metal, ResourceCount);
            }
            if (GUILayout.Button("9.玉米"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Corn, ResourceCount);
            }
            if (GUILayout.Button("10.零件"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Parts, ResourceCount);
            }
            if (GUILayout.Button("11.土豆"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Potato, ResourceCount);
            }
            if (GUILayout.Button("12.布料"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Fiber, ResourceCount);
            }
            if (GUILayout.Button("13.食物"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Food, ResourceCount);
            }
            if (GUILayout.Button("14.基本衣物"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Cloth, ResourceCount);
            }
            if (GUILayout.Button("15.部件"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Component, ResourceCount);
            }
            if (GUILayout.Button("16.废旧物"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Scrap, ResourceCount);
            }
            if (GUILayout.Button("17.蔬菜"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Vegetable, ResourceCount);
            }
            if (GUILayout.Button("18.肉"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Meat, ResourceCount);
            }
            if (GUILayout.Button("18.肉"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Meat, ResourceCount);
            }
            if (GUILayout.Button("19.药品"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Medicine, ResourceCount);
            }
            if (GUILayout.Button("20.能源"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Energy, ResourceCount);
            }

            if (GUILayout.Button("21.水"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Water, ResourceCount);
            }
            if (GUILayout.Button("22.浆果"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Berries, ResourceCount);
            }
            if (GUILayout.Button("23.污染"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Pollution, ResourceCount);
            }
            if (GUILayout.Button("24.小麦"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Wheat, ResourceCount);
            }
            if (GUILayout.Button("25.卷心菜"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Cabbage, ResourceCount);
            }
            if (GUILayout.Button("26.花生"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Peanut, ResourceCount);
            }
            if (GUILayout.Button("27.胡萝卜"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Carrot, ResourceCount);
            }
            if (GUILayout.Button("28.大豆"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Soybean, ResourceCount);
            }
            if (GUILayout.Button("29.娱乐箱"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Entertainment, ResourceCount);
            }
            if (GUILayout.Button("30.塑料"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Plastic, ResourceCount);
            }
            if (GUILayout.Button("31.抗生素"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Antibiotics, ResourceCount);
            }
            if (GUILayout.Button("32.草药"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Herbal, ResourceCount);
            }
            if (GUILayout.Button("33.蟑螂"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Cockroaches, ResourceCount);
            }
            if (GUILayout.Button("34.疫苗"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Vaccine, ResourceCount);
            }
            if (GUILayout.Button("35.电子元件"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Electronics, ResourceCount);
            }
            if (GUILayout.Button("36.木材"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Firewood, ResourceCount);
            }
            if (GUILayout.Button("37.肉餐"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MealMeat, ResourceCount);
            }
            if (GUILayout.Button("38.面包"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Bread, ResourceCount);
            }
            if (GUILayout.Button("39.面粉"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Flour, ResourceCount);
            }
            if (GUILayout.Button("40.面包虫"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Mealworms, ResourceCount);
            }
            if (GUILayout.Button("41.昆虫"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Insect, ResourceCount);
            }
            if (GUILayout.Button("42.蟋蟀"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Crickets, ResourceCount);
            }
            if (GUILayout.Button("43.水牛虫"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Buffaloworms, ResourceCount);
            }
            if (GUILayout.Button("44.蜡虫"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Waxworms, ResourceCount);
            }
            if (GUILayout.Button("45.素餐"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MealVeg, ResourceCount);
            }
            if (GUILayout.Button("46.药物(无翻译)"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Meds, ResourceCount);
            }
            if (GUILayout.Button("47.碘丸"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Iodine, ResourceCount);
            }
            if (GUILayout.Button("48.肉干"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Jerky, ResourceCount);
            }
            if (GUILayout.Button("49.水果罐头"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.CannedFruit, ResourceCount);
            }
            if (GUILayout.Button("50.糖果"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.ProteinBars, ResourceCount);
            }
            if (GUILayout.Button("51.汇率（钱）"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Currency, ResourceCount);
            }
            if (GUILayout.Button("52.昆虫餐"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MealInsect, ResourceCount);
            }
            if (GUILayout.Button("53.餐食"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Meal, ResourceCount);
            }
            if (GUILayout.Button("54.混合膳食"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MealMixed, ResourceCount);
            }
            if (GUILayout.Button("55.科学点数"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Research, ResourceCount);
            }
            if (GUILayout.Button("56.燃料"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Fuel, ResourceCount);
            }
            if (GUILayout.Button("57.向日葵"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Sunflower, ResourceCount);
            }
            if (GUILayout.Button("58.燃油"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Oil, ResourceCount);
            }
            if (GUILayout.Button("59.猎枪"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Guard_Rifle, ResourceCount);
            }
            if (GUILayout.Button("60.结实衣物"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Cloth_2, ResourceCount);
            }
            if (GUILayout.Button("61.霰弹枪"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Guard_Rifle_2, ResourceCount);
            }
            if (GUILayout.Button("62.耐用工具"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Tools_2, ResourceCount);
            }
            if (GUILayout.Button("63.稀有金属"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Rare, ResourceCount);
            }
            if (GUILayout.Button("64.牛奶"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Milk, ResourceCount);
            }
            if (GUILayout.Button("65.鸡蛋"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Egg, ResourceCount);
            }
            if (GUILayout.Button("66.主要肉食"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.PrimeMeat, ResourceCount);
            }
            if (GUILayout.Button("67.防护衣物"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Cloth_3, ResourceCount);
            }
            if (GUILayout.Button("68.高级工具"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Tools_3, ResourceCount);
            }
            if (GUILayout.Button("69.自动步枪"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Guard_Rifle_3, ResourceCount);
            }
            if (GUILayout.Button("70.甲虫面包"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.BeetleBread, ResourceCount);
            }
            if (GUILayout.Button("71.肉桂面包"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.CinnamonBun, ResourceCount);
            }
            if (GUILayout.Button("72.草药"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Medicinalherb, ResourceCount);
            }
            if (GUILayout.Button("73.混凝土块"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Rubble, ResourceCount);
            }
            if (GUILayout.Button("74.月尘"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Moondust, ResourceCount);
            }
            if (GUILayout.Button("75.月岩"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Moonrock, ResourceCount);
            }
            if (GUILayout.Button("76.抗压"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Antipsychotics, ResourceCount);
            }
            if (GUILayout.Button("77.抗体"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Injection, ResourceCount);
            }
            if (GUILayout.Button("78.常见的蘑菇"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MushroomFood, ResourceCount);
            }
            if (GUILayout.Button("79.镇静蘑菇"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MushroomAntipsychotic, ResourceCount);
            }
            if (GUILayout.Button("80.变异真菌"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.MushroomMutation, ResourceCount);
            }
            if (GUILayout.Button("81.枯萎病样本"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.BlightSamples, ResourceCount);
            }
            if (GUILayout.Button("82.枯萎化的花卉"))
            {
                CheatManager.AddResources(Aftermath.ResourceType.Blightflower, ResourceCount);
            }
            GUILayout.EndScrollView();
        }

        void UiFunc2(int ID)
        {
            UI2Scroll = GUILayout.BeginScrollView(
                        UI2Scroll, GUILayout.Width(UIRect1.width - 20), GUILayout.Height(UIRect2.height - 60));
            if (GUILayout.Button("增加1000点科学点数"))
            {
                CheatManager.AddResearchPoints(1000);
            }
            if (GUILayout.Button("解锁所有科技"))
            {
                CheatManager.Managers.TechTreeManager.CheatUnlockAll("");
            }
            if (GUILayout.Button("解锁所有种子"))
            {
                CheatManager.UnlockAllSeeds();
            }
            if (GUILayout.Button("填满食物存储箱"))
            {
                CheatManager.FillFoodStoragesRandomly();
            }

            if (GUILayout.Button("升级所选建筑"))
            {
                CheatManager.UpgradeSelectedBuilding();
            }

            if (GUILayout.Button("添加初始资源"))
            {
                CheatManager.GiveStartingResources();
            }
            if (GUILayout.Button("添加一个成人人口"))
            {
                CheatManager.SpawnPeople(true, IngameCheatWindow.IsEducated, 1);


            }
            if (GUILayout.Button("添加一个儿童人口"))
            {
                CheatManager.SpawnPeople(false, IngameCheatWindow.IsEducated, 1);

            }
            if (GUILayout.Button("治愈所有人口和专家"))
            {
                CheatManager.HealAll();
            }

            using (List<RanchAnimalTemplate>.Enumerator enumerator3 = Managers.Instance.Session.RanchAnimalManager.RancAnimalTemplates.GetEnumerator())
            {
                while (enumerator3.MoveNext())
                {
                    RanchAnimalTemplate animal = enumerator3.Current;
                    switch (animal.name)
                    {
                        case "Chicken":
                            if (GUILayout.Button("添加一只鸡"))
                            {
                                CheatManager.AddRanchAnimal(animal);
                            }
                            break;
                        case "Sheep":
                            if (GUILayout.Button("添加一只羊"))
                            {
                                CheatManager.AddRanchAnimal(animal);
                            }
                            break;
                        case "Cow":
                            if (GUILayout.Button("添加一只牛"))
                            {
                                CheatManager.AddRanchAnimal(animal);
                            }
                            break;
                        case "Pig":
                            if (GUILayout.Button("添加一只猪"))
                            {
                                CheatManager.AddRanchAnimal(animal);
                            }
                            break;
                        case "RanchBeetle":
                            if (GUILayout.Button("添加一只牧场甲虫"))
                            {
                                CheatManager.AddRanchAnimal(animal);
                            }
                            break;
                    }

                }
            }
            GUILayout.EndScrollView();
        }
        // void UiFunc3(int ID)
        // {
        //
        // }

    }
}
