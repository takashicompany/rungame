namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public abstract class Runner : TaBehabviour
	{
		[SerializeField]
		private UnityEvent<IGoal> _onGoal;

		public UnityEvent<IGoal> onGoal => _onGoal;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<IGoal>(out var goal))
			{
				_onGoal?.Invoke(goal);
			}
		}
	}
}
