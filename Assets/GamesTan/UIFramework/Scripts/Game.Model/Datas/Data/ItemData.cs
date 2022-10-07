using System;
using Sirenix.OdinInspector;

namespace GamesTan.Data {
    [System.Serializable]
    public class BaseItemData {
        public long EntityId;
        public long Id;
        public int Grade = 0;
        public int Level = 1;
        public long Count = 1;

        [NonSerialized] public long __TempData;
        public long ModelTypeId => Id / 10;

        public BaseItemData() {
        }
        public BaseItemData(long id, long count = 1, int grade = 0, int level = 1) {
            EntityId = GameData.NextEntityId();
            Id = id;
            Level = level;
            Grade = grade;
            Count = count;
        }

        public override string ToString() {
            return $"EntityId={EntityId} Id={Id} Grade={Grade}";
        }
    }
    [System.Serializable]
    public struct ItemInfo {
        public int ItemId;
        public long Count;

        public ItemInfo(int ItemId, long Count) {
            this.ItemId = ItemId;
            this.Count = Count;
        }
    }
}