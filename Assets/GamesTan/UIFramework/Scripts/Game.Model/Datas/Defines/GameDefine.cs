namespace GamesTan.Data {
    public class GameDefine {
        
        public const int TeamHeroCount = 5;
        public const int INVALID_ITEM_ID = 0;

        public const int MODEL_PER_GRADE = 4;
        public const int MAX_MODEL_ID = 2;
        
        
        public const string UIModelPrefabDir = "Prefabs/RTModel/";
        public static int GetCardGrade(ECardType type) {
            return type == ECardType.Normal ? 0 : (type == ECardType.Elite ? 1 : 3);
        }
    }
}