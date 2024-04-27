using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnerCoubs : MonoBehaviour
    {
        private const int MinCountChildren = 2;
        private const int MaxCountChildren = 6;
        private const int MinRandomRange = 1;
        private const int MaxRandomRange = 100;
        private const int Divider = 2;

        [SerializeField] private Coub _coub;        

        public bool TrySpawn(out Coub[] coubs, int chanceSeparation)
        {
            bool hasSpawned = Random.Range(MinRandomRange, MaxRandomRange) <= chanceSeparation;

            if (hasSpawned)
            {
                int count = Random.Range(MinCountChildren, MaxCountChildren);

                coubs = new Coub[count];

                for (int i = 0; i < count; i++)
                {
                    coubs[i] = Instantiate(_coub, transform.position, Quaternion.identity);
                    coubs[i].Init(transform.localScale / Divider, chanceSeparation / Divider);
                }
            }
            else
            {
                coubs = null;
            }

            return hasSpawned;
        }
    }
}