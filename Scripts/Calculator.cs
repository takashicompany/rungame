namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public interface ICalc
	{
		Calculator.CalcType calcType { get; }
		int number { get; }

		bool OnCalc(Calculator calculator);
	}

	public class Calculator : MonoBehaviour
	{
		public enum CalcType
		{
			Addition,
			Subtraction,
			Multiplication,
			Division
		}

		[SerializeField]
		private UnityEvent<ICalc> _onCalc;

		public UnityEvent<ICalc> onCalc => _onCalc;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<ICalc>(out var c))
			{
				if (c.OnCalc(this))
				{
					_onCalc?.Invoke(c);
				}
			}
		}
	}
}
