namespace takashicompany.RunGame
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Collider))]
	public class CalcZone : MonoBehaviour, ICalc
	{
		[SerializeField]
		private Calculator.CalcType _calcType;

		public Calculator.CalcType calcType => _calcType;

		[SerializeField]
		private int _number;

		public int number => _number;

		[SerializeField]
		private Text _text;

		private HashSet<Calculator> _calculated = new HashSet<Calculator>();

		private void Awake()
		{
			UpdatePrefixAndNumber();
		}

		public virtual void Setup(Calculator.CalcType calcType, int number)
		{
			_calcType = calcType;
			_number = number;
			UpdatePrefixAndNumber();
		}

		public virtual void UpdatePrefixAndNumber()
		{
			_text.text = GetPrefix(calcType) + number;
		}

		private static string GetPrefix(Calculator.CalcType calcType)
		{
			switch (calcType)
			{
				case Calculator.CalcType.Addition:			return "＋";
				case Calculator.CalcType.Subtraction:		return "−";
				case Calculator.CalcType.Multiplication:	return "×";
				case Calculator.CalcType.Division:			return "÷";
			}

			return "";
		}

		public bool OnCalc(Calculator calculator)
		{
			return _calculated.Add(calculator);
		}
	}
}
