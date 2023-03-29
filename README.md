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

CODE MENTIONED:
<b> for (; i < iterations; i++) {
width /= 2;
height /= 2;
currentDestination = textures[i] =
RenderTexture.GetTemporary(width, height, 0,
format); </b>

<b> for (; i < iterations; i++) {
Graphics.Blit(currentSource,
currentDestination);
// RenderTexture.ReleaseTemporary(currentSource);
currentSource = currentDestination;
}
for (i -= 2; i >= 0; i--) {
currentDestination = textures[i];
textures[i] = null;
Graphics.Blit(currentSource,
currentDestination);
RenderTexture.ReleaseTemporary(currentSource);
currentSource = currentDestination;
} </b>
  
  NEXT UNITY SEGMENT:
  
The first shader I picked was Outline. Which is done by creating a texture around the desired model, and then culling the front of this texture using the normalized vector of our view direction to see what parts of this texture should be culled.

The second shader I chose was a shadow shader that let me control the color of the shadows so I could have more control over the visuals of the scene. To do this, we use LightingCSLambert so we can calculate the lighting of the object, which we can then multiply by the decided color of our light. Finally we make the alpha of the object equal to the alpha of our input texture, and we have colored shadows.

No modifications were made.
  
  CODE SNIPPET 2:
  
  In this code, we are creating a shader that colors any shadow rendered onto that object. Using LightingCSLambert we can calculate the lighting of the object, which we can then multiply by the decided color of our light. Finally we make the alpha of the object equal to the alpha of our input texture, and we have colored shadows. This shader could be used to give a scene more visual flair with unique shadows, such as bluer shadows when underwater.
  
  MAIN CODE MENTIONED:
  <b> half4 LightingCSLambert(SurfaceOutput s, half3
lightDir, half atten) {
fixed diff = max(0, dot(s.Normal, lightDir));
half4 c;
c.rgb = s.Albedo * _LightColor0.rgb * (diff *
atten * 0.5);
//shadow color
c.rgb += _ShadowColor.xyz * (1.0 - atten);
c.a = s.Alpha;
return c;
}
void surf(Input IN, inout SurfaceOutput o) {
half4 c = tex2D(_MainTex, IN.uv_MainTex) *
_Color;
o.Albedo = c.rgb;
o.Alpha = c.a;
} </b>
    
One shader I find particularly interesting is the scrolling texture shader. A scroll effect is achieved by first getting a texture, and two floats for scroll intensity in both directions.
Multiply the two intensity floats by time, and then use those two values to update the UV values and create a scrolling effect. This can be used in a multitude of ways, the first obvious example being water, but it's also useful for things like tv screens, or message boards.

![scrolling flow chart](https://user-images.githubusercontent.com/92412422/228527662-215a0cbd-3ddb-459b-a6eb-b10a5b2d91d8.png)
