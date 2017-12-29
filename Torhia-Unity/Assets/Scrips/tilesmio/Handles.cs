/*using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TilesObjetos))]
public class SphereExampleEditor : Editor
{
    float size = 0.5f;
    DragAndDrop.AcceptDrag()
    protected virtual void OnSceneGUI()
    {
    	TilesObjetos tiles = (TilesObjetos)target;
        if (Event.current.type == EventType.Repaint)
        {
        	//Handles.Handles.SnapValue(tiles.tamaño, tiles.tamaño)
        	
            Transform transform = tiles.transform;
            Handles.color = Handles.xAxisColor;
            Handles.SphereHandleCap(
                0,
                transform.position + new Vector3(-tiles.tamaño/2, -tiles.tamaño/2, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.right),
                size,
                EventType.Repaint
                );
            Handles.color = Handles.yAxisColor;
            Handles.SphereHandleCap(
                1,
                transform.position + new Vector3(tiles.longitud - tiles.tamaño/2, -tiles.tamaño/2, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.up),
                size,
                EventType.Repaint
                );
            Handles.color = Handles.zAxisColor;
            Handles.SphereHandleCap(
                2,
                transform.position + new Vector3(-tiles.tamaño/2, tiles. altura-tiles.tamaño/2, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.forward),
                size,
                EventType.Repaint
                );
            Handles.color = Color.yellow;
            Handles.SphereHandleCap(
                3,
                transform.position + new Vector3(tiles.longitud - tiles.tamaño/2, tiles. altura-tiles.tamaño/2, 0f),
                transform.rotation * Quaternion.LookRotation(Vector3.forward),
                size,
                EventType.Repaint
                );
        }
        
/*
        Vector3 snap = Vector3.one * 0.5f;
        EditorGUI.BeginChangeCheck();
        Vector3 newTargetPosition = Handles.FreeMoveHandle(tiles.posicion1, Quaternion.identity, size, snap, Handles.RectangleHandleCap);
 		if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(tiles, "Change Look At Target Position");
            tiles.posicion1 = newTargetPosition;
            tiles.Generar();
        }
    }
}*/