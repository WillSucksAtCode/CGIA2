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
