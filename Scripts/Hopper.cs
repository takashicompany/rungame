namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	[RequireComponent(typeof(Rigidbody))]
	public class Hopper : Runner
	{
		[SerializeField]
		private Vector3 _hopPosition;

		[SerializeField]
		private Vector3 _hopPower;

		private void Hop(Vector3 power, Vector3 position)
		{
			_rigidbody.AddForceAtPosition(power, position);
		}

		public void Hop()
		{
			Hop(_hopPower, GetHopWorldPosition());
		}

		private Vector3 GetHopWorldPosition()
		{
			return transform.TransformVector(_hopPosition);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			takashicompany.Unity.Utils.DrawGizmosPoint(GetHopWorldPosition());
		}
	}
}