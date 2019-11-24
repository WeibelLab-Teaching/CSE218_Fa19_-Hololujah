using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace recipetable
{
    public class OptimizeforHololnes : MonoBehaviour
    {
        public GameObject containerObject;

        void Start()
        {
            // Check if the device type is HoloLens 
            if (HolographicSettings.IsDisplayOpaque)
            {
                // Optimize the default postion of the objects for Immersive HMD
                containerObject.transform.position = new Vector3(0.05f, 1.2f, -1.00f);

            }
            else
            {
                // Optimize the default postion of the objects for HoloLens
                containerObject.transform.position = new Vector3(0.05f, -0.65f, 0.50f);

                // Remove skybox for HoloLens
                RenderSettings.skybox = null;
            }
        }

    }
}
