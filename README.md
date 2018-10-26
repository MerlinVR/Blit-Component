# Blit Component
Proposed blit component for avatars and worlds to use in VRChat

This allows much lower CPU overhead for using render texture loops to run stateful logic in shaders for avatars and worlds. It is approximately 10x as fast as using Camera components on the CPU side since blit does not need to run culling an a number of other things. This brings each pass from ~0.3ms to ~0.03ms. 

[Example using the blit component with GPU particles](https://i.imgur.com/Io85hNc.gifv)

#### Example scene game object configuration
![Hierarchy](https://i.imgur.com/c9L13eX.png)
![BlitController](https://i.imgur.com/kXOe7zw.png)

Update0 and Update1 are identical, except the source and target textures are flipped on the BlitComponent.

![BlitComponent](https://i.imgur.com/6KwpziB.png)
