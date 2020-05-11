using System.Collections.Generic;
using UnityEngine;

namespace MonkeyGame.Scripts
{
    public enum TransitionParameter 
    {
        Run,
        RunBack,
        RunLeft,
        RunRight,
        TurnLeft,
        TurnRight,
        Jump,
        Grounded,
        ForceTransition
    }

    public class ThirdPersonCharacterController : MonoBehaviour
    {
        [Header("Movement")]
        public bool     RunForward;
        public bool     RunBack;
        public bool     RunRight;
        public bool     RunLeft;
        public bool     Jump;
        public bool     TurnLeft;
        public bool     TurnRight;
        public float    GravityMultiplier;
        public bool     Grounded;
        public Vector3  Forward;
        [Range(0, 500)] public float     JumpForce;
        [Range(0, 20)]  public float     Speed;
        [Tooltip("Hero rotation speed to direction's camera.")] [SerializeField] [Range(0.1f, 3f)] float TurnSpeed;

        [Header("Collision")]
        [Tooltip("CapsuleCollider for detection spheres.")] [SerializeField] CapsuleCollider GroundDetectorCollider;
        [Tooltip("Helper :)")] [SerializeField] GameObject ColliderEdgePrefab;
        [Tooltip("Start point for ground detection line.")] public List<GameObject> BottomSpheres = new List<GameObject>();
        [Tooltip("Start point for hindrance detection line for move forward.")] public List<GameObject> FrontSpheres = new List<GameObject>();

        [Header("Components")]
        [SerializeField] Animator Animator;
        [Tooltip("CapsuleCollider's Player.")] [SerializeField] CapsuleCollider CapsuleCollider;

        [Header("UpdateCapsuleCollider")]
        public bool     UpdatingCapsuleCollider;
        public float    TargetHeight;
        public float    Size_Speed;
        public Vector3  TargetCenter;
        public float    Center_Speed;

        public Rigidbody Rigidbody => rigidbody;
        private Rigidbody rigidbody;

        private void Awake()
        {
            if (GroundDetectorCollider == null) GroundDetectorCollider  = GetComponent<CapsuleCollider>();
            if (CapsuleCollider == null)        CapsuleCollider         = GetComponent<CapsuleCollider>();

            Vector3 bottom = GroundDetectorCollider.bounds.center - (Vector3.up * GroundDetectorCollider.bounds.extents.y);
            Vector3 curve = bottom + (Vector3.up * GroundDetectorCollider.radius);

            GameObject newObj = CreateEdgeSphere(curve);
            newObj.transform.parent = this.transform;
            BottomSpheres.Add(newObj);

            Forward = Vector3.forward;
        }

        private void Start()
        {
            if (Animator == null) Animator = GetComponent<Animator>();
            if (rigidbody == null) rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Tu działa grawitacja na skok
            if (!Jump)
                Rigidbody.velocity += (-Vector3.up * GravityMultiplier);

            UpdateCapsuleColliderSize();
            UpdateCapsuleColliderCenter();
        }

        public void UpdateCapsuleColliderSize()
        {
            if (!UpdatingCapsuleCollider)
            {
                return;
            }

            //Debug.Log(Mathf.Sqrt(CapsuleCollider.height - TargetHeight) + "> 0.01f");
            //if (Mathf.Sqrt(CapsuleCollider.height - TargetHeight) > 0.01f)
            //if (!Animator.GetBool("Grounded"))
            //{
                CapsuleCollider.height = Mathf.Lerp(CapsuleCollider.height, TargetHeight, Time.deltaTime * Size_Speed);
            //}
        }

        public void UpdateCapsuleColliderCenter()
        {
            if (!UpdatingCapsuleCollider)
            {
                return;
            }

            // Debug.Log(Vector3.SqrMagnitude(CapsuleCollider.center - TargetCenter) + " > 0.01f");
            // if (Vector3.SqrMagnitude(CapsuleCollider.center - TargetCenter) > 0.01f)
            //if(!Animator.GetBool("Grounded"))
            //{
                CapsuleCollider.center = Vector3.Lerp(CapsuleCollider.center, TargetCenter, Time.deltaTime * Center_Speed);
            //}
        }

        public void RotateToDirectionCamera()
        {
            Vector3 m_Move = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            if (m_Move.magnitude > 1f) m_Move.Normalize();

            m_Move = transform.InverseTransformDirection(m_Move);
            float m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
            float m_ForwardAmount = m_Move.z;
            float turnSpeed = Mathf.Lerp(180, 360, m_ForwardAmount);
            transform.Rotate(0, m_TurnAmount * (turnSpeed * TurnSpeed) * Time.deltaTime, 0);
        }

        public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int iterations, List<GameObject> spheresList)
        {
            for (int i = 0; i < iterations; ++i)
            {
                Vector3 pos = start.transform.position + (dir * sec * (i + 1));
                pos.y += 0.5f;
                GameObject newObj = CreateEdgeSphere(pos);
                newObj.transform.parent = this.transform;
                spheresList.Add(newObj);
            }
        }

        /// <summary>
        /// 
        /// Bottom left corner
        ///
        /// </summary>
        /// <param name="boxCollider"></param>
        /// <param name="obj"></param>
        /// <param name="spheresList"></param>
        /// <param name="iterations"></param>
        public void CreateBottom(BoxCollider boxCollider, GameObject obj, List<GameObject> spheresList, int iterations)
        {
            List<GameObject> horizonSpheres = new List<GameObject>();

            Vector3 start = boxCollider.bounds.center - boxCollider.bounds.extents;
            Vector3 end_Vertical = new Vector3(boxCollider.bounds.center.x - boxCollider.bounds.extents.x, boxCollider.bounds.center.y - boxCollider.bounds.extents.y, boxCollider.bounds.center.z + boxCollider.bounds.extents.z);
            Vector3 end_Horizontal = (new Vector3(boxCollider.bounds.center.x + boxCollider.bounds.extents.x, boxCollider.bounds.center.y - boxCollider.bounds.extents.y, boxCollider.bounds.center.z - boxCollider.bounds.extents.z));

            float verticalSection = (start - end_Vertical).magnitude / (iterations + 1);
            float horizontalSection = (start - end_Horizontal).magnitude / (iterations + 1);

            //Tworzymy linie horyzontu
            for (int i = 0; i < iterations + 2; ++i)
            {
                Vector3 sph = start;
                sph.x += horizontalSection * i;
                var newObj = CreateEdgeSphere(sph);
                newObj.transform.parent = this.transform;
                horizonSpheres.Add(newObj);
                spheresList.Add(newObj);
            }

            for (int i = 0; i < horizonSpheres.Count-1; ++i)
            {
                for (int j = 0; j < horizonSpheres.Count; ++j)
                {
                    Vector3 sph = horizonSpheres[j].transform.position;
                    sph.z += verticalSection * (i + 1);
                    var newObj = CreateEdgeSphere(sph);
                    newObj.transform.parent = this.transform;
                    spheresList.Add(newObj);
                }
            }
            horizonSpheres.Clear();
        }

        public GameObject CreateEdgeSphere(Vector3 pos) 
            => Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
    }
}