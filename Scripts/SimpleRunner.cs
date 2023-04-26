namespace takashicompany.RunGame
{

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using takashicompany.Unity;

	[RequireComponent(typeof(Rigidbody))]
	public class SimpleRunner : Runner, IDragHandler
	{
		[SerializeField]
		private float _speed = 5f;

		[SerializeField]
		private bool _isMoveByVelocity;

		private void FixedUpdate()
		{
			if (_isMoveByVelocity)
			{
				var v = _rigidbody.velocity;
				
				v.z = _speed;

				_rigidbody.velocity = v;
			}
			else
			{
				_rigidbody.MovePosition(_rigidbody.position += Vector3.forward * _speed * Time.fixedDeltaTime);
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (!enabled)
			{
				return;
			}

			var camera = Camera.main;

			var sp = camera.WorldToScreenPoint(transform.position);

			sp.x = eventData.position.x;

			var ray = camera.ScreenPointToRay(sp);

			ray.TryGetPositionOnRay(1, 0f, out var wp);
			wp.y = transform.position.y;
			wp.z = transform.position.z;

			_rigidbody.MovePosition(wp);

			// var delta = eventData.delta;
			// var ratioX = delta.x / Screen.width;
			// var ratioY = delta.y / Screen.height;

			// _rigidbody.MovePosition(_rigidbody.position += new Vector3(_speed.x * ratioX, _speed.y * ratioY, 0));
		}

		public override void Stop()
		{
			base.Stop();
			this.enabled = false;
		}

		public void SetSpeed(float z)
		{
			_speed = z;
		}
	}
} 