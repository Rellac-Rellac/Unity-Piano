using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PianoController : MonoBehaviour
{
	/// <summary>
	/// Width to display octaves at an octave count of 1
	/// </summary>
	[Tooltip("Width to display octaves at an octave count of 1")]
	[SerializeField] private float octaveWidth = 1024;
	/// <summary>
	/// Width to display black keys at an octave count of 1
	/// </summary>
	[Tooltip("Width to display black keys at an octave count of 1")]
	[SerializeField] private float blackKeyWidth = 100;
	/// <summary>
	/// InputValue to determine octave count
	/// </summary>
	[Tooltip("InputValue to determine octave count")]
	[SerializeField] private InputCounter octavesCounter = null;
	/// <summary>
	/// List of all available octaves
	/// </summary>
	[Tooltip("List of all available octaves")]
	[SerializeField] private Octave[] octaves = new Octave[7];


	// Start is called before the first frame update
	void Start()
    {
		octavesCounter.onValueUpdated.AddListener(OnOctaveCountUpdated);
		OnOctaveCountUpdated(octavesCounter.Value);
    }

	/// <summary>
	/// Update octave display when count is changed
	/// </summary>
	/// <param name="count">new octave count</param>
    public void OnOctaveCountUpdated(int count)
	{
		for (int i = 0; i < octaves.Length; i++)
		{
			octaves[i].gameObject.SetActive(i < count);
			RectTransform rt = (RectTransform)octaves[i].transform;
			Vector2 size = rt.sizeDelta;
			size.x = octaveWidth / count;
			rt.sizeDelta = size;
			for (int j = 0; j < octaves[i].blackKeys.Length; j++)
			{
				float keyWidth = blackKeyWidth / count;
				octaves[i].blackKeys[j].SetWidth(keyWidth);

				float childScale = keyWidth / blackKeyWidth;
				octaves[i].blackKeys[j].SetChildScale(childScale);
			}
		}
	}
}
