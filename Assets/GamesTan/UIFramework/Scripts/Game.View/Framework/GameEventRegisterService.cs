using GamesTan;
using GamesTan;
using GamesTanEncrypt;

namespace GamesTan {
    public class GameEventRegisterService : EventRegisterService {
        public override void RegisterEvent(object obj) {
            base.RegisterEvent(obj);
            DealEvent<EGameEvent, GlobalEventHandler>("OnEvent_", "OnEvent_".Length,
                EventUtil.AddListener, obj);
        }

        public override void UnRegisterEvent(object obj) {
            base.UnRegisterEvent(obj);
            DealEvent<EGameEvent, GlobalEventHandler>("OnEvent_", "OnEvent_".Length,
                EventUtil.RemoveListener, obj);
        }
    }
}