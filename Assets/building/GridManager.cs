using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private Dictionary<Vector3Int, GameObject> placedBlocks = new Dictionary<Vector3Int, GameObject>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Vector3Int SnapToGrid(Vector3 position)
    {
     int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        int z = Mathf.RoundToInt(position.z);
        return new Vector3Int(x, y, z);
    }

    public bool IsOccupied(Vector3Int pos)
    {
        return placedBlocks.ContainsKey(pos);
    }

    public void PlaceBlock(Vector3Int pos, GameObject prefab)
    {
        if (IsOccupied(pos)) return;

        GameObject block = Instantiate(prefab, pos, Quaternion.identity);
        placedBlocks[pos] = block;
    }

    public void RemoveBlock(Vector3Int pos)
    {
        if (IsOccupied(pos)) {
            Destroy(placedBlocks[pos]);
            placedBlocks.Remove(pos);
        }
    }
}