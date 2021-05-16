using System;
using System.Collections;
using System.Collections.Generic;
using tmlpaks.commons;
using UnityEngine;

public class TransparencyGrid : MonoBehaviour
{
    public int Rows = 10;
    public int Columns = 10;
    public float TileSize = 1;
    public float Alpha
    {
        get => GetComponent<MeshRenderer>().material.color.a;
        set
        {
            Material m = GetComponent<MeshRenderer>().material;
            m.color = new Color(m.color.r, m.color.g, m.color.b, value);
        }
    }

    internal GridSelectionInfo getSelectionInfo(RowColumn startCell, RowColumn endCell)
    {
        return new GridSelectionInfo(startCell, endCell, TileSize);
    }

    Transform visualizer;

    void Start()
    {
        visualizer = transform.GetChild(0);
        float w = TileSize * Columns;
        float h = TileSize * Rows;
        visualizer.localScale = new Vector3(w, h, 1);
        var mr = visualizer.GetComponent<MeshRenderer>();
        mr.material.SetTextureScale("_BaseMap", new Vector2(Columns, Rows));
    }

    internal RowColumn getCellAtPoint(Vector3 posOnPlane)
    {
        Vector2 gridMinOffset = new Vector2(-TileSize * Columns/2, -TileSize * Rows /2);
        RowColumn rc = GridHelper.getCellAtWorldPosition(posOnPlane, 
            TileSize, gridMinOffset.x, gridMinOffset.y);

        return rc;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.3f);
        Gizmos.DrawCube(transform.position, new Vector3(TileSize, TileSize, TileSize));
    }
}
