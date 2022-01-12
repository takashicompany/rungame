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

		private List<StackedObject> _stacked = new List<StackedObject>();

		private void Update()
		{
			Align();
		}

		public void AddStack(StackedObject stackedObject)
		{
			_stacked.Add(stackedObject);
			stackedObject.transform.SetParent(transform);
		}

		public void Align()
		{
			var stackPoint = transform.TransformPoint(_stackPoint);

			var point = _stackDirection.GetDirection(stackPoint);

			for (int i = 0; i < _stacked.Count; i++)
			{
				var current = _stacked[i];
				var bounds = current.GetBounds();
				
				var p = current.transform.position;
				
				if (0 < i)
				{
					var prev = _stacked[i];

					var prevBounds = prev.GetBounds();

					var x = Mathf.Clamp(p.x, prevBounds.min.x, prevBounds.max.x);

					p.x = x;
				}
				else
				{
					p.x = stackPoint.x;
				}

				p[_stackDirection.ToV3Index()] = point;
				
				current.transform.position = p;

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