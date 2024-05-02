using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnerCubes : MonoBehaviour
    {
        private const int MinCountChildren = 2;
        private const int MaxCountChildren = 6;
        private const int MinRandomRange = 1;
        private const int MaxRandomRange = 100;
        private const int Divider = 2;

        [SerializeField] private Cube _cube;        

        public bool TrySpawn(out Cube[] cubes, int chanceSeparation)
        {
            bool hasSpawned = Random.Range(MinRandomRange, MaxRandomRange) <= chanceSeparation;

            if (hasSpawned)
            {
                int count = Random.Range(MinCountChildren, MaxCountChildren);

                cubes = new Cube[count];

                for (int i = 0; i < count; i++)
                {
                    cubes[i] = Instantiate(_cube, transform.position, Quaternion.identity);
                    cubes[i].Init(transform.localScale / Divider, chanceSeparation / Divider);
                }
            }
            else
            {
                cubes = null;
            }

            return hasSpawned;
        }
    }
}