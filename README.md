# The Waiting Room Unity
This contains the scripts, sounds, textures, and objects for the Waiting Room. Tested and compiled with Unity 6000.0.46f1.

# Recommendations
- Unity 6 (6000.0.46f1 or newer)
- A VR headset supporting OpenXR or Oculus VR APIs. By default, the project is using the XR Simulation system, so this will have to be disabled in the project settings and changed to your VR API of choice.
- 25 GB of free space for cache
- 32GB of RAM for compilation
- Visual Studio 2022 for SLN usage
- GPU with at least 16GB of VRAM for GPU based light baking
- 24 core CPU for lightmap compression and code compilation

# Directory structure
📂Assets<br />
&nbsp;&nbsp;&nbsp;∟📂fonts (contains fonts in TTF and TextMeshPro compatible fonts)<br />
&nbsp;&nbsp;&nbsp;∟📂materials (contains materials for objects)<br />
&nbsp;&nbsp;&nbsp;∟📂objects (contains FBX 3d models)<br />
&nbsp;&nbsp;&nbsp; ∟📂prefabs (contains an explosion prefab)<br />
&nbsp;&nbsp;&nbsp;∟📂Resources<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;∟📂Audio (contains all audio, SFX, and voicelines)<br />
&nbsp;&nbsp;&nbsp;∟📂Samples (contains XR Interaction Toolkit samples)<br />
&nbsp;&nbsp;&nbsp;∟📂Scenes (contains the scene)<br />
&nbsp;&nbsp;&nbsp;∟📂scripts (contains all scripts)<br />
&nbsp;&nbsp;&nbsp;∟📂Settings (contains settings for the URP renderer and other misc. rendering features)<br />
&nbsp;&nbsp;&nbsp;∟📂TextMesh Pro (textmeshpro)<br />
&nbsp;&nbsp;&nbsp;∟📂textures (contains all textures for the game, 4K (4096) default resolution (!!) the game downscales it to 512, 1024, and 2048 where necessary)<br />
&nbsp;&nbsp;&nbsp;∟📂TutorialInfo (not relevant)<br />
&nbsp;&nbsp;&nbsp;∟📂Vefects (VFX for fire)<br />
&nbsp;&nbsp;&nbsp;∟📂XR (XR Interaction Toolkit)<br />
&nbsp;&nbsp;&nbsp;∟📂XRI (XR Interaction Toolkit)<br />

# Important notes
- MSAA is disabled on Android (AKA Oculus) platforms for performance. MSAA is enabled on PC OpenXR platforms only.
- This repository is very large and when cloning or forking you may run into an issue where you need to use Git LFS. Configure Git LFS to track *.EXR files on the client and then push to your forked repo to prevent this.
- A commit or push may exceed GitHub's 2GB limit. Use GitLab where the free limit is 10GB.
- Various temp files and namely the precompiled Library files are not included with this repo. Initial load times will be slow.
