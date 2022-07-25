using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildable : MonoBehaviour
{
    public LayerMask layer;
    public GameObject cursor;
    public GameObject towerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        layer = LayerMask.NameToLayer("BuildableLayer");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 hitPos;
        if (PositionBuildablePlane(out hitPos))
        {
            cursor.SetActive(true);
            cursor.transform.position = hitPos;
            if (Input.GetMouseButton(0))
            {
                PlaceTower(hitPos);
            }
        }
        else cursor.SetActive(false);
    }
    bool PositionBuildablePlane(out Vector3 position){
        Vector3 mousePos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, layer))
        {
            position = hit.point;
            return true;
        }
        position = Vector3.zero;
        return false;
    }

    private void PlaceTower(Vector3 pos){
        GameObject placedTower = Instantiate(towerPrefab);
        placedTower.transform.position = pos;
    }
}
