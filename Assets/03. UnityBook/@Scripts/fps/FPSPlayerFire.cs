using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;
    public GameObject bombFactory;

    public float throwPower = 15f;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    private ParticleSystem ps;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) return;

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            if(anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {

                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point; // 맞은 위치에 이펙트 생성
                    bulletEffect.transform.forward = hitInfo.normal; // 법선 방향으로 이펙트 방향 설정
                    ps.Play();
                }



                /*
                if (hitInfo.collider != null && hitInfo.collider.CompareTag("Enemy"))
                {
                    int v = Random.Range(-10, 10);

                    Vector3 dir = new Vector3(v, 0, v);

                    CharacterController cc = hitInfo.transform.GetComponent<CharacterController>();

                    hitInfo.transform.position = transform.position + dir;
                    cc.Move(dir * 50 * Time.deltaTime);

                    ps.Play();
                    return;
                }*/
                //ps.Play();
            }
        }

        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪽 버튼 클릭
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }


}
