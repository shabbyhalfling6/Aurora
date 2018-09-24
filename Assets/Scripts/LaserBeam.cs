using UnityEngine;
using System.Collections;
using System;

public class LaserBeam : SpecialWeapon {

    private Vector3 currentPos;
    private Vector3 currentScale;
    private float growthSpeed = 5.0f;
    private int maxGrowth = 10;


    public override void Ability()
    {
        currentPos = myTransform.position;
        currentScale = myTransform.localScale;

        currentScale.z += growthSpeed * Time.deltaTime;
        currentPos.z += (growthSpeed * Time.deltaTime) / 2;

        if (currentScale.z >= maxGrowth)
        {
            currentScale.z = maxGrowth;
        }

        if (currentPos.z >= maxGrowth / 2)
        {
            currentPos.z = maxGrowth / 2;
        }

        myTransform.position = currentPos;
        myTransform.localScale = currentScale;
    }
}
