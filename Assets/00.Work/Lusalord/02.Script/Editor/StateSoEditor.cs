using _00.Work.Lusalord._02.Script.SO.Player.FSM;
using UnityEngine.UIElements;
using UnityEditor;

namespace _00.Work.Lusalord._02.Script.Editor
{
    [CustomEditor(typeof(StateSO))]
    public class StateSoEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            return base.CreateInspectorGUI();
        }
    }
}