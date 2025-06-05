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
  ∟📂fonts (contains fonts in TTF and TextMeshPro compatible fonts)<br />
  ∟📂materials (contains materials for objects)<br />
  ∟📂objects (contains FBX 3d models)<br />
  ∟📂prefabs (contains an explosion prefab)<br />
  ∟📂Resources<br />
    ∟📂Audio (contains all audio, SFX, and voicelines)<br />
  ∟📂Samples (contains XR Interaction Toolkit samples)<br />
  ∟📂Scenes (contains the scene)<br />
  ∟📂scripts (contains all scripts)<br />
  ∟📂Settings (contains settings for the URP renderer and other misc. rendering features)<br />
  ∟📂TextMesh Pro (textmeshpro)<br />
  ∟📂textures (contains all textures for the game, 4K (4096) default resolution (!!) the game downscales it to 512, 1024, and 2048 where necessary)<br />
  ∟📂TutorialInfo (not relevant)<br />
  ∟📂Vefects (VFX for fire)<br />
  ∟📂XR (XR Interaction Toolkit)<br />
  ∟📂XRI (XR Interaction Toolkit)<br />

# Important notes
- MSAA is disabled on Android (AKA Oculus) platforms for performance. MSAA is enabled on PC OpenXR platforms only.
- This repository is very large and when cloning or forking you may run into an issue where you need to use Git LFS. Configure Git LFS to track *.EXR files on the client and then push to your forked repo to prevent this.
- A commit or push may exceed GitHub's 2GB limit. Use GitLab where the free limit is 10GB.
- Various temp files and namely the precompiled Library files are not included with this repo. Initial load times will be slow.
