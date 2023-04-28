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

		public Bounds size => _size;

		[SerializeField]
		private Vector3 _stackedRotation;

		[SerializeField]
		private UnityEngine.Events.UnityEvent<Stacker, StackedObject> _onStack;

		public UnityEngine.Events.UnityEvent<Stacker, StackedObject> onStack => _onStack;

		[SerializeField]
		private  UnityEngine.Events.UnityEvent<StackedObject> _onUnstack;

		public  UnityEngine.Events.UnityEvent<StackedObject> onUnstack => _onUnstack;

		public Stacker stacker { get; private set; }

		public void OnStacked(Stacker stacker)
		{
			this.stacker = stacker;
			onStack?.Invoke(stacker, this);
		}

		public void OnUnstacked()
		{
			this.stacker = null;
			_onUnstack?.Invoke(this);
		}

		public Bounds GetWorldBounds()
		{
			return _size.Transform(transform);
		}

		public bool IsStacked()
		{
			return stacker != null;
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			var b = GetWorldBounds();
			Gizmos.DrawWireCube(b.center, b.size);
		}
	}
}