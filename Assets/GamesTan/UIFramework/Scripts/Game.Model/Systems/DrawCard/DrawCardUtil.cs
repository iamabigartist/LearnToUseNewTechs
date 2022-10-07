using System;
using GamesTan.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamesTan.Data {
    public struct DrawCardResult {
        public int Id;
        public int Grade;

        public int FrameType => (Grade + 1) / 2;

        public DrawCardResult(int id, int grade) {
            this.Id = id;
            this.Grade = grade;
        }
    }

    public class DrawCardUtil : Singleton<DrawCardUtil> {
        public static int OneTimeDiamondCount = 300;
        public static int TneTimesDiamondCount = 2700;

        public float LegendaryPercent => UIConfigDrawCard.Instance.LegendaryPercent;
        public float ElitePercent => UIConfigDrawCard.Instance.ElitePercent;

        public static DrawCardResult[] Results = new DrawCardResult[10];

        public ECardType DrawOne() {
            var rnd = Random.value;
            var type = ECardType.Normal;
            if (rnd < LegendaryPercent) {
                type = ECardType.Legendary;
            }
            else if (rnd < LegendaryPercent + ElitePercent) {
                type = ECardType.Elite;
            }

            return type;
        }


        public bool CanDrawOne() {
            return GameData.Instance.Diamond >= OneTimeDiamondCount;
        }

        public bool CanDrawTen() {
            return GameData.Instance.Diamond >= TneTimesDiamondCount;
        }

        public void DrawCardOne(Action<bool> callback) {
            if (!CanDrawOne()) {
                callback(false);
                return;
            }

            GameData.Instance.Diamond -= OneTimeDiamondCount;
            Results[0] = DoDrawOnce();
            AddHero(Results[0]);
            callback?.Invoke(true);
        }
      
        public static int[] TotalTestModelId = new int[] {
            31500,
            31300,
            31401,
            31201,
            31600,
        };
        private DrawCardResult DoDrawOnce() {
            var type = DrawOne();
            int[] ids = TotalTestModelId;
            var idx = ids[Random.Range(0, ids.Length)];
            var grade = GameDefine. GetCardGrade(type);
            return new DrawCardResult(idx, grade);
        }

        public void DrawCardTen(Action<bool> callback) {
            if (!CanDrawTen()) {
                callback(false);
                return;
            }

            GameData.Instance.Diamond -= TneTimesDiamondCount;
            for (int i = 0; i < 10; i++) {
                Results[i] = DoDrawOnce();
                AddHero(Results[i]);
            }

            callback?.Invoke(true);
        }

        void AddHero(DrawCardResult result) {
            GameData.Instance.AddHero(result.Id, result.Grade);
        }
    }
}