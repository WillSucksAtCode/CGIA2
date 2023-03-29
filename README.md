# CGIA2
Computer Graphics Assignment #2
William Heath

Deferred VS Forward:

Forward rendering entail’s rendering each object and applying passes to it. An object will be rendered for every single light touching it so that the light can accumulate. This method of rendering is linear.

Deferred rendering waits until all the geometry is rendered, and then applies shading at the end, This allows us to use as many lights as we wish without causing additional passes for every light.

Overall deferred rendering is the faster option as it renders the scene’s basic attributes and then adds lighting for the final image, whereas forward rendering takes longer to render as it renders each individual light and how it affects each object.

FORWARD:
![ForwardRendering](https://user-images.githubusercontent.com/92412422/228296690-e75bd236-8be7-4b71-a0b9-00ad93fce561.png)
DEFERRED:
![DeferredRendering](https://user-images.githubusercontent.com/92412422/228296742-7a51ccfb-aee7-4857-9573-92d623f2c436.png)

For the scene, I used the colors from the provided screenshot as a color palette to make the scene look similar, I only used a mode I had on hand for a ship, which can move with WASD. 

I was unable to add toon ramp, but still attempted to add the square waves by rounding the sin wave used for the Y-displacement, which got it close, though I was still unable to fully match it.
![anAttempt](https://user-images.githubusercontent.com/92412422/228524923-12bc8d74-f4cb-443b-b69f-6a8dd9b744d5.png)

CODE SNIPPET 1:
This code will add a blur effect to the camera. Every time the camera renders an image, that image is downsampled in relation to the variable integerRange, then by the desired number of iterations, then upsampled by the same number of iterations, creating a blurry image that is then rendered on screen. This could be used for a variety of things, but one use I can imagine is the mimicking of an eye when a character wakes up, being blurry before coming into focus, which can give a scene more visual flair. 

<span style="background-color: #FFFF00">Marked text</span>
