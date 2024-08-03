using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class BrickWallGenerate : MonoBehaviour
{
        [SerializeField] private Transform Brick;
        [SerializeField] private int lines;
        [SerializeField] private int bricksInLine;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            Vector3 wallCenter = transform.position;
            float wallStartX = wallCenter.x - bricksInLine * Brick.localScale.x / 2;
            float wallStartY = wallCenter.y + Brick.localScale.y / 2;
            float wallStartZ = wallCenter.z;
            for (int i = 0; i < lines; i++)
            {
                float semiBrickDistance = 0f;
                if (i % 2 != 0)
                    semiBrickDistance = Brick.localScale.x / 2;
                for (int j = 0; j < bricksInLine; j++)
                {
                    Transform brick = Instantiate(Brick, new Vector3(
                        wallStartX + j * Brick.localScale.x + semiBrickDistance,
                        wallStartY + i * Brick.localScale.y,
                        wallStartZ), Quaternion.identity, transform);
                    Rigidbody brickRb = brick.GetComponent<Rigidbody>();
                    brickRb.Sleep();
                }
            }
        }

    }
