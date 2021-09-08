using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemDatabase))]
public class ItemDatabaseEditor : Editor
{
     ItemDatabase source;
     SerializedProperty s_items, s_itemNames;

     private void OnEnable()
     {
          source = (ItemDatabase)target;
          s_items = serializedObject.FindProperty("items");
          s_itemNames = serializedObject.FindProperty("itemNames");
     }

     public override void OnInspectorGUI()
     {
          serializedObject.Update();

          if (GUILayout.Button("Add Item"))
          {
               Item newItem = new Item(s_items.arraySize, "", "", null, false);
               source.AddItem(newItem);

          }

          for (int i = 0; i < s_items.arraySize; i++)
          {
            //draw item entry
            DrawItemEntry(s_items.GetArrayElementAtIndex(i));
          }

          if(GUI.changed)
               RecalculateID();

          serializedObject.ApplyModifiedProperties();

     }

     void DrawItemEntry(SerializedProperty item)
     {
          GUILayout.BeginVertical("box");

          //Item ID and Name
          GUILayout.BeginHorizontal();
          EditorGUILayout.LabelField("Item ID " + item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f));
          EditorGUILayout.PropertyField(item.FindPropertyRelative("itemName"));

          if(GUILayout.Button("X", GUILayout.Width(20f)))
          {
               //delete the item
               s_itemNames.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue);
               s_items.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue);
               RecalculateID();
               return;
          }

          GUILayout.EndHorizontal();
          //Item Description
          EditorGUILayout.PropertyField(item.FindPropertyRelative("itemDescription"));

          //Item Sprite
          GUILayout.BeginHorizontal();
          item.FindPropertyRelative("itemSprite").objectReferenceValue = EditorGUILayout.ObjectField("Item Sprite:",
          item.FindPropertyRelative("itemSprite").objectReferenceValue, typeof(Sprite),false);
          //Allow multiple items of this type?
          EditorGUILayout.PropertyField(item.FindPropertyRelative("allowMultiple"));
          GUILayout.EndHorizontal();

          GUILayout.EndVertical();


          }

          void RecalculateID()
          {
               for (int i = 0; i < s_items.arraySize; i++)
               {
                    s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemId").intValue = i;
                    s_itemNames.GetArrayElementAtIndex(i).stringValue =
                    s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemName").stringValue;
               }
     }
}
