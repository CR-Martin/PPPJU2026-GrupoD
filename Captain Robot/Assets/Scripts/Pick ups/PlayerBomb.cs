using UnityEngine;

public class PlayerBomb : MonoBehaviour, IWorldSpawn
{
    [SerializeField] GameObject bomb;
    public void WorldSpawn(Transform position)
    {
        Instantiate(bomb, new Vector3(Mathf.Round(position.transform.position.x), 0.5f,
                     position.transform.position.z), Quaternion.identity);
    }

}
