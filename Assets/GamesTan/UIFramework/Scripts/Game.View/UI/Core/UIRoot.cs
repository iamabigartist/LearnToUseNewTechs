using UnityEngine;

namespace GamesTan.Data {}

namespace GamesTan.UI {
    public class UIRoot : UIBaseWindow {
        private Transform TransNormal => GetRef<Transform>("TransNormal");
        private Transform TransForward => GetRef<Transform>("TransForward");
        private Transform TransNotice => GetRef<Transform>("TransNotice");
        
    }
}