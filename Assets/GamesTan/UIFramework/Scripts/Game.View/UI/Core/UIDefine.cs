using GamesTan;
using UnityEngine;

namespace GamesTan.UI {
 
    public partial class UIDefine {
        // Common 
        public static WindowCreateInfo UIChat = new WindowCreateInfo("UIChat", EWindowDepth.Normal);
        public static WindowCreateInfo UIMainMenu = new WindowCreateInfo("UIMainMenu", EWindowDepth.Normal);
        public static WindowCreateInfo UIRoot = new WindowCreateInfo("UIRoot", EWindowDepth.Normal);
        public static WindowCreateInfo UIDrawCard = new WindowCreateInfo("UIDrawCard", EWindowDepth.Normal,true);
        
        public static WindowCreateInfo UIDemoStart = new WindowCreateInfo("UIDemoStart", EWindowDepth.Normal);
        
        public static WindowCreateInfo UIDemo01_PureList = new WindowCreateInfo("UIDemo01_PureList", EWindowDepth.Normal);
        public static WindowCreateInfo UIDemo02_PureModel = new WindowCreateInfo("UIDemo02_PureModel", EWindowDepth.Normal);
        public static WindowCreateInfo UIDemo03_ModelList = new WindowCreateInfo("UIDemo03_ModelList", EWindowDepth.Normal);
        public static WindowCreateInfo UIDemo04_MutilSubPanel = new WindowCreateInfo("UIDemo04_MutilSubPanel", EWindowDepth.Normal);
        

        // Forward
        public static WindowCreateInfo UIReward = new WindowCreateInfo("UIReward", EWindowDepth.Forward );
        
        // Dialog
        public static WindowCreateInfo UINoticeSure = new WindowCreateInfo("UINoticeSure", EWindowDepth.Notice);
        public static WindowCreateInfo UINoticeSureCancel = new WindowCreateInfo("UINoticeSureCancel", EWindowDepth.Notice);
    }
}