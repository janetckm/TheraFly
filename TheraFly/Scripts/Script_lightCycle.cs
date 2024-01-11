

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_lightCycle : MonoBehaviour
{
        public float rotationSpeed = 20f;

        void Update()
        {
            // change according to deltatime
            float angle = rotationSpeed * Time.deltaTime;
            // rotate y of sun
            transform.Rotate(Vector3.up, angle);
        }
}
