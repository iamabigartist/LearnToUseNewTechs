using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Labs.ExamBattleSystem.ExamFullBattleSystem.EffectBuilder
{
    public interface IEffected
    {
        List<IEffector> prev_effector_list { get; }
    }
}