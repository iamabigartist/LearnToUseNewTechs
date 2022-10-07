using System.Collections.Generic;
using System.IO;
using GamesTan;
using UnityEngine;

namespace GamesTan.Data {
    public class GameData : Singleton<GameData> {
        public const long SECOND_PER_DAY = 24 * 60 * 60;

        // 货币定义
        public const int ITEM_ID_DIAMOND = 9001;
        public const int ITEM_ID_COIN = 9002;
        public const int ITEM_ID_EXP = 9003;
        public const int ITEM_ID_DIRTY = 9004;
        public const int ITEM_ID_TICKET = 9005;



        public long _Coin;
        public long _Diamond;
        public long _Exp;
        public long _Dirty;
        public long _Ticket;

        public long Coin { get => _Coin; set { _Coin = value; EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged); } }
        public long Diamond{ get => _Diamond; set { _Diamond = value; EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged); } }
        public long Exp{ get => _Exp; set { _Exp = value; EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged); } }
        public long Dirty{ get => _Dirty; set { _Dirty = value; EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged); } }
        public long Ticket{ get => _Ticket; set { _Ticket = value; EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged); } }
        
        public List<BaseItemData> Heroes = new List<BaseItemData>();

        public long __GlobalEntityId = 0;

        public static long NextEntityId() {
            ++Instance.__GlobalEntityId;
            return Instance.__GlobalEntityId;
        }

        public void SubMoney(long coin, long exp, long dirty, long diamond) {
            AddMoney(-coin, -exp, -dirty, -diamond);
        }

        public void AddMoney(long coin, long exp, long dirty, long diamond) {
            _Coin += coin;
            _Diamond += diamond;
            _Exp += exp;
            _Dirty += dirty;
            EventUtil.Trigger(EEvent.OnServerPlayerPropertyChanged);
        }

        public BaseItemData GetHero(long entityId) {
            foreach (var item in Heroes) {
                if (item.EntityId == entityId) return item;
            }
            return null;
        }


        public void AddHero(int id, int grade = 0) {
            Heroes.Add(new BaseItemData(id, 1,grade));
        }
   
    }
}