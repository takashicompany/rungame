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

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position += Vector3.forward * _speedZ * Time.fixedDeltaTime);
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			var delta = eventData.delta;
			var ratio = delta.x / Screen.width;

			_rigidbody.MovePosition(_rigidbody.position += Vector3.right * ratio * _speedX);
		}
	}
} 