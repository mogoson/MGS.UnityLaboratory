/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CoroutineTest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  11/30/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace MGS.UnityAPI.Coroutine
{
    public class CoroutineTest : MonoBehaviour
    {
        void Awake()
        {
            StartTest();
            //LoopExceptionTest();
            //StopTest();
        }

        void StartTest()
        {
            StartCoroutine(DelayDebug());

            Debug.Log("enabled = false");
            enabled = false;
            StartCoroutine(DelayDebug());

            Debug.Log("SetActive(false)");
            gameObject.SetActive(false);
            //Coroutine couldn't be started because the game object 'CoroutineTest' is inactive!
            StartCoroutine(DelayDebug());
        }

        void StopTest()
        {
            //Can not stop.
            //StartCoroutine(DelayDebugLoop());
            //StopCoroutine(DelayDebugLoop());

            //Can not stop.
            //StartCoroutine(DelayDebugLoop());
            //StopCoroutine("DelayDebugLoop");

            //OK.
            //StartCoroutine("DelayDebugLoop");
            //StopCoroutine("DelayDebugLoop");

            //OK.
            //var debugger = StartCoroutine("DelayDebugLoop");
            //StopCoroutine(debugger);

            //OK.
            //var debugger = StartCoroutine(DelayDebugLoop());
            //StopCoroutine(debugger);

            //OK.
            var debugger = DelayDebugLoop();
            StartCoroutine(debugger);
            StopCoroutine(debugger);
        }

        void LoopExceptionTest()
        {
            StartCoroutine(DelayDebugLoopException());
        }

        IEnumerator DelayDebug()
        {
            yield return null;
            Debug.Log("Coroutine debug.");
        }

        IEnumerator DelayDebugLoop()
        {
            while (true)
            {
                yield return null;
                Debug.Log("Coroutine debug.");
            }
        }

        IEnumerator DelayDebugLoopException()
        {
            while (true)
            {
                yield return null;
                Debug.Log("Coroutine debug.");

                //Loop break if exception throw.
                throw new Exception("Test throw Exception.");
            }
        }
    }
}