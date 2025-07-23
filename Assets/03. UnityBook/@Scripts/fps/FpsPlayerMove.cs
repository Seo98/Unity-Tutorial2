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

        Vector3 dir = new Vector3(h, 0, v); // �Է°� ���� ����
        dir = dir.normalized; // ����ȭ

        anim.SetFloat("MoveMotion", dir.magnitude);
        // ī�޶��� Transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        // �߷� ����
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); // ĳ���� ��Ʈ�ѷ��� ����� �̵� ���


        // none : �ƹ��͵� ���� ����
        // below : �ٴڿ� ����
        // adove : �Ӹ��� ����
        // sides : ���鿡 ����

        if(cc.collisionFlags == CollisionFlags.Below) // 
        {
            if(isJumping) isJumping = false;

            yVelocity = 0f; // �߷� �ʱ�ȭ�� ������ �߷��� ��� �����Ǳ� ������
            // �ʱ�ȭ�� ���ϸ� ������ �Ʒ��� ������ �ƴ�, �ܼ��������� �����̵� �ϴ� ������ �߻�
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