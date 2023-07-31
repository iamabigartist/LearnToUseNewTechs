using System.Collections.Generic;
using UnityEngine;
namespace Labs.LearnAnimation
{
public class LearnTimeline : MonoBehaviour
{
	Animator animator;
	float timer;
	List<AnimatorClipInfo> clip_infos;
	public float step = 0.25f;
	void Start()
	{
		animator = GetComponent<Animator>();
		clip_infos = new();
	}


	void Update()
	{
		if (timer < step) { timer += Time.deltaTime; }
		else
		{
			timer = 0;
			var state = animator.GetCurrentAnimatorStateInfo(0);
			var normalized_time = state.normalizedTime;
			if (!(normalized_time <= 1f)) { normalized_time = 0; }
			animator.GetCurrentAnimatorClipInfo(0, clip_infos);
			var cur_clip_info = clip_infos[0];
			// float offset = cur_clip_info.clip.length * normalized_time;
			float offset = step / cur_clip_info.clip.length;
			Debug.Log($"offset:{normalized_time}");
			animator.Play("Attack1", 0, normalized_time + offset);
			animator.speed = 0;
		}
	}
}
}