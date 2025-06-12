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
        // Find BuildTool child once at startup
        buildToolTransform = Camera.main.transform.Find("BuildTool");

        if (buildToolTransform == null)
        {
            Debug.LogError("BuildTool object not found as a child of the camera.");
        }

        if (ghostBlockPrefab == null || realBlockPrefab == null)
        {
            Debug.LogError("Missing prefab assignments on BlockPlacer.");
            return;
        }

        ghostInstance = Instantiate(ghostBlockPrefab);
        ghostInstance.SetActive(false);

        Debug.Log("BlockPlacer initialized.");
    }

    void Update()
    {
        // If ghost is missing or camera isn't ready, exit
        if (ghostInstance == null || Camera.main == null)
            return;

        // Check if BuildTool exists and is active
        if (buildToolTransform == null || !buildToolTransform.gameObject.activeInHierarchy)
        {
            if (ghostInstance.activeSelf)
                ghostInstance.SetActive(false);

            return;
        }

        // Enable ghost if not already
        if (!ghostInstance.activeSelf)
        {
            ghostInstance.SetActive(true);
            Debug.Log("BuildTool active — showing ghost block.");
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f, groundMask))
        {
            Vector3 rawPos = hit.point + hit.normal * 0.49f;

            // Snap to nearest whole grid coordinate
            Vector3 snapped = new Vector3(
                Mathf.Round(rawPos.x),
                Mathf.Round(rawPos.y),
                Mathf.Round(rawPos.z)
            );

            ghostInstance.transform.position = snapped;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log($"Placing real block at {snapped}");
                Instantiate(realBlockPrefab, snapped, Quaternion.identity);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Collider[] targets = Physics.OverlapBox(snapped, Vector3.one * 0.45f);
                foreach (var col in targets)
                {
                    if (col.CompareTag("RealBlock"))
                    {
                        Debug.Log($"Destroying block: {col.gameObject.name}");
                        Destroy(col.gameObject);
                    }
                }
            }
        }
        else
        {
            if (ghostInstance.activeSelf)
            {
                ghostInstance.SetActive(false);
                Debug.Log("Raycast did not hit ground. Hiding ghost.");
            }
        }
    }
}
