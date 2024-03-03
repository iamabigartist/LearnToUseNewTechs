using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Labs.ExamBattleSystem.ExamFullBattleSystem.EffectBuilder
{
    public class Builder
    {
        //从被影响器中根据当前影响器的阶数，获取所有的+1阶影响器
        //规则是永远先执行已经没有影响器的影响器
        //按照上述规则生成所有影响器的执行顺序列表
        //请生成函数代码
        private List<IEffector> Build ( IEffector effector, IEffected effected )
        {
            return null;
        }
    }
}