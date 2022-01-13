namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class Stacker : MonoBehaviour
	{
		public enum StackDirection
		{
			// Horizontal = 0,
			Up = 1,
			Forward = 2,
		}

		[SerializeField]
		private StackDirection _stackDirection;

		[SerializeField]
		private Vector3 _stackPoint;

		[SerializeField]
		private float _fixSpeed = 1f;

		[SerializeField]
		private bool _alignWithRotate;

		private List<StackedObject> _stacked = new List<StackedObject>();

		[SerializeField]
		private UnityEngine.Events.UnityEvent<StackedObject> _onStack;

		public UnityEngine.Events.UnityEvent<StackedObject> onStack => _onStack;

		private void Update()
		{
			Align(Time.deltaTime);
		}

		public void AddStack(StackedObject stackedObject)
		{
			_stacked.Add(stackedObject);
			// stackedObject.transform.SetParent(transform);
			onStack?.Invoke(stackedObject);
			stackedObject.OnStacked(this);
		}

		public void RemoveStack(StackedObject stackedObject)
		{
			_stacked.Remove(stackedObject);
			stackedObject.OnUnstacked();
		}

		public void Align(float deltaTime)
		{
			var stackPoint = transform.TransformPoint(_stackPoint);

			var point = _stackDirection.GetDirection(stackPoint);

			var movementBySpeed = _fixSpeed * deltaTime;

			for (int i = 0; i < _stacked.Count; i++)
			{
				var current = _stacked[i];
				var bounds = current.GetBounds();
				
				var currentPosition = current.transform.position;
				currentPosition[_stackDirection.ToV3Index()] = point;
				
				if (0 < i)
				{
					var prev = _stacked[i - 1];
					
					var x = currentPosition.x;
					var prevBounds = prev.GetBounds();
					var offset = prev.transform.position.x - x;
					
					if (Mathf.Abs(offset) > movementBySpeed)
					{
						x += Mathf.Sign(offset) * movementBySpeed;
					}
					else
					{
						x = prev.transform.position.x;
					}
					
					x = Mathf.Clamp(x, prevBounds.min.x, prevBounds.max.x);

					currentPosition.x = x;

					if (_alignWithRotate)
					{
						current.transform.LookAt(currentPosition + (currentPosition - prev.transform.position) / 2);
					}
				}
				else
				{
					currentPosition.x = stackPoint.x;
				}
				
				current.transform.position = currentPosition;

				point = _stackDirection.GetBoundsEnd(bounds);
			}
		}
	}

	public static class StackerExtension
	{
		public static int ToV3Index(this Stacker.StackDirection self)
		{
			return (int)self;
		}

		public static float GetDirection(this Stacker.StackDirection direction, Vector3 v3)
		{
			switch (direction)
			{
				case Stacker.StackDirection.Forward:	return v3.z;
				case Stacker.StackDirection.Up: 		return v3.y;
			}

			throw new System.NotImplementedException();
		}

		public static float GetBoundsEnd(this Stacker.StackDirection direction, Bounds bounds)
		{
			switch(direction)
			{
				case Stacker.StackDirection.Forward:	return bounds.max.z;
				case Stacker.StackDirection.Up:			return bounds.max.y;
			}

			throw new System.NotImplementedException();
		}
	}
}