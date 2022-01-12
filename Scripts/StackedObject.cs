namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using takashicompany.Unity;

	public class StackedObject : MonoBehaviour
	{
		[SerializeField]
		private Bounds _size = new Bounds(Vector3.zero, Vector3.one);

		[SerializeField]
		private Vector3 _stackedRotation;

		[SerializeField]
		private UnityEngine.Events.UnityEvent<Stacker, StackedObject> _onStack;

		public UnityEngine.Events.UnityEvent<Stacker, StackedObject> onStack => _onStack;

		public void OnStacked(Stacker stacker)
		{
			onStack?.Invoke(stacker, this);
		}

		public Bounds GetBounds()
		{
			return _size.Transform(transform);
		}
		
	}
}