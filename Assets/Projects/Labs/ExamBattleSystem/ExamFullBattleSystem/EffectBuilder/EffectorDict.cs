using Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree;
using Labs.ExamBattleSystem.ExamFullBattleSystem.EffectBuilder;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Projects.Labs.ExamBattleSystem.ExamFullBattleSystem.EffectBuilder
{
    public class EffectorDict : CategoryTreeContainer<List<IEffector>>
    {
        public EffectorDict () : base( new( "root" ) )
        {
        }
    }
}