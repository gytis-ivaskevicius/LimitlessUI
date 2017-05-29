# EULA:
End-User Licence Agreement (EULA) for WithoutCaps Software 

This version is current as of May 27, 2017. Please consult withoutcapsdev@gmail.com for any new versions of this EULA.

You can only use the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team after you agree to this licence. By using this software, you agree to all of the clauses in the WithoutCaps Software EULA.

PLEASE READ CAREFULLY BEFORE USING THIS PRODUCT: This End-User Licence Agreement(EULA) is a legal agreement between you (either an individual or as a single entity) and the entity that is known as the WithoutCaps Team.

(a) Introduction. This is the End-User Licence Agreement (EULA) for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This EULA outlines the clauses of the licence that the WithoutCaps Team is willing to grant you (either as an individual or as a single entity) to use this software.

(b) Licence. The entity known as the WithoutCaps Team will grant a free of charge, fully-revocable, non-exclusive, non-transferable licence to any person obtaining a copy of the software known as "LimitlessUI" as well as the associated documentation. The aforementioned documentation consists of the End-User Licence Agreement (EULA) for the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team. This licence permits you to use, modify and re-distribute this software non-commercially so long as you (either an individual or as a single entity) has permission from the WithoutCaps Team to do so. If the user wants to re-distribute software made by the WithoutCaps Team this EULA must be included in the software package.

(c) Ownership. The software known as "LimitlessUI" and produced by the WithoutCaps Team is licenced, not sold, to you (either an individual or as a single entity) and as such the WithoutCaps Software Team reserves any rights not explicitly granted to you (either an individual or as a single entity).

The WithoutCaps Team also reserves the right to revoke any persons (either an individual or as a single entity) licence without previous notification or agreements as long as said the person (either an individual or as a single entity) didn't adhere to the End-User Licence Agreement (EULA) distributed with this software.

Notwithstanding the terms and conditions of this EULA, any part of the software contained within the product known as "LimitlessUI" which is currently maintained by the WithoutCaps Team which constitutes Third Party Software and as such now is licenced to you subject to the terms and conditions of the software licence agreement accompanying such Third Party Software. Whatever the form of the licence, whether it be in the form of a discrete agreement, shrink wrap licence or electronic licence terms are accepted at the time of acceptance of the End-User Licence Agreement for the software known as "LimitlessUI" which is currently maintained by the WithoutCaps Team.

(d) Limitation of Liability. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) 2017 WithoutCaps
<br>
<br>

# Documentation:

<br>

