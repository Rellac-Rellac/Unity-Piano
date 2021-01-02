using UnityEditor;
[CustomEditor(typeof(PianoKey))]
[CanEditMultipleObjects]
public class PianoKeyEditor : Editor
{
	SerializedProperty renderMode;
	SerializedProperty onSprite;
	SerializedProperty offSprite;
	SerializedProperty onColour;
	SerializedProperty offColour;

	void OnEnable()
	{
		renderMode = serializedObject.FindProperty("renderMode");
		onSprite = serializedObject.FindProperty("onSprite");
		offSprite = serializedObject.FindProperty("offSprite");
		onColour = serializedObject.FindProperty("onColour");
		offColour = serializedObject.FindProperty("offColour");
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		// Display properties
		EditorGUILayout.PropertyField(renderMode);

		PianoKey main = (PianoKey)target;
		if (main.renderMode == PianoKey.RenderMode.Sprite)
		{
			EditorGUILayout.PropertyField(onSprite);
			EditorGUILayout.PropertyField(offSprite);
		} else
		{
			EditorGUILayout.PropertyField(onColour);
			EditorGUILayout.PropertyField(offColour);
		}

		serializedObject.ApplyModifiedProperties();
	}
}
