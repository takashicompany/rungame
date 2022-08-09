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
		private Vector3 _speed = new Vector3(2, 0, 5);

		[SerializeField]
		private bool _isMoveByVelocity;

		public float speedZ => _speed.z;

		private void FixedUpdate()
		{
			if (_isMoveByVelocity)
			{
				var v = _rigidbody.velocity;
				
				v.z = speedZ;

				_rigidbody.velocity = v;
			}
			else
			{
				_rigidbody.MovePosition(_rigidbody.position += Vector3.forward * speedZ * Time.fixedDeltaTime);
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (!enabled)
			{
				return;
			}

			var delta = eventData.delta;
			var ratioX = delta.x / Screen.width;
			var ratioY = delta.y / Screen.height;

			_rigidbody.MovePosition(_rigidbody.position += new Vector3(_speed.x * ratioX, _speed.y * ratioY, 0));
		}

		public override void Stop()
		{
			base.Stop();
			this.enabled = false;
		}

		public void SetSpeedZ(float z)
		{
			var speed = _speed;
			speed.z = z;
			_speed = speed;
		}
	}
} 