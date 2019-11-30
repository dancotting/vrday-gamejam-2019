﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TaskObject")
        {
            SuccessCriterion checkVal = other.gameObject.GetComponent<SuccessCriteria>().successCriterion;
            TaskManager.Instance.CheckForSuccess(checkVal);
        }
    }
}