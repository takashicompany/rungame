namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class SmoothRunnerChaser : MonoBehaviour, IRunnerChaser
	{
		[SerializeField]
		private AnimationCurve _curve = AnimationCurve.EaseInOut(0, 0, 1, 1);

		[SerializeField]
		private bool _findTargetOnStart;

		[SerializeField]
		private float _speed = 1f;

		private Runner _runner;

		private Vector3 _prevPosition;

		void Start()
		{
			_curve.postWrapMode = WrapMode.ClampForever;
			_prevPosition = transform.position;

			if (_findTargetOnStart)
			{
				var runner = GameObject.FindObjectOfType<Runner>();
				if (runner != null)
				{
					SetTarget(runner);
				}
			}
		}

		private void LateUpdate()
		{
			if (_runner != null)
			{
				var speedPerFrame = _speed * Time.deltaTime;

				var to = _runner.transform.position;

				to.x = transform.position.x;
				to.y = transform.position.y;

				var offset = to - transform.position;
				var dir = offset.normalized;

				var movement = speedPerFrame * _curve.Evaluate(offset.magnitude);

				var p = transform.position;

				if (offset.magnitude > movement)
				{
					p = transform.position +  dir * movement;
				}
				else
				{
					p = to;
				}
				
				if (p.z < _prevPosition.z)
				{
					p.z = _prevPosition.z;
				}

				transform.position = p;

			}
		}

		public void RemoveTarget()
		{
			_runner = null;
		}

		public void SetTarget(Runner runner)
		{
			_runner = runner;
		}
	}
}