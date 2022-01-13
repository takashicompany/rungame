namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public interface IGoal
	{
		void OnGoal(Runner runner);
	}

	[RequireComponent(typeof(Collider))]
	public class Goal : MonoBehaviour, IGoal
	{
		private UnityEvent<Goal> _onGoal;
		public UnityEvent<Goal> onGoal => _onGoal;
		
		public virtual void OnGoal(Runner runner)
		{
			_onGoal?.Invoke(this);
		}
	}
}
