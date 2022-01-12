namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class RunnerChaser : MonoBehaviour
	{
		[SerializeField]
		private bool _findTargetOnStart;

		[SerializeField]
		private bool _chaseOnlyZ = true;

		private Runner _target;

		// Start is called before the first frame update
		void Start()
		{
			if (_findTargetOnStart)
			{
				var runner = GameObject.FindObjectOfType<Runner>();
				if (runner != null)
				{
					SetTarget(runner);
				}
			}
		}

		void LateUpdate()
		{
			if (_target != null)
			{
				var p = _target.transform.position;

				if (_chaseOnlyZ)
				{
					p.x = transform.position.x;
					p.y = transform.position.y;
				}

				transform.position = p;
			}
		}

		public void SetTarget(Runner target)
		{
			_target = target;
		}
	}
}
