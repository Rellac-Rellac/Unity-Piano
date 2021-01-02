using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
[CustomEditor(typeof(InputCounter))]
[CanEditMultipleObjects]
public class InputCounterEditor : Editor
{
	SerializedProperty value;
	SerializedProperty min;
	SerializedProperty max;
	SerializedProperty onValueUpdated;

	void OnEnable()
	{
		value = serializedObject.FindProperty("Value");
		min = serializedObject.FindProperty("min");
		max = serializedObject.FindProperty("max");
		onValueUpdated = serializedObject.FindProperty("onValueUpdated");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		// Display properties
		EditorGUILayout.PropertyField(value);
		EditorGUILayout.PropertyField(min);
		EditorGUILayout.PropertyField(max);

		// Having trouble finding the property for this, still works fine so eh
		InputCounter main = (InputCounter)target;
		main.textComponent = (Text)EditorGUILayout.ObjectField("Text", main.textComponent, typeof(Text), true);

		// clamp value between min/max
		main.Value = Mathf.Clamp(main.Value, main.min, main.max);
		main.text = main.Value.ToString();

		// final event
		EditorGUILayout.PropertyField(onValueUpdated);

		serializedObject.ApplyModifiedProperties();
	}
}