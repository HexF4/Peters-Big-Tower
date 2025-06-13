using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject ghostBlockPrefab;
    public GameObject realBlockPrefab;
    public LayerMask groundMask;

    private GameObject ghostInstance;
    private Transform buildToolTransform;

    void Start()
    {
        buildToolTransform = Camera.main.transform.Find("BuildTool");

        if (buildToolTransform == null)
        {
            Debug.LogError("BuildTool object not found under Camera.");
            return;
        }

        if (ghostBlockPrefab == null || realBlockPrefab == null)
        {
            Debug.LogError("Assign ghostBlockPrefab and realBlockPrefab in Inspector.");
            return;
        }

        ghostInstance = Instantiate(ghostBlockPrefab);
        ghostInstance.SetActive(false);
    }

    void Update()
    {
        if (Camera.main == null || ghostInstance == null || buildToolTransform == null)
            return;

        if (!buildToolTransform.gameObject.activeInHierarchy)
        {
            ghostInstance.SetActive(false);
            return;
        }

        ghostInstance.SetActive(true);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, groundMask))
        {
            // ✅ THE CORRECT SNAPPING — this WORKS
            Vector3 snapped = new Vector3(
                Mathf.Floor(hit.point.x) + 0.5f,
                Mathf.Floor(hit.point.y) + 0.5f,
                Mathf.Floor(hit.point.z) + 0.5f
            );

            ghostInstance.transform.position = snapped;

            if (Input.GetMouseButtonDown(0)) // Left click
            {
                Instantiate(realBlockPrefab, snapped, Quaternion.identity);
            }

            if (Input.GetMouseButtonDown(1)) // Right click
            {
                Collider[] hits = Physics.OverlapBox(snapped, Vector3.one * 0.45f);
                foreach (var col in hits)
                {
                    if (col.CompareTag("RealBlock"))
                    {
                        Destroy(col.gameObject);
                    }
                }
            }
        }
        else
        {
            ghostInstance.SetActive(false);
        }
    }
}
