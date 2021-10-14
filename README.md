# CS-AR-AlienShooter

## Alien Shooter Workshop - Circuit Stream

### Setting up the project

1. Create a new URP Project in Unity
2. Change the build target of that to Android
3. Package Manager -> Install the following >> AR Foundation, AR Core/ AR Kit, 2D Sprite
4. XR Plugin management -> Add ARCore, ARKit (iOS)
5. Player Settings -> Android Version to 24, Remove Vulken API, for iOS add the Camera usage description and enable AR Kit
6. URP Settings -> Enable AR Camera
7. Create a new Scene

### Project flow

1. Import the asset package provided
2. Add AR Session and AR Session Origin
3. Inside AR Camera, create a player, laser and a spawner.
4. Laser > Box mesh which is long
5. Spawner > Box collider in front
6. Player > Sphere collider
7. Add tags > Player and Alien
8. Add an empty Game Manager > Add the Script
9. Add Sound Manager and add Shoot and Explotion Audio Managers
10. Add the Canvas prefab
11. Setup the Game Manager and the buttons, include the alien prefab and the poof particle
12. Build and Run.


### Attribution

* Shooting Sound : https://www.youtube.com/watch?v=zHa-hy4xldg
* Explosion sound : https://www.youtube.com/watch?v=EXzoh6uJO1w
* Space Invader 3D model : https://sketchfab.com/3d-models/space-invader-018c7dc205cd4442b5a10e0469b9bc79
* UI Button : Kenney.nl
