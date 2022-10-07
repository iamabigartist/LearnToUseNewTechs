namespace GamesTan {
    /// 游戏内部消息 取值范围 [1000~ 65535)
    public enum EGameEvent {
        OnBossBorn = 1001, // boss 生成
        OnBossDied= 1002, // boss 死亡
        
        TeamMemberChanged= 1013, // 队伍成员更变
        TestUIEvent= 1014, // 队伍成员更变
    }
}