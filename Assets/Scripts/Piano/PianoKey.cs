using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
[RequireComponent(typeof(Image))]
public class PianoKey : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	/// <summary>
	/// How we display changes when key pressed
	/// </summary>
	[Tooltip("How we display changes when key pressed")]
	public RenderMode renderMode = RenderMode.Colour;

	/// <summary>
	/// Sprite to display when key is pressed
	/// </summary>
	[Tooltip("Sprite to display when key is pressed")]
	public Sprite onSprite;
	/// <summary>
	/// Sprite to display when key is idle
	/// </summary>
	[Tooltip("Sprite to display when key is idle")]
	public Sprite offSprite;

	/// <summary>
	/// Colour to display when key is pressed
	/// </summary>
	[Tooltip("Colour to display when key is pressed")]
	public Color onColour = Color.grey;
	/// <summary>
	/// Colour to display when key is idle
	/// </summary>
	[Tooltip("Colour to display when key is idle")]
	public Color offColour = Color.white;

	private bool isOn = false;

	private Image img_;
	private Image img
	{
		get
		{
			if (img_ == null) img_ = GetComponent<Image>();
			return img_;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		SetPressState(false);
	}

    // Update is called once per frame
    void Update()
    {
        if (isOn)
		{
			if (Input.GetMouseButtonUp(0))
			{
				SetPressState(false);
			}
		}
    }

	/// <summary>
	/// Set the width for this key
	/// </summary>
	/// <param name="input">new width</param>
	public void SetWidth(float input)
	{
		RectTransform rt = (RectTransform)transform;
		Vector2 size = rt.sizeDelta;
		size.x = input;
		rt.sizeDelta = size;
	}

	/// <summary>
	/// Set key press state
	/// </summary>
	/// <param name="input">key is pressed</param>
	private void SetPressState(bool input)
	{
		isOn = input;
		SetRenderOn(input);
	}

	/// <summary>
	/// Update render to display key press
	/// </summary>
	/// <param name="input">key is pressed</param>
	private void SetRenderOn(bool input)
	{
		switch (renderMode)
		{
			case RenderMode.Colour:
				img.color = input ? onColour : offColour;
				break;
			case RenderMode.Sprite:
				img.sprite = input ? onSprite : offSprite;
				break;
		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		SetPressState(true);
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		if (Input.GetMouseButton(0)) SetPressState(true);
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		SetPressState(false);
	}

	public enum RenderMode
	{
		Colour,
		Sprite
	}
}