## ArchProgressBar:
### Description:
It's a progress bar in the shape of an arch. It's very customisable in that it has several styles that determine label positions and count.
### Properties:
1. Angle - It determines the angle of the arch (360 - Full Circle, 180 - Half a circle etc.)
2. BackLineThickness - It determines the thickness of the back line.
3. ProgressLineThickness - It determines the thickness of progress line.
4. ProgressBackCollor - It determines the color of a back line (It's grey by default).
5. ProgressColor - It determines the color of the line that shows progress (It's lime-green by default).
6. Style - It determines which style is in use. Styles change mostly labels' layouts.
7. Text1, Text2, Text3 - The text of the labels.
8. Text1Color, Text2Color, Text3Color - The color of the text inside the labels.
9. Font1, Font2, Font3 - It determines the font used for the text inside of the labels.
10. IgnoreHeight - If it's set to false then feel free to increase progressBar radius as long as the height allows.
### Notes:
For updating labels the method "UpdateText" should be used unless there is only the need to update one label.

<br>

## DragControl:
### Description:
A way to drag borderless forms. It also has double-click functionality which is currently used to maximise the form.
### Properties:
1. Fixed - If set to true it will drag the entire form and if set to false it will drag its TargetControl within the current form only (not moving the form itself).
2. MaximiseOnDoubleClick - If set to true it will maximise the form with a double-click and if set to false then it won't do anything.
3. TargetControl -  What the DragControl is using as it's grip.
4. DraggableInnerControls - If there are any buttons, controls etc. contained within the TargetControl if set to true it will make it so you can use said controls to drag the form. It also seems to disable the buttons.

<br>

## DropDown:
### Description:
A simple drop down arrow to either show or hide controls.
### Properties:
1. ArrowSize - It determines the size of the arrow.
2. Control - It determines the control that is supposed to be either shown or minimised.
3. TextOffset - Offsets text position by specified amount of pixels.
4. Image - It allows you to set a custom image for the arrow pointing down.

<br>

## Ellipse:
### Description:
A way to round the corners of something, usually used for borderless forms.
### Properties:
CornerRadius - It determines the corner radius.
TargetControl - It determines which control that supposed to have rounded corners.

<br>

## FlatButton:
### Description:
A flat theme button that works as a way of changing tabs hence why it's usually used for navigations around a form.
### Properties:
1. ActiveColor - The color that the background changes to whenever the button is pressed.
2. ActiveTextColor -  A color that the text changes to whenever the button is pressed.
3. Image - Image that gets placed to the right of the text.
4. ImageSize - Size of the image.
5. OnHoverColor - It determines the color of the background whenever the mouse is hovering over it.
6. OnHoverTextColor - It determines the color of the text whenever the mouse is hovering over it.
7. Selected - If set to true the default text and background color will be set to active.
8. TextAligment - It determines which was the text will be aligned on the button, TopLeft, MiddleRight etc.
9. ActiveImage - It determines the image that will be shown whenever the button is active.
10. DefaultBack(Fore)Color - It needs to be set to the default one if the button is selected.
11. DrawImage - It determines whether to draw the image. if provided.
12. DrawText - It determines whether to render the text. If set to false the button can be used as basic picture box.
13. IsTab - It determines whether the button is used to navigate to a tab.
14. TextOffset - It determines the distance that the text is supposed to be offset by a specified amount of pixels, for example, 5px on the x scale and 8px on the y scale would be "5, 7".
15. UseActiveImageWhileHovering - It determines whether the button uses the active image when the mouse is hovering over the button.

<br>

## GradientPanel:
### Description:
It's a panel that has a background of a gradient.
### Properties:
1. Angle - It determines at which angle the gradient is drawn.
2. StartColor - It determines the color that at the beginning of the gradient.
3. EndColor - It determines the color at the end of the gradient.

<br>

## ListView:
### Description:
It's a panel that accepts "UserControl" objects as its childs.
### Properties:
1. AutoExpand - It determines whether the ListView will change its height instead of having scrollbars.
2. Vertical - It determines whether the ListView stacks items vertically or horizontally.
### Methods:
1. Add();
2. Clear();
3. Remove();

<br>

## ProgressBar:
### Description:
It's just a basic progress bar.
### Properties:
1. BackLineThikness - It determines the thickness of the back line.
2. FrontLineThikness - It determines the thickness of the front line.
3. ProgressBackColor - It determines the color of the back line.
4. ForeColor - It determines the color of the front line.
5. Rounded - It determines whether the back and front lines are rounded.
6. Smooth - It determines whether to use anti-aliasing for drawing the lines.
7. Value - It determines the currently filled percentage of the ProgressBar.

<br>

## Separator:
### Description:
A simple line which can be used to separate parts of the user interface.
### Properties:
1. LineThickness - It determines the thickness of the line.
2. Vertical - It determines lines angle.

<br>

## Slider:
### Description:
It's a bar with a slider on it for user input.
### Properties:
1. BackLineThickness - It determines the thickness of the back line.
2. CircleSize - It determines the diameter of the circle.
3. DrawCircle - It determines whether to draw the circle.
4. FrontLineThickness - It determines the thickness of the front line.
5. MaxValue - It determines the maximum value of the slider.
6. Value - It determines the current value of the slider.

<br>

## Switch:
### Description:
It's a switch which can be set to either true or false with customisable text for the states.
### Properties:
1. IsOn - It determines whether the switch is set to on by default.
2. OnColor -  It determines the color of the switch while it's on.
3. OffColor - It determines the color of the switch while it's off.
4. OnText - It determines the text that is shown while the switch is on.
5. OffText - It determines the text that is shown while the switch is off.
6. TextEnable - It determines whether the text is shown.

<br>

## TabsAdapter:
### Description:
It's a component that helps manage "tabs". A tab is UserControl which is added dynamically. It works with the "Tab_WOC" class.
### Properties:
1. Control - It determines where the tabs will be drawn when they are toggled to be rendered.
### Methods:
1. addTab()
2. showTab()

<br>

## Tab:
### Description:
It's an interface that adds the onShowTab method but only if used with a TabsAdapter. Basically, it triggers an event when a tab is opened.
### Methods:
1. onShowTab();

<br>

## Form:
### Description:
A class that adds resizable grips to borderless form's edges. It also adds Windows 7 style shadow to the form.
### How to use it:
1. Change form's inheritance from "Form" to "Form_WOC".
2. Add a padding of your choice (My recommendation is 2 to 4).
### Notes:
The grip will be drawn on the edge of the form, this means that form needs to have small padding (around 2-4). To hide that padding the drawLine method was created, please view the sample code to learn more about it.

<br>

### MaterialTextBox:
### Description:
A material-styled text box with an animation.
### How to use it:
1. AnimationColor - It determines the color of the animation.
2. TextBox - It the text box object itself.
3. AnimationLength - It determines how long animation takes, in milliseconds.

<br>

### Animator:
### Description:
It allows more functionality for animating controls. Unfortunately, as of now it's only able to change their size.
### Properties:
1. Control - It determines which control you wish to animate.
2. Animation - It determines the type of animation.
### How to use it:
1. Add it to the form.
2. Set animation and "Control" per your choice. 
3. Use "animate(int animationLengthInMiliseconds, int value)" to start the animation.
### Delegates:
1. onWidthChanged(Control control, int change, bool isExpanding);
2. onHeightChanged(Control control, int change, bool isExpanding);
3. onAnimationTick(Control control);
### Methods:
1. animate(int animationLengthInMiliseconds, int value);
