﻿using UnityEngine;
using System.Collections.Generic;
using System;

#if PrivateSDK
using Crest;
#endif

#if DUNGEN
using DunGen;
#endif

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using EasyButtons;
#endif

namespace ThunderRoad
{
    [AddComponentMenu("ThunderRoad/Levels/Ocean")]
    public class Ocean : MonoBehaviour
    {
        public static List<Ocean> all = new List<Ocean>();
        public static Ocean current;

        public string prefabAddress = "Bas.Ocean.Greenland.LightHouse";

#if PrivateSDK
        [NonSerialized]
        public OceanRenderer crestOceanRenderer;
        [NonSerialized]
        public OceanDepthCache crestOceanDepthCache;
        [NonSerialized]
        public ShapeGerstner crestShapeGerstner;
#endif

        private void Awake()
        {
            all.Add(this);
        }

        [Button]
        public void Spawn()
        {
#if PrivateSDK
            Catalog.InstantiateAsync<OceanRenderer>(prefabAddress, oceanRenderer =>
            {
                if (oceanRenderer)
                {
                    crestOceanRenderer = oceanRenderer;
                    crestOceanRenderer.transform.position = this.transform.position;
                    crestOceanRenderer.transform.rotation = Quaternion.identity;

                    crestOceanDepthCache = crestOceanRenderer.GetComponentInChildren<OceanDepthCache>();
                    if (crestOceanDepthCache)
                    {
                        crestOceanRenderer.transform.rotation = Quaternion.Euler(0, this.transform.eulerAngles.y, 0);
                        crestOceanDepthCache.transform.SetParent(null, true);
                        crestOceanRenderer.transform.rotation = Quaternion.identity;
                        crestOceanDepthCache.transform.SetParent(crestOceanRenderer.transform, true);
                        crestOceanDepthCache.enabled = true;
                    }

                    crestShapeGerstner = crestOceanRenderer.GetComponent<ShapeGerstner>();
                    if (crestShapeGerstner)
                    {
                        crestShapeGerstner._waveDirectionHeadingAngle = this.transform.eulerAngles.y - 90;
                        if (SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.OpenGLES3)
                        {
                            Debug.LogError("Disabled crest ocean shapeGerstner as not supported on OpenGLES3");
                            crestShapeGerstner.enabled = false;
                        }
                    }

                    if (PlayerTest.local) crestOceanRenderer.ViewCamera = PlayerTest.local.cam;
                }
            }, "OceanSpawner");
#endif
        }

#if PrivateSDK

        private void OnEnable()
        {
            current = this;
            if (crestOceanRenderer)
            {
                crestOceanRenderer.gameObject.SetActive(true);
            }
            else
            {
                if (Level.current.dungeonGenerator)
                {
                    if (Level.current.dungeonGenerator.Generator.Status == GenerationStatus.Complete)
                    {
                        Spawn();
                    }
                }
                else
                {
                    Spawn();
                }
            }
        }

        private void OnDisable()
        {
            current = null;
            if (crestOceanRenderer)
            {
                crestOceanRenderer.gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            all.Remove(this);
            if (crestOceanRenderer)
            {
                Destroy(crestOceanRenderer.gameObject);
            }
        }
#endif
    }
}