using UnityEngine;

public class Rayt : MonoBehaviour
{
    [SerializeField] private float _rayDistance;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, ray.direction * _rayDistance);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray))
            {
                Debug.Log("Вы попали в цель");
            }
        }
    }
}