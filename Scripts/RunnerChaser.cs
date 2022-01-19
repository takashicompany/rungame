namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public interface IRunnerChaser
	{
		void SetTarget(Runner runner);
		void RemoveTarget();
	}

	public class RunnerChaser : MonoBehaviour, IRunnerChaser
	{
		[SerializeField]
		private bool _findTargetOnStart;

		[SerializeField]
		private bool _chaseOnlyZ = true;

		[SerializeField]
		private bool _onlyForward = false;

		private Runner _target;

		private Vector3 _prevPosition;

		// Start is called before the first frame update
		void Start()
		{
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

				if (_onlyForward)
				{
					if (_prevPosition.z > p.z)
					{
						p.z = _prevPosition.z;
					}
				}

				transform.position = p;
				_prevPosition = transform.position;
			}
		}

		public void SetTarget(Runner target)
		{
			_target = target;
		}

		public void RemoveTarget()
		{
			_target = null;
		}
	}
}
