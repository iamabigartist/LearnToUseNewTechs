using System.Collections.Generic;

namespace GamesTan.Data {
    public class RewardDatas {
        public static List<BaseItemData> ItemDatas = new List<BaseItemData>();

        public static void AddItems(IList<ItemInfo> rewards) {
            foreach (var reward in rewards) {
                if (reward.Count != 0) {
                    ItemDatas.Add(new BaseItemData(reward.ItemId, reward.Count));
                }
            }
        }

        public static void SetItems(List<ItemInfo> rewards) {
            ItemDatas.Clear();
            AddItems(rewards);
        }
        public static void SetItems(long coin, long exp, long dirty, long diamond,IList<ItemInfo> rewards = null) {
            ItemDatas.Clear();
            if ((long)coin != 0) { ItemDatas.Add(new BaseItemData(GameData.ITEM_ID_COIN, (long)coin)); }
            if ((long)exp != 0) { ItemDatas.Add(new BaseItemData(GameData.ITEM_ID_EXP, (long)exp)); }
            if ((long)dirty != 0) { ItemDatas.Add(new BaseItemData(GameData.ITEM_ID_DIRTY, (long)dirty)); }
            if ((long)diamond != 0) { ItemDatas.Add(new BaseItemData(GameData.ITEM_ID_DIAMOND, (long)diamond)); }
            if (rewards != null) {
                AddItems(rewards);
            }
        }
    }
}