using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
namespace Labs.LearnAsync
{
    public class TestUniTaskThread : MonoBehaviour
    {
        private bool mValue;

        async void StartAsync()
        {
            Debug.LogFormat("frame start:{0}", Time.frameCount);
            Observable.TimerFrame(100).Subscribe(_ => mValue = true);

            //之后的代码运行中线程池中
            await UniTask.SwitchToThreadPool();
            // 当达到某种条件才进行等待，条件失败通过
            await UniTask.WaitWhile(() => mValue == false);
            Debug.LogFormat("frame end:{0}", Time.frameCount);
        }
    
        void Start()
        {
            StartAsync();
        }
    }
}

