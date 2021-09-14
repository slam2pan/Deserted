using UnityEngine;

public class CurrGunDirection : MonoBehaviour
{
    [SerializeField] private Transform playerAimTransform;
    private SpriteRenderer currGunImage;

    bool GunOnLeftSide => playerAimTransform.eulerAngles.z > 0 && playerAimTransform.eulerAngles.z < 180;

    void Awake()
    {
        currGunImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GunOnLeftSide)
            currGunImage.flipY = true;
        else
            currGunImage.flipY = false;

    }
}
