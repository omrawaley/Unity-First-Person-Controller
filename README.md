# Unity-First-Person-Controller
First-person player controller made in C# for the Unity game engine.

## Features
As of the initial release date, it includes:

- Player movement
- Camera movement
- Jumping

A toggle in the editor is included that can be switched accordingly if you want input processing/smoothing or raw movement (for both the camera and player movement)

<img width="380" alt="image" src="https://github.com/omrawaley/Unity-First-Person-Controller/assets/133281331/f20b0393-76e8-4c79-92d1-9b7f9a40ba37">


Crouching may be added soon.

## To Use:
Ideally, the player hierarchy should look like this:

<img width="247" alt="image" src="https://github.com/omrawaley/Unity-First-Person-Controller/assets/133281331/a0ff3341-da40-4076-9cdb-23cf4780d170">

`Player` is an empty parent, containing both the Rigidbody, and the controller script. 

`PlayerObj` is simply the visual of the player, e.g. a prefab or a capsule. 

`PlayerCam` is the camera the player utilizes. It should be the only camera enabled in your scene. 

`GroundCheck` is the position where the raycast to check if the player can jump is positioned. It should be at the bottom of your player object, but there should be no gap between it and the object.

<img width="345" alt="image" src="https://github.com/omrawaley/Unity-First-Person-Controller/assets/133281331/917a80b8-b9eb-491a-94d2-1c1995304f47">



## License Notice
Copyright 2023 Om Rawaley (@omrawaley)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

### Terms
- Redistribution and modification is permitted as long as you abide by the redistribution terms
- The author or license cannot be held liable for any damage caused by the software
- Must include a copy of the license and original copyright notice when redistributing
- Must state all changes made to the software when distributing
