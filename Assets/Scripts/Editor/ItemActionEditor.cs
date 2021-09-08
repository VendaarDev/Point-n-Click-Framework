using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemActions))]
public class ItemActionEditor : Editor
{
    ItemActions source;
    SerializedProperty s_itemDatabase, s_giveItem, s_yesActions, s_noActions;

    private void OnEnable()
    {
         source = (ItemActions)target;
         s_itemDatabase = serializedObject.FindProperty("itemDatabase");
         s_giveItem = serializedObject.FindProperty("giveItem");
         s_yesActions = serializedObject.FindProperty("yesActions");
         s_noActions = serializedObject.FindProperty("noActions");
    }

    public override void OnInspectorGUI()
    {
         serializedObject.Update();

         EditorGUILayout.PropertyField(s_itemDatabase, new GUIContent("Item Database: "));

         if (s_itemDatabase != null)
         {
              //draw the popup or enum for selecting items
              source.itemId = EditorGUILayout.Popup(source.itemId, source.ItemDatabase.ItemNames.ToArray());

              EditorGUILayout.PropertyField(s_giveItem, new GUIContent("Give Item: "));

              //draw item entry
              DrawItemEntry(source.CurrentItem);

              EditorGUILayout.PropertyField(s_yesActions, new GUIContent("Yes Actions: "), true);

              EditorGUILayout.PropertyField(s_noActions, new GUIContent("No Actions: "), true);
         }

         if (GUI.changed)
         {
              source.ChangeItem(source.ItemDatabase.GetItem(source.itemId));

              EditorUtility.SetDirty(source);
         }

         serializedObject.ApplyModifiedProperties();
    }

    void DrawItemEntry(Item item)
    {
         GUILayout.BeginVertical("box");

         //Item ID and Name
         GUILayout.BeginHorizontal();
         EditorGUILayout.LabelField("Item ID " + item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f));
         EditorGUILayout.LabelField("Item Name: "+ item.FindPropertyRelative("itemName").stringValue);

         GUILayout.EndHorizontal();
         //Item Description
         EditorGUILayout.LabelField("Item Description: "+ item.FindPropertyRelative("itemDescription").stringValue, GUILayout.Height(70f));

         //Item Sprite
         GUILayout.BeginHorizontal();
         var spriteViewer = AssetPreview.GetAssetPreview(item.FindPropertyRelative("itemSprite").objectReferenceValue);
         GUILayout.Label(spriteViewer);

         if (item.FindPropertyRelative("allowMultiple").boolValue)
              EditorGUILayout.PropertyField(item.FindPropertyRelative("amount"));

         GUILayout.EndHorizontal();

         GUILayout.EndVertical();
    }

}
