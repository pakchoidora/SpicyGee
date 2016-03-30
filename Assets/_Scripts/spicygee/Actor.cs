using UnityEngine;
using System.Collections;

namespace spicygee
{
    public abstract class Actor : MonoBehaviour {

        public float moveTime = 0.1f;

        private Rigidbody2D rb2D;
        private float inverseMoveTime;

        public abstract bool CanMove();

        public abstract void TakeDamage(Damage damage);

        protected abstract bool Move(int x, int y, out RaycastHit2D hit);

        protected virtual IEnumerator SmoothMovement(Vector3 end) {
            //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
            //Square magnitude is used instead of magnitude because it's computationally cheaper.
            float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //While that distance is greater than a very small amount (Epsilon, almost zero):
            while (sqrRemainingDistance > float.Epsilon)
            {
                //Find a new position proportionally closer to the end, based on the moveTime
                Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);

                //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
                rb2D.MovePosition(newPostion);

                //Recalculate the remaining distance after moving.
                sqrRemainingDistance = (transform.position - end).sqrMagnitude;

                //Return and loop until sqrRemainingDistance is close enough to zero to end the function
                yield return null;
            }
        }

        public abstract void Attack(Actor target);
    }
}
