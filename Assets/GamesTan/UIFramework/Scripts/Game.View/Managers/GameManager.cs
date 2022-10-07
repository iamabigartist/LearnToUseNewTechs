using GamesTan.Data;
using GamesTan.UI;

using UnityEngine;

namespace GamesTan.UI {
    [System.Serializable]
    public abstract partial class GameManager : MonoBaseManager<GameManager> {
        public static BaseItemData[] Enemies;

        public override void DoAwake() {
            base.DoAwake();
            AddTestData();
            AudioManager.PlayMusic(8000);
        }

        private static void AddTestData() {
            GameData.Instance.Coin = 100000;
            GameData.Instance.Diamond = 95000;
            GameData.Instance.Dirty = 1200;
            GameData.Instance.Ticket = 130;
            int[] ids = DrawCardUtil.TotalTestModelId;
            Enemies = new BaseItemData[ids.Length];
            for (int i = 0; i < ids.Length; i++) {
                GameData.Instance.AddHero(ids[i], 0);
                Enemies[i] = new BaseItemData(ids[i], 0, 0);
            }

            for (int i = 0; i < 26; i++) {
                GameData.Instance.AddHero(ids[Random.Range(0, ids.Length)], Random.Range(0, 9));
            }
        }
    }
}