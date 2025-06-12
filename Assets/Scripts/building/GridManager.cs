using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    // Stores all placed blocks with their grid positions
    private Dictionary<Vector3Int, GameObject> placedBlocks = new Dictionary<Vector3Int, GameObject>();

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Snaps any world position to the nearest grid-aligned Vector3Int
    /// </summary>
    public Vector3Int SnapToGrid(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        int z = Mathf.RoundToInt(position.z);
        return new Vector3Int(x, y, z);
    }

    /// <summary>
    /// Check if the grid position is already occupied
    /// </summary>
    public bool IsOccupied(Vector3Int pos)
    {
        return placedBlocks.ContainsKey(pos);
    }

    /// <summary>
    /// Instantiates a block prefab at the grid position and stores it
    /// </summary>
    public void PlaceBlock(Vector3Int pos, GameObject prefab)
    {
        if (IsOccupied(pos)) return;

        GameObject block = Instantiate(prefab, pos, Quaternion.identity);
        placedBlocks[pos] = block;
    }

    /// <summary>
    /// Destroys and removes a block at the grid position
    /// </summary>
    public void RemoveBlock(Vector3Int pos)
    {
        if (IsOccupied(pos))
        {
            Destroy(placedBlocks[pos]);
            placedBlocks.Remove(pos);
        }
    }
}
