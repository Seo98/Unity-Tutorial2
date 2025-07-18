using UnityEngine;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 5f;
    public bool isJumping = false;

    private float h;
    private float v;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        dir = dir.normalized; // 방향만 있는 벡터

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
}