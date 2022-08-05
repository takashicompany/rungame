namespace takashicompany.RunGame
{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.EventSystems;

	[RequireComponent(typeof(Rigidbody))]
	public class SimpleRunner : Runner, IDragHandler
	{
		[SerializeField]
		private float _speedX = 2f;

		[SerializeField]
		private float _speedZ = 5f;

		[SerializeField]
		private bool _isMoveByVelocity;

		public float speedZ => _speedZ;

		private void FixedUpdate()
		{
			if (_isMoveByVelocity)
			{
				var v = _rigidbody.velocity;
				
				v.z = _speedZ;

				_rigidbody.velocity = v;
			}
			else
			{
				_rigidbody.MovePosition(_rigidbody.position += Vector3.forward * _speedZ * Time.fixedDeltaTime);
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			var delta = eventData.delta;
			var ratio = delta.x / Screen.width;

			_rigidbody.MovePosition(_rigidbody.position += Vector3.right * ratio * _speedX);
		}

		public override void Stop()
		{
			base.Stop();
			this.enabled = false;
		}

		public void SetSpeedZ(float z)
		{
			_speedZ = z;
		}
	}
} 