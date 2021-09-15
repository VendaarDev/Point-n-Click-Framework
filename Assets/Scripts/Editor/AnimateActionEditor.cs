using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimateAction))]
public class AnimateActionEditor : Editor
{
   SerializedProperty anims, actions;

   private void OnEnable()
   {
        anims = serializedObject.FindProperty("anims");
        actions = serializedObject.FindProperty("actions");
   }

   public override void OnInspectorGUI()
   {
        serializedObject.Update();
        if (GUILayout.Button("Add Animation Parameter"))
        {
            anims.InsertArrayElementAtIndex(anims.arraySize);
        }

        //draw anim inspector


        serializedObject.ApplyModifiedProperties();
   }

   void DrawAnimsInspector(SerializedProperty entry, int id)
   {

   }
}
