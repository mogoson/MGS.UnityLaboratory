[TOC]

﻿# MGS.UnityAPI.UILayout

## Summary

- Document for Unity UI layout.

## Environment

- Unity 5.6 or above.
- .Net Framework 3.5 or above.

## Horizontal

## Vertical

### Fitter+Layout

Use **ContentSizeFitter** and multi **VerticalLayoutGroup** components to made vertical auto layout frame.

```tex
Panel(root)				[ContentSizeFitter, VerticalLayoutGroup]
	Text				[Text]
	Layout				[VerticalLayoutGroup]
		Image			[Image, LayoutElement]
		Layout			[VerticalLayoutGroup]
			...
	Layout				[VerticalLayoutGroup]
		...
```

1. Add **ContentSizeFitter** to the root gameobject.

   ```tex
   Vertical Fit = Preferred;
   ```

2. Add **VerticalLayoutGroup** to the root gameobject.

   Add **VerticalLayoutGroup** to the children gameobjects if need.

   ```tex
   Control Child Size:
   	Height = true;
   ```

3. If child node with a **Text** component, the layout will auto calculate preferred size.

4. If child node with a **Image** component, the preferred size is base on the image; 

5. Add the **LayoutElement** component, and we can set a specific preferred size(width/height).

   ```tex
   Preferred Height = 100;	//Example case.
   ```

## Grid

------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com