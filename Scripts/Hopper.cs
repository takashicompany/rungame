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
		private Vector3 _hopPower;

		[SerializeField]
		private Vector3 _hopTorque;

		private void Hop(Vector3 power, Vector3 torque)
		{
			_rigidbody.AddForce(power, ForceMode.Impulse);
			_rigidbody.AddRelativeTorque(torque);
		}

		public void Hop()
		{
			Hop(_hopPower, _hopTorque);
		}

		// private Vector3 GetHopWorldPosition()
		// {
		// 	return transform.TransformVector(_hopPosition);
		// }

		// private void OnDrawGizmos()
		// {
		// 	Gizmos.color = Color.red;
		// 	takashicompany.Unity.Utils.DrawGizmosPoint(GetHopWorldPosition());
		// }
	}
}