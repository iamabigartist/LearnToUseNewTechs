using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Labs.ExamBattleSystem.ExamFullBattleSystem.EffectBuilder
{
    public interface IEffector
    {
        void Apply ( IEffected effected );
    }
}