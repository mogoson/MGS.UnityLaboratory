[TOC]

# MGS.UnityAPI.Component

## Summary

- Document for Unity Component.

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Reference

### Component Reference.

#### GetComponent on Awake

- Set the target game object active before use the Component that get on Awake

```C#
public class CpntReference0 : MonoBehaviour
{
    Image image;
    void Awake()
    {
        image = GetComponent<Image>();
    }
    public void Refresh(Color color)
    {
        image.color = color;
    }
}
public class CpntReferenceDemo : MonoBehaviour
{
    public CpntReference0 cpnt0;//GetComponent on Awake
    void Awake()
    {
        //cpnt0.Refresh(Color.green);//NullReferenceException
        cpnt0.gameObject.SetActive(true);//Awake invoke
        cpnt0.Refresh(Color.green);//Is OK
        //cpnt0.gameObject.SetActive(false);//If need inactive
    }
}
```

#### SerializeField for Component

- Need do nothing before use the Component

```C#
public class CpntReference1 : MonoBehaviour
{
    public Image image;//Set image in inspector
    void Reset()
    {
        image = GetComponent<Image>();
    }
    public void Refresh(Color color)
    {
        image.color = color;
    }
}
public class CpntReferenceDemo : MonoBehaviour
{
    public CpntReference1 cpnt1;//SerializeField for Component
    void Awake()
    {
        cpnt1.Refresh(Color.green);//Is OK
        cpnt1.gameObject.SetActive(true);//Remove this line if need inactive
    }
}
```

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com