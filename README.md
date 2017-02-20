# Documentation:

<br>

## ArchProgressBar:
### Description:
Nearly the same thing as CircularProgressBar just more customisible, has several styles (That determen labels positions and count).
### Properties:
1. Angle - Determens angle of the arch (360 - Full circle, 180 - Half a circle)
2. BackLineThikness - Thikness of back line.
3. ProgressLineThikness - Thikness of line that shows progress.
4. ProgressBackCollor - Color of a back line (Gray - By default).
5. ProgressColor - Collor of line that shows progress (Lime - By default).
6. Style - Styles that changes labels layout (Style1, Style2, Style3, None)
7. Text1, Text2, Text3 - Text of labels.
8. Text1Color, Text2Color, Text3Color - Colors of labels.
9. Font1, Font2, Font3 - Fonts of labels.

### Notes:
For updating labels method "UpdateText" should be used UNLESS there is a need to update only one label.

<br>

## DragControl:
### Description:
A way to drag borderless forms. Has double left click functionality to maximise form.
### Properties:
1. Fixed - True - to drag the form, False - to drag it withing the form. (if that makes sense)
2. MaximiseOnDoubleClick - If setted to true - maximises form on double-click.
3. TargetControl -  Control that is your grip.

<br>

## DropDown:
### Description:
Really simple DropDown.
### Properties:
1. ArrowSize - Size of the arrow. 
2. ArrowThikness - Thikness of arrow.
3. SetLayout - Control that supposed to be Dropped down.
4. TextDistance - Changes drawn text distance from  the left.

<br>

## Elipse:
### Description:
A way to round the conners of something, usualy used for borderless forms.
### Properties:
ConnerRadius - Conner radius...
TargetControl - Control that supposed to have rounded conners.

<br>

## FlatButton:
### Description:
Flat button that works as a tab, usualy used for navigations.
### Properties:
1. ActiveColor - Color that background changes whenever button is pressed.
2. ActiveTextColor -  Color that text changes to whenever button is pressed.
3. Image - Image that gets placed to the right of the text.
4. ImageSize - Size of the image.
5. OnHoverColor - Color of the background whenever mouse is hovering it.
6. OnHoverTextColor - Color of the text whenever mouse is hovering it.
7. Selected - If setted to true - default text and backgroud collor will be set to "active".
8. TextAligment - Aligment of the text.

<br>

## GradientPanel:
### Description:
Panel with gradient drawn on top of it.
### Properties:
1. Angle - Gradient angle.
2. StartColor - Color that gradient starts with.
3. EndColor - color that gradient ends with.

<br>
## ListView:
### Description:
ListView that accepts UserControls as its childs
### Properties:
1. AutoExpang - If setted to true, ListView changes its Height instead of having scrollbars.
2. Vertical - If setted to true, it adds childs verticly (From top to bottom), if setted to false - adds childs horizoticly - from left to right.

<br>

## ProgressBar:
### Description:
Basic ProgressBar.
### Properties:
1. BackLineThikness - Thikness of back line.
2. FrontLineThikness - Thikness of front line.
3. ProgressBackColor - Color of back line.
4. ForeColor - Color of front line.
5. Rounded - Rounds lines endings.
6. Smooth - enables anti-alias.
7. Value - value of the progressBar.

<br>

## Seperator:
### Description:
Probobly the most dificult componet out of all of them. Line. I putted alot of work into it, I hope my mom is proud of me now.
### Properties:
1. LineColor - Color of the line.
2. LineThikness - Thikness of hte line.
### Notes:
  Compatible with Left and right paddings. :)
  
  
<br>

## Slider:
### Description:
Slider - aka trakbar.
### Properties:
1. BackLineThikness - Thikness of back line.
2. CircleSize - Diameter of a circle.
3. DrawCircle - if setted to true - draws circle, false othervise.
4. FrontLineThikness - Thikness of front line.
5. MaxValue - Slider max value.
6. Value - Value.


<br>

## Switch:
### Description:
Basic switch.
### Properties:
1. IsOn - If setted to true - on by default.
2. OnColor -  Color of switch while its on.
3. OffColor - Same but while off.
4. OnText - Text that shows while switch is on.
5. OffText - Same but while Switch is off.
6. TextEnable - If setted to true, shows text.


<br>

## Form_WOC.cs (Class):
### Description:
Class that adds resisible grip to borderless forms edges. 
### How to use it:
  1. Change forms inharance from "Form" to "Form_WOC".
  2. Add padding of ur choice (Reccomended 2-3).
### Notes:
  Im still working on it, the problem that im having is that i cant make it transparent. Got any suggestions? Please contact me.




