# Blit Component
Proposed blit component for avatars and worlds to use in VRChat

This allows much lower CPU overhead for using render texture loops to run stateful logic in shaders for avatars and worlds. It is approximately 10x as fast as using Camera components on the CPU side since blit does not need to run culling an a number of other things. This brings each pass from ~0.3ms to ~0.03ms. 

[Example using the blit component with GPU particles](https://i.imgur.com/Io85hNc.gifv)

#### Example Scene
*BlitExample.unitypackage* contains a complete setup of both the blit component loop and the camera loop that is commonly used in VRC. If you press play, both of the large quads should fade from black to white and then loop back to black.

![Scene](https://i.imgur.com/yXZi9go.png)

#### Example scene game object configuration
![Hierarchy](https://i.imgur.com/c9L13eX.png)
![BlitController](https://i.imgur.com/kXOe7zw.png)

Update0 and Update1 are identical, except the source and target textures are flipped on the BlitComponent.

![BlitComponent](https://i.imgur.com/6KwpziB.png)
