using UnityEngine.Events;
namespace UnityEngine.UI
{
	public class InputCounter : InputField
	{
		/// <summary>
		/// Current value of input
		/// </summary>
		[Tooltip("Current value of input")]
		public int Value;
		/// <summary>
		/// Minimum possible value to output
		/// </summary>
		[Tooltip("Minimum possible value to output")]
		public int min;
		/// <summary>
		/// Maximum possible value to output
		/// </summary>
		[Tooltip("Maximum possible value to output")]
		public int max = 5;

		/// <summary>
		/// Pass int value on any update
		/// </summary>
		public IntValueEvent onValueUpdated;

		// Start is called before the first frame update
		new void Start()
		{
			base.Start();
			contentType = ContentType.IntegerNumber;
			onValueChanged.AddListener(ValueChanged);
			text = Value.ToString();
		}

		/// <summary>
		/// Increment value and update display
		/// </summary>
		public void IncrementValue()
		{
			Value++;
			text = Value.ToString();
		}

		/// <summary>
		/// Decrement value and update display
		/// </summary>
		public void DecrementValue()
		{
			Value--;
			text = Value.ToString();
		}

		void ValueChanged(string newValue)
		{
			int parsedValue = int.Parse(newValue);
			if (parsedValue > max)
			{
				Value = max;
				text = max.ToString();
			}
			else if (parsedValue < min)
			{
				Value = min;
				text = min.ToString();
			}
			else
			{
				Value = int.Parse(text);
			}
			onValueUpdated.Invoke(Value);
		}

		[System.Serializable]
		public class IntValueEvent : UnityEvent<int>
		{
		}

	}
}