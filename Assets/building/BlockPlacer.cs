using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject ghostBlockPrefab;  // transparent preview block
    public GameObject realBlockPrefab;   // solid block to place
    public LayerMask placementMask;      // what the ray can hit
    public float maxRayDistance = 10f;

    private GameObject ghostBlock;

    void Start()
    {
        ghostBlock = Instantiate(ghostBlockPrefab);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxRayDistance, placementMask))
        {
            Vector3 worldPos = hit.point + hit.normal * 0.5f;
            Vector3Int gridPos = GridManager.Instance.SnapToGrid(worldPos);

            ghostBlock.transform.position = gridPos;

            if (Input.GetMouseButtonDown(0) && !GridManager.Instance.IsOccupied(gridPos))
            {
                GridManager.Instance.PlaceBlock(gridPos, realBlockPrefab);
            }
        }
        else
        {
            ghostBlock.transform.position = new Vector3(0, -100, 0);  // hide if nothing hit
        }
    }
}
