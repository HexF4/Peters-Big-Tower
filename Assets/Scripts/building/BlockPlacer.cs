using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject ghostBlock;
    public LayerMask placementLayer;
    public float maxDistance = 5f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        if (ghostBlock != null)
        {
            ghostBlock = Instantiate(ghostBlock);
        }
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, placementLayer))
        {
            ghostBlock.SetActive(true);

            Vector3Int pos = Vector3Int.RoundToInt(hit.point + hit.normal * 0.5f);
            ghostBlock.transform.position = pos;

            if (Input.GetMouseButtonDown(0)) // Left click = place
            {
                if (!GridManager.Instance.IsOccupied(pos))
                {
                    Instantiate(blockPrefab, pos, Quaternion.identity);
                    GridManager.Instance.PlaceBlock(pos, blockPrefab);
                }
            }
            else if (Input.GetMouseButtonDown(1)) // Right click = break
            {
                Vector3Int blockPos = Vector3Int.RoundToInt(hit.point - hit.normal * 0.5f);
                if (GridManager.Instance.IsOccupied(blockPos))
                {
                    Collider[] hits = Physics.OverlapSphere(blockPos, 0.1f);
                    foreach (var h in hits)
                    {
                        if (h.CompareTag("Block"))
                        {
                            Destroy(h.gameObject);
                            GridManager.Instance.RemoveBlock(blockPos);
                        }
                    }
                }
            }
        }
        else
        {
            ghostBlock.SetActive(false);
        }
    }
}
