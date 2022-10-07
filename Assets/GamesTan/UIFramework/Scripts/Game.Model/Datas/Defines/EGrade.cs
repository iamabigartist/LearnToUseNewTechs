using Sirenix.OdinInspector;

namespace GamesTan.Data {
    

    public enum ECardType {
        Normal, // 普通
        Elite, // 精英
        Legendary, // 传说 
        //Myth , // 神话
    }
    
    public enum EGrade {
        [LabelText("绿")]
        Green,

        [LabelText("蓝")]
        Blue,

        [LabelText("蓝+")]
        BluePlus,

        [LabelText("紫")]
        Purple,

        [LabelText("紫+")]
        PurplePlus,

        [LabelText("橙")]
        Origin,

        [LabelText("橙+")]
        OriginPlus,

        [LabelText("红")]
        Red,

        [LabelText("红+")]
        RedPlus,

        [LabelText("白")]
        White,

        [LabelText("星1")]
        Star1,

        [LabelText("星2")]
        Star2,

        [LabelText("星3")]
        Star3,

        [LabelText("星4")]
        Star4,

        [LabelText("星5")]
        Star5,
        EnumCount
    }
}