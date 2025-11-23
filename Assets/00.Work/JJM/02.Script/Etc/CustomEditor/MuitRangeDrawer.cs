//using UnityEngine;
//using UnityEditor;

//[CustomPropertyDrawer(typeof(MultiRangeAttribute))]
//public class MultiRangeDrawer : PropertyDrawer
//{
//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        return base.GetPropertyHeight(property, label) * 2.0f;
//    }

//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        MultiRangeAttribute multiRange = attribute as MultiRangeAttribute;

//        if (property.propertyType == SerializedPropertyType.Float || property.propertyType == SerializedPropertyType.Integer)
//        {
//            Rect position1 = new Rect(position.x, position.y, position.width, position.height / 2.0f - 2.0f);
//            Rect position2 = new Rect(position.x, position.y + position.height / 2.0f + 2.0f, position.width, position.height / 2.0f - 2.0f);

//            EditorGUI.Slider(position1, property, multiRange.min1, multiRange.max1, new GUIContent(label.text + " (Range 1)"));
//        }
//        else
//        {
//            EditorGUI.LabelField(position, label.text, "Use MultiRange with float or int.");
//        }
//    }
//}