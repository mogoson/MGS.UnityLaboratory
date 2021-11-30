[TOC]

﻿# MGS.UnityAPI.Coroutine

## Summary

- Document for Unity Coroutine.

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Start Coroutine

- Coroutine couldn't be started if the the game object is inactive.


```C#
void Awake()
{
    gameObject.SetActive(false);
    //Coroutine couldn't be started because the game object is inactive!
    StartCoroutine(DelayDebug());
}
```

## Stop Coroutine

- Suggest use instance parameters to stop Coroutine.

```C#
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
```

## Coroutine Loop

- Loop break if exception throw.

```C#
IEnumerator DelayDebugLoop()
{
    while (true)
    {
        yield return null;
        Debug.Log("Coroutine debug.");

        //Loop break if exception throw.
        throw new Exception("Test throw Exception.");
    }
}
```

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com