[TOC]

# MGS.UnityAPI.Coordinate

## Summary

- Document for Unity Coordinate.

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## UI Coordinate

### UI To UI

#### Use World Position

- Use **World Position** to set other UI Position and use **localPosition** or **anchoredPosition** to set offset.

```C#
//Require this method invoke after related Components Init the value of position and localPosition and anchoredPosition.
void Start()
{
    image1.position = image0.position;

    var anchor = Vector2.one * 0.5f;
    var pivotOffset = image1.pivot - anchor;
    
    /*
    //If need align to specific anchor, but do not modify pivot.
    var localPos = image1.localPosition;
    var posOffsetV3 = new Vector3(pivotOffset.x * image1.rect.width, pivotOffset.y * image1.rect.height);
    localPos += posOffsetV3;
    image1.localPosition = localPos;//Use localPosition is OK
    */
    
    //If need align to specific anchor, but do not modify pivot.
    var anchorPos = image1.anchoredPosition;
    var posOffsetV2 = new Vector2(pivotOffset.x * image1.rect.width, pivotOffset.y * image1.rect.height);
    anchorPos += posOffsetV2;
    image1.anchoredPosition = anchorPos;//Use anchoredPosition is OK
}
```

### Screen To UI

#### Use Local Position

- Use **localPosition**, then we don't need to care about self Anchors and Pivot of parent and use **localPosition** to set offset.

```C#
Camera uiCamera = null;
if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
{
    uiCamera = canvas.worldCamera;
}
var localPos = Vector2.zero;
var isInRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(target.parent as RectTransform, Input.mousePosition, uiCamera, out localPos);
if (isInRect)
{
    //If need align to specific anchor, but do not modify pivot.
    var anchor = Vector2.one * 0.5f;
    var pivotOffset = target.pivot - anchor;
    var posOffset = new Vector2(pivotOffset.x * target.rect.width, pivotOffset.y * target.rect.height);
    localPos += posOffset;
    //Use localPosition, then we don't need to care about self Anchors and Pivot of parent.
    target.localPosition = localPos;
}
```

#### Use World Position

- Use **World  Position**, then we don't need to care about self Anchors and Pivot of parent and use **localPosition** or **anchoredPosition** to set offset.

```C#
Camera uiCamera = null;
if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
{
    uiCamera = canvas.worldCamera;
}
var worldPos = Vector3.zero;
var isInRect = RectTransformUtility.ScreenPointToWorldPointInRectangle(target.parent as RectTransform,Input.mousePosition, uiCamera, out worldPos);
if (isInRect)
{
    //Use position, then we don't need to care about self Anchors and Pivot of parent.
    target.position = worldPos;
    //If need align to specific anchor, but do not modify pivot.
    var anchor = Vector2.one * 0.5f;
    var pivotOffset = target.pivot - anchor;
    //var posOffsetV3 = new Vector3(pivotOffset.x * target.rect.width, pivotOffset.y * target.rect.height);
    //target.localPosition += posOffsetV3;  //is OK
    var posOffsetV2 = new Vector2(pivotOffset.x * target.rect.width, pivotOffset.y * target.rect.height);
    target.anchoredPosition += posOffsetV2;  //is OK
}
```

#### Use Anchored Position

- Use anchoredPosition, we need to care about Pivot of parent, and self Anchors  and Pivot.
- The general algorithm is complex, this method is not recommended.

```C#
//TODO: 09/01/2021 Mogoson, general algorithms are being explored.
```

### World To UI

#### Use Camera

- General method of **World To Screen** and See **Screen To UI**

```C#
var worldCamera = Camera.main;  //Camera for world gameobject.
var screenPos = worldCamera.WorldToScreenPoint(cube.position);
```

#### Use RectTransformUtility

- Specific method of **World To Screen** for UI and See **Screen To UI**

```C#
var worldCamera = Camera.main;  //Camera for world gameobject.
var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, cube.position);
```

## View Coordinate

## Screen Coordinate

## World Coordinate

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com