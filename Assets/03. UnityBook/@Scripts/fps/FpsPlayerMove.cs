using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 5f;
    public bool isJumping = false;

    private float h;
    private float v;


    public int hp = 20;
    private int maxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run) return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 입력값 벡터 생성
        dir = dir.normalized; // 정규화

        anim.SetFloat("MoveMotion", dir.magnitude);
        // 카메라의 Transform 기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        // 중력 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // 캐릭터 컨트롤러에 내장된 이동 기능


        // none : 아무것도 닿지 않음
        // below : 바닥에 닿음
        // adove : 머리에 닿음
        // sides : 옆면에 닿음

        if(cc.collisionFlags == CollisionFlags.Below) // 
        {
            if(isJumping) isJumping = false;

            yVelocity = 0f; // 중력 초기화의 이유는 중력은 계속 누적되기 때문에
            // 초기화를 안하면 위에서 아래로 점프가 아닌, 단순떨어질때 순간이동 하는 현상이 발생
        }


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            yVelocity = jumpPower;
            isJumping = true;
        }

        
    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp / maxHp;

        if(hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);  

        hitEffect.SetActive(false);
    }


}