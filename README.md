# Blit Component
Proposed blit component for avatars and worlds to use in VRChat

This allows much lower CPU overhead for using render texture loops to run stateful logic in shaders for avatars and worlds. It is approximately 10x as fast as using Camera components on the CPU side since blit does not need to run culling an a number of other things. This brings each pass from ~0.3ms to ~0.03ms. 

### Example In Editor
![example use in editor on GPU particles](https://i.imgur.com/Io85hNc.gif)
