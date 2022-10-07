namespace GamesTan {
    public static class GameUtil {
        public static int ToInt(this string val) => int.Parse(val);

        public static int ToCompareInt(this long val) {
            return val > 0 ? 1 : (val < 0 ? -1 : 0);
        }
        public static int ToNoLevelId(this int configId) {
            if (configId >= 100000) return configId / 1000;
            return configId;
        }
    }
}